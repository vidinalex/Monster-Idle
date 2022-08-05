using System;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TMP_Text t_swordDamage, t_arrowDamage, t_swordIncome, t_arrowIncome;

    private int initialCost;
    private void Start()
    {
        initialCost = GameData.Default.initialCost;
        SetupUI();
    }

    private void UpdateUI(TMP_Text targetText, int result)
    {
        targetText.text = result.ToString();
    }

    public void UpdateSwordDamage()
    {
        if(!CheckForWeaponMaxed())
        {
            t_swordDamage.text = GameData.Default.maxedPlaceholder;
            return;
        }

        ProceedBuy(GameData.Default.lvl_Sword, t_swordDamage);
        ActionManager.Default.UpdateWeaponModel();

        if(!CheckForWeaponMaxed())
            t_swordDamage.text = GameData.Default.maxedPlaceholder;
    }

    private bool CheckForWeaponMaxed()
    {
        if (PlayerPrefs.GetInt(GameData.Default.lvl_Sword, 1) >= GameData.Default.max_lvl_Sword)
            return false;
        return true;
    }

    public void UpdateArrowsDamage()
    {
        ProceedBuy(GameData.Default.lvl_Arrow, t_arrowDamage);
    }

    public void UpdateSwordIncome()
    {
        ProceedBuy(GameData.Default.lvl_SwordIncome, t_swordIncome);
    }

    public void UpdateArrowsIncome()
    {
        ProceedBuy(GameData.Default.lvl_ArrowIncome, t_arrowIncome);
    }

    private void ProceedBuy(string prefsAdress, TMP_Text targetText)
    {
        int currentLvl = PlayerPrefs.GetInt(prefsAdress, 1);
        int totalCost = initialCost * currentLvl;
        if (CheckAndWithdraw(totalCost))
        {
            PlayerPrefs.SetInt(prefsAdress, ++currentLvl);
            UpdateUI(targetText, totalCost + initialCost);
            ActionManager.Default.UpdateValues();
        }
    }

    private bool CheckAndWithdraw(int cost)
    {
        int currentMoney = PlayerPrefs.GetInt(GameData.Default.money, 0);
        if (currentMoney < cost)
            return false;
        PlayerPrefs.SetInt(GameData.Default.money, currentMoney - cost);
        return true;
    }

    private void SetupUI()
    {
        UpdateUI(t_swordDamage, PlayerPrefs.GetInt(GameData.Default.lvl_Sword, 1) * initialCost);
        UpdateUI(t_arrowDamage, PlayerPrefs.GetInt(GameData.Default.lvl_Arrow, 1) * initialCost);
        UpdateUI(t_swordIncome, PlayerPrefs.GetInt(GameData.Default.lvl_SwordIncome, 1) * initialCost);
        UpdateUI(t_arrowIncome, PlayerPrefs.GetInt(GameData.Default.lvl_ArrowIncome, 1) * initialCost);

        if (!CheckForWeaponMaxed())        
            t_swordDamage.text = GameData.Default.maxedPlaceholder;                    
    }

    [ContextMenu("Set Money 1000")]
    private void SetMoney()
    {
        PlayerPrefs.SetInt(GameData.Default.money, 1000);
    }

    [ContextMenu("Reset Prefs")]
    private void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}