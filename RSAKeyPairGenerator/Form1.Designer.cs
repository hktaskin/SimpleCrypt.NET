namespace RSAKeyPairGenerator
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
            this.btnGeneratePair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublic = new System.Windows.Forms.TextBox();
            this.txtPrivate = new System.Windows.Forms.TextBox();
            this.btnCopyPublic = new System.Windows.Forms.Button();
            this.btnCopyPrivate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGeneratePair
            // 
            this.btnGeneratePair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeneratePair.Location = new System.Drawing.Point(12, 12);
            this.btnGeneratePair.Name = "btnGeneratePair";
            this.btnGeneratePair.Size = new System.Drawing.Size(246, 31);
            this.btnGeneratePair.TabIndex = 0;
            this.btnGeneratePair.Text = "Generate Key Pair";
            this.btnGeneratePair.UseVisualStyleBackColor = true;
            this.btnGeneratePair.Click += new System.EventHandler(this.btnGeneratePair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "PUBLIC KEY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(233, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PRIVATE KEY";
            // 
            // txtPublic
            // 
            this.txtPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublic.BackColor = System.Drawing.Color.White;
            this.txtPublic.Location = new System.Drawing.Point(12, 78);
            this.txtPublic.Multiline = true;
            this.txtPublic.Name = "txtPublic";
            this.txtPublic.ReadOnly = true;
            this.txtPublic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublic.Size = new System.Drawing.Size(219, 398);
            this.txtPublic.TabIndex = 3;
            // 
            // txtPrivate
            // 
            this.txtPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivate.BackColor = System.Drawing.Color.White;
            this.txtPrivate.Location = new System.Drawing.Point(237, 78);
            this.txtPrivate.Multiline = true;
            this.txtPrivate.Name = "txtPrivate";
            this.txtPrivate.ReadOnly = true;
            this.txtPrivate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivate.Size = new System.Drawing.Size(461, 398);
            this.txtPrivate.TabIndex = 4;
            // 
            // btnCopyPublic
            // 
            this.btnCopyPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyPublic.Location = new System.Drawing.Point(12, 482);
            this.btnCopyPublic.Name = "btnCopyPublic";
            this.btnCopyPublic.Size = new System.Drawing.Size(137, 23);
            this.btnCopyPublic.TabIndex = 5;
            this.btnCopyPublic.Text = "Copy to Clipboard";
            this.btnCopyPublic.UseVisualStyleBackColor = true;
            this.btnCopyPublic.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCopyPrivate
            // 
            this.btnCopyPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyPrivate.Location = new System.Drawing.Point(561, 482);
            this.btnCopyPrivate.Name = "btnCopyPrivate";
            this.btnCopyPrivate.Size = new System.Drawing.Size(137, 23);
            this.btnCopyPrivate.TabIndex = 6;
            this.btnCopyPrivate.Text = "Copy to Clipboard";
            this.btnCopyPrivate.UseVisualStyleBackColor = true;
            this.btnCopyPrivate.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 515);
            this.Controls.Add(this.btnCopyPrivate);
            this.Controls.Add(this.btnCopyPublic);
            this.Controls.Add(this.txtPrivate);
            this.Controls.Add(this.txtPublic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeneratePair);
            this.Name = "Form1";
            this.Text = "RSA Key Pair Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneratePair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublic;
        private System.Windows.Forms.TextBox txtPrivate;
        private System.Windows.Forms.Button btnCopyPublic;
        private System.Windows.Forms.Button btnCopyPrivate;
    }
}

