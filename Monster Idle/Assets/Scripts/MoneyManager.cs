using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private string prefsMoneyIndex;
    private int moneyPerHit;
    private void Start()
    {
        prefsMoneyIndex = GameData.Default.money;
        moneyPerHit = GameData.Default.moneyPerHit;
        ActionManager.Default.swordDamageAction += SwordDamageDone;
        ActionManager.Default.arrowDamageAction += ArrowDamageDone;
    }

    private void SwordDamageDone()
    {
        PlayerPrefs.SetInt(
            prefsMoneyIndex,
            PlayerPrefs.GetInt(prefsMoneyIndex, 0) + moneyPerHit * PlayerPrefs.GetInt(GameData.Default.lvl_SwordIncome, 1));
    }

    private void ArrowDamageDone()
    {
        PlayerPrefs.SetInt(
            prefsMoneyIndex,
            PlayerPrefs.GetInt(prefsMoneyIndex, 0) + moneyPerHit * PlayerPrefs.GetInt(GameData.Default.lvl_ArrowIncome, 1));
    }
}
