using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class RoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnectionToClient conn)//서버에서 새로접속한 클라이언트를 감지하면 생성하는 함수
    {
        base.OnRoomServerConnect(conn);

        var player = Instantiate(spawnPrefabs[0]);
        NetworkServer.Spawn(player, conn);//클라이언트에게 소환된걸 알리기(오브젝트 클라이언트 표시)
                                        //NetworkServer.Spawn(생성할 오브젝트,소유자)
    }
}
