using Unity.Netcode;

using UnityEngine;


public class PlayerCombat : NetworkBehaviour

{

    public bool IsInDuel { get; private set; }

    private ulong currentOpponentId;


    public void EnterDuelMode(ulong opponentClientId)

    {

        IsInDuel = true;

        currentOpponentId = opponentClientId;


        Debug.Log($"Entered duel with player {opponentClientId}");

    }


    public void ExitDuelMode()

    {

        IsInDuel = false;

        currentOpponentId = 0;


        Debug.Log("Exited duel mode");

    }


    void Update()

    {

        if (!IsInDuel || !IsOwner) return;


        // Example: only allow targeting your opponent

        var input = GetComponent<PlayerInput>();

        if (input.Target != null && input.Target.OwnerClientId != currentOpponentId)

        {

            input.ClearTarget();

        }

    }


    public bool CanAttack(ulong targetId)

    {

        return IsInDuel && targetId == currentOpponentId;

    }

}