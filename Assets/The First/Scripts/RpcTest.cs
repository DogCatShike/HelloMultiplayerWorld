using Unity.Netcode;
using UnityEngine;

public class RpcTest : NetworkBehaviour
{
    // 不知道什么时候调用, 说是生成时, 但实际效果好像是类似于每帧
    public override void OnNetworkSpawn()
    {
        if (!IsServer && IsOwner)
        {
            TestServerRpc(0, NetworkObjectId);
        }
    }

    [Rpc(SendTo.ClientsAndHost)]
    void TestClientRpc(int value, ulong sourceNetworkObjectId)
    {
        Debug.Log($"Client Received the RPC #{value} on NetworkObject #{sourceNetworkObjectId}");

        if (IsOwner) // Owner: 此NetworkBehaviour 的所有者
        {
            TestServerRpc(value + 1, sourceNetworkObjectId);
        }
    }

    [Rpc(SendTo.Server)]
    void TestServerRpc(int value, ulong sourceNetworkObjectId)
    {
        Debug.Log($"Server Received the RPC #{value} on NetworkObject #{sourceNetworkObjectId}");
        TestClientRpc(value, sourceNetworkObjectId);
    }
}
