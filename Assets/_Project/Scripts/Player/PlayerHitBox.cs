using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private Player _player;
    public Player Player => _player;

    public PlayerHitBox InjectPlayer(Player player)
    {
        _player = player;
        return this;
    }
}