using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_true2
{


    internal class Bank
    {
        private int nom;
        private string name;
        private float sum;

        private void popolnenie(float money)
        {
            Console.WriteLine("Вы успешно добавили на счёт " + money);
            sum += money;
            Console.WriteLine($"Ваш баланс: {sum}");
        }

        private void spisanie(float money)
        {
            Console.WriteLine("Вы успешно сняли со счёта " + money);
            sum -= money;
            if (sum < 0)
            {
                Console.WriteLine("Ваш баланс отрицателен. За вами уже едут, я договорился");
            }
            Console.WriteLine($"Ваш баланс: {sum}");
        }

        private void obnul()
        {
            Console.WriteLine("Вы успешно сняли всю сумму.\nС вашего счёта списано " + sum);
            sum = 0;
        }

        private void perevod(float money, Bank id2)
        {
            Console.WriteLine($"Вы успешно перевели {money} на счет клиента {id2.name}");

            if (sum < money)
            {
                Console.WriteLine("Недостаточно средств для перевода.");
            }
            else
            {
                sum -= money;
                id2.sum += money;
                Console.WriteLine($"Ваш баланс: {sum}");
                Console.WriteLine($"Баланс клиента {id2.name}: {id2.sum}");
            }
        }

        public void ProcessOperation(int choice, float money, Bank id2)
        {
            switch (choice)
            {
                case 2:
                    popolnenie(money);
                    break;
                case 3:
                    spisanie(money);
                    break;
                case 4:
                    obnul();
                    Out();
                    break;
                case 5:
                    perevod(money, id2);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор операции.");
                    break;
            }
        }

        public void open(int nom, string name, float sum)
        {
            this.nom = nom;
            this.name = name;
            this.sum = sum;
        }

        public void Out()
        {
            Console.WriteLine($"Номер счёта: {nom}. ФИО: {name}. Сумма: {sum}.");
        }
    }
}


