using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataObjects;
using System.Resources;
using System.Reflection;
using LogicLayer;

namespace PresentationLayer
{
	public partial class frmGame : Form
	{
		private ResourceManager _rm;
		private AchievementLogic _achievementLogic;

		private Image _emptyState;
		private Image _playerOneStateImage;
		private Image _playerTwoStateImage;
		private Image _playerOneHighlightStateImage;
		private Image _playerTwoHighlightStateImage;


		private String _firstPlayerColor;
		private String _secondPlayerColor;

		private const int _bottomMargin = 150;
		private GameOptions _gameOptions;
		private int _rows;
		private int _columns;
		private Point _boardPosition = new Point(160, 50);
		private PositionState[,] _positionStates;
		private GameLogic _game;
		private int _highlightedColumn = -1;

		private int TileWidth { set; get; } = 80;
		public frmGame(GameOptions gameOptions,AchievementLogic achievementLogic ,ResourceManager rm)
		{
			InitializeComponent();
			this._gameOptions = gameOptions;
			_rm = rm;
			_achievementLogic = achievementLogic;
			_game = new GameLogic(_achievementLogic);
			NewGame();
			UpdateDisplay();
		}

		private void UpdateTheme()
		{
			if (_gameOptions.Theme.Name == "dark")
			{
				try
				{
					_achievementLogic.UpdateAchievement(AchievementList.LIGHTS_OUT);
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
				}
			}
			this.BackColor = _gameOptions.Theme.BackgroundColor;
			this.btnNewGame.BackColor = _gameOptions.Theme.ButtonColor;
			this.btnQuitGame.BackColor = _gameOptions.Theme.ButtonColor;
			this.btnNewGame.ForeColor = _gameOptions.Theme.ButtonTextColor;
			this.btnQuitGame.ForeColor = _gameOptions.Theme.ButtonTextColor;
			this.btnOptions.BackColor = _gameOptions.Theme.ButtonColor;
			this.btnOptions.ForeColor = _gameOptions.Theme.ButtonTextColor;

			_firstPlayerColor = _gameOptions.Theme.PlayerOneColorText;
			_secondPlayerColor = _gameOptions.Theme.PlayerTwoColorText;
			_emptyState = (Image)_rm.GetObject(_gameOptions.Theme.EmptyStateFileName);
			_playerOneHighlightStateImage = (Image)_rm.GetObject(_gameOptions.Theme.PlayerOneHighlightStateFileName);
			_playerTwoHighlightStateImage = (Image)_rm.GetObject(_gameOptions.Theme.PlayerTwoHighlightStateFileName);
			_playerOneStateImage = (Image)_rm.GetObject(_gameOptions.Theme.PlayerOneFilledStateFileName);
			_playerTwoStateImage = (Image)_rm.GetObject(_gameOptions.Theme.PlayerTwoFilledStateFileName);
			RedrawBoard();
		}
		private void UpdateBoardSize()
		{
			_columns = _game.Columns;
			_rows = _game.Rows;
		}
		private void PositionButtons()
		{
			btnNewGame.Location = new Point(this.Width / 2 - btnNewGame.Width / 2 - 200, this.Height - 75 - btnNewGame.Height);
			btnQuitGame.Location = new Point(this.Width / 2 - btnQuitGame.Width / 2 + 0, this.Height - 75 - btnQuitGame.Height);
			btnOptions.Location = new Point(this.Width / 2 - btnQuitGame.Width / 2 + +200, this.Height - 75 - btnOptions.Height);
		}

		public void UpdateDisplay()
		{
			_positionStates = _game.GetPositionStates();
			RedrawBoard();
			// update view button
			if (_game.CanUndo())
			{
				pbUndo.Visible = true;
			}
			else
			{
				pbUndo.Visible = false;
			}
		}

		private void RedrawBoard()
		{
			if (_connectFourPictureBoxSegments != null)
			{
				for (int column = 0; column < this._connectFourPictureBoxSegments.GetLength(0); column++)
				{
					RedrawColumn(column);
				}
			}
		}

		private void RedrawColumn(int column)
		{
			for (int row = 0; row < this._connectFourPictureBoxSegments.GetLength(1); row++)
			{
				if (_positionStates[column, row] == PositionState.EMPTY)
				{
					if (column != _highlightedColumn)
					{
						this._connectFourPictureBoxSegments[column, row].Image = _emptyState;
					}
					else
					{
						if (_game.PlayerTurn == 0)
						{
							this._connectFourPictureBoxSegments[column, row].Image = _playerOneHighlightStateImage;
						}
						else
						{
							this._connectFourPictureBoxSegments[column, row].Image = _playerTwoHighlightStateImage;
						}
					}
				}
				else if (_positionStates[column, row] == PositionState.PLAYER_ONE)
				{
					this._connectFourPictureBoxSegments[column, row].Image = _playerOneStateImage;
				}
				else
				{
					this._connectFourPictureBoxSegments[column, row].Image = _playerTwoStateImage;
				}
			}
		}

		private void frmGame_Load(object sender, EventArgs e)
		{
			this.Width = _boardPosition.X * 2 + TileWidth * _connectFourPictureBoxSegments.GetLength(0);
			this.Height = _boardPosition.Y * 2 + TileWidth * _connectFourPictureBoxSegments.GetLength(1) + _bottomMargin;
			PositionButtons();
		}

		private void connectFourPictureBoxSegment_MouseEnter(object sender, EventArgs e)
		{
			if (!_game.GameOver)
			{
				_highlightedColumn = ((ConnectFourPictureBoxSegment)sender).Column;
				RedrawColumn(_highlightedColumn);
			}
		}
		private void connectFourPictureBoxSegment_MouseExit(object sender, EventArgs e)
		{
			if (!_game.GameOver)
			{
				_highlightedColumn = -1;
				RedrawColumn(((ConnectFourPictureBoxSegment)sender).Column);
			}
		}

		private void connectFourPictureBoxSegment_Click(object sender, EventArgs e)
		{
			if (!_game.GameOver)
			{
				try
				{
					_game.PlacePiece(((ConnectFourPictureBoxSegment)sender).Column);
					UpdateDisplay();
					if (_game.GameOver)
					{
						_highlightedColumn = -1;
						RedrawBoard();
						if (_game.GameWinner() == PositionState.EMPTY)
						{
							MessageBox.Show("The game has ended\n\nNoone won");
							_game.UpdateAchievements();
							DisplayNewAchievements();
						}
						else if (_game.GameWinner() == PositionState.PLAYER_ONE)
						{
							MessageBox.Show($"The game has ended\n\n{_firstPlayerColor} won");
							_game.UpdateAchievements();
							DisplayNewAchievements();
						}
						else
						{
							MessageBox.Show($"The game has ended\n\n{_secondPlayerColor} won");
							_game.UpdateAchievements();
							DisplayNewAchievements();
						}
					}
				}
				catch (ApplicationException down)
				{
					UpdateDisplay();
					MessageBox.Show(down.Message);
				}
			}
		}

		private void DisplayNewAchievements()
		{
			AchievementList nextAchievement;
			int currentAchievement = 0;
			while (_achievementLogic.HasAchievementsToShow())
			{
				nextAchievement = _achievementLogic.GetNextNewAchievement();
				CreateAchievementBox(20, 100 * currentAchievement + 50);
				_achievementsLabel[_achievementsLabel.Count - 1].Text = _achievementLogic.GetAchievementText(nextAchievement);
				_achievementsPicture[_achievementsPicture.Count - 1].Image = (Image)_rm.GetObject(_achievementLogic.GetAchievementImageName(nextAchievement));
				currentAchievement++;
			}
		}

		private void btnQuitGame_Click(object sender, EventArgs e)
		{
			if (!_game.GameOver)
			{
				DialogResult result = MessageBox.Show("Exit to main menu?", "Quit", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
						this.Close();
				}
			}
			else
			{
				this.Close();
			}
		}

		private void btnNewGame_Click(object sender, EventArgs e)
		{
			this.DeleteAchievementBoxes();
			if (!_game.GameOver)
			{
				DialogResult result = MessageBox.Show("Restart game?", "New Game", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					NewGame();
					UpdateDisplay();
				}
			}
			else
			{
				NewGame();
				UpdateDisplay();
			}
		}

		private void NewGame()
		{
			if (_gameOptions.SinglePlayer)
			{
				_game.NewGame(_gameOptions.BoardSize, _gameOptions.Difficulty);
			}
			else
			{
				_game.NewGame(_gameOptions.BoardSize);
			}
			UpdateBoardSize();
			_positionStates = new PositionState[_columns, _rows];
			DeleteConnectFourBoard();
			CreateConnectFourBoard();
		}

		private void btnOptions_Click(object sender, EventArgs e)
		{
			frmOptions options = new frmOptions(_gameOptions);
			DialogResult result = options.ShowDialog();
			_game.UpdateAIDifficulty(_gameOptions.Difficulty);
			if (result == DialogResult.OK)
			{
				MessageBox.Show("Settings changed" + (options.BoardSizeChanged ? "\n\nBoard size will change next game" : ""));
			}
		}
		private void pbUndo_Click(object sender, EventArgs e)
		{
			if (_game.CanUndo())
			{
				_game.Undo();
			}
			UpdateDisplay();
		}

		private void frmGame_Resize(object sender, EventArgs e)
		{
			this.RePositionAndSizeBoard();
			this.PositionButtons();
		}

		private void frmGame_Activated(object sender, EventArgs e)
		{
			UpdateTheme();
		}
	}
}
