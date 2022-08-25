using RPG.Character.CharacterCreationFactory;

namespace Rpg.Balans
{
    public interface IGetBalans
    {
        Balance GetBalans();
        void CreateJsonBalansFromExample();
    }
}