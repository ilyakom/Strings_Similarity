namespace Compare_Example
{
	partial class Form1
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
			this.richTextBoxRight = new System.Windows.Forms.RichTextBox();
			this.richTextBoxLeft = new System.Windows.Forms.RichTextBox();
			this.CompareButton = new System.Windows.Forms.Button();
			this.ResultTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.FindDuplicatesButton = new System.Windows.Forms.Button();
			this.ThresholdTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// richTextBoxRight
			// 
			this.richTextBoxRight.Location = new System.Drawing.Point(634, 45);
			this.richTextBoxRight.Name = "richTextBoxRight";
			this.richTextBoxRight.Size = new System.Drawing.Size(421, 522);
			this.richTextBoxRight.TabIndex = 1;
			this.richTextBoxRight.Text = "";
			// 
			// richTextBoxLeft
			// 
			this.richTextBoxLeft.Location = new System.Drawing.Point(13, 45);
			this.richTextBoxLeft.Name = "richTextBoxLeft";
			this.richTextBoxLeft.Size = new System.Drawing.Size(421, 522);
			this.richTextBoxLeft.TabIndex = 2;
			this.richTextBoxLeft.Text = "";
			// 
			// CompareButton
			// 
			this.CompareButton.Location = new System.Drawing.Point(473, 294);
			this.CompareButton.Name = "CompareButton";
			this.CompareButton.Size = new System.Drawing.Size(121, 39);
			this.CompareButton.TabIndex = 3;
			this.CompareButton.Text = "Compare";
			this.CompareButton.UseVisualStyleBackColor = true;
			this.CompareButton.Click += new System.EventHandler(this.CompareButton_Click);
			// 
			// ResultTextBox
			// 
			this.ResultTextBox.Location = new System.Drawing.Point(473, 266);
			this.ResultTextBox.Name = "ResultTextBox";
			this.ResultTextBox.Size = new System.Drawing.Size(121, 22);
			this.ResultTextBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "First string :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(631, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Second string :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(470, 246);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "Result :";
			// 
			// FindDuplicatesButton
			// 
			this.FindDuplicatesButton.Location = new System.Drawing.Point(473, 415);
			this.FindDuplicatesButton.Name = "FindDuplicatesButton";
			this.FindDuplicatesButton.Size = new System.Drawing.Size(121, 39);
			this.FindDuplicatesButton.TabIndex = 8;
			this.FindDuplicatesButton.Text = "Find Duplicated";
			this.FindDuplicatesButton.UseVisualStyleBackColor = true;
			this.FindDuplicatesButton.Click += new System.EventHandler(this.FindDuplicatesButton_Click);
			// 
			// ThresholdTextBox
			// 
			this.ThresholdTextBox.Location = new System.Drawing.Point(473, 387);
			this.ThresholdTextBox.Name = "ThresholdTextBox";
			this.ThresholdTextBox.Size = new System.Drawing.Size(121, 22);
			this.ThresholdTextBox.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(473, 364);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "Threshold:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 579);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ThresholdTextBox);
			this.Controls.Add(this.FindDuplicatesButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ResultTextBox);
			this.Controls.Add(this.CompareButton);
			this.Controls.Add(this.richTextBoxLeft);
			this.Controls.Add(this.richTextBoxRight);
			this.Name = "Form1";
			this.Text = "Use Example";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBoxRight;
		private System.Windows.Forms.RichTextBox richTextBoxLeft;
		private System.Windows.Forms.Button CompareButton;
		private System.Windows.Forms.TextBox ResultTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button FindDuplicatesButton;
		private System.Windows.Forms.TextBox ThresholdTextBox;
		private System.Windows.Forms.Label label4;
	}
}

