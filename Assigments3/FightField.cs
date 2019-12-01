using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assigments3.Tanks;
using System.Threading;


namespace Assigments3
{
    /// <summary>
    /// Класс, описывающий поле битвы танков.
    /// </summary>
    class FightField
    {
        static Random random = new Random();
        // Имена игроков.
        private string player1, player2;
        // Отряды танков.
        private List<Tank> tanks1 = new List<Tank>();
        private List<Tank> tanks2 = new List<Tank>();

        // Конструктор для передачи значений полям класса.
        public FightField(List<Tank> tanks1, List<Tank> tanks2, string name1, string name2)
        {
            this.tanks1 = tanks1;
            this.tanks2 = tanks2;
            player1 = name1;
            player2 = name2;
        }

        // Метод, описывающий бой танков на поле битвы.
        public void Fight()
        {
            // Повторять цикл битвы, пока есть живые танки в двух отрядах.
            while (tanks1.Count != 0 && tanks2.Count != 0)
            {
                // Показывать игрока, который делает ход.
                Console.WriteLine($"Ход игрока {player1} \n");
                // Счетчик засвеченных танков.
                int k = -1;
                // Выбор случайного танка из отряда игрока, который делает ход.
                int index = random.Next(0, tanks1.Count);
                // Цикл, для засвета танков.
                for (int i = 0; i < tanks2.Count; ++i)
                {
                    double probability = 0.7 - 0.1 * i - 0.2 * (tanks2[i] is Artillery ? 1 : 0);
                    if (probability > random.NextDouble())
                    {
                        k = 0;
                        tanks2[i].IsVisible = true;
                    }
                }
                // Информация о танке игрока, который делает ход.
                Console.WriteLine($"Ваш {tanks1[index].ToString()}\n\n");
                Console.WriteLine("Сделайте выбор: \n");
                int[] remindIndex = new int[5];
                for (int i = 0; i < tanks2.Count; ++i)
                {
                    if (tanks2[i].IsVisible == true)
                    {
                        // Вывод меню выбора засвеченных танков.
                        Console.WriteLine($"\t\t{k + 1} - {tanks2[i].ToString()}");
                        remindIndex[k] = i;
                        ++k;
                        tanks2[i].IsVisible = false;
                    }
                }

                // Вывод информации, если танки не были засвечены.
                if (k == -1)
                {
                    Console.WriteLine("Вражеские танки не обнаружены... ");
                    Console.WriteLine("Ход переходит к противоположной команде.");
                }


                if(k!= -1)
                {
                    // Ввод значения пользователем.
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
                            if (k >= 2)
                            {
                                tanks1[index].Attack(tanks2[remindIndex[1]]);
                                if (tanks2[remindIndex[1]].Healthy <= 0)
                                {
                                    Console.WriteLine($"{tanks2[remindIndex[1]]} Уничтожен.");
                                    tanks2.RemoveAt(remindIndex[1]);
                                    break;
                                }
                                Console.WriteLine(tanks2[remindIndex[1]].ToString());
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введите корректное значение! Начало нового раунда! \n\n");
                                continue;
                            }
                        case '3':
                            if (k >= 3)
                            {
                                tanks1[index].Attack(tanks2[remindIndex[2]]);
                                if (tanks2[remindIndex[2]].Healthy <= 0)
                                {
                                    Console.WriteLine($"{tanks2[remindIndex[2]]} Уничтожен.");
                                    tanks2.RemoveAt(remindIndex[2]);
                                    break;
                                }
                                Console.WriteLine(tanks2[remindIndex[2]].ToString());
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введите корректное значение! Начало нового раунда! \n\n");
                                continue;
                            }
                        case '4':
                            if (k >= 4)
                            {
                                tanks1[index].Attack(tanks2[remindIndex[3]]);
                                if (tanks2[remindIndex[3]].Healthy <= 0)
                                {
                                    Console.WriteLine($"{tanks2[remindIndex[3]]} Уничтожен.");
                                    tanks2.RemoveAt(remindIndex[3]);
                                    break;
                                }
                                Console.WriteLine(tanks2[remindIndex[3]].ToString());
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введите корректное значение! Начало нового раунда! \n\n");
                                continue;
                            }
                        case '5':
                            if (k >= 5)
                            {
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
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Введите корректное значение! Начало нового раунда! \n\n");
                                continue;
                            }
                        default:
                            Console.Clear();
                            Console.WriteLine("Введите корректное значение! Начало нового раунда! \n\n");
                            continue;
                    }
                }

                // Пересортировка отряда танков.
                for (int i = tanks1.Count - 1; i >= 1; i--)
                {
                    int j = random.Next(i + 1);
                    var temp1 = tanks1[j];
                    tanks1[j] = tanks1[i];
                    tanks1[i] = temp1;
                }

                for (int i = tanks2.Count - 1; i >= 1; i--)
                {
                    int j = random.Next(i + 1);
                    var temp2 = tanks2[j];
                    tanks2[j] = tanks2[i];
                    tanks2[i] = temp2;
                }

                // Смена имен местами для перехода хода к следующему игроку.
                string strtemp = player1;
                player1 = player2;
                player2 = strtemp;

                // Смена отрядов местами для перехода хода к следующему игроку.
                List<Tank> temp = new List<Tank>();
                temp = tanks1;
                tanks1 = tanks2;
                tanks2 = temp;

                // Ожидание и очистка консоли перед началом следующего цикла.
                Thread.Sleep(5000);
                Console.Clear();
            }

            // Вывод информации о победителе после завершения боя.
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
