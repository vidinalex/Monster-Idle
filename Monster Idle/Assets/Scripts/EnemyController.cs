using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform impactTransform;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private Animator animator;
    [SerializeField] private RectTransform hpBar;

    private float hp;
    private float hpRatio;

    public Action deathAction;

    public void ReceiveDamage(float damage)
    {
        if (hp <= 0) return;
        Instantiate(impactEffect,impactTransform);
        animator.SetTrigger(GameData.Default.animRecieve);
        hp -= damage;
        hpBar.sizeDelta = new Vector2 (hp*hpRatio, hpBar.sizeDelta.y);
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool(GameData.Default.animDeath,true);
        deathAction?.Invoke();
    }

    private void Start()
    {
        hp = GameData.Default.enemyHP;
        hpRatio = hpBar.sizeDelta.x / hp;
    }

    public void Respawn()
    {
        hp = GameData.Default.enemyHP;
        hpBar.sizeDelta = new Vector2(hp * hpRatio, hpBar.sizeDelta.y);
        animator.SetBool(GameData.Default.animDeath, false);
    }
}
