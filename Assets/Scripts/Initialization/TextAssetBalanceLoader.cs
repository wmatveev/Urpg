using Newtonsoft.Json;
using RPG.Character.CharacterCreationFactory;
using UnityEngine;

namespace Rpg.Initialization
{
    public class TextAssetBalanceLoader : IBalanceProvider
    {
        private readonly TextAsset _textAsset;

        public TextAssetBalanceLoader(TextAsset textAsset)
        {
            _textAsset = textAsset;
        }

        public void GetBalance(BalanceLoadCallback onBalance)
        {
            // Аналог нижней записи
            // if (onBalance != null)
            // {
            //     onBalance(JsonConvert.DeserializeObject<Balance>(_textAsset.text));
            // }

            onBalance?.Invoke(JsonConvert.DeserializeObject<Balance>(_textAsset.text));
        }
    }
}