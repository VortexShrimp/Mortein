using UnityEngine;

/// <summary>
/// Used for controlling the summoning circles.
/// TODO: Rename this?
/// </summary>
public class InputController : MonoBehaviour
{
    [SerializeField] GameObject morteinPrefab;
    [SerializeField] string gunName;

    private bool playerInZone = false;
    private GameObject oldPlayer = null;
    public delegate void NewPlayerAnimationHandler();
    public static event NewPlayerAnimationHandler onNewPlayerAnimation;

    private void FixedUpdate() 
    {
        // Player is in the summoning zone.
        if (playerInZone)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (GameManager.Instance.playerSoulCount >= GetGunPrice())
                {
                    GameManager.Instance.playerSoulCount -= GetGunPrice();

                    // Spawn the new player animation sprite.
                    var newPlayer = Instantiate(morteinPrefab, GameManager.Instance.playerPos, Quaternion.identity);
                    GameManager.Instance.currentPlayer = newPlayer;

                    if (oldPlayer != null)
                    {
                        Destroy(oldPlayer);
                    }

                    onNewPlayerAnimation?.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            oldPlayer = other.gameObject;
            playerInZone = true;

            GameManager.Instance.instructionText.text = $"Press \"E\" to summon {gunName} for {GetGunPrice()} souls.";
            GameManager.Instance.instructionText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            GameManager.Instance.instructionText.enabled = false;
        }
    }

    // Should probably use an enum for this.
    private int GetGunPrice()
    {
        switch (gunName)
        {
            case "SMG":
                return 35;
            case "LMG":
                return 70;
            case "SHOTGUN":
                return 40;
            case "ASSUALT RIFLE":
                return 20;

            default:
                return 0;
        }
    }
}
