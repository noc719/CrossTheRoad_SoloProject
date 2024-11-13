public class CharacterManager : Manager<CharacterManager>
{
    private Player player;
    public Player Player
    {
        get { return player; }

        set { player = value; }
    }
}
