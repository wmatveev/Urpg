using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RPG.Character.CharacterCreationFactory;
using Rpg.TurnBased;
using RPG.Weapons.DamageCalculation;
using RPG.Weapons.WeaponsFactory;
using UnityEngine;

namespace Rpg.Initialization
{
    public class Initializator : MonoBehaviour
    {
        [SerializeField]
        private TextAsset _balanceFile;// = "MyJson.json";

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
            Character character = _charactersFactory.CreateCharacter(id);
            if (isControlable)
            {
                _controlables.Add(character);
            }
            view.Init(character);
            view.OnCharacterClicked += OnCharacterSelected;
            character.Health.OnHit += (dmg) =>
            {
                Debug.Log($"{id} was hitted!");
            };
            _turnQueue.Enqueue(character);
        }

        private void OnCharacterSelected(Character character)
        {
            _turnController.Interact(character);
        }

        private void CreateFactories(Balance balance)
        {
            _weaponsFactory = new WeaponsFactory(balance);
            _charactersFactory = new CharactersFactory(balance, new DamageCalculator(), _weaponsFactory);
        }
    }
}