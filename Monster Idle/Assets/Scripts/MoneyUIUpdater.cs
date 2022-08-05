using TMPro;
using UnityEngine;

public class MoneyUIUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text targetText;

    private void FixedUpdate()
    {
        int currentMoney = int.Parse(targetText.text);
        int targetMoney = PlayerPrefs.GetInt(GameData.Default.money, 0);
        if (currentMoney < targetMoney)
            targetText.text = (currentMoney + GameData.Default.updateStep).ToString();
        if (currentMoney > targetMoney)
            targetText.text = (currentMoney - GameData.Default.updateStep).ToString();
    }
}
