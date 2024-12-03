using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    public Light2D lightSource; // �� �ҽ��� ����
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (IsInLightRange())
        {
            spriteRenderer.enabled = true; // �� ���� �ȿ� ������ ���̰�
        }
        else
        {
            spriteRenderer.enabled = false; // �� ���� �ۿ� ������ ������
        }
    }

    // ������Ʈ�� �� ���� �ȿ� �ִ��� üũ
    bool IsInLightRange()
    {
        if (lightSource == null)
            return false;

        // Light2D�� ������ ������Ʈ�� ��ġ ��
        float distance = Vector2.Distance(transform.position, lightSource.transform.position);
        return distance <= lightSource.pointLightOuterRadius; // ���� �ܺ� �ݰ� ���� ���� �ִ��� üũ
    }
}
