using System;
using System.Collections;
using System.Collections.Generic;
using com.digitalmind.towertest;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Health _playerHealth;
    private PlayerTurret _playerTurret;

    private void Awake()
    {
        gameObject.AddComponent<PlayerHitBox>().InjectPlayer(this);
        _playerHealth = GetComponent<Health>();
        _playerTurret = GetComponent<PlayerTurret>();
    }

    public void TakeDamage(float amount)
        => _playerHealth.TakeDamage(amount);
    public void Shoot()
        => _playerTurret.Shoot();
    public void RotateTurret(Direction direction)
        => _playerTurret.RotateTurret(direction);

    //TODO - optimize finding player game object
    public static Player Find => GameObject.FindWithTag("Player").GetComponent<Player>();
}
