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
            // Assume the UpgradeManager is accessible globally or through a singleton
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
        if (upgradeName == "FireRate" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            return false;
        }

        if (upgradeName == "Shield" && !UpgradeManager.instance.IsUpgradePermanentlyUnlocked("MaxHP"))
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
