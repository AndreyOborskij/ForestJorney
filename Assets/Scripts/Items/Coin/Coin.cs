public class Coin : Item
{
    public float ResetTime => 4f;

    public override void Collect()
    {
        NotifyCollected();
    }
}