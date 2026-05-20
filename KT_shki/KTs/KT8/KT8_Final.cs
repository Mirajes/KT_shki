using System;

namespace KT_shki
{
    public class KT8_Final : KT
    {
        ReflectionHeadler reflectionHandler = new ReflectionHeadler();

        public override void Execute()
        {
            Helper.MakeAnIndentation("KT8 - Итоговая работа");

            //User user = new User("Bebebe", 13, "mail", ".ru");
            User user1 = new User("Danya", 11, MailService.mail, MailDomain.ru);
            User user2 = new User("Diddy", 57, MailService.gmail, MailDomain.com);

            while (true)
            {
                Console.WriteLine("\nСовершите действие:" +
                    "\n  >> debug - debug :o" +
                    "\n  >> exit - exit :O");

                string action = string.Empty;
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "debug":
                        Console.WriteLine($"\n      Пользователь {user1.Name}:");
                        user1.GetInfo();
                        reflectionHandler.PrintTypeInfo(user1);
                        reflectionHandler.PrintObjectValues(user1);

                        Console.WriteLine($"\n      Пользователь {user2.Name}:");
                        user2.GetInfo();
                        reflectionHandler.PrintTypeInfo(user2);
                        reflectionHandler.PrintObjectValues(user2);
                        break;

                    case "exit":
                        Console.WriteLine("\n\n Возращение...");
                        return;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }
    }
}

public enum MailService
{
    gmail,
    mail,
    yandex
}

public enum MailDomain
{
    ru,
    com
}