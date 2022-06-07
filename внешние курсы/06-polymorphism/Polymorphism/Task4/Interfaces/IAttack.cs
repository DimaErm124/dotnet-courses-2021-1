namespace Task4
{
    public interface IAttack
    {
        double Damage { get; set; }

        void Attack(IActiveMobilable activeMobilable);
    }
}
