using System;
using System.Windows.Forms;

namespace TimelineBuilderPro
{
	public partial class AboutForm : Form
	{
		private readonly string lastUpdateDate; // Store the last update date

		public AboutForm()
		{
			lastUpdateDate = "January 15, 2025"; // Example date, replace with dynamic logic as needed
			InitializeComponent();
			AdjustFormSize();
			CenterCloseButton();
		}

		private void InitializeComponent()
		{
			this.labelAppName = new System.Windows.Forms.Label();
			this.labelCreator = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCurrentDate = new System.Windows.Forms.Label();
			this.labelLastUpdate = new System.Windows.Forms.Label(); // New label for Last Update
			this.buttonClose = new System.Windows.Forms.Button();
			this.SuspendLayout();

			// 
			// labelAppName
			// 
			this.labelAppName.AutoSize = true;
			this.labelAppName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
			this.labelAppName.Location = new System.Drawing.Point(40, 30); // Increased margin
			this.labelAppName.Name = "labelAppName";
			this.labelAppName.Text = "Timeline Builder Pro";

			// 
			// labelCreator
			// 
			this.labelCreator.AutoSize = true;
			this.labelCreator.Font = new System.Drawing.Font("Arial", 10F);
			this.labelCreator.Location = new System.Drawing.Point(40, 80); // Increased margin
			this.labelCreator.Name = "labelCreator";
			this.labelCreator.Text = "Created by: CanisDirusPrime";

			// 
			// labelCopyright
			// 
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.Font = new System.Drawing.Font("Arial", 10F);
			this.labelCopyright.Location = new System.Drawing.Point(40, 130); // Increased margin
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Text = "Copyright © 2023 CanisDirusPrime";

			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new System.Drawing.Font("Arial", 10F);
			this.labelVersion.Location = new System.Drawing.Point(40, 180); // Increased margin
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Text = "Version: 1.0.0";

			// 
			// labelCurrentDate
			// 
			this.labelCurrentDate.AutoSize = true;
			this.labelCurrentDate.Font = new System.Drawing.Font("Arial", 10F);
			this.labelCurrentDate.Location = new System.Drawing.Point(40, 230); // Increased margin
			this.labelCurrentDate.Name = "labelCurrentDate";
			this.labelCurrentDate.Text = $"Current Date: {DateTime.Now.ToShortDateString()}";

			// 
			// labelLastUpdate
			// 
			this.labelLastUpdate.AutoSize = true;
			this.labelLastUpdate.Font = new System.Drawing.Font("Arial", 10F);
			this.labelLastUpdate.Location = new System.Drawing.Point(40, 280); // Increased margin
			this.labelLastUpdate.Name = "labelLastUpdate";
			this.labelLastUpdate.Text = $"Last Update: {lastUpdateDate}";

			// 
			// buttonClose
			// 
			this.buttonClose.Font = new System.Drawing.Font("Arial", 10F);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(100, 35); // Slightly larger button
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);

			// 
			// AboutForm
			// 
			this.ClientSize = new System.Drawing.Size(400, 400); // Increased default width and height
			this.Controls.Add(this.labelAppName);
			this.Controls.Add(this.labelCreator);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.labelCurrentDate);
			this.Controls.Add(this.labelLastUpdate); // Add Last Update label
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void AboutForm_Load(object? sender, EventArgs e)
		{
			CenterCloseButton();
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AdjustFormSize()
		{
			// Dynamically calculate the required height
			int requiredHeight = labelLastUpdate.Bottom + 80; // Extra padding below the last label
			int requiredWidth = Math.Max(400, labelAppName.Width + 80); // Minimum width with extra padding
			this.ClientSize = new System.Drawing.Size(requiredWidth, requiredHeight);
		}

		private void CenterCloseButton()
		{
			// Center the Close button horizontally and position it near the bottom
			int formWidth = this.ClientSize.Width;
			int formHeight = this.ClientSize.Height;
			int buttonVerticalPosition = formHeight - buttonClose.Height - 30; // 30px padding from the bottom
			buttonClose.Location = new System.Drawing.Point((formWidth - buttonClose.Width) / 2, buttonVerticalPosition);
		}

		private System.Windows.Forms.Label labelAppName;
		private System.Windows.Forms.Label labelCreator;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCurrentDate;
		private System.Windows.Forms.Label labelLastUpdate; // New label
		private System.Windows.Forms.Button buttonClose;
	}
}
