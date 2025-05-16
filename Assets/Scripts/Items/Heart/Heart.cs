public class Heart : Item
{
    private int _healPower = 10;

    public int HealPower => _healPower;

    public override void Collect()
    {
        NotifyCollected();
    }
}
