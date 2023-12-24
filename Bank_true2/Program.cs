using System;
using System.Threading.Channels;

namespace Bank_true2
{

    class Program
    {
        static void Main()
        { 

            Bank[] Schet = new Bank[3];

            for (int i = 0; i < 3; i++)
            {
                

                Schet[i] = new Bank();
                
            }

            Console.WriteLine($"\nОткрываем Ваш счет");
            Console.Write("Введите ваше фио: ");
            string fio = Console.ReadLine();
            Console.Write("Введите начальный баланс: ");
            float balance = float.Parse(Console.ReadLine());
            Schet[0].open(1, fio, balance);
            Schet[1].open(2,"Маслов", 100000);
            Schet[2].open(3, "Эмманюэль Макрон", 56);


            for (int i = 0; i< Schet.Length; i++) {
                Schet[i].Out();
            }
           
            Console.Write("\nВведите айди клиента для входа: ");
            int currentUserId = int.Parse(Console.ReadLine()) - 1;

            while (currentUserId < 0 || currentUserId >= Schet.Length)
            {
                Console.WriteLine("Некорректный айди клиента. Попробуйте еще раз.");
                Console.Write("Введите айди клиента для входа: ");
                currentUserId = int.Parse(Console.ReadLine()) - 1;
            }

            float money = 0;
            Bank id2 = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nВсе счета: ");
                for (int i = 0; i < Schet.Length; i++)
                {
                    Console.Write($"{i + 1} - ");
                    Schet[i].Out();
                }

                Console.WriteLine($"\nВы вошли под пользователем {currentUserId + 1}.");
                Console.WriteLine("\nВыберите действие:\n2 - положить деньги на счёт\n3 - снять деньги со счёта\n4 - Обналичить счёт полностью\n5 - Перевести клиенту банка\n6 - Сменить пользователя\n7 - Выйти из программы");
                Console.Write("Ввод: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Schet[currentUserId].Out();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Пополнение счета");
                        Console.Write("Сколько вы хотите положить?: ");
                        money = float.Parse(Console.ReadLine());
                        Schet[currentUserId].ProcessOperation(choice, money, null);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Снятие денег со счета.");
                        Console.Write("Введите сумму: ");
                        money = float.Parse(Console.ReadLine());
                        Schet[currentUserId].ProcessOperation(choice, money, null);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Обналичивание всего счета.");
                        Schet[currentUserId].ProcessOperation(choice, 0, null);
                        break;
                    case 5:
                        Console.Clear();
                        for (int i = 0; i < Schet.Length; i++)
                        {
                            Console.Write($"{i + 1} - ");
                            Schet[i].Out();
                        }
                        Console.Write("Перевод с вашего счёта на счет другого клиента банка.\nВведите айди клиента на который хотите сделать перевод: ");
                        int id2Index = int.Parse(Console.ReadLine()) - 1;

                        if (id2Index < 0 || id2Index >= Schet.Length)
                        {
                            Console.WriteLine("Некорректный айди клиента для перевода.");

                            break;
                        }

                        Console.Write("Введите сумму: ");
                        money = float.Parse(Console.ReadLine());
                        id2 = Schet[id2Index];
                        Schet[currentUserId].ProcessOperation(choice, money, id2);
                        break;
                    case 6:
                        Console.Write("Введите айди клиента для смены пользователя: ");
                        currentUserId = int.Parse(Console.ReadLine()) - 1;

                        while (currentUserId < 0 || currentUserId > Schet.Length)
                        {
                            Console.WriteLine("Некорректный айди клиента. Попробуйте ещё раз..");
                            Console.Write("Введите айди клиента для входа: ");
                            int.TryParse(Console.ReadLine(), out currentUserId);
                            currentUserId--;
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}