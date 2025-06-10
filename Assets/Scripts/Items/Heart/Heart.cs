public class Heart : ItemLogic<Heart>
{
    public int HealPower => 10;

    public override void Collect()
    {
        NotifyCollected();
    }
}
