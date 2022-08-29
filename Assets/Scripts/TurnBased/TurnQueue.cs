using System;
using System.Collections.Generic;
using Rpg.TurnBased;

namespace Rpg
{
    public class TurnQueue
    {
        public event Action<GameTurn> OnTurnChanged;
        public GameTurn Currrent => _queue.Count > 0 ? _queue.Peek() : default;
        private Queue<GameTurn> _queue = new Queue<GameTurn>();

        public void Enqueue(Character item)
        {
            var newTurn = new GameTurn(item, OnTurnComplete);
            _queue.Enqueue(newTurn);
            if (_queue.Count == 1)
            {
                OnTurnChanged?.Invoke(newTurn);
            }
        }

        private void OnTurnComplete(GameTurn turn)
        {
            if (turn == Currrent)
            {
                Dequeue();
                Enqueue(turn.Owner);
                OnTurnChanged?.Invoke(Currrent);
            }
        }

        public GameTurn Dequeue()
        {
            var item = _queue.Peek();
            _queue.Dequeue();
            return item;
        }
    }
}