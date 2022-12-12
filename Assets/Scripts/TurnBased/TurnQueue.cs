using System;
using System.Collections.Generic;
using Unit;

namespace TurnBased
{
    // Очередь ходов
    public class TurnQueue
    {
        public event Action<GameTurn> OnTurnChanged;
        public GameTurn Currrent => _queue.Count > 0 ? _queue.Peek() : default;
        private Queue<GameTurn> _queue = new Queue<GameTurn>();

        // Добавляем персонажа в очередь
        public void Enqueue(Character item)
        {
            // Создаем новый ход
            var newTurn = new GameTurn(item, OnTurnComplete);

            // Добавляем ход в очередь
            _queue.Enqueue(newTurn);

            if (_queue.Count == 1)
            {
                OnTurnChanged?.Invoke(newTurn);
            }
        }

        // Завершение хода
        private void OnTurnComplete(GameTurn turn)
        {
            if (turn == Currrent)
            {
                Dequeue();
                Enqueue(turn.Owner);
                OnTurnChanged?.Invoke(Currrent);
            }
        }

        // Удаляем персонажа из очереди
        public GameTurn Dequeue()
        {
            var item = _queue.Peek();
            _queue.Dequeue();
            return item;
        }
    }
}