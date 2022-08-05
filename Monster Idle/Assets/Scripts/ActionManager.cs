using System;
using System.Collections;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private CharaController charaController;
    [SerializeField] private EnemyController enemyController;

    private float swordDamage, arrowDamage;

    public Action swordDamageAction, arrowDamageAction;

    private void OnEnable()
    {
        charaController.deliverDamage += DeliverSwordDamage;
        enemyController.deathAction += EnemyIsDead;
    }

    private void OnDisable()
    {
        charaController.deliverDamage -= DeliverSwordDamage;
        enemyController.deathAction -= EnemyIsDead;
    }

    private void Awake()
    {
        _default = this;
    }

    private void Start()
    {
        UpdateValues();
    }

    public void UpdateValues()
    {
        swordDamage = GameData.Default.swordDamage * PlayerPrefs.GetInt(GameData.Default.lvl_Sword, 1);
        arrowDamage = GameData.Default.arrowDamage * PlayerPrefs.GetInt(GameData.Default.lvl_Arrow, 1);
    }

    public void UpdateWeaponModel()
    {
        charaController.SetupWeapon();
    }

    private void DeliverSwordDamage()
    {
        enemyController.ReceiveDamage(swordDamage);
        swordDamageAction?.Invoke();
    }

    public void DeliverArrowDamage()
    {
        enemyController.ReceiveDamage(arrowDamage);
        arrowDamageAction?.Invoke();
    }

    private void EnemyIsDead()
    {
        StartCoroutine(EnemyRespawnWait());
    }

    private IEnumerator EnemyRespawnWait()
    {
        charaController.SetHurrayAnim(true);
        yield return new WaitForSeconds(GameData.Default.enemyDeathTime);
        enemyController.Respawn();
        charaController.SetHurrayAnim(false);
    }

    #region Singleton
    private static ActionManager _default;
    public static ActionManager Default => _default;
    #endregion
}
