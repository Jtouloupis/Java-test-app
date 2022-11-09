
namespace EkpaideytikoLogismiko
{
    partial class ResultsForm
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
            this.resultTitle = new System.Windows.Forms.Label();
            this.questionTXT = new System.Windows.Forms.RichTextBox();
            this.correctLBL = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.explanationTXT = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nextBTN = new System.Windows.Forms.PictureBox();
            this.backBTN = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBTN)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultTitle
            // 
            this.resultTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTitle.Font = new System.Drawing.Font("Arial", 24.856F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.resultTitle.ForeColor = System.Drawing.Color.White;
            this.resultTitle.Location = new System.Drawing.Point(13, 12);
            this.resultTitle.Name = "resultTitle";
            this.resultTitle.Size = new System.Drawing.Size(894, 63);
            this.resultTitle.TabIndex = 19;
            this.resultTitle.Text = "Results";
            this.resultTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionTXT
            // 
            this.questionTXT.BackColor = System.Drawing.Color.Wheat;
            this.questionTXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionTXT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.questionTXT.Font = new System.Drawing.Font("Arial", 13.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.questionTXT.Location = new System.Drawing.Point(33, 247);
            this.questionTXT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.questionTXT.Name = "questionTXT";
            this.questionTXT.ReadOnly = true;
            this.questionTXT.Size = new System.Drawing.Size(855, 164);
            this.questionTXT.TabIndex = 20;
            this.questionTXT.Text = "question , explanation";
            // 
            // correctLBL
            // 
            this.correctLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctLBL.Font = new System.Drawing.Font("Arial", 17.856F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.correctLBL.ForeColor = System.Drawing.Color.White;
            this.correctLBL.Location = new System.Drawing.Point(53, 37);
            this.correctLBL.Name = "correctLBL";
            this.correctLBL.Size = new System.Drawing.Size(814, 65);
            this.correctLBL.TabIndex = 21;
            this.correctLBL.Text = "right answers: 5/10";
            this.correctLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 63);
            this.button1.TabIndex = 23;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // explanationTXT
            // 
            this.explanationTXT.BackColor = System.Drawing.Color.Wheat;
            this.explanationTXT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.explanationTXT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.explanationTXT.Font = new System.Drawing.Font("Arial", 13.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.explanationTXT.Location = new System.Drawing.Point(33, 457);
            this.explanationTXT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.explanationTXT.Name = "explanationTXT";
            this.explanationTXT.ReadOnly = true;
            this.explanationTXT.Size = new System.Drawing.Size(855, 202);
            this.explanationTXT.TabIndex = 26;
            this.explanationTXT.Text = "question , explanation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.resultTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panel1.Size = new System.Drawing.Size(920, 87);
            this.panel1.TabIndex = 27;
            // 
            // nextBTN
            // 
            this.nextBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.nextBTN.Image = global::EkpaideytikoLogismiko.Properties.Resources.next_arrow;
            this.nextBTN.Location = new System.Drawing.Point(775, 37);
            this.nextBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextBTN.Name = "nextBTN";
            this.nextBTN.Size = new System.Drawing.Size(92, 65);
            this.nextBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextBTN.TabIndex = 28;
            this.nextBTN.TabStop = false;
            this.nextBTN.Click += new System.EventHandler(this.nextBTN_Click);
            // 
            // backBTN
            // 
            this.backBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.backBTN.Image = global::EkpaideytikoLogismiko.Properties.Resources.back_arrow;
            this.backBTN.Location = new System.Drawing.Point(53, 37);
            this.backBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBTN.Name = "backBTN";
            this.backBTN.Size = new System.Drawing.Size(92, 65);
            this.backBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backBTN.TabIndex = 29;
            this.backBTN.TabStop = false;
            this.backBTN.Click += new System.EventHandler(this.backBTN_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.backBTN);
            this.panel2.Controls.Add(this.nextBTN);
            this.panel2.Controls.Add(this.correctLBL);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(53, 37, 53, 12);
            this.panel2.Size = new System.Drawing.Size(920, 114);
            this.panel2.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 20.16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 41);
            this.label2.TabIndex = 31;
            this.label2.Text = "Question:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 20.16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 415);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 41);
            this.label3.TabIndex = 32;
            this.label3.Text = "Explanation:";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(920, 673);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.explanationTXT);
            this.Controls.Add(this.questionTXT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(920, 673);
            this.MinimumSize = new System.Drawing.Size(920, 673);
            this.Name = "ResultsForm";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nextBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBTN)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultTitle;
        private System.Windows.Forms.RichTextBox questionTXT;
        private System.Windows.Forms.Label correctLBL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox explanationTXT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox nextBTN;
        private System.Windows.Forms.PictureBox backBTN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}