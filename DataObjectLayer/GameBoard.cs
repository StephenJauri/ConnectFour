using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public class GameBoard
	{
		private List<Move> _moves = new List<Move>();
		public PositionState Winner { get; private set;  } = PositionState.EMPTY;

		private PositionState[,] _positionStates;

		public GameBoard(int columns, int rows)
		{
			_positionStates = new PositionState[columns, rows];
			ResetBoard();
		}

		//private GameBoard(GameBoard other)
  //      {
		//	this._moves = other._moves;
		//	this.Winner = other.Winner;
		//	this._positionStates = new PositionState[other._positionStates.GetLength(0), other._positionStates.GetLength(1)];
  //          for (int column = 0; column < _positionStates.GetLength(0);column++)
  //          {
		//		for (int row = 0; row < _positionStates.GetLength(1);row++)
  //              {
		//			this._positionStates[column, row] = other._positionStates[column, row];
  //              }
  //          }
  //      }

		//public GameBoard Replicate()
  //      {
		//	return new GameBoard(this);
  //      }
		public void ResetBoard()
		{
			for (int column = 0; column < _positionStates.GetLength(0); column++)
			{
				for (int row = 0; row < _positionStates.GetLength(1); row++)
				{
					_positionStates[column, row] = PositionState.EMPTY;
				}
			}
		}

		public void AddPieceAtLowestPointInColumn(int column, int player)
		{
			int row = GetNextOpenSpotInColumn(column);
			if (row == -1)
			{
				throw new ApplicationException("Cannot place piece in full column");
			}
			else
			{
				AddPiece(column, row, player);
				_moves.Add(new Move(column, row));
			}
		}

		public void RemoveLastPiece()
		{
			if (CanUndo())
			{
				_positionStates[_moves[_moves.Count - 1].Column, _moves[_moves.Count - 1].Row] = PositionState.EMPTY;
				_moves.RemoveAt(_moves.Count - 1);
			}
			else
			{
				throw new ApplicationException("Could not remove last piece, no pieces have been placed.");
			}
		}

		private void AddPiece(int column, int row, int player)
		{
			if (player == 0)
			{
				_positionStates[column, row] = PositionState.PLAYER_ONE;
			}
			else
			{
				_positionStates[column, row] = PositionState.PLAYER_TWO;
			}
		}

		public bool CanUndo()
		{
			return _moves.Count > 0;
		}
		public int GetNextOpenSpotInColumn(int column)
		{
			for (int row = _positionStates.GetLength(1) - 1; row >= 0; row--)
			{
				if (_positionStates[column, row] == PositionState.EMPTY)
				{
					return row;
				}
			}
			return -1;
		}

		public PositionState GetPositionState(int column, int row)
		{
			return _positionStates[column, row];
		}

		public bool BoardFull()
		{
			int fullRows = 0;
			for (int column = 0; column < _positionStates.GetLength(0); column++)
			{
				if (_positionStates[column, 0] != PositionState.EMPTY)
				{
					fullRows++;
				}
			}
			return fullRows == _positionStates.GetLength(0);
		}

		public bool CheckWinner()
		{
			Winner = PositionState.EMPTY;
			if (NumberOfWinningRows() > 0)
			{
				Winner = GetPositionState(_moves[_moves.Count - 1].Column, _moves[_moves.Count - 1].Row);
				return true;
			}
			return false;
		}

		public int NumberOfWinningRows()
		{
			int _lastPlacedColumn = _moves[_moves.Count - 1].Column;
			int _lastPlacedRow = _moves[_moves.Count - 1].Row;
			PositionState tilePositionState = GetPositionState(_lastPlacedColumn, _lastPlacedRow);
			int numberOfDirections = 0;
			if (CountDiagonalDown(_lastPlacedColumn, _lastPlacedRow, tilePositionState) >= 4)
			{
				numberOfDirections++;
			}
			if (CountDiagonalUp(_lastPlacedColumn, _lastPlacedRow, tilePositionState) >= 4)
			{
				numberOfDirections++;
			}
			if (CountHorizontal(_lastPlacedColumn, _lastPlacedRow, tilePositionState) >= 4)
			{
				numberOfDirections++;
			}
			if (CountVertical(_lastPlacedColumn, _lastPlacedRow, tilePositionState) >= 4)
			{
				numberOfDirections++;
			}
			return numberOfDirections;
		}

		public int NumberOfWinningTilesInARow()
		{
			int _lastPlacedColumn = _moves[_moves.Count - 1].Column;
			int _lastPlacedRow = _moves[_moves.Count - 1].Row;
			PositionState tilePositionState = GetPositionState(_lastPlacedColumn, _lastPlacedRow);
			return Math.Max(Math.Max(CountVertical(_lastPlacedColumn, _lastPlacedRow, tilePositionState), CountHorizontal(_lastPlacedColumn, _lastPlacedRow, tilePositionState)),
				Math.Max(CountDiagonalDown(_lastPlacedColumn, _lastPlacedRow, tilePositionState), CountDiagonalUp(_lastPlacedColumn, _lastPlacedRow, tilePositionState)));

		}

		public bool HasThreeConnectingSamePieces(int column, int row, PositionState tilePositionState)
		{
			return (LongestInARowConnected(column, row, tilePositionState) >= 4);
		}

		public int LongestInARowConnected(int column, int row, PositionState tilePositionState)
		{
			return Math.Max(Math.Max(CountHorizontal(column, row, tilePositionState), CountVertical(column, row, tilePositionState)), Math.Max(CountDiagonalDown(column, row, tilePositionState), CountDiagonalUp(column, row, tilePositionState)));
		}

		public int CountHorizontal(int column, int row, PositionState tilePositionState)
		{
			int inARowCount = 1;
			// check left
			for (int currentColumn = column - 1; currentColumn >= 0; currentColumn--)
			{
				if (tilePositionState == GetPositionState(currentColumn, row))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			// check right
			for (int currentColumn = column + 1; currentColumn < _positionStates.GetLength(0); currentColumn++)
			{
				if (tilePositionState == GetPositionState(currentColumn, row))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			return inARowCount;
		}
		public int CountVertical(int column, int row, PositionState tilePositionState)
		{
			int inARowCount = 1;
			// check up
			for (int currentRow = row - 1; currentRow >= 0; currentRow--)
			{
				if (tilePositionState == GetPositionState(column, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			// check down
			for (int currentRow = row + 1; currentRow < _positionStates.GetLength(1); currentRow++)
			{
				if (tilePositionState == GetPositionState(column, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			return inARowCount;
		}

		public int CountDiagonalDown(int column, int row, PositionState tilePositionState)
		{
			int inARowCount = 1;
			// check up left
			for (int currentRow = row - 1, currentColumn = column - 1; currentRow >= 0 && currentColumn >= 0; currentRow--, currentColumn--)
			{
				if (tilePositionState == GetPositionState(currentColumn, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			// check down right
			for (int currentRow = row + 1, currentColumn = column + 1; currentRow < _positionStates.GetLength(1) && currentColumn < _positionStates.GetLength(0); currentRow++, currentColumn++)
			{
				if (tilePositionState == GetPositionState(currentColumn, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			return inARowCount;
		}
		public int CountDiagonalUp(int column, int row, PositionState tilePositionState)
		{
			int inARowCount = 1;
			// check down left
			for (int currentRow = row + 1, currentColumn = column - 1; currentRow < _positionStates.GetLength(1) && currentColumn >= 0; currentRow++, currentColumn--)
			{
				if (tilePositionState == GetPositionState(currentColumn, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			// check up right
			for (int currentRow = row - 1, currentColumn = column + 1; currentRow >= 0 && currentColumn < _positionStates.GetLength(0); currentRow--, currentColumn++)
			{
				if (tilePositionState == GetPositionState(currentColumn, currentRow))
				{
					inARowCount++;
				}
				else
				{
					break;
				}
			}
			return inARowCount;
		}

	}

}
