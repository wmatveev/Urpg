using System;
using System.Collections;
using System.Collections.Generic;
using Rpg;
using Rpg.Attack;
using Rpg.Balans;
using RPG.Character.CharacterCreationFactory;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Camera    _camera;
    private bool      _isCameraNotNull;

    private Character  _enemy;
    private GameObject _objBullet;

    [SerializeField] private GameObject _mainHero;
    [SerializeField] private Animator   _animator;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform  _bulletSpawnPoint;
    
    private WalkingQueue _walkingQueue;
    
    private static readonly int Shooting = Animator.StringToHash("Shooting");

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _isCameraNotNull = _camera != null;

        Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();

        IWeaponsFactory   WeaponsFactory = new WeaponsFactory(balance);
        ICharatersFactory MainCharacter  = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);

        _enemy  = MainCharacter.CreateCharacter("Enemy1");
        
        // Инициализируем очередь
        _walkingQueue = new WalkingQueue();
    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IAttack attack = new Attack();
        attack.CharacterAttack(_mainHero.GetComponent<MainHero>().mainHero, _enemy);

        if (_enemy.Health.CurrentHealth <= 0)
        {
            Destroy( gameObject );
        }
    }
    
    void InitBullet()
    {
        _objBullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
    }

    void CheckShoot()
    {
        // Проверяем очередь
        if ( _walkingQueue.Queue != "Enemy1")
            return ;

        // Проверяем, кликнули на противнике или нет
        if (_animator)
        {
            _animator.SetTrigger(Shooting);
            
            // Меняем очередь на противника
            _walkingQueue.Queue = "Player1";
        }
    }

    void Shoot()
    {
        _objBullet.GetComponent<Bullet>().SetImpulse(Vector2.left, 10.0f);
    }
}
