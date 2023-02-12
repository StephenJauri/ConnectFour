using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayer
{
	public class AILogic
	{
		private int _columns;
		private PositionState _aiPlayerState;
		private PositionState _otherPlayerState;
		private int _aiPlayerTurn;
		public AIDifficulty AIDifficulty { get; set; }
		private GameBoard _gameBoard;


		private Random _rand;

		public AILogic(int boardSize, int playerTurn, AIDifficulty difficulty, Random rand, GameBoard gameBoard)
		{
			_rand = rand;
			_gameBoard = gameBoard;
			_columns = boardSize;
			_aiPlayerTurn = playerTurn;

			if (_aiPlayerTurn == 0)
			{
				_aiPlayerState = PositionState.PLAYER_ONE;
				_otherPlayerState = PositionState.PLAYER_TWO;
			}
			else
			{
				_aiPlayerState = PositionState.PLAYER_TWO;
				_otherPlayerState = PositionState.PLAYER_ONE;
			}
			AIDifficulty = difficulty;
		}

		public void TakeTurn()
		{
			int column;
			if (AIDifficulty == AIDifficulty.EASY)
			{
				column = FindPlacement();
			}
			else if (AIDifficulty == AIDifficulty.NORMAL)
			{
				column = FindBestPlacement();
			}
			else
            {
				column = FindBestPlacementPredictive();
            }
			_gameBoard.AddPieceAtLowestPointInColumn(column, _aiPlayerTurn);
		}

		private int FindPlacement()
		{
			if (_gameBoard.BoardFull())
			{
				throw new ApplicationException("The board is full");
			}

			int placementColumn;
			// if i can win then win
			placementColumn = GetWinningColumnForUser(_aiPlayerState);
			if (placementColumn != -1)
			{
				return placementColumn;
			}

			// if the other player can win block it
			placementColumn = GetWinningColumnForUser(_otherPlayerState);
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			// extend longest line
			placementColumn = ChooseRandomFromOptions(GetSafeColumnsFromOptions(PlacingHereGivesPlayerXTilesInARow(0, _columns, 2, _aiPlayerState)));
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			// random spot
			placementColumn = ChooseRandomFromOptions(GetOpenColumnsInRange(0, _columns));
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			throw new ApplicationException("There are no open columns");
		}

		private int FindBestPlacement()
		{
			if (_gameBoard.BoardFull())
			{
				throw new ApplicationException("The board is full");
			}

			int placementColumn;
			// get middle range
			int columnMiddleLeft = (int)(_columns / 2.0 - _columns / 3.0);
			int columnMiddleRight = (int)(_columns / 2.0 + _columns / 3.0) + 1;
			// if i can win then win
			placementColumn = GetWinningColumnForUser(_aiPlayerState);
			if (placementColumn != -1)
			{
				return placementColumn;
			}

			// if the other player can win block it
			placementColumn = GetWinningColumnForUser(_otherPlayerState);
			if (placementColumn != -1)
			{
				return placementColumn;
			}

			// all arrays are checked for safety as a middle step
			// block players progress anywhere
			placementColumn = ChooseRandomFromOptions(GetSafeColumnsFromOptions(PlacingHereGivesPlayerXTilesInARow(0,_columns,3,_otherPlayerState)));
			if (placementColumn != -1)
			{
				return placementColumn;
			}

			// extend longest line find minus edges
			placementColumn = ChooseRandomFromOptions(GetSafeColumnsFromOptions(PlacingHereGivesPlayerXTilesInARow(1, _columns - 1, 2, _aiPlayerState)));
			if (placementColumn != -1)
			{
				return placementColumn;
			}


			// no good spot was found attempt to choose a spot towards the center

			// safe spot in middle of board?
			placementColumn = ChooseRandomFromOptions(GetSafeColumnsFromOptions(GetOpenColumnsInRange(columnMiddleLeft, columnMiddleRight)));
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			// safe spot anywhere on board?
			placementColumn = ChooseRandomFromOptions(GetSafeColumnsFromOptions(GetOpenColumnsInRange(0, _columns)));
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			// random spot cause it doesn't matter
			placementColumn = ChooseRandomFromOptions(GetOpenColumnsInRange(0, _columns));
			if (placementColumn != -1)
			{
				return placementColumn;
			}
			throw new ApplicationException("There are no open columns");
		}
		
		private int FindBestPlacementPredictive()
        {
			return PredicteBestSpot(4);
		}

		private int PredicteBestSpot(int lookAheadTimes)
		{
			int leastLosses = int.MaxValue;
			int mostWins = int.MinValue;
			int[] potentialColumns = GetOpenColumnsInRange(0, _columns);
			PotentialWinLossTracker[] winLossRatesForEachColumn = new PotentialWinLossTracker[potentialColumns.Length];
			for (int potentialTrackerNum = 0; potentialTrackerNum < winLossRatesForEachColumn.Length; potentialTrackerNum++)
            {
				winLossRatesForEachColumn[potentialTrackerNum] = new PotentialWinLossTracker();
            }

			List<int> bestColumns = new List<int>();

			for (int currentPotentialColumnIndex = 0; currentPotentialColumnIndex < potentialColumns.Length; currentPotentialColumnIndex++)
            {
				FindWinsAndLossesForPlacement(lookAheadTimes, winLossRatesForEachColumn[currentPotentialColumnIndex], potentialColumns[currentPotentialColumnIndex],_aiPlayerTurn);
			}

            for (int currentPotentialColumnIndex = 0; currentPotentialColumnIndex < potentialColumns.Length; currentPotentialColumnIndex++)
            {
                if (winLossRatesForEachColumn[currentPotentialColumnIndex].LoseCount < leastLosses)
                {
                    leastLosses = winLossRatesForEachColumn[currentPotentialColumnIndex].LoseCount;
                    mostWins = winLossRatesForEachColumn[currentPotentialColumnIndex].WinCount;
                    bestColumns.Clear();
                    bestColumns.Add(potentialColumns[currentPotentialColumnIndex]);
                }
                else if (winLossRatesForEachColumn[currentPotentialColumnIndex].LoseCount == leastLosses)
                {
                    if (winLossRatesForEachColumn[currentPotentialColumnIndex].WinCount > mostWins)
                    {
                        mostWins = winLossRatesForEachColumn[currentPotentialColumnIndex].WinCount;
                        bestColumns.Clear();
                        bestColumns.Add(potentialColumns[currentPotentialColumnIndex]);
                    }
                    else if (winLossRatesForEachColumn[currentPotentialColumnIndex].WinCount == mostWins)
                    {
                        bestColumns.Add(potentialColumns[currentPotentialColumnIndex]);
                    }
                }
            }


			if (bestColumns.Count / 2 > _columns / 3)
            {
				bestColumns.Remove(0);
				bestColumns.Remove(_columns - 1);
            }

            return ChooseRandomFromOptions(bestColumns.ToArray());
		}

		private void FindWinsAndLossesForPlacement(int lookAheadTimesLeft, PotentialWinLossTracker currentColumnWinLossTracker, int placementColumn, int currentPlayerTurn)
        {
			_gameBoard.AddPieceAtLowestPointInColumn(placementColumn, currentPlayerTurn);
			if (_gameBoard.CheckWinner())
			{
				if (_gameBoard.Winner == _aiPlayerState)
				{
					currentColumnWinLossTracker.WinCount += (int)Math.Pow(lookAheadTimesLeft, _columns - 1);
				}
				if (_gameBoard.Winner == _otherPlayerState)
				{
					currentColumnWinLossTracker.LoseCount += (int)Math.Pow(lookAheadTimesLeft, _columns - 1);
				}
			}
			else
			{

				int[] potentialColumns = GetOpenColumnsInRange(0, _columns);

				if (lookAheadTimesLeft != 0)
				{
					foreach (int potentialColumn in potentialColumns)
					{
						FindWinsAndLossesForPlacement(lookAheadTimesLeft-1, currentColumnWinLossTracker, potentialColumn, currentPlayerTurn == 0 ? 1 : 0);
					}
				}
			}
			_gameBoard.RemoveLastPiece();
			return;
		}

		private bool SafeToPlace(int column)
		{
			int row = _gameBoard.GetNextOpenSpotInColumn(column);
			if (row > 0)
			{
				if (_gameBoard.HasThreeConnectingSamePieces(column, row - 1, _otherPlayerState))
				{
					return false;
				}
			}
			return true;
		}

		private int GetWinningColumnForUser(PositionState playerState)
		{
			int[] placeableColumns = GetOpenColumnsInRange(0, _columns);
			int row;
			for (int placeableColumn = 0; placeableColumn < placeableColumns.Length; placeableColumn++)
			{
				row = _gameBoard.GetNextOpenSpotInColumn(placeableColumns[placeableColumn]);
				if (row != -1)
				{
					if (_gameBoard.HasThreeConnectingSamePieces(placeableColumns[placeableColumn], row, playerState))
					{
						return placeableColumns[placeableColumn];
					}
				}
			}
			return -1;
		}

		private int[] GetOpenColumnsInRange(int min, int max)
		{

			List<int> openColumns = new List<int>();
			for (int column = min; column < max; column++)
			{
				if (_gameBoard.GetNextOpenSpotInColumn(column) != -1)
				{
					openColumns.Add(column);
				}
			}
			return openColumns.ToArray();
		}

		private int[] GetSafeColumnsFromOptions(int[] spots)
		{
			List<int> safeColumns = new List<int>();
			for (int openColumn = 0; openColumn < spots.Length; openColumn++)
			{
				if (SafeToPlace(spots[openColumn]))
				{
					safeColumns.Add(spots[openColumn]);
				}
			}
			return safeColumns.ToArray();
		}

		private int[] PlacingHereGivesPlayerXTilesInARow(int min, int max, int numberWanted, PositionState playerState)
		{
			int[] placeableColumns = GetOpenColumnsInRange(min, max);
			int row;
			List<int> columnsLongerThanX = new List<int>();
			for (int placeableColumn = 0; placeableColumn < placeableColumns.Length; placeableColumn++)
			{
				row = _gameBoard.GetNextOpenSpotInColumn(placeableColumns[placeableColumn]);
				// if this is not out of bounds
				if (row != -1)
				{
					if (_gameBoard.LongestInARowConnected(placeableColumns[placeableColumn], row, playerState) >= numberWanted)
					{
						columnsLongerThanX.Add(placeableColumns[placeableColumn]);
					}
				}
			}
			return columnsLongerThanX.ToArray();
		}

		private int ChooseRandomFromOptions(int[] spots)
		{
			if (spots.Length > 0)
			{
				return spots[_rand.Next(spots.Length)];
			}
			else
			{
				return -1;
			}
		}
	}
}
