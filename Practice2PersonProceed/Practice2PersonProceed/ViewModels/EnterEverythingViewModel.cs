using Practice2PersonProceed.Models;
using System;
using System.CodeDom;
using System.Threading;
using System.Windows;
using Practice2PersonProceed.Exceptions;
using Practice2PersonProceed.Exeptions;
using System.Text.RegularExpressions;

namespace Practice2PersonProceed.ViewModels
{
    internal class EnterEverythingViewModel
    {
        private RelayCommand<object> _proceedCommand;
        private InputModel _user = new InputModel();

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand = new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        #region Properties
        public string Name
        {
            get
                {
                return _user.Name;
            }
            set
            {
                _user.Name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _user.Surname;
            }
            set
            {
                _user.Surname = value;
            }
        }

        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                _user.Email = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _user.DateOfBirth;
            }
            set
            {
                _user.DateOfBirth = value;
            }
        }
        #endregion

        private void Proceed()
        {
            try
            {
                ValidateData();

                Person person = new(_user.Name, _user.Surname, _user.Email, _user.DateOfBirth);
                Thread.Sleep(2000);
                MessageBox.Show($"Name: {person.Name}\n" +
                                $"Surname: {person.Surname}\n" +
                                $"Email: {person.Email}\n" +
                                $"Date of birth: {person.DateOfBirth.ToString("dd/MM/yyyy")}\n" +
                                $"Is Adult: {person.IsAdult}\n" +
                                $"Sun Sign: {person.SunSign}\n" +
                                $"Chinese Sign: {person.ChineseSign}\n" +
                                $"Is Birthday: {person.IsBirthday}\n");
                if (person.IsBirthday) MessageBox.Show("HAPPY BIRTHDAY!");
            }
            catch(PersonIsNotBornException)
            {
                MessageBox.Show("Future date was selected.");
            }
            catch (PersonIsTooOldException)
            {
                MessageBox.Show("Too age-old date was selected.");
            }
            catch (WrongEmailFormatException)
            {
                MessageBox.Show("Wrong email format was entered.");
            }
        }
        
        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Name) && !String.IsNullOrWhiteSpace(_user.Surname) &&
                   !String.IsNullOrWhiteSpace(_user.Email) && !_user.DateOfBirth.Equals(DateTime.Today.AddDays(1));
        }

        private void ValidateData()
        {
            if(_user.DateOfBirth > DateTime.Today) throw new PersonIsNotBornException();
            if(DateTime.Today.Year - _user.DateOfBirth.Year > 135) throw new PersonIsTooOldException();
            Regex rgx = new Regex("[A-Za-z.-]+@[A-Za-z]+[.][A-Za-z]+");
            if (!rgx.IsMatch(_user.Email)) throw new WrongEmailFormatException();
        }
    }
}
