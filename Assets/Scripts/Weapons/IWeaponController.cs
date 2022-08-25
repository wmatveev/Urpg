using System.Collections.Generic;

namespace RPG.Weapons
{
    public interface IWeaponController
    {
        List<IWeapon> listOfWeapons { get; }
        IWeapon CurrentWeapon { get; }

        void AddWeaponToCharacter(IWeapon weapon);
        void DropWeaponFromCharacter(IWeapon weapon);
        void SelectWeapon(int index);
    }
}