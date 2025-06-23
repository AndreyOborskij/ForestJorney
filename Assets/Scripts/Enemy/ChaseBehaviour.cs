public class ChaseBehaviour : Behaviour
{
    public void SetTrigger(Player player)
    {
        _player = player;
    }

    public override void Walk()
    {
        _moverEnemy.Move(_player.transform.position);
    }

    public override float DetermineDirection()
    {
        return transform.position.x - _player.transform.position.x;
    }
}