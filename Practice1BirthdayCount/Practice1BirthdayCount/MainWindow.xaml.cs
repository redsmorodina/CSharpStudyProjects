using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice1BirthdayCount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BCount_OnClick(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate is null)
            {
                Clear();
                MessageBox.Show("Date wasn't selected.");
                return;
            }

            if (DatePicker.SelectedDate>DateTime.Today||
                DateTime.Today.Year-DatePicker.SelectedDate.Value.Year>135)
            {
                Clear();
                MessageBox.Show("Wrong date selected.");
                return;
            }

            Count();
        }

        private void Clear()
        {
            TbAgeResult.Text = String.Empty;
            TbWesternSignResult.Text = String.Empty;
            TbChineseSignResult.Text = String.Empty;
        }

        private void Count()
        {
            var date = DatePicker.SelectedDate.Value;
            var age = DateTime.Today.Year - date.Year;
            if (age > 0)
            {
                if (date.Month > DateTime.Today.Month) age--;
                else if (date.Month == DateTime.Today.Month &&
                         date.Day > DateTime.Today.Day) age--;
            }

            var westernSign = "";
            switch (date.Month)
            {
                case 1:
                    if (date.Day < 20) westernSign = "Capricorn";
                    else westernSign = "Aquarius";
                    break;
                case 2:
                    if (date.Day < 19) westernSign = "Aquarius";
                    else westernSign = "Pisces";
                    break;
                case 3:
                    if (date.Day < 21) westernSign = "Pisces";
                    else westernSign = "Aries";
                    break;
                case 4:
                    if (date.Day < 20) westernSign = "Aries";
                    else westernSign = "Taurus";
                    break;
                case 5:
                    if (date.Day < 21) westernSign = "Taurus";
                    else westernSign = "Gemini";
                    break;
                case 6:
                    if (date.Day < 22) westernSign = "Gemini";
                    else westernSign = "Cancer";
                    break;
                case 7:
                    if (date.Day < 23) westernSign = "Cancer";
                    else westernSign = "Leo";
                    break;
                case 8:
                    if (date.Day < 23) westernSign = "Leo";
                    else westernSign = "Virgo";
                    break;
                case 9:
                    if (date.Day < 23) westernSign = "Virgo";
                    else westernSign = "Libra";
                    break;
                case 10:
                    if (date.Day < 24) westernSign = "Libra";
                    else westernSign = "Scorpio";
                    break;
                case 11:
                    if (date.Day < 23) westernSign = "Scorpio";
                    else westernSign = "Sagittarius";
                    break;
                case 12:
                    if (date.Day < 22) westernSign = "Sagittarius";
                    else westernSign = "Capricorn";
                    break;
            }

            var chineseSign = "";
            switch (date.Year % 12)
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


            TbAgeResult.Text = age.ToString();
            TbWesternSignResult.Text = westernSign;
            TbChineseSignResult.Text = chineseSign;
        }
    }
}
