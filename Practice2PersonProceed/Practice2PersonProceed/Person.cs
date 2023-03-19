using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice2PersonProceed
{
    internal class Person
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool IsAdult { get; private set; }
        public string SunSign { get; private set; }
        public string ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }

        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;

            CountOthers();
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;

            CountOthers();
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;

            CountOthers();
        }

        private async Task CountOthers()
        {
            var isAdultTask = CountIfIsAdult();
            var sunSignTask = CountSunSign();
            var sunChineseTask = CountChineseSign();
            var isBirthdayTask = CountIfIsBirthday();

            IsAdult = await isAdultTask;
            SunSign = await sunSignTask;
            ChineseSign = await sunChineseTask;
            IsBirthday = await isBirthdayTask;
        }

        private Task<bool> CountIfIsBirthday()
        {
            return Task.Run(() =>(DateOfBirth.Day == DateTime.Today.Day && DateOfBirth.Month == DateTime.Today.Month));
        }

        private Task<bool> CountIfIsAdult()
        {
            var dateToday = DateTime.Today;
            var age = dateToday.Year - DateOfBirth.Year;
            if (age > 0)
            {
                if (DateOfBirth.Month > dateToday.Month) age--;
                else if (DateOfBirth.Month == dateToday.Month &&
                         DateOfBirth.Day > dateToday.Day) age--;
            };
            return Task.Run(() => (age >= 18));
        }

        private Task<string> CountChineseSign()
        {
            var chineseSign = "";
            switch (DateOfBirth.Year % 12)
            {
                case 0:
                    chineseSign = "Monkey";
                    break;
                case 1:
                    chineseSign = "Rooster";
                    break;
                case 2:
                    chineseSign = "Dog";
                    break;
                case 3:
                    chineseSign = "Pig";
                    break;
                case 4:
                    chineseSign = "Rat";
                    break;
                case 5:
                    chineseSign = "Ox";
                    break;
                case 6:
                    chineseSign = "Tiger";
                    break;
                case 7:
                    chineseSign = "Rabbit";
                    break;
                case 8:
                    chineseSign = "Dragon";
                    break;
                case 9:
                    chineseSign = "Snake";
                    break;
                case 10:
                    chineseSign = "Horse";
                    break;
                case 11:
                    chineseSign = "Goat";
                    break;
            }
            return Task.Run(() => chineseSign);
        }

        private Task<string> CountSunSign()
        {
            var westernSign = "";
            switch (DateOfBirth.Month)
            {
                case 1:
                    if (DateOfBirth.Day < 20) westernSign = "Capricorn";
                    else westernSign = "Aquarius";
                    break;
                case 2:
                    if (DateOfBirth.Day < 19) westernSign = "Aquarius";
                    else westernSign = "Pisces";
                    break;
                case 3:
                    if (DateOfBirth.Day < 21) westernSign = "Pisces";
                    else westernSign = "Aries";
                    break;
                case 4:
                    if (DateOfBirth.Day < 20) westernSign = "Aries";
                    else westernSign = "Taurus";
                    break;
                case 5:
                    if (DateOfBirth.Day < 21) westernSign = "Taurus";
                    else westernSign = "Gemini";
                    break;
                case 6:
                    if (DateOfBirth.Day < 22) westernSign = "Gemini";
                    else westernSign = "Cancer";
                    break;
                case 7:
                    if (DateOfBirth.Day < 23) westernSign = "Cancer";
                    else westernSign = "Leo";
                    break;
                case 8:
                    if (DateOfBirth.Day < 23) westernSign = "Leo";
                    else westernSign = "Virgo";
                    break;
                case 9:
                    if (DateOfBirth.Day < 23) westernSign = "Virgo";
                    else westernSign = "Libra";
                    break;
                case 10:
                    if (DateOfBirth.Day < 24) westernSign = "Libra";
                    else westernSign = "Scorpio";
                    break;
                case 11:
                    if (DateOfBirth.Day < 23) westernSign = "Scorpio";
                    else westernSign = "Sagittarius";
                    break;
                case 12:
                    if (DateOfBirth.Day < 22) westernSign = "Sagittarius";
                    else westernSign = "Capricorn";
                    break;
            }

            return Task.Run(() => westernSign);
        }
    }
}
