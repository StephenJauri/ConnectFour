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
using System.Reflection;
using System.Resources;
using LogicLayer;

namespace PresentationLayer
{
	public partial class frmStartScreen : Form
	{
		private ResourceManager _rm = new ResourceManager("PresentationLayer.ConnectFourStates", Assembly.GetExecutingAssembly());
		private GameOptions _gameOptions = new GameOptions();
		private AchievementLogic _achievementLogic;
		public frmStartScreen()
		{
			InitializeComponent();
		}

		private void frmStartScreen_Load(object sender, EventArgs e)
		{
			UpdateTheme();
			try
			{
				_achievementLogic = new AchievementLogic();
			}
			catch (ApplicationException exc)
			{
				MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message);
			}
		}

		private void UpdateTheme()
		{
			lblTitle.ForeColor = _gameOptions.Theme.TextColor;
			lblPlayGame.ForeColor = _gameOptions.Theme.SubTextColor;
			lblHelp.ForeColor = _gameOptions.Theme.SubTextColor;
			btnSinglePlayer.ForeColor = _gameOptions.Theme.ButtonTextColor;
			btnMultiPlayer.ForeColor = _gameOptions.Theme.ButtonTextColor;
			btnAbout.ForeColor = _gameOptions.Theme.ButtonTextColor;
			btnOptions.ForeColor = _gameOptions.Theme.ButtonTextColor;
			btnInstructions.ForeColor = _gameOptions.Theme.ButtonTextColor;

			btnSinglePlayer.BackColor = _gameOptions.Theme.ButtonColor;
			btnMultiPlayer.BackColor = _gameOptions.Theme.ButtonColor;
			btnAbout.BackColor = _gameOptions.Theme.ButtonColor;
			btnOptions.BackColor = _gameOptions.Theme.ButtonColor;
			btnInstructions.BackColor = _gameOptions.Theme.ButtonColor;

			btnAchievements.ForeColor = _gameOptions.Theme.ButtonTextColor;
			btnAchievements.BackColor = _gameOptions.Theme.ButtonColor;
			lblAchievements.ForeColor = _gameOptions.Theme.SubTextColor;

			this.BackColor = _gameOptions.Theme.BackgroundColor;
		}

		private void btnSinglePlayer_Click(object sender, EventArgs e)
		{
			_gameOptions.SinglePlayer = true;
			frmGame game = new frmGame(_gameOptions,_achievementLogic , _rm);
			this.Visible = false;
			game.ShowDialog();
			this.Visible = true;
		}

		private void btnMultiPlayer_Click(object sender, EventArgs e)
		{
			_gameOptions.SinglePlayer = false;
			frmGame game = new frmGame(_gameOptions, _achievementLogic, _rm);
			this.Visible = false;
			game.ShowDialog();
			this.Visible = true;
		}

		private void btnOptions_Click(object sender, EventArgs e)
		{
			frmOptions options = new frmOptions(_gameOptions);
			options.ShowDialog();
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Created by some handsome guy in Iowa City named Stephen\n\n©2022\n\nFeaturing Gwens cool ideas");
		}

		private void btnInstructions_Click(object sender, EventArgs e)
		{
			frmInstructions instructions = new frmInstructions(_gameOptions);
			instructions.ShowDialog();
		}

		private void btnAchievements_Click(object sender, EventArgs e)
		{
			frmAchievements achievements = new frmAchievements(_gameOptions, _achievementLogic ,_rm);
			achievements.ShowDialog();
		}

		private void frmStartScreen_Activated(object sender, EventArgs e)
		{
			UpdateTheme();
		}
	}
}
