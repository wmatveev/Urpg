using System;
using System.Collections.Generic;
using Rpg.Target;

namespace RPG.Weapons
{
    public interface IWeaponController
    {
        event Action<IWeapon> OnAttacked;
        List<IWeapon> listOfWeapons { get; }
        IWeapon CurrentWeapon { get; }

        void InitCharacter(Rpg.Character character);
        void AddWeaponToCharacter(IWeapon weapon);
        void DropWeaponFromCharacter(IWeapon weapon);
        void SelectWeapon(int index);
        void Attack(ITarget target);
    }
}