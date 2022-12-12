using System.Collections.Generic;
using System.Linq;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased
{
    public class TurnController : MonoBehaviour
    {
        [SerializeField]
        private Button _btnSkip;
        [SerializeField]
        private Text _lblTurn;

        private List<Character> _controlables;

        private TurnQueue _queue;
        private GameTurn  _currentTurn;
        private bool      _isPlayerTurn;

        public void Init(TurnQueue queue, List<Character> controlables)
        {
            _controlables = controlables;
            _queue        = queue;

            _queue.OnTurnChanged += OnTurnChanged;

            _btnSkip.onClick.AddListener(OnSkip);
        }
        
        // Подписка на событие нажатия на персонажа
        public void SubscriptionByClick(CharacterView view)
        {
            view.OnCharacterClicked += Interact;
        }

        private void OnSkip()
        {
            _currentTurn.Skip();
        }

        private void OnTurnChanged(GameTurn turn)
        {
            _currentTurn = turn;
            _lblTurn.text = $"Turn of {turn.Owner.Id} HP:{turn.Owner.Health.CurrentHealth}";

            if (_controlables.Contains(turn.Owner))
            {
                StartPlayerControls(turn);
            }
            else
            {
                DisablePlayerControls();
                // HACK! only temp solution
                Invoke("EnemyAttack", 1f);
            }
        }

        private void EnemyAttack()
        {
            _currentTurn.Attack(_controlables.First());
        }
        
        private void StartPlayerControls(GameTurn turn)
        {
            _isPlayerTurn = true;
            _btnSkip.gameObject.SetActive(true);
        }

        private void Interact(Character character)
        {
            if (_currentTurn.Owner != character && _isPlayerTurn)
            {
                _currentTurn.Attack(character);
            }
        }

        private void DisablePlayerControls()
        {
            _isPlayerTurn = false;
            _btnSkip.gameObject.SetActive(false);
        }

    }
}