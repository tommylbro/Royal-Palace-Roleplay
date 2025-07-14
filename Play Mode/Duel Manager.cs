public class DuelManager : NetworkBehaviour

{

    public GameObject duelCirclePrefab; // A prefab with visual effects for the arena

    public float duelRadius = 6f;

    public float transitionTime = 2f;


    public void AcceptDuel(NetworkObject playerA, NetworkObject playerB)

    {

        if (!IsServer) return;


        Vector3 center = (playerA.transform.position + playerB.transform.position) / 2f;


        // Spawn the duel circle effect

        GameObject duelCircle = Instantiate(duelCirclePrefab, center, Quaternion.identity);

        duelCircle.transform.localScale = Vector3.zero;


        NetworkObject circleNetObj = duelCircle.GetComponent<NetworkObject>();

        circleNetObj.Spawn();


        StartCoroutine(DuelTransition(playerA, playerB, circleNetObj));

    }


    private IEnumerator DuelTransition(NetworkObject playerA, NetworkObject playerB, NetworkObject duelCircle)

    {

        // Freeze movement

        FreezePlayer(playerA, true);

        FreezePlayer(playerB, true);


        float elapsed = 0f;

        while (elapsed < transitionTime)

        {

            elapsed += Time.deltaTime;

            float t = elapsed / transitionTime;

            duelCircle.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * duelRadius, t);

            yield return null;

        }


        // Start the duel

        StartDuel(playerA, playerB);

    }


    private void StartDuel(NetworkObject playerA, NetworkObject playerB)

    {

        playerA.GetComponent<PlayerCombat>().EnterDuelMode(playerB.OwnerClientId);

        playerB.GetComponent<PlayerCombat>().EnterDuelMode(playerA.OwnerClientId);


        // Unfreeze movement only within circle bounds (handled in PlayerCombat)

    }


    private void FreezePlayer(NetworkObject player, bool freeze)

    {

        var rb = player.GetComponent<Rigidbody>();

        if (rb != null)

        {

            rb.isKinematic = freeze;

        }


        var controller = player.GetComponent<PlayerController>();

        if (controller != null)

        {

            controller.enabled = !freeze;

        }

    }

}