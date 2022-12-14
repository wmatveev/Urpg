using System;
using System.Collections;
using System.Collections.Generic;
using Logs;
using Unit;
using UnityEngine;
using UnityEngine.EventSystems;
using Weapons;
using Weapons.DamageCalculation;
using Random = System.Random;

public class CharacterView : MonoBehaviour, IPointerClickHandler
{
    public event Action<Character> OnCharacterClicked;
    public Character Character { get; private set; }
    
    private GameObject objBullet;
    
    [SerializeField] private Animator   _animator;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform  _bulletSpawnPoint;

    // private Camera _camera;
    
    // private TurnQueue _turnQueue;

    private static readonly int Shooting = Animator.StringToHash("Shooting");

    public void Init(Character character)
    {
        Character = character;
        
        Character.WeaponController.OnAttacked += OnAttack;
        Character.Health.OnDie                += DestroyCharacter;
        Character.Health.OnDieLog             += DamageLogs.DieLogConsoleOutput;
        Character.Health.OnHitLog             += DamageLogs.HitLogConsoleOutput;

        // TODO: remove on character die. here and in logic (INIT class)
    }

    private void DestroyCharacter(Damage obj)
    {
        Destroy(gameObject);
    }

    private void OnAttack(IWeapon obj)
    {
        // TODO: specify shoot depends on weapon and target
        InitBullet();
        Shoot();
    }

    void InitBullet()
    {
        objBullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
    }

    void Shoot()
    {
        objBullet.GetComponent<Bullet>().SetImpulse(_bulletSpawnPoint.forward, 10.0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCharacterClicked?.Invoke(Character);
    }
}
