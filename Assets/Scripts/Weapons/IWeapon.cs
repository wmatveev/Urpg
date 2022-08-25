using System;
using Rpg.Target;

namespace RPG.Weapons
{
    public interface IWeapon : IEquatable<Gun>
    {
        int CountCartridges { get; }        // Количество патронов
        int IsReloading     { get; }        // В процессе перезарядки
        int Range           { get; }        // Диапазон выстрела
        bool CanShoot       { get; }        // Возможность стрелять
        int ShotDamage      { get; }        // Урон от выстрела / броска

        ITarget Shoot();
        void Reload();
    }
}