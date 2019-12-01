using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigments3.Tanks
{
    class T34 : Tank
    {
        // Вероятность критического урона
        protected double probOfCrit;
        // Реализация метода получения урона.
        public override void GetDamage(double damage)
        {
            healthy = healthy - damage;
            // Возгорание танка с вероятностью 0,2.
            if (random.Next(10) < 2)
            {
                fire = true;
            }
        }
        // Реализация метода атаки другого танка.
        public override void Attack(Tank tank)
        {
            if (fire == true)
            {
                fire = false;
                return;
            }

            tank.GetDamage(damage);
            if (probOfCrit > random.NextDouble())
            {
                tank.GetDamage(damage);
            }
        }
        // Конструктор, задающий начальные параметры танка T34 при создании.
        public T34()
        {
            healthy = random.Next(3000, 3501);
            damage = random.Next(450, 651);
            probOfCrit = random.Next(10, 20) / 100.0;
        }


        public override string ToString()
        {
            if(fire == true)
            {
                return $"Танк: T34, урон: {damage}, здоровье: {healthy}, танк горит!";
            }
            else
            {
                return $"Танк: T34, урон: {damage}, здоровье: {healthy}.";
            }
        }
    }
}
