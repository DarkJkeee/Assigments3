using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments3.Tanks
{
    class Artillery : Tank
    {
        // Вероятность уничтожения.
        protected double probOfDestuctions;
        // Реализация метода GetDamage у танка Artillery.
        public override void GetDamage(double damage)
        {
            healthy = healthy - damage;
            if (random.Next(0, 10) < 2)
            {
                fire = true;
            }
        }
        // Реализация метода Attack у танка Artillery.
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
                if (probOfDestuctions > random.NextDouble())
                {
                    tank.Healthy = 0;
                }
            }
        }
        // Конструктор, задающий начальные параметры танка Artillery при создании.
        public Artillery()
        {
            healthy = random.Next(1500, 2001);
            damage = random.Next(2000, 2501);
            probOfDestuctions = random.Next(30, 60) / 100.0;
        }

        public override string ToString()
        {
            if(fire == true)
            {
                return $"Танк: Artillery, урон: {damage}, здоровье: {healthy}, танк горит!";
            }
            else
            {
                return $"Танк: Artillery, урон: {damage}, здоровье: {healthy}.";
            }
        }
    }
}
