
namespace PresentationLayer
{
	partial class frmGame
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnNewGame = new System.Windows.Forms.Button();
			this.btnQuitGame = new System.Windows.Forms.Button();
			this.pbUndo = new System.Windows.Forms.PictureBox();
			this.btnOptions = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbUndo)).BeginInit();
			this.SuspendLayout();
			// 
			// btnNewGame
			// 
			this.btnNewGame.BackColor = System.Drawing.Color.MediumPurple;
			this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNewGame.Location = new System.Drawing.Point(394, 191);
			this.btnNewGame.Name = "btnNewGame";
			this.btnNewGame.Size = new System.Drawing.Size(144, 74);
			this.btnNewGame.TabIndex = 2;
			this.btnNewGame.Text = "New Game";
			this.btnNewGame.UseVisualStyleBackColor = false;
			this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
			// 
			// btnQuitGame
			// 
			this.btnQuitGame.BackColor = System.Drawing.Color.MediumPurple;
			this.btnQuitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuitGame.Location = new System.Drawing.Point(746, 191);
			this.btnQuitGame.Name = "btnQuitGame";
			this.btnQuitGame.Size = new System.Drawing.Size(144, 74);
			this.btnQuitGame.TabIndex = 4;
			this.btnQuitGame.Text = "Quit Game";
			this.btnQuitGame.UseVisualStyleBackColor = false;
			this.btnQuitGame.Click += new System.EventHandler(this.btnQuitGame_Click);
			// 
			// pbUndo
			// 
			this.pbUndo.Image = global::PresentationLayer.Properties.Resources.Undo_PNG_Free_Image;
			this.pbUndo.Location = new System.Drawing.Point(13, 13);
			this.pbUndo.Name = "pbUndo";
			this.pbUndo.Size = new System.Drawing.Size(50, 50);
			this.pbUndo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbUndo.TabIndex = 5;
			this.pbUndo.TabStop = false;
			this.pbUndo.Click += new System.EventHandler(this.pbUndo_Click);
			// 
			// btnOptions
			// 
			this.btnOptions.BackColor = System.Drawing.Color.MediumPurple;
			this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOptions.Location = new System.Drawing.Point(921, 489);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(144, 74);
			this.btnOptions.TabIndex = 6;
			this.btnOptions.Text = "Options";
			this.btnOptions.UseVisualStyleBackColor = false;
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			// 
			// frmGame
			// 
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(1120, 707);
			this.Controls.Add(this.btnOptions);
			this.Controls.Add(this.pbUndo);
			this.Controls.Add(this.btnQuitGame);
			this.Controls.Add(this.btnNewGame);
			this.Name = "frmGame";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "4 in a row";
			this.Activated += new System.EventHandler(this.frmGame_Activated);
			this.Load += new System.EventHandler(this.frmGame_Load);
			this.ResizeEnd += new System.EventHandler(this.frmGame_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pbUndo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private void CreateConnectFourBoard()
		{
			this.SuspendLayout();
			_connectFourPictureBoxSegments = new DataObjects.ConnectFourPictureBoxSegment[_columns, _rows];
			for (int column = 0; column < this._connectFourPictureBoxSegments.GetLength(0); column++)
			{
				for (int row = 0; row < this._connectFourPictureBoxSegments.GetLength(1); row++)
				{
					this._connectFourPictureBoxSegments[column,row] = new DataObjects.ConnectFourPictureBoxSegment();
					((System.ComponentModel.ISupportInitialize)(this._connectFourPictureBoxSegments[column, row])).BeginInit();
					this.SuspendLayout();
					// 
					// picBoxConnectFourSegment1
					// 
					this._connectFourPictureBoxSegments[column, row].Column = column;
					this._connectFourPictureBoxSegments[column, row].Location = new System.Drawing.Point(0,0);
					this._connectFourPictureBoxSegments[column, row].Size = new System.Drawing.Size(TileWidth, TileWidth);
					this._connectFourPictureBoxSegments[column, row].Name = "picBoxConnectFourSegment" + column + row;
					this._connectFourPictureBoxSegments[column, row].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
					this._connectFourPictureBoxSegments[column, row].MouseEnter += new System.EventHandler(this.connectFourPictureBoxSegment_MouseEnter);
					this._connectFourPictureBoxSegments[column, row].MouseLeave += new System.EventHandler(this.connectFourPictureBoxSegment_MouseExit);
					this._connectFourPictureBoxSegments[column, row].Click += new System.EventHandler(this.connectFourPictureBoxSegment_Click);
					this._connectFourPictureBoxSegments[column, row].TabIndex = 0;
					this._connectFourPictureBoxSegments[column, row].TabStop = false;
					this.Controls.Add(this._connectFourPictureBoxSegments[column, row]);
					((System.ComponentModel.ISupportInitialize)(this._connectFourPictureBoxSegments[column, row])).EndInit();
				}
			}
			RePositionAndSizeBoard();
			this.ResumeLayout();
		}

		private void RePositionAndSizeBoard()
		{
			this.SuspendLayout();
			TileWidth = this.Width / (4 + _columns);
			_boardPosition = new System.Drawing.Point(TileWidth * 2, TileWidth);
			for (int column = 0; column < this._connectFourPictureBoxSegments.GetLength(0); column++)
			{
				for (int row = 0; row < this._connectFourPictureBoxSegments.GetLength(1); row++)
				{
					this._connectFourPictureBoxSegments[column, row].Location = new System.Drawing.Point(_boardPosition.X + (column * (TileWidth - 1)), _boardPosition.Y + (row * (TileWidth - 1)));
					this._connectFourPictureBoxSegments[column, row].Size = new System.Drawing.Size(TileWidth, TileWidth);
				}
			}
			this.ResumeLayout();
		}

		private void CreateAchievementBox(int x, int y)
		{
			this.pnlAchievement1 = new System.Windows.Forms.Panel();
			this.lblAchievementText1 = new System.Windows.Forms.Label();
			this.picAchievementImage1 = new System.Windows.Forms.PictureBox();
			this.pnlAchievement1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picAchievementImage1)).BeginInit();

			// 
			// pnlAchievement1
			// 
			this.pnlAchievement1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlAchievement1.Controls.Add(this.lblAchievementText1);
			this.pnlAchievement1.Controls.Add(this.picAchievementImage1);
			this.pnlAchievement1.Location = new System.Drawing.Point(x, y);
			this.pnlAchievement1.Name = "pnlAchievement1";
			this.pnlAchievement1.Size = new System.Drawing.Size(250, 80);
			this.pnlAchievement1.TabIndex = 5;
			// 
			// lblAchievementText1
			// 
			this.lblAchievementText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAchievementText1.Location = new System.Drawing.Point(100, 0);
			this.lblAchievementText1.Name = "lblAchievementText1";
			this.lblAchievementText1.Size = new System.Drawing.Size(150, 80);
			this.lblAchievementText1.TabIndex = 1;
			this.lblAchievementText1.Text = "label1";
			this.lblAchievementText1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picAchievementImage1
			// 
			this.picAchievementImage1.Location = new System.Drawing.Point(0, 0);
			this.picAchievementImage1.Name = "picAchievementImage1";
			this.picAchievementImage1.Size = new System.Drawing.Size(80, 80);
			this.picAchievementImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picAchievementImage1.TabIndex = 0;
			this.picAchievementImage1.TabStop = false;


			this.Controls.Add(this.pnlAchievement1);
			this.pnlAchievement1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picAchievementImage1)).EndInit();
			
			_achievementsPanel.Add(pnlAchievement1);
			_achievementsLabel.Add(lblAchievementText1);
			_achievementsPicture.Add(picAchievementImage1);
			this.pnlAchievement1.BringToFront();
		}

		private void DeleteConnectFourBoard()
		{
			this.SuspendLayout();
			if(_connectFourPictureBoxSegments != null)
			{
				for (int column = 0; column < this._connectFourPictureBoxSegments.GetLength(0); column++)
				{
					for (int row = 0; row < this._connectFourPictureBoxSegments.GetLength(1); row++)
					{
						this.Controls.Remove(_connectFourPictureBoxSegments[column, row]);
					}
				}
				_connectFourPictureBoxSegments = null;
			}
			this.ResumeLayout();
		}
		private void DeleteAchievementBoxes()
		{
			for (int i = 0; i < _achievementsPicture.Count; i++)
			{
				this.Controls.Remove(this._achievementsPicture[i]);
				this.Controls.Remove(this._achievementsLabel[i]);
				this.Controls.Remove(this._achievementsPanel[i]);
			}
			this._achievementsPicture.Clear();
			this._achievementsLabel.Clear();
			this._achievementsPanel.Clear();
		}


		private System.Collections.Generic.List<System.Windows.Forms.Panel> _achievementsPanel = new System.Collections.Generic.List<System.Windows.Forms.Panel>();
		private System.Collections.Generic.List<System.Windows.Forms.PictureBox> _achievementsPicture = new System.Collections.Generic.List<System.Windows.Forms.PictureBox>();
		private System.Collections.Generic.List<System.Windows.Forms.Label> _achievementsLabel = new System.Collections.Generic.List<System.Windows.Forms.Label>();
		private DataObjects.ConnectFourPictureBoxSegment[,] _connectFourPictureBoxSegments;
		private System.Windows.Forms.Button btnNewGame;
		private System.Windows.Forms.Button btnQuitGame;
		private System.Windows.Forms.Panel pnlAchievement1;
		private System.Windows.Forms.Label lblAchievementText1;
		private System.Windows.Forms.PictureBox picAchievementImage1;
		private System.Windows.Forms.PictureBox pbUndo;
		private System.Windows.Forms.Button btnOptions;
	}
}