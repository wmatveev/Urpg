﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

internal static class Program
{
    // public static void Main(string[] args)
    // {
    //     Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();
    //
    //     IWeaponsFactory WeaponsFactory = new WeaponsFactory(balance);
    //     
    //     ICharatersFactory MainCharacter = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);
    //
    //     Character Player  = MainCharacter.CreateCharacter("Player1");
    //     Character Enemy1  = MainCharacter.CreateCharacter("Enemy1");
    //
    //
    //     IAttack Attack = new Attack.Attack();
    //     Attack.CharacterAttack(Player, Enemy1);
    // }
}

// public class FactoryKeeper
// {
//     Balance balance = new GetCharactersBalans("MyJson.json").GetBalans();
//
//     IWeaponsFactory   WeaponsFactory = new WeaponsFactory(balance);
//     ICharatersFactory MainCharacter  = new CharactersFactory(balance, new DamageCalculator(), WeaponsFactory);
// }