namespace RPG.Character.CharacterCreationFactory
{
    public interface ICharatersFactory
    {
        Rpg.Character CreateCharacter(string idCharacter);
    }
}