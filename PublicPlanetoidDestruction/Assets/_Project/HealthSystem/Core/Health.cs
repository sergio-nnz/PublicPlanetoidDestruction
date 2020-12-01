using System;

namespace _Project.HealthSystem.Core
{
    public abstract class Health : IHealth
    {
        protected int hitPoints = 0;

        public void Decrease()
        {
            hitPoints--;
        }

        public void Increase()
        {
            hitPoints++;
        }

        public bool IsDeath()
        {
            return hitPoints <= 0;
        }
    }
}