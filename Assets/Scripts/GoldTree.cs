    using UnityEngine;
    using TMPro;

    public class GoldTree : MonoBehaviour, IDataPersistence
    {
        public static GoldTree instance;
        private TMP_Text textComponent;
        private int goldAmount;

        void Awake()
        {
            textComponent = GetComponentInChildren<TMP_Text>();

            instance = this;
        }

        public void LoadData(GameData data)
        {
            goldAmount = data.gold;
            UpdateGoldDisplay();
        }

        public void SaveData(ref GameData data)
        {
            data.gold = goldAmount;
        }

        public void SpendGold(int amount)
        {
            if (amount <= goldAmount)
            {
                goldAmount -= amount;
                UpdateGoldDisplay();
                SaveCurrentGameData();
            }
        }

        private void UpdateGoldDisplay()
        {
            if (textComponent != null)
            {
                textComponent.text = goldAmount.ToString();
            }
            else
            {
                Debug.LogError("Text component for gold display not found.");
            }
        }

        private void SaveCurrentGameData()
        {
            if (DataPersistenceManager.instance != null)
            {
                DataPersistenceManager.instance.SaveGame();
            }
        }
    }