using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;
using System.Collections;

public class Light_Find_Enemy : MonoBehaviour
{
    public Light2D light2D; // Light2D ������Ʈ
    public LayerMask enemyLayer; // ���� ���Ե� ���̾�
    public float rayLength = 10f; // ������ ����
    public int rayCount = 36; // �ݿ� ����� ���� ����
    public float outerAngle = 180f; // ���� �ܺ� ����

    public List<Enemy> checkEnemy; // �߰ߵ� ������ ������ ����Ʈ
    public bool is_E;

    private void Start()
    {
        StartCoroutine("find_Enemy");
    }


    private void FixedUpdate()
    {
        
    }
    IEnumerator find_Enemy()
    {
        print("startCo");
        is_E = false;
        Vector2 lightPosition = light2D.transform.position;
        float outerRadius = light2D.pointLightOuterRadius;
        float innerRadius = light2D.pointLightInnerRadius;

 

        // Light2D�� ������ ��������, ���� Ȥ�� ���������� ���� ���
        Vector2 lightDirection = light2D.transform.up; // ���� �ٶ󺸴� ����
       
        // ���� �ݿ� ���·� ���� �׸���
        for (int i = 0; i < rayCount; i++)
        {
           
            // ������ ����Ͽ� ������ ������ ����
            float angle = Mathf.Lerp(-outerAngle / 2, outerAngle / 2, i / (float)(rayCount - 1));
            Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

            // ���� ���� ������ �������� �ݴ� ���⵵ ó��
            direction = Quaternion.FromToRotation(Vector2.right, lightDirection) * direction; // ���� ȸ��

            // ���̸� �ܺ� ������ ���̷� �߻�
            RaycastHit2D hit = Physics2D.Raycast(lightPosition, direction, outerRadius, enemyLayer);

            // ���� �׸��� (������)
            Debug.DrawRay(lightPosition, direction * outerRadius, Color.green);

            if (hit.collider != null)
            {
                if (hit.transform.GetComponent<Enemy>())
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    if (!checkEnemy.Contains(enemy)) // �ߺ��� ���ϱ� ���� üũ
                    {
                        checkEnemy.Add(enemy);
                        enemy.GetComponent<SpriteRenderer>().enabled = true;
                        is_E = true;
                        break;
                    }
                }
            }

            
         
        }

        yield return new WaitForSeconds(0.08f);

        if (is_E == false && checkEnemy.Count != 0)
        {
            for(int i=0;i< checkEnemy.Count; i++)
            {
                checkEnemy[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            checkEnemy.Clear();
        }
        StartCoroutine("find_Enemy");
    }
}
