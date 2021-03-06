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

namespace MyWpfControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>

    public partial class LoginUserControl : UserControl
    {
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(String), typeof(LoginUserControl));
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(String), typeof(LoginUserControl));

        public string UserName
        {
            get
            {
                return (string)GetValue(UserNameProperty);
            }
        }
        public string Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
            }
        }

        public LoginUserControl()
        {
            InitializeComponent();
        }
    }
}