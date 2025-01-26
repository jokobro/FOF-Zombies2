using UnityEngine;

public class PerkUpgrades : MonoBehaviour
{
    private bool isSpeedColaBought = false;
    private bool isJunngernautPerkBought = false;
    private bool isDoubleTapBought = false; 
    private bool isQuickReviveBought = false;
    private bool hasUsedQuickRevive = false;
    
    public bool IsSpeedColaBought => isSpeedColaBought; 
    public bool IsQuickReviveBought => isQuickReviveBought && !hasUsedQuickRevive; 

    public void HandleBuyingSpeedCola()
    {
        if (isSpeedColaBought)
        {
            Debug.Log("Speed Cola is al gekocht!");
            return;
        }

        if (GameManager.Instance.Points >= 1500)
        {
            GameManager.Instance.Points -= 1500f;
            GameManager.Instance.UpdatePointsUI();
            PlayerController.Instance.walkSpeed = 12.6f; // Pas de snelheid aan
            isSpeedColaBought = true;

            Debug.Log("Speed Cola gekocht!");
            HUDcontroller.instance.DisableInteractionText();
        }
        else
        {
            Debug.Log("Niet genoeg punten voor Speed Cola!");
            HUDcontroller.instance.EnableInteractionText("Niet genoeg punten!");
        }
    }

    public void HandleBuyingQuickRevive()
    {
        if (isQuickReviveBought && !hasUsedQuickRevive)
        {
            Debug.Log("Quick Revive is al gekocht!");
            return;
        }

        if (GameManager.Instance.Points >= 1000)
        {
            GameManager.Instance.Points -= 1000f;
            GameManager.Instance.UpdatePointsUI();
            isQuickReviveBought = true;
            hasUsedQuickRevive = false;

            Debug.Log("Quick Revive gekocht!");
            HUDcontroller.instance.DisableInteractionText(); 
        }
        else
        {
            Debug.Log("Niet genoeg punten voor Quick Revive!");
            HUDcontroller.instance.EnableInteractionText("Niet genoeg punten!"); // Toon foutmelding
        }
    }

    public void HandleBuyingJuggernaut()
    {
        if (isJunngernautPerkBought)
        {
            Debug.Log("juggernaut is al gekocht!");
            return;
        }

        if (GameManager.Instance.Points >= 2500)
        {
            GameManager.Instance.Points -= 2500f;
            GameManager.Instance.UpdatePointsUI();
            PlayerController.Instance.playerHealth = 170f;
            isJunngernautPerkBought = true;

            Debug.Log("juggernaut perk gekocht!");
            HUDcontroller.instance.DisableInteractionText();
        }
        else
        {
            Debug.Log("Niet genoeg punten voor Speed Cola!");
            HUDcontroller.instance.EnableInteractionText("Niet genoeg punten!");
        }
    }

    public bool IsJuggernautBought()
    {
        return isJunngernautPerkBought;
    }

    public void HandleBuyingDoubleTap()
    {
        if (isJunngernautPerkBought)
        {
            Debug.Log("double tap gekocht!");
            return;
        }

        if (GameManager.Instance.Points >= 2000)
        {
            GameManager.Instance.Points -= 2000f;
            GameManager.Instance.UpdatePointsUI();
            
            //logica toevoegen voor het upgraden firerate


            isDoubleTapBought = true;

            Debug.Log("double tap perk gekocht!");
            HUDcontroller.instance.DisableInteractionText();
        }
        else
        {
            Debug.Log("Niet genoeg punten voor doubletap!");
            HUDcontroller.instance.EnableInteractionText("Niet genoeg punten!");
        }
    }

    public bool IsDoubleTapBougt()
    {
        return isDoubleTapBought;
    }


    // Roep deze methode aan wanneer de speler Quick Revive gebruikt
    public void UseQuickRevive()
    {
        if (isQuickReviveBought)
        {
            Debug.Log("Quick Revive gebruikt!");
            hasUsedQuickRevive = true;
            isQuickReviveBought = false;

            // extra logica voor reviven toevoegen
        }
    }
}
