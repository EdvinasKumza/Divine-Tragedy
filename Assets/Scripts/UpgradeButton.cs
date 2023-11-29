using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public Button upgradeButton;
    public TextMeshProUGUI costText;
    public Image lockImage;
    public TextMeshProUGUI buttonText;
    public string upgradeName;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        InitializeUI(UpgradeManager.instance);
        UpdateUI();
    }

    public void InitializeUI(UpgradeManager upgradeManager)
    {
        if (upgradeManager.IsUpgradePermanentlyUnlocked(upgradeName))
        {
            upgradeButton.interactable = false;
            costText.gameObject.SetActive(false);
            lockImage.gameObject.SetActive(false);
            buttonText.text = "BOUGHT";
        }
        else
        {
            upgradeButton.interactable = true;
            lockImage.gameObject.SetActive(true);
            costText.gameObject.SetActive(true);
            buttonText.text = "PURCHASE";
        }
    }

    private void OnUpgradeButtonClick()
    {
        if (CanPurchaseUpgrade())
        {
            UpgradeManager.instance.PurchaseUpgrade(upgradeName);
            UpdateUI();
        }
        else
        {
            Debug.Log("Upgrade cannot be purchased.");
        }
    }

    private bool CanPurchaseUpgrade()
    {
        if (upgradeName == "FireRate" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP") 
        && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("GoldIncrease"))
        {
            return false;
        }

        if (upgradeName == "Shield" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP") 
        && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("HealthRegeneration"))
        {
            return false;
        }

        if (upgradeName == "HealthRegeneration" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            return false;
        }

        if (upgradeName == "GoldIncrease" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            return false;
        }


        return true;
    }

    public void UpdateUI()
    {
        InitializeUI(UpgradeManager.instance);
    }
}
