public class PlayerDuel : NetworkBehaviour

{

    [ClientRpc]

    public void ReceiveDuelRequestClientRpc(ulong senderId)

    {

        Debug.Log($"Received a duel request from player {senderId}");


        // Show UI popup to accept or decline

        // Example: UIManager.Instance.ShowDuelPopup(senderId);

    }

}