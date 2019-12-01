using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments3.Tanks
{
    abstract class Tank
    {
        protected static Random random = new Random();
        // Поле здоровья танка.
        protected double healthy;
        // Свойство, которое дает доступ к приватному полю healthy.
        public double Healthy
        {
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным.");
                }
                healthy = value;
            }
            get {
                return healthy;
            }
        }
        // Поле урона танка.
        protected int damage;
        // Поле с информацией о том, горит танк или нет.
        protected bool fire = false;
        // Поле с информацией о том, обнаружен ли танк.
        protected bool isVisible = false;
        // Свойство, которое даёт доступ к приватному полю isVisible.
        public bool IsVisible { set; get; }

        // Абстрактные методы атаки и получения урона.
        public abstract void GetDamage(double damage);
        public abstract void Attack(Tank tank);
    }

}
