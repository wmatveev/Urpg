using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MoveChange : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text   _text;

        private void Start()
        {
            _text.text = "Move -> " + "Player";
        }
    }
}