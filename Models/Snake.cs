using Snape.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Snape.Models
{
    internal class Snake
    {
        public Queue<CellVM> SnakeCells { get; } = new Queue<CellVM>();

        private List<List<CellVM>> _allCells;

        private CellVM _start;
        private Action _genarateFood;
        private Action _incrementScore;

        public Snake(List<List<CellVM>> allCells, CellVM start, Action genarateFood, Action incrementScore)
        {
            _start = start;
            _allCells = allCells;
            _start.CellType = CellType.Snake;
            SnakeCells.Enqueue(_start);
            _genarateFood = genarateFood;
            _incrementScore = incrementScore;
        }

        public void Restart()
        {
            foreach (var cell in SnakeCells) { 
                cell.CellType = CellType.None;
            }
            SnakeCells.Clear();
            _start.CellType = CellType.Snake;
            SnakeCells.Enqueue(_start);
        }

        public int GetScore() {
            return SnakeCells.Count;
        }

        public void Move(MoveDirection direction)
        {
            var leaderCell = SnakeCells.Last();

            int nextRow = leaderCell.Row;
            int nextColumn = leaderCell.Column;
            switch (direction)
            {
                case MoveDirection.Left:
                    nextColumn--;
                    break;
                case MoveDirection.Right:
                    nextColumn++;
                    break;
                case MoveDirection.Up:
                    nextRow--;
                    break;
                case MoveDirection.Down:
                    nextRow++;
                    break;
                default:
                    break;
            }

            try {
                var nextCell = _allCells[nextRow][nextColumn];

                switch (nextCell.CellType)
                {
                    case CellType.None:
                        nextCell.CellType = CellType.Snake;
                        SnakeCells.Dequeue().CellType = CellType.None;
                        SnakeCells.Enqueue(nextCell);
                        break;
                    case CellType.Snake:
                        break;
                    case CellType.Food:
                        nextCell.CellType = CellType.Snake;
                        SnakeCells.Enqueue(nextCell);
                        _genarateFood?.Invoke();
                        _incrementScore?.Invoke();
                        break;
                    default:
                      
                        throw _gameOverEx;
                    }
                }
            catch (ArgumentOutOfRangeException)
            {
                throw _gameOverEx;
            }
        }

        private Exception _gameOverEx => new Exception("Game Over");

        
    }
}
