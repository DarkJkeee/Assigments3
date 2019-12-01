using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assigments3.Tanks;
using System.Threading;

namespace Assigments3
{
    class FightField
    {
        static Random random = new Random();
        private string player1, player2;
        private List<Tank> tanks1 = new List<Tank>();
        private List<Tank> tanks2 = new List<Tank>();

        public FightField(List<Tank> tanks1, List<Tank> tanks2, string name1, string name2)
        {
            this.tanks1 = tanks1;
            this.tanks2 = tanks2;
            player1 = name1;
            player2 = name2;
        }

        public void Fight()
        {
            while (tanks1.Count != 0 && tanks2.Count != 0)
            {
                Console.WriteLine($"Ход игрока {player1} \n");
                int k = -1;
                int index = random.Next(0, tanks1.Count);
                for (int i = 0; i < tanks2.Count; ++i)
                {
                    double probability = 0.7 - 0.1 * i - 0.2 * (tanks2[i] is Artillery ? 1 : 0);
                    if (probability > random.NextDouble())
                    {
                        k = 0;
                        tanks2[i].IsVisible = true;
                    }
                }
                Console.WriteLine($"Ваш {tanks1[index].ToString()}\n\n");
                Console.WriteLine("Сделайте выбор: \n");
                int[] remindIndex = new int[5];
                for (int i = 0; i < tanks2.Count; ++i)
                {
                    if (tanks2[i].IsVisible == true)
                    {
                        Console.WriteLine($"\t\t{k + 1} - {tanks2[i].ToString()}");
                        remindIndex[k] = i;
                        ++k;
                        tanks2[i].IsVisible = false;
                    }
                }

                if (k == -1)
                {
                    Console.WriteLine("Вражеские танки не обнаружены... ");
                    Console.WriteLine("Ход переходит к противоположной команде.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    continue;
                }

                char num = (char)Console.ReadKey(true).Key;

                switch (num)
                {
                    case '1':
                        tanks1[index].Attack(tanks2[remindIndex[0]]);
                        if (tanks2[remindIndex[0]].Healthy <= 0)
                        {
                            Console.WriteLine($"{tanks2[remindIndex[0]]} Уничтожен.");
                            tanks2.RemoveAt(remindIndex[0]);
                            break;
                        }
                        Console.WriteLine(tanks2[remindIndex[0]].ToString());
                        break;
                    case '2':
                        tanks1[index].Attack(tanks2[remindIndex[1]]);
                        if (tanks2[remindIndex[1]].Healthy <= 0)
                        {
                            Console.WriteLine($"{tanks2[remindIndex[1]]} Уничтожен.");
                            tanks2.RemoveAt(remindIndex[1]);
                            break;
                        }
                        Console.WriteLine(tanks2[remindIndex[1]].ToString());
                        break;
                    case '3':
                        tanks1[index].Attack(tanks2[remindIndex[2]]);
                        if (tanks2[remindIndex[2]].Healthy <= 0)
                        {
                            Console.WriteLine($"{tanks2[remindIndex[2]]} Уничтожен.");
                            tanks2.RemoveAt(remindIndex[2]);
                            break;
                        }
                        Console.WriteLine(tanks2[remindIndex[2]].ToString());
                        break;
                    case '4':
                        tanks1[index].Attack(tanks2[remindIndex[3]]);
                        if (tanks2[remindIndex[3]].Healthy <= 0)
                        {
                            Console.WriteLine($"{tanks2[remindIndex[3]]} Уничтожен.");
                            tanks2.RemoveAt(remindIndex[3]);
                            break;
                        }
                        Console.WriteLine(tanks2[remindIndex[3]].ToString());
                        break;
                    case '5':
                        tanks1[index].Attack(tanks2[remindIndex[4]]);
                        if (tanks2[remindIndex[4]].Healthy <= 0)
                        {
                            Console.WriteLine($"{tanks2[remindIndex[4]]} Уничтожен.");
                            tanks2.RemoveAt(remindIndex[4]);
                            break;
                        }
                        Console.WriteLine(tanks2[remindIndex[4]].ToString());
                        break;
                }
                
                for(int i = tanks1.Count -1; i>=1; i--)
                {
                    int j = random.Next(i + 1);
                    var temp1 = tanks1[j];
                    tanks1[j] = tanks1[i];
                    tanks1[i] = temp1;
                }

                string strtemp = player1;
                player1 = player2;
                player2 = strtemp;

                List<Tank> temp = new List<Tank>();
                temp = tanks1;
                tanks1 = tanks2;
                tanks2 = temp;
                Thread.Sleep(5000);

                Console.Clear();
            }
            if(tanks1.Count == 0)
            {
                Console.WriteLine($"Поздравляем {player2}, вы победили!");
            }
            else if(tanks2.Count == 0)
            {
                Console.WriteLine($"Поздравляем {player1}, вы победили!");
            }
        }
    }
}
