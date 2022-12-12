using Unit.CharacterCreationFactory;

namespace Balans
{
    public interface IGetBalans
    {
        Balance GetBalans();
        void CreateJsonBalansFromExample();
    }
}