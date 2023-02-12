
namespace PresentationLayer
{
	partial class frmStartScreen
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
			this.btnSinglePlayer = new System.Windows.Forms.Button();
			this.btnMultiPlayer = new System.Windows.Forms.Button();
			this.btnInstructions = new System.Windows.Forms.Button();
			this.lblPlayGame = new System.Windows.Forms.Label();
			this.lblHelp = new System.Windows.Forms.Label();
			this.btnAbout = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnOptions = new System.Windows.Forms.Button();
			this.lblAchievements = new System.Windows.Forms.Label();
			this.btnAchievements = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSinglePlayer
			// 
			this.btnSinglePlayer.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnSinglePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSinglePlayer.Location = new System.Drawing.Point(102, 115);
			this.btnSinglePlayer.Name = "btnSinglePlayer";
			this.btnSinglePlayer.Size = new System.Drawing.Size(187, 74);
			this.btnSinglePlayer.TabIndex = 0;
			this.btnSinglePlayer.Text = "Single Player";
			this.btnSinglePlayer.UseVisualStyleBackColor = false;
			this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
			// 
			// btnMultiPlayer
			// 
			this.btnMultiPlayer.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnMultiPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMultiPlayer.Location = new System.Drawing.Point(102, 195);
			this.btnMultiPlayer.Name = "btnMultiPlayer";
			this.btnMultiPlayer.Size = new System.Drawing.Size(187, 74);
			this.btnMultiPlayer.TabIndex = 1;
			this.btnMultiPlayer.Text = "Multi Player";
			this.btnMultiPlayer.UseVisualStyleBackColor = false;
			this.btnMultiPlayer.Click += new System.EventHandler(this.btnMultiPlayer_Click);
			// 
			// btnInstructions
			// 
			this.btnInstructions.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnInstructions.Location = new System.Drawing.Point(102, 406);
			this.btnInstructions.Name = "btnInstructions";
			this.btnInstructions.Size = new System.Drawing.Size(187, 74);
			this.btnInstructions.TabIndex = 2;
			this.btnInstructions.Text = "Instructions";
			this.btnInstructions.UseVisualStyleBackColor = false;
			this.btnInstructions.Click += new System.EventHandler(this.btnInstructions_Click);
			// 
			// lblPlayGame
			// 
			this.lblPlayGame.AutoSize = true;
			this.lblPlayGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayGame.ForeColor = System.Drawing.Color.MediumSlateBlue;
			this.lblPlayGame.Location = new System.Drawing.Point(159, 81);
			this.lblPlayGame.Name = "lblPlayGame";
			this.lblPlayGame.Size = new System.Drawing.Size(67, 31);
			this.lblPlayGame.TabIndex = 3;
			this.lblPlayGame.Text = "Play";
			// 
			// lblHelp
			// 
			this.lblHelp.AutoSize = true;
			this.lblHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHelp.ForeColor = System.Drawing.Color.MediumSlateBlue;
			this.lblHelp.Location = new System.Drawing.Point(159, 292);
			this.lblHelp.Name = "lblHelp";
			this.lblHelp.Size = new System.Drawing.Size(70, 31);
			this.lblHelp.TabIndex = 6;
			this.lblHelp.Text = "Help";
			// 
			// btnAbout
			// 
			this.btnAbout.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAbout.Location = new System.Drawing.Point(102, 486);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(187, 74);
			this.btnAbout.TabIndex = 7;
			this.btnAbout.Text = "About";
			this.btnAbout.UseVisualStyleBackColor = false;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
			this.lblTitle.Location = new System.Drawing.Point(78, 13);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(251, 55);
			this.lblTitle.TabIndex = 8;
			this.lblTitle.Text = "4 in a Row";
			// 
			// btnOptions
			// 
			this.btnOptions.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOptions.Location = new System.Drawing.Point(102, 326);
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(187, 74);
			this.btnOptions.TabIndex = 9;
			this.btnOptions.Text = "Options";
			this.btnOptions.UseVisualStyleBackColor = false;
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			// 
			// lblAchievements
			// 
			this.lblAchievements.AutoSize = true;
			this.lblAchievements.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAchievements.ForeColor = System.Drawing.Color.MediumSlateBlue;
			this.lblAchievements.Location = new System.Drawing.Point(103, 571);
			this.lblAchievements.Name = "lblAchievements";
			this.lblAchievements.Size = new System.Drawing.Size(185, 31);
			this.lblAchievements.TabIndex = 10;
			this.lblAchievements.Text = "Achievements";
			// 
			// btnAchievements
			// 
			this.btnAchievements.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnAchievements.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAchievements.Location = new System.Drawing.Point(102, 605);
			this.btnAchievements.Name = "btnAchievements";
			this.btnAchievements.Size = new System.Drawing.Size(187, 74);
			this.btnAchievements.TabIndex = 11;
			this.btnAchievements.Text = "Achievements";
			this.btnAchievements.UseVisualStyleBackColor = false;
			this.btnAchievements.Click += new System.EventHandler(this.btnAchievements_Click);
			// 
			// frmStartScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(409, 709);
			this.Controls.Add(this.btnAchievements);
			this.Controls.Add(this.lblAchievements);
			this.Controls.Add(this.btnOptions);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.lblHelp);
			this.Controls.Add(this.lblPlayGame);
			this.Controls.Add(this.btnInstructions);
			this.Controls.Add(this.btnMultiPlayer);
			this.Controls.Add(this.btnSinglePlayer);
			this.Name = "frmStartScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "4 in a Row";
			this.Activated += new System.EventHandler(this.frmStartScreen_Activated);
			this.Load += new System.EventHandler(this.frmStartScreen_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSinglePlayer;
		private System.Windows.Forms.Button btnMultiPlayer;
		private System.Windows.Forms.Button btnInstructions;
		private System.Windows.Forms.Label lblPlayGame;
		private System.Windows.Forms.Label lblHelp;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnOptions;
		private System.Windows.Forms.Label lblAchievements;
		private System.Windows.Forms.Button btnAchievements;
	}
}

