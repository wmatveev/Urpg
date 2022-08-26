using System.Collections;
using System.Collections.Generic;
using Rpg;
using Rpg.Balans;
using RPG.Character.CharacterCreationFactory;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();

        IWeaponsFactory   WeaponsFactory = new WeaponsFactory(balance);
        ICharatersFactory MainCharacter  = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);

        Character Enemy  = MainCharacter.CreateCharacter("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

}
