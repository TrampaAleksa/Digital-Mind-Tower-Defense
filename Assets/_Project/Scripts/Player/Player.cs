using System;
using System.Collections;
using System.Collections.Generic;
using com.digitalmind.towertest;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Health _playerHealth;
    private PlayerTurretRotation _playerTurretRotation;

    private void Awake()
    {
        gameObject.AddComponent<PlayerHitBox>().InjectPlayer(this);
        _playerHealth = GetComponent<Health>();
        _playerTurretRotation = GetComponent<PlayerTurretRotation>();
    }

    public void TakeDamage(float amount)
        => _playerHealth.TakeDamage(amount);

    public void RotateTurret(float rotationInput)
        => _playerTurretRotation.RotateTurret(rotationInput);

    public static Player Find => GameObject.FindWithTag("Player").GetComponent<Player>(); // don't use in update if possible
}
