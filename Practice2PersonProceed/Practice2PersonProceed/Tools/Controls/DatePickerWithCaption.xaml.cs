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

namespace Practice2PersonProceed.Tools.Controls
{
    /// <summary>
    /// Interaction logic for DatePickerWithCaption.xaml
    /// </summary>
    public partial class DatePickerWithCaption : UserControl
    {

        public string Caption
        {
            get
            {
                return TbCaption.Text;
            }
            set
            {
                TbCaption.Text = value;
            }
        }

        public DateTime SelectedDate
        {
            get
            {
                return (DateTime)GetValue(SelectedDateProperty);
            }
            set
            {
                SetValue(SelectedDateProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedDateProperty = DependencyProperty.Register
        (
            "SelectedDate",
            typeof(DateTime),
            typeof(DatePickerWithCaption),
            new PropertyMetadata(null)
        );
        public DatePickerWithCaption()
        {
            InitializeComponent();
        }
    }
}
