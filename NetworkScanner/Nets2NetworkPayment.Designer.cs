namespace RetailPlan.POS.NETS
{
    partial class Nets2NetworkPayment
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
            this.components = new System.ComponentModel.Container();
            this.pnlBodyMain = new System.Windows.Forms.Panel();
            this.butCancel = new System.Windows.Forms.Button();
            this.picNets = new System.Windows.Forms.PictureBox();
            this.lblPayBy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAmountToPay = new System.Windows.Forms.Label();
            this.lblAmountToPayText = new System.Windows.Forms.Label();
            this.pnlBodyBottom = new System.Windows.Forms.Panel();
            this.pnlBodyRgtHdr = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlBodyMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNets)).BeginInit();
            this.pnlBodyRgtHdr.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBodyMain
            // 
            this.pnlBodyMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.pnlBodyMain.Controls.Add(this.butCancel);
            this.pnlBodyMain.Controls.Add(this.picNets);
            this.pnlBodyMain.Controls.Add(this.lblPayBy);
            this.pnlBodyMain.Controls.Add(this.label2);
            this.pnlBodyMain.Controls.Add(this.lblAmountToPay);
            this.pnlBodyMain.Controls.Add(this.lblAmountToPayText);
            this.pnlBodyMain.Controls.Add(this.pnlBodyBottom);
            this.pnlBodyMain.Controls.Add(this.pnlBodyRgtHdr);
            this.pnlBodyMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBodyMain.Location = new System.Drawing.Point(0, 0);
            this.pnlBodyMain.Margin = new System.Windows.Forms.Padding(9, 62, 4, 4);
            this.pnlBodyMain.Name = "pnlBodyMain";
            this.pnlBodyMain.Size = new System.Drawing.Size(1191, 838);
            this.pnlBodyMain.TabIndex = 8;
            // 
            // butCancel
            // 
            this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCancel.Location = new System.Drawing.Point(1045, 763);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(133, 71);
            this.butCancel.TabIndex = 68;
            this.butCancel.Text = "Close";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Visible = false;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // picNets
            // 
            this.picNets.Image = global::RetailPlan.Properties.Resources.ICT250_NETS;
            this.picNets.Location = new System.Drawing.Point(105, 281);
            this.picNets.Margin = new System.Windows.Forms.Padding(4);
            this.picNets.Name = "picNets";
            this.picNets.Size = new System.Drawing.Size(1028, 558);
            this.picNets.TabIndex = 67;
            this.picNets.TabStop = false;
            // 
            // lblPayBy
            // 
            this.lblPayBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayBy.ForeColor = System.Drawing.Color.Green;
            this.lblPayBy.Location = new System.Drawing.Point(632, 188);
            this.lblPayBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayBy.Name = "lblPayBy";
            this.lblPayBy.Size = new System.Drawing.Size(543, 66);
            this.lblPayBy.TabIndex = 66;
            this.lblPayBy.Text = "NETS";
            this.lblPayBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.label2.Location = new System.Drawing.Point(116, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 69);
            this.label2.TabIndex = 65;
            this.label2.Text = "Pay By";
            // 
            // lblAmountToPay
            // 
            this.lblAmountToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountToPay.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblAmountToPay.Location = new System.Drawing.Point(737, 82);
            this.lblAmountToPay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountToPay.Name = "lblAmountToPay";
            this.lblAmountToPay.Size = new System.Drawing.Size(341, 57);
            this.lblAmountToPay.TabIndex = 64;
            this.lblAmountToPay.Text = "0.00";
            this.lblAmountToPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountToPayText
            // 
            this.lblAmountToPayText.AutoSize = true;
            this.lblAmountToPayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lblAmountToPayText.Location = new System.Drawing.Point(116, 71);
            this.lblAmountToPayText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountToPayText.Name = "lblAmountToPayText";
            this.lblAmountToPayText.Size = new System.Drawing.Size(421, 69);
            this.lblAmountToPayText.TabIndex = 63;
            this.lblAmountToPayText.Text = "Amount to Pay";
            // 
            // pnlBodyBottom
            // 
            this.pnlBodyBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBodyBottom.Location = new System.Drawing.Point(0, 826);
            this.pnlBodyBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBodyBottom.Name = "pnlBodyBottom";
            this.pnlBodyBottom.Size = new System.Drawing.Size(1191, 12);
            this.pnlBodyBottom.TabIndex = 9;
            // 
            // pnlBodyRgtHdr
            // 
            this.pnlBodyRgtHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(228)))), ((int)(((byte)(247)))));
            this.pnlBodyRgtHdr.Controls.Add(this.lblStatus);
            this.pnlBodyRgtHdr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBodyRgtHdr.Location = new System.Drawing.Point(0, 0);
            this.pnlBodyRgtHdr.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBodyRgtHdr.Name = "pnlBodyRgtHdr";
            this.pnlBodyRgtHdr.Size = new System.Drawing.Size(1191, 48);
            this.pnlBodyRgtHdr.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1191, 48);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrStatus
            // 
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // NetsPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 838);
            this.Controls.Add(this.pnlBodyMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetsPayment";
            this.Text = "Nets Payment";
            this.Load += new System.EventHandler(this.NetsPayment_Load);
            this.pnlBodyMain.ResumeLayout(false);
            this.pnlBodyMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNets)).EndInit();
            this.pnlBodyRgtHdr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBodyMain;
        private System.Windows.Forms.PictureBox picNets;
        private System.Windows.Forms.Label lblPayBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAmountToPay;
        private System.Windows.Forms.Label lblAmountToPayText;
        private System.Windows.Forms.Panel pnlBodyBottom;
        private System.Windows.Forms.Panel pnlBodyRgtHdr;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Timer tmrStatus;
    }
}