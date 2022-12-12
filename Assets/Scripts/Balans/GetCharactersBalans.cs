using System.IO;
using Newtonsoft.Json;
using Unit.CharacterCreationFactory;

namespace Balans
{
    public class GetCharactersBalans : IGetBalans
    {
        private string _path;
        
        public GetCharactersBalans(string Path)
        {
            _path = Path;
        }

        public Balance GetBalans()
        {
            // TODO сделать через конструктор
            return JsonConvert.DeserializeObject<Balance>(File.ReadAllText(_path));
        }

        public void CreateJsonBalansFromExample()
        {
            // Balance balance = new Balance() {
            //     PlayerBalance = new Dictionary<string, PlayerBalance>() {
            //         ["Player1"] = new PlayerBalance() {
            //             Stats = Stats.Default
            //         }
            //     },
            //     EnemyBalance  = new Dictionary<string, EnemyBalance>() {
            //         ["Enemy1"] = new EnemyBalance() {
            //             Stats = Stats.Default,
            //             AvailableWeapons = new List<string>()
            //             {
            //                 IDWeapon.Gun
            //             }
            //         }
            //     }
            // };
            //
            // string json = JsonConvert.SerializeObject(balance, Formatting.Indented);
            //
            // string path = _path;
            // File.WriteAllText(path, json);
        }
    }
}