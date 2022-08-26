using System;
using System.Collections;
using System.Collections.Generic;
using Rpg;
using Rpg.Balans;
using RPG.Character.CharacterCreationFactory;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;

public class MainHero : MonoBehaviour
{
    private GameObject objCartridge;
    
    [SerializeField] private Animator   Animator;
    [SerializeField] private GameObject Cartridge;
    [SerializeField] private Transform  BulletSpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();

        IWeaponsFactory   WeaponsFactory = new WeaponsFactory(balance);
        ICharatersFactory MainCharacter  = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);

        Character Player  = MainCharacter.CreateCharacter("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
    }

    void CheckShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objCartridge = Instantiate(Cartridge, BulletSpawnPoint.position, Quaternion.identity);
            
            if(Animator)
                Animator.SetTrigger("Shooting");
        }
    }

    void Shoot()
    {
        int i = 0;
    }
}
