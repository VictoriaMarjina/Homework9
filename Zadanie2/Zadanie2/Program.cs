using System;

namespace Zadanie2
/* Создать базовый класс Счет, котороый содержит информацию - сумма, номер счета, дата открытия, а также методы Выдача суммы и Выдача даты открытия счета.С помошью механизма наследования создать класс "Счет физического лица" и "Счет юридического лица.

"Счет физического лица" содержит:
поле "Вид счета"
методы "Начисление процентов" и "Снятие денег со счета"

"Счет юридического лица содержит:
метод начисления процентов*/
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введите номер счета (10000-10009)");
            string accountnumber = Console.ReadLine();
            try
            {
                int acc = Convert.ToInt32(accountnumber);
                if (acc >= 10000 && acc <= 10009)
                {
                    DataBase(accountnumber);
                }
                else
                {
                    Console.WriteLine("Указанный счет отсутствует в базе");
                    Main();
                }
            }
            catch
            {
                Console.WriteLine("Введите число в диапазоне от 10000 до 10009");
                Main();
            }
        }

        public static void DataBase(string accountnumber)
        {
            string[,] accounts = new[,] { { "10000","Александр Сергеевич Пушкин", "физ.лицо", "RUB", "депозитный счет", "300446", "25.08.2015", "" },
                                       { "10001","Лев Николаевич Толстой", "юр.лицо", "USD", "депозитный счет", "151523,45", "21.01.2019","Tolstoy MMC" },
                                       { "10002","Антон Павлович Чехов", "физ.лицо", "AZN", "кредитный счет", "-1689", "01.05.2020", "" },
                                       { "10003","Николай Васильевич Гоголь", "юр.лицо", "AZN", "дебетовый счет", "8789", "05.09.2010", "Qoqol-Moqol ASC" },
                                       { "10004","Федор Михайлович Достоевский", "физ.лицо", "AZN", "дебетовый счет", "5 689", "25.08.2015", ""  },
                                       { "10005","Гавриил Романович Державин", "физ.лицо", "RUB", "дебетовый счет", "5 689", "25.08.2015", ""  },
                                       { "10006","Иван Андреевич Крылов", "юр.лицо", "USD", "дебетовый счет", "5 689", "25.08.2015", "Redbull QSC"  },
                                       { "10007","Федор Иванович Тютчев", "физ.лицо", "AZN", "кредитный счет", "-5 689", "25.08.2015", "-"  },
                                       { "10008","Николай Алексеевич Некрасов", "физ.лицо", "AZN", "кредитный счет", "-5 689", "25.08.2015", ""  },
                                       { "10009","Михаил Евграфович Салтыков-Щедрин", "юр.лицо", "USD", "дебетовый счет", "5 689", "25.08.2015", "Sosial MMC" } };


            for (int i = 0; i < 10; i++)
            {

                if (accounts[i, 0] == accountnumber)
                {

                    int sum = Convert.ToInt32(accounts[i, 5]);
                    string accounttype = accounts[i, 4];
                    string openingDate = accounts[i, 6];
                    string company = accounts[i, 7];
                    string currency = accounts[i, 3];
                    string clientType = accounts[i, 2];

                    Console.WriteLine($"{accounts[i, 1]}, \n {clientType}, \n {currency}, \n {accounttype}, \n {company}, \n");

                    BankAccount client = new BankAccount(sum, accountnumber, openingDate, clientType, currency, accounttype);
                    switch (client.ClientType)
                    {
                        case "физ.лицо":
                            Individual client1 = new Individual(sum, accountnumber, openingDate, accounttype, clientType, currency);
                            if (accounttype == "депозитный счет")
                            {
                                client1.PrintDate();
                                client1.PrintSum();
                                client1.Deposit();
                                Main();

                            }
                            else if (accounttype == "Кредитный счет")
                            {
                                client1.PrintDate();
                                client1.Credit();
                                Main();
                            }
                            else
                            {
                                client1.PrintDate();
                                client1.CashOut();
                                Main();

                            }

                            break;

                        case "юр.лицо":

                            Entity client2 = new Entity(sum, accountnumber, openingDate, accounttype, clientType, currency, company);
                            client2.PrintDate();
                            client2.PrintSum();
                            client2.Deposit();
                            Main();
                            break;
                    }
                    break;

                }

                else if(accounts[i, 0] != accountnumber)
                {
                    continue;
                   
                }

            }


        }


    }

}
public class BankAccount
{
    private static int sum;
    public static int Sum { get; set; }
    private string accountnumber;
    public string Accountnumber { get; set; }
    private string openingDate;
    public string OpeningDate { get; set; }
    private string clientType;
    public string ClientType { get; set; }
    private string currency;
    public string Currency { get; set; }
    private string accounttype;
    public string Accounttype { get; set; }
    public BankAccount(int sum, string accountnumber, string openingDate, string clientType, string currency, string accounttype)
    {
        Sum = sum;
        Accountnumber = accountnumber;
        OpeningDate = openingDate;
        ClientType = clientType;
        Accounttype = accounttype;
        Currency = currency;
    }

    public void PrintSum()
    {
        Console.WriteLine($"Баланс равен: {Sum} {Currency}");
    }
    public void PrintDate()
    {
        Console.WriteLine($"Дата открытия данного счета: {OpeningDate}");
    }


}
public class Individual : BankAccount
{
    private string accounttype;
    public string Accounttype { get; set; }
    private int interest;
    public int Interest { get; set; }
    private int days;
    public int Days { get; set; }
    /*private static int newSum;
    public static int NewSum { get; set; }*/

    public Individual(int sum, string accountnumber, string openingDate, string accounttype, string clientType, string currency) : base(sum, accountnumber, openingDate, clientType, currency, accounttype)
    {
        Accounttype = accounttype;
        Interest = interest;
        Days = days;
    }

    public int Deposit()
    {

        int interest = 11;
        Console.WriteLine("Введите количество дней пребывания денег на депозитном счету чтобы узнать как изменится баланс счета");
        try
        {   
            int days = Convert.ToInt32(Console.ReadLine());
            if(days>0){
                int Depsum = (Sum * interest * days / 365) / 100;
                Console.WriteLine($"Баланс будет равен{Sum + Depsum} {Currency}");
                return Depsum;
            }
            else
            {
                Console.WriteLine("Введите целое положительное число");
                return Deposit();
            }
        }
        catch
        {
            Console.WriteLine("Введите целое положительное число");
            return Deposit();
        }
        
        

    }
    public int CashOut()
    {
        Console.WriteLine("Какую сумму вы хотите снять со счета?");
        int moneyout = Convert.ToInt32(Console.ReadLine());
          if(moneyout>0){
                Sum = Sum - moneyout;
                Console.WriteLine($"Баланс будет равен {Sum} {Currency}");
                return Sum;
            }
            else
            {
                Console.WriteLine("Введите целое положительное число");
                return CashOut();
            }
       
    }
    public void Credit()
    {
        Sum = Math.Abs(Sum);
        Console.WriteLine($"Задолженность составляет {Sum} {Currency}");

    }

}
public class Entity : Individual
{
    private string company;
    public string Company { get; set; }
    public Entity(int sum, string accountnumber, string openingDate, string accounttype, string clientType, string currency, string company) : base(sum, accountnumber, openingDate, accounttype, clientType, currency)
    {
        Company = company;
    }
    public new int Deposit()
    {
        int interest = 8;
        Console.WriteLine("Введите количество дней пребывания денег на депозитном счету чтобы узнать как изменится баланс счета");
        try
        {
            int days = Convert.ToInt32(Console.ReadLine());
            if (days > 0)
            {
                int Depsum = (Sum * interest * days / 365) / 100;
                Console.WriteLine($"Баланс будет равен{Sum + Depsum} {Currency}");
                return Depsum;
            }
            else
            {
                Console.WriteLine("Введите целое положительное число");
                return Deposit();
            }
        }
        catch
        {
            Console.WriteLine("Введите целое положительное число");
            return Deposit();
        }

    }
}
