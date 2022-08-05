using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;
    [SerializeField] private Animator animator;

    public Action deliverDamage;

    private void Start()
    {
        SetupWeapon();
    }

    public void SetupWeapon()
    {
        foreach (var weapon in weapons)
        {
            weapon.SetActive(false);
        }

        int currentWeaponIndex = PlayerPrefs.GetInt(GameData.Default.lvl_Sword,1) - 1;

        weapons[currentWeaponIndex].SetActive(true);
    }

    private void AttackComplete()
    {
        deliverDamage?.Invoke();
    }

    public void SetHurrayAnim(bool animationState)
    {
        animator.SetBool(GameData.Default.animHurray, animationState);
    }
}
