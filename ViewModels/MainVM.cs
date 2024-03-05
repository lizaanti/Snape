using Prism.Commands;
using Prism.Mvvm;
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

		public DelegateCommand StartStopCommand { get; }

		public MainVM() {
			StartStopCommand = new DelegateCommand(() => ContinueGame = !ContinueGame);
		}
    }
}
