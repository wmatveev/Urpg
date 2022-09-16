using System;
using Rpg.Target;
using RPG.Weapons.DamageCalculation;

namespace RPG.Weapons
{
    public interface IWeapon
    {
        // int CountCartridges { get; }        // Количество патронов
        // int IsReloading     { get; }        // В процессе перезарядки
        // int Range           { get; }        // Диапазон выстрела
        // bool CanShoot       { get; }        // Возможность стрелять
        int ShotDamage      { get; }        // Урон от выстрела / броска

        ITarget Shoot(Damage damage);
        // void Reload();
    }
}