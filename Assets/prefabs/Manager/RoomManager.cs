using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class RoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnectionToClient conn)//�������� ���������� Ŭ���̾�Ʈ�� �����ϸ� �����ϴ� �Լ�
    {
        base.OnRoomServerConnect(conn);

        var player = Instantiate(spawnPrefabs[0]);
        NetworkServer.Spawn(player, conn);//Ŭ���̾�Ʈ���� ��ȯ�Ȱ� �˸���(������Ʈ Ŭ���̾�Ʈ ǥ��)
                                        //NetworkServer.Spawn(������ ������Ʈ,������)
    }
}
