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

namespace PresentationLayer
{
	public partial class frmOptions : Form
	{
		private GameOptions _gameOptions;
		private GameOptions _tempGameOptions;

		private Theme[] _themes = new Theme[2];

		public bool BoardSizeChanged { get; private set; } = false;
		public frmOptions(GameOptions options)
		{
			this._gameOptions = options;
			_tempGameOptions = new GameOptions(options);
			InitializeComponent();
			_themes[0] = new Theme();
			_themes[1] = new Theme("dark", Color.FromArgb(50, 50, 50), Color.FromArgb(30, 30, 30), Color.LightGray, Color.DimGray, Color.Gray, "Grey", "Red", "dark_empty", "dark_grey_filled", "dark_red_filled", "dark_grey_highlight", "dark_red_highlight");
		}

		private void Options_Load(object sender, EventArgs e)
		{
			UpdateTheme();
			rbSmall.Checked = _gameOptions.BoardSize == BoardSize.SMALL;
			rbNormal.Checked = _gameOptions.BoardSize == BoardSize.NORMAL;
			rbLarge.Checked = _gameOptions.BoardSize == BoardSize.LARGE;
			rbAbsurd.Checked = _gameOptions.BoardSize == BoardSize.ABSURD;
			rbLight.Checked = _gameOptions.Theme.Name == "light";
			rbDark.Checked = _gameOptions.Theme.Name == "dark";
			rbEasyDifficulty.Checked = _gameOptions.Difficulty == AIDifficulty.EASY;
			rbNormalDifficulty.Checked = _gameOptions.Difficulty == AIDifficulty.NORMAL;
			rbHardDifficulty.Checked = _gameOptions.Difficulty == AIDifficulty.HARD;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void UpdateTheme()
		{
			gbBoardSize.ForeColor = _tempGameOptions.Theme.SubTextColor;
			gbTheme.ForeColor = _tempGameOptions.Theme.SubTextColor;
			gbDifficulty.ForeColor = _tempGameOptions.Theme.SubTextColor;
			label1.ForeColor = _tempGameOptions.Theme.TextColor;
			this.BackColor = _tempGameOptions.Theme.BackgroundColor;
			btnCancel.BackColor = _tempGameOptions.Theme.ButtonColor;
			btnOK.BackColor = _tempGameOptions.Theme.ButtonColor;
			btnCancel.ForeColor = _tempGameOptions.Theme.ButtonTextColor;
			btnOK.ForeColor = _tempGameOptions.Theme.ButtonTextColor;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (!_gameOptions.Equals(_tempGameOptions))
			{
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				this.DialogResult = DialogResult.Cancel;
			}
			if (_gameOptions.BoardSize != _tempGameOptions.BoardSize)
            {
				BoardSizeChanged = true;
            }
			_gameOptions.UpdateOptions(_tempGameOptions);
			this.Close();
		}

		private void rbSize_CheckedChanged(object sender, EventArgs e)
		{
			if (rbSmall.Checked)
			{
				_tempGameOptions.BoardSize = BoardSize.SMALL;
			}
			if (rbNormal.Checked)
			{
				_tempGameOptions.BoardSize = BoardSize.NORMAL;
			}
			if (rbLarge.Checked)
			{
				_tempGameOptions.BoardSize = BoardSize.LARGE;
			}
			if (rbAbsurd.Checked)
			{
				_tempGameOptions.BoardSize = BoardSize.ABSURD;
			}
		}

		private void rbTheme_CheckedChanged(object sender, EventArgs e)
		{
			if (rbLight.Checked)
			{
				_tempGameOptions.Theme = _themes[0];
			}
			if (rbDark.Checked)
			{
				_tempGameOptions.Theme = _themes[1];
			}
			UpdateTheme();
		}

		private void rbDifficulty_CheckedChanged(object sender, EventArgs e)
		{
			if (rbEasyDifficulty.Checked)
            {
				_tempGameOptions.Difficulty = AIDifficulty.EASY;
            }
			if (rbNormalDifficulty.Checked)
			{
				_tempGameOptions.Difficulty = AIDifficulty.NORMAL;
			}
			if (rbHardDifficulty.Checked)
			{
				_tempGameOptions.Difficulty = AIDifficulty.HARD;
			}
			UpdateTheme();
		}
	}
}
