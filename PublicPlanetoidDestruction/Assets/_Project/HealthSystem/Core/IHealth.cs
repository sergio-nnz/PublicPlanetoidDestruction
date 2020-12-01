namespace _Project.HealthSystem.Core
{
    public interface IHealth
    {
        void Decrease();

        void Increase();

        bool IsDeath();
    }
}