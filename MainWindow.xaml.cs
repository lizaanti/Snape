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

        private MainVM model;

        public MainWindow()
        {

            InitializeComponent();
            model = new MainVM(this); ;
            DataContext = model;

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

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            model._name = Username.Text;
        }
    }
}
