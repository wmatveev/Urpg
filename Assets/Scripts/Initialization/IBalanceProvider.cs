using System;
using RPG.Character.CharacterCreationFactory;

namespace Rpg.Initialization
{
    public delegate void BalanceLoadCallback(Balance balance);

    // Интерфейс предоставляющий нам баланс - провайдер баланса
    public interface IBalanceProvider
    {
        // void GetBalance(Action<string> balanceText);
        //  Action<Balance> или аналог делегат - тк мы хотим предусмотреть асинхронную вычитку (к примеру загрузку из сети)
        
        void GetBalance(BalanceLoadCallback onBalance);
    }
}