
namespace PresentationLayer
{
	partial class frmOptions
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
            this.rbSmall = new System.Windows.Forms.RadioButton();
            this.gbBoardSize = new System.Windows.Forms.GroupBox();
            this.rbAbsurd = new System.Windows.Forms.RadioButton();
            this.rbLarge = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rbDark = new System.Windows.Forms.RadioButton();
            this.rbLight = new System.Windows.Forms.RadioButton();
            this.gbTheme = new System.Windows.Forms.GroupBox();
            this.gbDifficulty = new System.Windows.Forms.GroupBox();
            this.rbHardDifficulty = new System.Windows.Forms.RadioButton();
            this.rbNormalDifficulty = new System.Windows.Forms.RadioButton();
            this.rbEasyDifficulty = new System.Windows.Forms.RadioButton();
            this.gbBoardSize.SuspendLayout();
            this.gbTheme.SuspendLayout();
            this.gbDifficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbSmall
            // 
            this.rbSmall.AutoSize = true;
            this.rbSmall.Location = new System.Drawing.Point(6, 29);
            this.rbSmall.Name = "rbSmall";
            this.rbSmall.Size = new System.Drawing.Size(74, 28);
            this.rbSmall.TabIndex = 0;
            this.rbSmall.TabStop = true;
            this.rbSmall.Text = "Small";
            this.rbSmall.UseVisualStyleBackColor = true;
            this.rbSmall.CheckedChanged += new System.EventHandler(this.rbSize_CheckedChanged);
            // 
            // gbBoardSize
            // 
            this.gbBoardSize.Controls.Add(this.rbAbsurd);
            this.gbBoardSize.Controls.Add(this.rbLarge);
            this.gbBoardSize.Controls.Add(this.rbNormal);
            this.gbBoardSize.Controls.Add(this.rbSmall);
            this.gbBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBoardSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbBoardSize.Location = new System.Drawing.Point(111, 91);
            this.gbBoardSize.Name = "gbBoardSize";
            this.gbBoardSize.Size = new System.Drawing.Size(203, 173);
            this.gbBoardSize.TabIndex = 1;
            this.gbBoardSize.TabStop = false;
            this.gbBoardSize.Text = "Board Size";
            // 
            // rbAbsurd
            // 
            this.rbAbsurd.AutoSize = true;
            this.rbAbsurd.Location = new System.Drawing.Point(6, 131);
            this.rbAbsurd.Name = "rbAbsurd";
            this.rbAbsurd.Size = new System.Drawing.Size(89, 28);
            this.rbAbsurd.TabIndex = 3;
            this.rbAbsurd.TabStop = true;
            this.rbAbsurd.Text = "Absurd";
            this.rbAbsurd.UseVisualStyleBackColor = true;
            this.rbAbsurd.CheckedChanged += new System.EventHandler(this.rbSize_CheckedChanged);
            // 
            // rbLarge
            // 
            this.rbLarge.AutoSize = true;
            this.rbLarge.Location = new System.Drawing.Point(6, 97);
            this.rbLarge.Name = "rbLarge";
            this.rbLarge.Size = new System.Drawing.Size(76, 28);
            this.rbLarge.TabIndex = 2;
            this.rbLarge.Text = "Large";
            this.rbLarge.UseVisualStyleBackColor = true;
            this.rbLarge.CheckedChanged += new System.EventHandler(this.rbSize_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Location = new System.Drawing.Point(6, 63);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(89, 28);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbSize_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Options";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(246, 575);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 74);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.MediumPurple;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(36, 575);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(144, 74);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rbDark
            // 
            this.rbDark.AutoSize = true;
            this.rbDark.Location = new System.Drawing.Point(7, 62);
            this.rbDark.Name = "rbDark";
            this.rbDark.Size = new System.Drawing.Size(66, 28);
            this.rbDark.TabIndex = 1;
            this.rbDark.Text = "Dark";
            this.rbDark.UseVisualStyleBackColor = true;
            this.rbDark.CheckedChanged += new System.EventHandler(this.rbTheme_CheckedChanged);
            // 
            // rbLight
            // 
            this.rbLight.AutoSize = true;
            this.rbLight.Checked = true;
            this.rbLight.Location = new System.Drawing.Point(7, 28);
            this.rbLight.Name = "rbLight";
            this.rbLight.Size = new System.Drawing.Size(68, 28);
            this.rbLight.TabIndex = 0;
            this.rbLight.TabStop = true;
            this.rbLight.Text = "Light";
            this.rbLight.UseVisualStyleBackColor = true;
            this.rbLight.CheckedChanged += new System.EventHandler(this.rbTheme_CheckedChanged);
            // 
            // gbTheme
            // 
            this.gbTheme.Controls.Add(this.rbDark);
            this.gbTheme.Controls.Add(this.rbLight);
            this.gbTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTheme.Location = new System.Drawing.Point(111, 279);
            this.gbTheme.Name = "gbTheme";
            this.gbTheme.Size = new System.Drawing.Size(203, 103);
            this.gbTheme.TabIndex = 8;
            this.gbTheme.TabStop = false;
            this.gbTheme.Text = "Theme";
            // 
            // gbDifficulty
            // 
            this.gbDifficulty.Controls.Add(this.rbEasyDifficulty);
            this.gbDifficulty.Controls.Add(this.rbHardDifficulty);
            this.gbDifficulty.Controls.Add(this.rbNormalDifficulty);
            this.gbDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDifficulty.Location = new System.Drawing.Point(111, 403);
            this.gbDifficulty.Name = "gbDifficulty";
            this.gbDifficulty.Size = new System.Drawing.Size(203, 135);
            this.gbDifficulty.TabIndex = 9;
            this.gbDifficulty.TabStop = false;
            this.gbDifficulty.Text = "Difficulty";
            // 
            // rbHardDifficulty
            // 
            this.rbHardDifficulty.AutoSize = true;
            this.rbHardDifficulty.Location = new System.Drawing.Point(6, 96);
            this.rbHardDifficulty.Name = "rbHardDifficulty";
            this.rbHardDifficulty.Size = new System.Drawing.Size(69, 28);
            this.rbHardDifficulty.TabIndex = 1;
            this.rbHardDifficulty.Text = "Hard";
            this.rbHardDifficulty.UseVisualStyleBackColor = true;
            this.rbHardDifficulty.CheckedChanged += new System.EventHandler(this.rbDifficulty_CheckedChanged);
            // 
            // rbNormalDifficulty
            // 
            this.rbNormalDifficulty.AutoSize = true;
            this.rbNormalDifficulty.Checked = true;
            this.rbNormalDifficulty.Location = new System.Drawing.Point(6, 62);
            this.rbNormalDifficulty.Name = "rbNormalDifficulty";
            this.rbNormalDifficulty.Size = new System.Drawing.Size(89, 28);
            this.rbNormalDifficulty.TabIndex = 0;
            this.rbNormalDifficulty.TabStop = true;
            this.rbNormalDifficulty.Text = "Normal";
            this.rbNormalDifficulty.UseVisualStyleBackColor = true;
            this.rbNormalDifficulty.CheckedChanged += new System.EventHandler(this.rbDifficulty_CheckedChanged);
            // 
            // rbEasyDifficulty
            // 
            this.rbEasyDifficulty.AutoSize = true;
            this.rbEasyDifficulty.Location = new System.Drawing.Point(6, 28);
            this.rbEasyDifficulty.Name = "rbEasyDifficulty";
            this.rbEasyDifficulty.Size = new System.Drawing.Size(69, 28);
            this.rbEasyDifficulty.TabIndex = 2;
            this.rbEasyDifficulty.Text = "Easy";
            this.rbEasyDifficulty.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(450, 661);
            this.Controls.Add(this.gbDifficulty);
            this.Controls.Add(this.gbTheme);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbBoardSize);
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.gbBoardSize.ResumeLayout(false);
            this.gbBoardSize.PerformLayout();
            this.gbTheme.ResumeLayout(false);
            this.gbTheme.PerformLayout();
            this.gbDifficulty.ResumeLayout(false);
            this.gbDifficulty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbSmall;
		private System.Windows.Forms.GroupBox gbBoardSize;
		private System.Windows.Forms.RadioButton rbAbsurd;
		private System.Windows.Forms.RadioButton rbLarge;
		private System.Windows.Forms.RadioButton rbNormal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.RadioButton rbDark;
		private System.Windows.Forms.RadioButton rbLight;
		private System.Windows.Forms.GroupBox gbTheme;
		private System.Windows.Forms.GroupBox gbDifficulty;
		private System.Windows.Forms.RadioButton rbHardDifficulty;
		private System.Windows.Forms.RadioButton rbNormalDifficulty;
        private System.Windows.Forms.RadioButton rbEasyDifficulty;
    }
}