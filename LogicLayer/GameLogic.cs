using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
	public class GameLogic
	{
		private GameBoard _gameBoard;

		private AILogic _computer;

		private BoardSize _boardSize;

		private AIDifficulty _aiDifficulty;

		private AchievementLogic _achievementLogic;

		private int _userNum;

		private Random _rand = new Random();

		private bool _aIAchievementPossible = true;


		public int Columns { get; private set; }
		public int Rows { get; private set; }
		public bool GameOver { get; private set; }
		public int PlayerTurn { private set; get; }
		public bool SinglePlayer { get; private set; }

		public GameLogic(AchievementLogic achievementLogic)
		{
			_achievementLogic = achievementLogic;
		}

		// single player mode new game
		public void NewGame(BoardSize boardSize, AIDifficulty difficulty)
		{
			// choose who goes first
			_userNum = _rand.Next(2);
			_aiDifficulty = difficulty;
			_aIAchievementPossible = true;
			NewGame(boardSize);
			SinglePlayer = true;
			_computer = new AILogic(Columns, _userNum == 0 ? 1 : 0, difficulty, _rand,_gameBoard);
			_computer = new AILogic(Columns, _userNum == 0 ? 1 : 0, difficulty, _rand, _gameBoard);
			// if the ai is starting, have it place a piece
			if (_userNum == 1)
			{
				AIPlacePiece();
			}
		}

		// multi player mode new game
		public void NewGame(BoardSize boardSize)
		{
			GameOver = false;
			PlayerTurn = 0;
			_boardSize = boardSize;
			UpdateBoardSize(boardSize);
			SinglePlayer = false;
			_gameBoard = new GameBoard(Columns, Rows);
		}

		public void UpdateAIDifficulty(AIDifficulty difficulty)
        {
			_aIAchievementPossible = false;
			if (_computer != null)
			{
				_computer.AIDifficulty = difficulty;
			}
		}
		public bool CanUndo()
		{
			return (_gameBoard.CanUndo() && !SinglePlayer && !GameOver);
		}

		public void Undo()
		{
			if (CanUndo())
			{
				_gameBoard.RemoveLastPiece();
				SwitchPlayer();
			}
			else
			{
				throw new ApplicationException("You cannot undo, you have not placed a piece");
			}
		}

		private void UpdateBoardSize(BoardSize boardSize)
		{
			if (boardSize == BoardSize.SMALL)
			{
				Columns = 6;
				Rows = 5;
			}
			else if (boardSize == BoardSize.NORMAL)
			{
				Columns = 7;
				Rows = 6;
			}
			else if (boardSize == BoardSize.LARGE)
			{
				Columns = 9;
				Rows = 7;
			}
			else
			{
				Columns = 11;
				Rows = 8;
			}
		}

		public PositionState[,] GetPositionStates()
		{
			PositionState[,] positionStates = new PositionState[Columns, Rows];
			for (int column = 0; column < positionStates.GetLength(0); column++)
			{
				for (int row = 0; row < positionStates.GetLength(1); row++)
				{
					positionStates[column, row] = _gameBoard.GetPositionState(column, row);
				}
			}
			return positionStates;
		}

		private bool IsGameOver()
		{
			return _gameBoard.CheckWinner() || _gameBoard.BoardFull();
		}

		public PositionState GameWinner()
		{
			return _gameBoard.Winner;
		}

		private void SwitchPlayer()
		{
			this.PlayerTurn = (this.PlayerTurn == 0 ? 1 : 0);
		}

		public void PlacePiece(int column)
		{
			if (!GameOver)
			{
				try
				{
					_gameBoard.AddPieceAtLowestPointInColumn(column, PlayerTurn);
					SwitchPlayer();
					GameOver = IsGameOver();
				}
				catch (ApplicationException up)
				{
					throw up;
				}
			}
			else
			{
				throw new ApplicationException("The game has already ended");
			}
			if (!GameOver && SinglePlayer)
			{
				AIPlacePiece();
			}
		}
		public void AIPlacePiece()
		{
			try
			{
				_computer.TakeTurn();
				SwitchPlayer();
				GameOver = IsGameOver();
			}
			catch (ApplicationException up)
			{
				throw up;
			}
		}

		public void UpdateAchievements()
	{
			if (GameOver && SinglePlayer)
			{
				if (GameWinner() == PositionState.EMPTY && _boardSize == BoardSize.ABSURD)
				{
					_achievementLogic.UpdateAchievement(AchievementList.ALL_FILLED);
				}
				if (((int)GameWinner()) - 1 == _userNum && _aiDifficulty == AIDifficulty.HARD)
				{
					_achievementLogic.UpdateAchievement(AchievementList.THATS_EASY);
				}
				if (((int)GameWinner()) - 1 == _userNum && _aIAchievementPossible && _gameBoard.NumberOfWinningRows() > 1)
				{
					_achievementLogic.UpdateAchievement(AchievementList.DOUBLE_TROUBLE);
				}
				if (((int)GameWinner()) - 1 == _userNum && _gameBoard.NumberOfWinningTilesInARow() >= 5)
				{
					_achievementLogic.UpdateAchievement(AchievementList.MINES_BIGGER);
				}
			}
		}
	}
}

