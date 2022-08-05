using UnityEngine;

[DefaultExecutionOrder(-105)]

[CreateAssetMenu(menuName = "Scriptables/GameData")]
public class GameData : DataHolder
{
    #region Singleton
    private static GameData _default;
    public static GameData Default => _default;
    #endregion

    [Header("Player Prefs Names")]
    [Space(10)]
    public string p_WeaponIndex;
    public string p_SwordDamage;
    public string p_ArrowDamage;
    public string p_EnemyHP;

    [Header("Shop")]
    [Space(10)]
    public string lvl_Sword;
    public string lvl_Arrow;

    public string lvl_SwordIncome;
    public string lvl_ArrowIncome;

    public int max_lvl_Sword;
    public string maxedPlaceholder;

    public int initialCost;

    [Header("Setup")]
    [Space(10)]
    public float enemyHP;
    public float swordDamage;
    public float arrowDamage;

    public float flyTime;
    public float enemyDeathTime;

    public float uninteractableAreaPercent;

    [Header("Money")]
    [Space(10)]
    public string money;
    public int updateStep;
    public int moneyPerHit;


    [Header("Animator")]
    [Space(10)]
    public string animRecieve;
    public string animDeath;
    public string animHurray;

    override public void Init()
    {
        _default = this;
    }
}