using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI roomCode_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        string roomCode = GenerateRandomRoomCode();
        roomCode_Text.text = roomCode;
        var manager = RoomManager.singleton;

        //������ ���鼭 Ŭ��� ����
        manager.StartHost();

    }

    public void Link_Sever()
    {
        NetworkManager.singleton.StartClient();
    }

    public string GenerateRandomRoomCode(int length = 8)//�����
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        System.Random random = new System.Random();
        char[] stringChars = new char[length];

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);  // �� �ڵ� ��ȯ

    }
}
