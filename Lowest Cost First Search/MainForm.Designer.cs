namespace Lowest_Cost_First_Search
{
    partial class MainForm
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
            this.StartNodeTextBox = new System.Windows.Forms.TextBox();
            this.EndNodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShortestPathButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // StartNodeTextBox
            // 
            this.StartNodeTextBox.Location = new System.Drawing.Point(79, 13);
            this.StartNodeTextBox.Name = "StartNodeTextBox";
            this.StartNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartNodeTextBox.TabIndex = 0;
            // 
            // EndNodeTextBox
            // 
            this.EndNodeTextBox.Location = new System.Drawing.Point(79, 39);
            this.EndNodeTextBox.Name = "EndNodeTextBox";
            this.EndNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.EndNodeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Node:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Node:";
            // 
            // ShortestPathButton
            // 
            this.ShortestPathButton.Location = new System.Drawing.Point(12, 65);
            this.ShortestPathButton.Name = "ShortestPathButton";
            this.ShortestPathButton.Size = new System.Drawing.Size(167, 23);
            this.ShortestPathButton.TabIndex = 4;
            this.ShortestPathButton.Text = "Find Shortest";
            this.ShortestPathButton.UseVisualStyleBackColor = true;
            this.ShortestPathButton.Click += new System.EventHandler(this.ShortestPathButton_Clicked);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 95);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(167, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "Click anywhere to create a new node, then give it a name in the pop up. To create" +
    " a path, please click one of the nodes, then the node you want to join it too, t" +
    "hen give it a distance.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ShortestPathButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndNodeTextBox);
            this.Controls.Add(this.StartNodeTextBox);
            this.Name = "Form1";
            this.Text = "Lowest Cost First Search";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawEdges);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CreateNode);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StartNodeTextBox;
        private System.Windows.Forms.TextBox EndNodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShortestPathButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

