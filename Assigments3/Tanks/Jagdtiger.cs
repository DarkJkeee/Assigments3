using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments3.Tanks
{
    class Jagdtiger : Tank
    {
        // Вероятность рикошета.
        protected double probOfRicochet;
        // Реализация метода получения урона.
        public override void GetDamage(double damage)
        {
            if (probOfRicochet > random.NextDouble())
            {
                return;
            }
            else
            {
                healthy = healthy - damage;
                if (random.Next(10) < 4)
                {
                    fire = true;
                }
            }
        }
        // Реализация метода атаки.
        public override void Attack(Tank tank)
        {
            if (fire == true)
            {
                fire = false;
                return;
            }
            else
            {
                tank.GetDamage(damage);
            }
        }
        // Конструктор, задающий начальные параметры танка Jagdtiger при создании.
        public Jagdtiger()
        {
            healthy = random.Next(4500, 5501);
            damage = random.Next(600, 901);
            probOfRicochet = random.Next(30, 50) / 100.0;
        }

        public override string ToString()
        {
            if (fire == true)
            {
                return $"Танк: Jagdtiger, урон: {damage}, здоровье: {healthy}, танк горит!";
            }
            else
            {
                return $"Танк: Jagdtiger, урон: {damage}, здоровье: {healthy}.";
            }
        }
    }
}
