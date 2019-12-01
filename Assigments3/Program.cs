using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Assigments3.Tanks;

namespace Assigments3
{
    class Program
    {
        
        static Random random = new Random();
        static void Main()
        {
            do
            {

                Console.Clear();
                int i = 0;
                int j = 0;
                int size1 = 5;
                int size2 = 5;
                int money1 = 22;
                int money2 = 22;
                bool check = true;
                Console.WriteLine("Введите имя первого игрока: ");
                string name1 = Console.ReadLine();
                Console.WriteLine("Введите имя второго игрока: ");
                string name2 = Console.ReadLine();
                Console.Clear();

                List<Tank> tanksp1 = new List<Tank>();
                List<Tank> tanksp2 = new List<Tank>();

                while (money1 >= 3 && size1 > 0)
                {
                    if (check == false)
                    {
                        check = true;
                        continue;
                    }
                    Console.WriteLine($"{name1}: \n\n");
                    Console.WriteLine($"У тебя осталось {money1} кредита(ов) и {size1} мест(а).");
                    MenuOfChoice(ref size1, ref tanksp1, ref money1, ref check);
                    ++i;
                }

                Console.WriteLine($"{name1} закончил собирать отряд.\n");

                while (money2 >= 3 && size2 > 0)
                {
                    if (check == false)
                    {
                        check = true;
                        continue;
                    }
                    Console.WriteLine($"{name2}: \n\n");
                    Console.WriteLine($"У тебя осталось {money2} кредита(ов) и {size2} мест(а).");
                    MenuOfChoice(ref size2, ref tanksp2, ref money2, ref check);
                    ++j;
                }

                Console.WriteLine("Начало игры...\n\n");

                if (random.Next(0, 2) == 0)
                {
                    FightField fight = new FightField(tanksp1, tanksp2, name1, name2);
                    fight.Fight();
                }
                else
                {
                    FightField fight = new FightField(tanksp2, tanksp1, name2, name1);
                    fight.Fight();
                }

                Console.WriteLine("Желаете продолжить игру?...");
                Console.WriteLine("Если да - нажмите F");

            } while (Console.ReadKey().Key == ConsoleKey.F);
            
        }

        static void MenuOfChoice(ref int size, ref List<Tank> tankp, ref int money, ref bool check)
        {
            Console.WriteLine("Выбирай танки: ");
            Console.WriteLine("\t\t1 - T34 (Стоимость: 3 кредита)");
            Console.WriteLine("\t\t2 - Jagdtiger (Стоимость: 5 кредитов)");
            Console.WriteLine("\t\t3 - Artillery (Стоимость: 6 кредитов)");
            char symb = (char)Console.ReadKey(true).Key;
            Console.Clear();
            switch (symb)
            {
                case '1':
                    if (money - 3 >= 0)
                    {
                        tankp.Add(new T34());
                        money = money - 3;
                        size--;
                        break;
                    }
                    else
                    {
                        check = false;
                        Console.WriteLine("У тебя не хватает денег на этот танк. Купи другой!");
                        break;
                    }
                case '2':
                    if (money - 5 >= 0)
                    {
                        tankp.Add(new Jagdtiger());
                        money = money - 5;
                        size--;
                        break;
                    }
                    else
                    {
                        check = false;
                        Console.WriteLine("У тебя не хватает денег на этот танк. Купи другой!");
                        break;
                    }
                case '3':
                    if (money - 6 >= 0)
                    {
                        tankp.Add(new Artillery());
                        money = money - 6;
                        size--;
                        break;
                    }
                    else
                    {
                        check = false;
                        Console.WriteLine("У тебя не хватает денег на этот танк. Купи другой!");
                        break;
                    }
            }
        }
    }
}
