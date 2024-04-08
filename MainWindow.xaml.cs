using Snape.Models;
using Snape.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
using System.Windows.Threading;
using Microsoft.Win32;

namespace Snape

{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // int score = 10;

        public MainWindow()
        {

            InitializeComponent();
            DataContext = new MainVM(this);

        }



        public void setScoreTextBox(int score)
        {
            ScoreTextBox.Text = Convert.ToString(score);
        }

        public void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            windowA windowA = new windowA();
            windowA.Show();
        }


    }
}
