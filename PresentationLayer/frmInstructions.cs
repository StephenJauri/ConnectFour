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
	public partial class frmInstructions : Form
	{
		private GameOptions _gameOptions;
		public frmInstructions(GameOptions gameOptions)
		{

			InitializeComponent();
			this._gameOptions = gameOptions;
		}

		private void frmInstructions_Load(object sender, EventArgs e)
		{
			UpdateTheme();
		}

		public void UpdateTheme()
		{
			this.BackColor = _gameOptions.Theme.BackgroundColor;
			lblInstructions.ForeColor = _gameOptions.Theme.TextColor;
			lblInstructionsText.ForeColor = _gameOptions.Theme.SubTextColor;
			btnOK.BackColor = _gameOptions.Theme.ButtonColor;
			btnOK.ForeColor = _gameOptions.Theme.ButtonTextColor;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
