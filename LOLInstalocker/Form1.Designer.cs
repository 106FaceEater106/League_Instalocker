﻿
namespace LOLInstalocker
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
            this.label1 = new System.Windows.Forms.Label();
            this.CHAMPION = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ROLE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.START = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "LEAGUE INSTALOCKER";
            // 
            // CHAMPION
            // 
            this.CHAMPION.Location = new System.Drawing.Point(88, 139);
            this.CHAMPION.Name = "CHAMPION";
            this.CHAMPION.Size = new System.Drawing.Size(172, 20);
            this.CHAMPION.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(151, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Champion";
            // 
            // ROLE
            // 
            this.ROLE.Location = new System.Drawing.Point(88, 192);
            this.ROLE.Name = "ROLE";
            this.ROLE.Size = new System.Drawing.Size(172, 20);
            this.ROLE.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(160, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Role";
            // 
            // START
            // 
            this.START.Location = new System.Drawing.Point(134, 268);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(75, 23);
            this.START.TabIndex = 7;
            this.START.Text = "Start";
            this.START.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(350, 391);
            this.Controls.Add(this.START);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ROLE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CHAMPION);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Instalocker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CHAMPION;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ROLE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button START;
    }
}
