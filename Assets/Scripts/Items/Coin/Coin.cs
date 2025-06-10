public class Coin : ItemLogic<Coin>
{
    public override void Collect()
    {
        NotifyCollected();
    }
}