using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RPG.Character;
using RPG.Character.CharacterCreationFactory;
using Rpg.TurnBased;
using RPG.Weapons;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;

namespace Rpg.Initialization
{
    // Создаем класс Initializator, в котором инициализируем все начальные объекты + вычитываем баланс
    public class Initializator : MonoBehaviour
    {
        // "MyJson.json" загружаем из Ассетов, чтобы смогли найти и прочитать файл с любой платформы
        [SerializeField]
        private TextAsset _balanceFile;

        [SerializeField]
        private TurnController _turnController;

        [SerializeField]
        private CharacterView _hero;
        [SerializeField]
        private CharacterView _enemy;
        
        private WeaponsFactory _weaponsFactory;
        private CharactersFactory _charactersFactory;
        private TurnQueue _turnQueue;
        private List<Character> _controlables = new List<Character>();


        void Awake()
        {
            // Вычитываем баланс
            var balanceLoader = new TextAssetBalanceLoader(_balanceFile);

            _turnQueue = new TurnQueue();

            balanceLoader.GetBalance((balance) =>
            {
                CreateFactories(balance);

                _turnController.Init(_turnQueue, _controlables);

                InitCharacter("Player1", _hero, true);
                InitCharacter("Enemy1", _enemy, false);
            });
        }

        void InitCharacter(string id, CharacterView view, bool isControlable)
        {
            // Создаем персонажа
            Character character = _charactersFactory.CreateCharacter(id);

            // Сохраняем в WeaponController персонажа, которому принадлежит WC
            character.WeaponController.InitCharacter(character);

            if (isControlable)
            {
                _controlables.Add(character);
            }

            view.Init(character);

            _turnController.SubscriptionByClick(view);

            character.Health.OnHit += (dmg) =>
            {
                Debug.Log($"{id} was hitted!");
            };

            // Добавляем в очередь
            _turnQueue.Enqueue(character);
        }

        private void CreateFactories(Balance balance)
        {
            _weaponsFactory    = new WeaponsFactory(balance);
            _charactersFactory = new CharactersFactory(balance, new DamageCalculator(), _weaponsFactory);
        }
    }
}