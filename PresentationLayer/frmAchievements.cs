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
using LogicLayer;
using System.Resources;
using System.Reflection;

namespace PresentationLayer
{
	public partial class frmAchievements : Form
	{
		private GameOptions _gameOptions;
		private AchievementLogic _achievementLogic;
		private PictureBox[] _achievementPictures;
		private Label[] _achievementLabels;
		private ResourceManager _rm;

		public frmAchievements(GameOptions gameOptions, AchievementLogic achievementLogic, ResourceManager rm)
		{
			_gameOptions = gameOptions;
			_achievementLogic = achievementLogic;
			_rm = rm;
			InitializeComponent();
			LoadTheme();
			_achievementPictures = new PictureBox[] { picAchievementImage1, picAchievementImage2, picAchievementImage3, picAchievementImage4, picAchievementImage5 };
			_achievementLabels = new Label[] { lblAchievementText1, lblAchievementText2, lblAchievementText3, lblAchievementText4, lblAchievementText5 };
		}

		private void LoadTheme()
		{
			lblAchievements.ForeColor = _gameOptions.Theme.TextColor;
			this.BackColor = _gameOptions.Theme.BackgroundColor;
			lblAchievementText1.ForeColor = _gameOptions.Theme.SubTextColor;
			lblAchievementText2.ForeColor = _gameOptions.Theme.SubTextColor;
			lblAchievementText3.ForeColor = _gameOptions.Theme.SubTextColor;
			lblAchievementText4.ForeColor = _gameOptions.Theme.SubTextColor;
			lblAchievementText5.ForeColor = _gameOptions.Theme.SubTextColor;
			btnOK.BackColor = _gameOptions.Theme.ButtonColor;
			btnOK.ForeColor = _gameOptions.Theme.ButtonTextColor;

		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmAchievements_Load(object sender, EventArgs e)
		{
			try
			{
				_achievementLogic.LoadAchievements();
				UpdateAchievementsDisplay();
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
				this.Close();
			}
			ttAchievementDesc.SetToolTip(pnlAchievement1, _achievementLogic.GetAchievementDescription(AchievementList.LIGHTS_OUT));
			ttAchievementDesc.SetToolTip(pnlAchievement2, _achievementLogic.GetAchievementDescription(AchievementList.DOUBLE_TROUBLE));
			ttAchievementDesc.SetToolTip(pnlAchievement3, _achievementLogic.GetAchievementDescription(AchievementList.THATS_EASY));
			ttAchievementDesc.SetToolTip(pnlAchievement4, _achievementLogic.GetAchievementDescription(AchievementList.ALL_FILLED));
			ttAchievementDesc.SetToolTip(pnlAchievement5, _achievementLogic.GetAchievementDescription(AchievementList.MINES_BIGGER));

			ttAchievementDesc.SetToolTip(picAchievementImage1, _achievementLogic.GetAchievementDescription(AchievementList.LIGHTS_OUT));
			ttAchievementDesc.SetToolTip(picAchievementImage2, _achievementLogic.GetAchievementDescription(AchievementList.DOUBLE_TROUBLE));
			ttAchievementDesc.SetToolTip(picAchievementImage3, _achievementLogic.GetAchievementDescription(AchievementList.THATS_EASY));
			ttAchievementDesc.SetToolTip(picAchievementImage4, _achievementLogic.GetAchievementDescription(AchievementList.ALL_FILLED));
			ttAchievementDesc.SetToolTip(picAchievementImage5, _achievementLogic.GetAchievementDescription(AchievementList.MINES_BIGGER));

			ttAchievementDesc.SetToolTip(lblAchievementText1, _achievementLogic.GetAchievementDescription(AchievementList.LIGHTS_OUT));
			ttAchievementDesc.SetToolTip(lblAchievementText2, _achievementLogic.GetAchievementDescription(AchievementList.DOUBLE_TROUBLE));
			ttAchievementDesc.SetToolTip(lblAchievementText3, _achievementLogic.GetAchievementDescription(AchievementList.THATS_EASY));
			ttAchievementDesc.SetToolTip(lblAchievementText4, _achievementLogic.GetAchievementDescription(AchievementList.ALL_FILLED));
			ttAchievementDesc.SetToolTip(lblAchievementText5, _achievementLogic.GetAchievementDescription(AchievementList.MINES_BIGGER));

		}

		private void UpdateAchievementsDisplay()
		{
			foreach (AchievementList currentAchievement in Enum.GetValues(typeof(AchievementList)))
			{
				UpdateAchievementDisplay(currentAchievement);
			}
		}
		private void UpdateAchievementDisplay(AchievementList achievement)
		{
			_achievementPictures[(int)achievement].Image = (Image)_rm.GetObject(_achievementLogic.GetAchievementImageName(achievement));
			_achievementLabels[(int)achievement].Text = _achievementLogic.GetAchievementText(achievement);
		}

    }
}
