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
using System.Windows.Shapes;


namespace Snape
{
    /// <summary>
    /// Логика взаимодействия для windowA.xaml
    /// </summary>
    public partial class windowA : Window
    {
        public windowA()
        {
            InitializeComponent();
            DGrid.ItemsSource = SnakeAntipovaEntities.GetContext().Users.OrderByDescending(u=>u.Score).ToList();
        }
    }
}
