using System;
using System.Collections;
using System.Collections.Generic;
using Rpg;
using RPG.Character;
using RPG.Weapons;
using UnityEngine;
using UnityEngine.EventSystems;
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
        // TODO: remove on character die. here and in logic (INIT class)
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
