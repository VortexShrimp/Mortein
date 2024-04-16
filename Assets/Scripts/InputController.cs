using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

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
        if (playerInZone)
        {
           /// GameManager.Instance.instructionText.enabled = true;

            if (Input.GetKey(KeyCode.E))
            {
                if (GameManager.Instance.playerSoulCount >= GetGunPrice())
                {
                    GameManager.Instance.playerSoulCount -= GetGunPrice();

                    var newPlayer = Instantiate(morteinPrefab,GameManager.Instance.playerPos, Quaternion.identity);
                    GameManager.Instance.currentPlayer = newPlayer;

                    if (oldPlayer != null)
                    {
                        Destroy(oldPlayer);
                    }

                    onNewPlayerAnimation?.Invoke();
                }
            }
        }
        else
        {
           // GameManager.Instance.instructionText.enabled = false;
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

   private int GetGunPrice()
   {
    switch (tag)
    {
        case "Green Circle":
            return 35;
        case "Purple Circle":
            return 70;
        case "Red Circle":
            return 40;
        case "Blue Circle":
            return 20;

        default:
            return 0;
    }
   }
}
