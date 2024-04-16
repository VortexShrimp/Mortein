using TMPro;
using UnityEngine;

class GameManager : MonoBehaviour
{
    public delegate void NewRoundHandler();
    public static NewRoundHandler onNewRound;

    // Access the singleton.
    public static GameManager Instance { get; private set; }

    public Vector2 playerPos;
    public GameObject currentPlayer;
    public int playerHealth = 10;

    public int currentRound = 1;
    public TextMeshProUGUI roundText;

    public int maxEnemies = 5;
    public int currentEnemies = 0;

    public int maxPickups = 4;
    public int playerSoulCount = 0;

    public TextMeshProUGUI instructionText;
    public bool displayInstruction = false;

    public TextMeshProUGUI soulsText;
    public GameObject heart5;
    public GameObject heart4;
    public GameObject heart3;
    public GameObject heart2;
    public GameObject heart1;
    public GameObject halfHeart1;
    public GameObject halfHeart2;
    public GameObject halfHeart3;
    public GameObject halfHeart4;
    public GameObject halfHeart5;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    private void Start()
    {
        roundText.text = $"Round: {currentRound}";
        instructionText.enabled = false;
    }

    private void OnEnable()
    {
        EnemyHitController.onEnemyHit += OnEnemyHit;
        PlayerHealthController.onPlayerHealthDecrease += OnPlayerHealthDecrease;
        InputController.onNewPlayerAnimation += OnNewPlayerAnimation;

        SoulPickup.onSoulPickedUp += OnSoulPickedUp;
        HealthPickup.onHealthPickedUp += OnHealthPickedUp;
    }

    private void OnDisable()
    {
        EnemyHitController.onEnemyHit -= OnEnemyHit;
        PlayerHealthController.onPlayerHealthDecrease -= OnPlayerHealthDecrease;
        InputController.onNewPlayerAnimation -= OnNewPlayerAnimation;

        SoulPickup.onSoulPickedUp -= OnSoulPickedUp;
        HealthPickup.onHealthPickedUp -= OnHealthPickedUp;
    }

    private void OnEnemyHit()
    {
        // Decrease the current amount of enemies.
        currentEnemies--;

        // Check if we need a new level.
        if (currentEnemies == 0)
        {
            currentRound++;
            maxEnemies += 4;

            roundText.text = $"Round: {currentRound}";

            onNewRound?.Invoke();
        }
    }

    private void OnPlayerHealthDecrease(int amount)
    {
        RefreshHearts();
    }

    // Player's animation has changed due to purchasing a weapon.
    // Update the text to display the correct amount of souls.
    private void OnNewPlayerAnimation()
    {
        soulsText.text = playerSoulCount.ToString();
    }

    private void OnSoulPickedUp()
    {
        soulsText.text = playerSoulCount.ToString();
    }

    private void OnHealthPickedUp(int amount)
    {
        playerHealth += amount;

        if (playerHealth >= 10)
        {
            playerHealth = 10;  
        }

        RefreshHearts();
    }

    private void RefreshHearts()
    {
        halfHeart1.SetActive(playerHealth < 1 ? false : true);
        heart1.SetActive(playerHealth < 2 ? false : true);

        halfHeart2.SetActive(playerHealth < 3 ? false : true);
        heart2.SetActive(playerHealth < 4 ? false : true);

        halfHeart3.SetActive(playerHealth < 5 ? false : true);
        heart3.SetActive(playerHealth < 6 ? false : true);

        halfHeart4.SetActive(playerHealth < 7 ? false : true);
        heart4.SetActive(playerHealth < 8 ? false : true);

        halfHeart5.SetActive(playerHealth < 9 ? false : true);
        heart5.SetActive(playerHealth < 10 ? false : true);
    }
}