using UnityEngine;
using UnityEngine.UI;

public class MaxHPUpgradeButton : MonoBehaviour
{
    public Button upgradeButton;
    public Text costText;
    public UpgradeManager upgradeManager;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        UpdateUI();
    }

    private void OnUpgradeButtonClick()
    {
        if (upgradeManager.PurchaseUpgrade("MaxHP"))
        {
            upgradeButton.interactable = false;
            costText.text = "Unlocked";
        }
    }

    private void UpdateUI()
    {
        if (upgradeManager.IsUpgradePermanentlyUnlocked("MaxHP"))
        {
            upgradeButton.interactable = false;
            costText.text = "Unlocked";
        }
        else
        {
            costText.text = "Cost: 50 Gold";
        }
    }
}
