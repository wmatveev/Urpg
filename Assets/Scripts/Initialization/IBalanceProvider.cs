using System;
using RPG.Character.CharacterCreationFactory;

namespace Rpg.Initialization
{
    public delegate void BalanceLoadCallback(Balance balance);

    public interface IBalanceProvider
    {
        void GetBalance(BalanceLoadCallback onBalance);
    }
}