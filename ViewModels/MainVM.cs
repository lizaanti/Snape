using Prism.Commands;
using Prism.Mvvm;
using Snape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snape.ViewModels
{
    internal class MainVM : BindableBase
    {
		private bool _continueGame; //флаг, отвечающий за стоп или продолжение команды

		public bool  ContinueGame
		{
			get => _continueGame; 
			private set 
			{ 
				_continueGame = value;
				RaisePropertyChanged(nameof(ContinueGame)); //метод для уведомления системы об изменении свойства
			}
		}

		public List<List<CellVM>> AllCells { get; } = new List<List<CellVM>>(); //хранение данных для массива матрицы ячеек

		public DelegateCommand StartStopCommand { get; }
		private MoveDirection _currentMoveDirection = MoveDirection.Right; //флаг текущего направления. при старте игры змейка движется вправо

		private int _rowCount = 10;
		private int _columnCount = 10;
		public MainVM() {
			StartStopCommand = new DelegateCommand(() => ContinueGame = !ContinueGame);

			for (int row = 0; row < _rowCount; row++)
			{
				var rowList = new List<CellVM>();
				for (int column = 0; column < _columnCount; column++)
				{
					var cell = new CellVM(row, column);
					rowList.Add(cell);	
				}
				AllCells.Add(rowList);
			}
		}
    }
}
