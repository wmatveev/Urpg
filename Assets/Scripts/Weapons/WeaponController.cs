using System;
using System.Collections.Generic;
using Rpg.Target;

namespace RPG.Weapons
{
    public class WeaponController : IWeaponController
    {
        public event Action<IWeapon> OnAttacked;
        public List<IWeapon> listOfWeapons { get; }
        public IWeapon CurrentWeapon { get; private set; }

        public WeaponController()
        {
            listOfWeapons = new List<IWeapon>();
        }
        
        public void AddWeaponToCharacter(IWeapon weapon)
        {
            listOfWeapons.Add(weapon);

            // Когда добавляем персонажу новое оружие, сразу делаем его активным
            CurrentWeapon = weapon;
        }

        // Удаляем оружие из списка, которым владеет персонаж
        public void DropWeaponFromCharacter(IWeapon weapon)
        {
            listOfWeapons.Remove(weapon);
            
            // Если не остается оружия у персонажа, то обнуляем текущее оружие
            CurrentWeapon = listOfWeapons.Count != 0 ? listOfWeapons[0] : null;
        }

        // Функция выбора оружия
        public void SelectWeapon(int index)
        {
            throw new System.NotImplementedException();
        }

        public void Attack(ITarget target)
        {
            // TODO: CurrentWeapon.Shoot to tareget
            target.Health.DealDamage(CurrentWeapon);
            OnAttacked?.Invoke(CurrentWeapon);
        }
    }
}