using Target;
using Weapons.DamageCalculation;

namespace Weapons
{
    public interface IWeapon
    {
        TypesOfWeapons TypeOfWeapon { get; set; }

        int CurrentBulletsAmount { set; get; }  // Количество патронов на текущий момент
        int TotalBulletsInClip   { set; get; }  // Общее количество патронов в обойме
        int Range { set; get; }                 // Диапазон выстрела
        bool CanShoot { set; get; }             // Возможность стрелять
        bool IsReloading { set; get; }          // В процессе перезарядки

        int ShotDamage      { get; }            // Урон от выстрела / броска

        ITarget Shoot(Damage damage);
    }
}