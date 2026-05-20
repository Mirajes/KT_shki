using System;

namespace KT_shki
{
    public class User
    {
        public string Name => _name;
        public int Age => _age;
        public string Email => _name + _age + "@" + _mail + _mailDomain;

        private string _name;
        private int _age;
        private string _mail;
        private string _mailDomain;

        public User(string name, int age, string mail, string mailDomain)
        {
            _name = name;
            _age = age;
            _mail = mail;
            _mailDomain = mailDomain;
        }

        public User(string name, int age, MailService mail, MailDomain mailDomain)
        {
            _name = name;
            _age = age;
            _mail = mail.ToString();
            _mailDomain = "." + mailDomain.ToString();
        }

        public int GetYearOfBirth()
        {
            return DateTime.Today.Year - _age;
        }

        public void GetInfo()
        {
            Console.WriteLine("Данные о пользователе:" +
                $"\n Имя - {_name}" +
                $"\n Год рождения - {GetYearOfBirth()} ({_age})" +
                $"\n Эл.Почта - {Email}");
        }
    }
}



// perevod Enum v Array => Enum.GetValues(typeof(Countries)).Cast<Countries>()
