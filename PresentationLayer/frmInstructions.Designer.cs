
namespace PresentationLayer
{
	partial class frmInstructions
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstructions));
			this.lblInstructions = new System.Windows.Forms.Label();
			this.lblInstructionsText = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblInstructions
			// 
			this.lblInstructions.AutoSize = true;
			this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInstructions.Location = new System.Drawing.Point(108, 9);
			this.lblInstructions.Name = "lblInstructions";
			this.lblInstructions.Size = new System.Drawing.Size(181, 37);
			this.lblInstructions.TabIndex = 0;
			this.lblInstructions.Text = "Instructions";
			// 
			// lblInstructionsText
			// 
			this.lblInstructionsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInstructionsText.Location = new System.Drawing.Point(64, 79);
			this.lblInstructionsText.Name = "lblInstructionsText";
			this.lblInstructionsText.Size = new System.Drawing.Size(314, 362);
			this.lblInstructionsText.TabIndex = 1;
			this.lblInstructionsText.Text = resources.GetString("lblInstructionsText.Text");
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.MediumPurple;
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(145, 444);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(144, 74);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmInstructions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(439, 532);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblInstructionsText);
			this.Controls.Add(this.lblInstructions);
			this.Name = "frmInstructions";
			this.Text = "Instructions";
			this.Load += new System.EventHandler(this.frmInstructions_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblInstructions;
		private System.Windows.Forms.Label lblInstructionsText;
		private System.Windows.Forms.Button btnOK;
	}
}