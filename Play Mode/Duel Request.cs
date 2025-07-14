using UnityEngine;

using Unity.Netcode;


public class DuelManager : NetworkBehaviour

{

    public float duelRequestRange = 10f;

    public float requestCooldown = 30f;


    private float lastRequestTime = -Mathf.Infinity;


    public void RequestDuel(NetworkObject sender, NetworkObject target)

    {

        if (!IsServer) return;


        if (Time.time < lastRequestTime + requestCooldown)

        {

            Debug.Log("Duel request is on cooldown.");

            return;

        }


        if (Vector3.Distance(sender.transform.position, target.transform.position) > duelRequestRange)

        {

            Debug.Log("Target is too far away for a duel.");

            return;

        }


        PlayerState senderState = sender.GetComponent<PlayerState>();

        PlayerState targetState = target.GetComponent<PlayerState>();


        if (senderState == null || targetState == null) return;


        if (senderState.IsInCombat || targetState.IsInCombat)

        {

            Debug.Log("One or both players are currently in combat.");

            return;

        }


        target.GetComponent<PlayerDuel>().ReceiveDuelRequestClientRpc(sender.NetworkObjectId);


        lastRequestTime = Time.time;

    }

}