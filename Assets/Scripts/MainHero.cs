using System;
using System.Collections;
using System.Collections.Generic;
using Rpg;
using Rpg.Balans;
using RPG.Character.CharacterCreationFactory;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;
using Random = System.Random;

public class MainHero : MonoBehaviour
{
    public Character mainHero;
    
    private GameObject objBullet;
    
    [SerializeField] private Animator   _animator;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform  _bulletSpawnPoint;

    private Camera _camera;
    private bool   _isCameraNotNull;
    
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

        mainHero  = MainCharacter.CreateCharacter("Player1");
        
        // Устанавливаем очередь игрока
        _walkingQueue = new WalkingQueue { Queue = "Player1" };
    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
    }

    void InitBullet()
    {
        objBullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Проверяем очередь
            if ( _walkingQueue.Queue != "Player1")
                return ;
            
            if( !Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) )
                return ;

            // Проверяем, кликнули на противнике или нет
            if (_animator && hit.transform.name == "Enemy")
            {
                _animator.SetTrigger(Shooting);
                _walkingQueue.Queue = "NotMainHero";

                StartCoroutine(StartLife());
            }
        }
    }

    void Shoot()
    {
        objBullet.GetComponent<Bullet>().SetImpulse(Vector2.right, 10.0f);
    }
    
    private IEnumerator StartLife()
    {
        print("Started Coroutine at timestamp : " + Time.time);
        
        yield return new WaitForSeconds( new Random().Next(1,2) );

        // Меняем очередь на противника
        _walkingQueue.Queue = "Enemy1";
        
        print("Finished Coroutine at timestamp : " + Time.time);
    
        yield break;
    }

}
