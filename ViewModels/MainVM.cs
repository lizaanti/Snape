using Prism.Commands;
using Prism.Mvvm;
using Snape.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snape.ViewModels
{
    internal class MainVM : BindableBase
    {
		private bool _continueGame = false; //флаг, отвечающий за стоп или продолжение команды

		public bool  ContinueGame
		{
			get => _continueGame; 
			set 
			{ 
				_continueGame = value;
				RaisePropertyChanged(nameof(ContinueGame)); //метод для уведомления системы об изменении свойства

				if (_continueGame)
				{
					SnakeGo();
				}
			}
		}
        private double _cellD = 50;
        public double CellD
        {
            get => _cellD;
            set
            {
                _cellD = value;
                RaisePropertyChanged(nameof(CellD));
            }
        }

        public List<List<CellVM>> AllCells { get; } = new List<List<CellVM>>(); //хранение данных для массива матрицы ячеек

		public DelegateCommand StartStopCommand { get; }
		private MoveDirection _currentMoveDirection = MoveDirection.Right; //флаг текущего направления. при старте игры змейка движется вправо

		private int _rowCount = 10;
		private int _columnCount = 10;
		private const int SPEED = 400;
		private int _speed = 0;
		private int score;
        //private int result;
        private TextBox ScoreTextBox;
        private Snake _snake;
		private MainWindow _mainVM;
        private CellVM _lastFood;
        public MainVM(MainWindow mainVM) {
			_speed = SPEED;
			_mainVM = mainVM;
			StartStopCommand = new DelegateCommand(() => ContinueGame = !ContinueGame);

			for (int row = 0; row <= _rowCount; row++)
			{
				var rowList = new List<CellVM>();
				for (int column = 0; column <= _columnCount; column++)
				{
                    var newCell = new CellVM(row, column, Models.CellType.None);
                    rowList.Add(newCell);
                }
				AllCells.Add(rowList);
			}

			_snake = new Snake(AllCells, AllCells[_rowCount / 2][_columnCount/2], CreateFood, ScoreCount);
			CreateFood();
			_mainVM.KeyDown += UserKeyDown;

        }

		private async Task SnakeGo()
		{
			while (ContinueGame)
			{
				await Task.Delay(_speed);

				try
				{
					_snake.Move(_currentMoveDirection);
				}

				catch (Exception ex)
				{
					ContinueGame = false;
					MessageBox.Show(ex.Message);
					_speed = SPEED;
				}
			}
		}

		private void UserKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.A:
					if(_currentMoveDirection != MoveDirection.Right)
						_currentMoveDirection = MoveDirection.Left; 
					break;
                case Key.D:
                    if (_currentMoveDirection != MoveDirection.Left)
                        _currentMoveDirection = MoveDirection.Right;
                    break;
                case Key.W:
                    if (_currentMoveDirection != MoveDirection.Down)
                        _currentMoveDirection = MoveDirection.Up;
                    break;
                case Key.S:
                    if (_currentMoveDirection != MoveDirection.Up)
                        _currentMoveDirection = MoveDirection.Down;
                    break;
                default:
					break;
			}
		}

		private void CreateFood()
		{
			var random = new Random();
			int row = random.Next(_rowCount);
            int column = random.Next(_columnCount);
			_lastFood = AllCells[row][column];
			//if (_snake.SnakeCells.Contains(_lastFood))
			//{
               
            //}
                //CreateFood();
            _lastFood.CellType = CellType.Food;
            _speed = (int)(_speed * 0.95);

                //_snake.Restart();
                //_lastFood.CellType = CellType.None;
                //}

            //CreateFood();
        }

		private void ScoreCount() {
            score += 1;
            _mainVM.setScoreTextBox(score);
        }

        public class User
        {
            public string Name { get; set; }
            public int Score { get; set; }

            public User(string name, int score)
            {
                Name = name;
                Score = score;
            }
        }

        List<User> users = new List<User>
		{
			new User("Alice", 100),
			new User("Bob", 150),
			new User("Charlie", 120)
		};
    }
}
