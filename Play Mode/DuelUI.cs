public class DuelUI : MonoBehaviour

{

    public GameObject duelPopup;

    private ulong requesterId;


    public void ShowDuelRequest(ulong senderId)

    {

        requesterId = senderId;

        duelPopup.SetActive(true);

    }


    public void Accept()

    {

        NetworkManager.Singleton.LocalClient.PlayerObject

            .GetComponent<DuelResponder>()

            .SubmitDuelResponseServerRpc(requesterId, true);

        duelPopup.SetActive(false);

    }


    public void Decline()

    {

        NetworkManager.Singleton.LocalClient.PlayerObject

            .GetComponent<DuelResponder>()

            .SubmitDuelResponseServerRpc(requesterId, false);

        duelPopup.SetActive(false);

    }

}