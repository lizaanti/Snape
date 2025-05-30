﻿using Prism.Mvvm;
using Snape.Models;

namespace Snape.ViewModels
{
    internal class CellVM : BindableBase //координаты положения
    {
        public int Row { get; }
        public int Column { get; }

        private CellType _cellType = CellType.None;

        public CellType CellType{
            get => _cellType; 
            set
            {
                _cellType = value;
                RaisePropertyChanged(nameof(CellType));
            }
        }

        public CellVM(int row, int column, CellType cellType)
        {
            Row = row;
            Column = column;
            CellType = cellType;
        }

        public CellVM(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
