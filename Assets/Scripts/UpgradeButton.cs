using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public Button upgradeButton;
    public TextMeshProUGUI costText;
    public UpgradeManager upgradeManager;
    public Image lockImage;
    public TextMeshProUGUI buttonText;

    public string upgradeName;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        UpdateUI();
    }

    public void InitializeUI()
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
        // Check if the upgrade can be purchased
        if (CanPurchaseUpgrade())
        {
            if (upgradeManager.PurchaseUpgrade(upgradeName))
            {
                UpdateUI();
            }
        }
        else
        {
            Debug.Log("Upgrade cannot be purchased.");
        }
    }

    private bool CanPurchaseUpgrade()
    {
        if (upgradeName == "FireRate" && !upgradeManager.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            return false;
        }

        if (upgradeName == "Shield" && !upgradeManager.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            return false;
        }

        return true;
    }

    public void UpdateUI()
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
}
