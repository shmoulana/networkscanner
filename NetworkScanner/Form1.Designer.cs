﻿namespace NetworkScanner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdScan = new System.Windows.Forms.Button();
            this.listVAddr = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.cmdStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.conMenuStripIP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openNetworkFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.conMenuStripIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdScan
            // 
            this.cmdScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScan.Location = new System.Drawing.Point(996, 794);
            this.cmdScan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(205, 92);
            this.cmdScan.TabIndex = 0;
            this.cmdScan.Text = "Scan";
            this.cmdScan.UseVisualStyleBackColor = true;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // listVAddr
            // 
            this.listVAddr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listVAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listVAddr.HideSelection = false;
            this.listVAddr.Location = new System.Drawing.Point(147, 22);
            this.listVAddr.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listVAddr.Name = "listVAddr";
            this.listVAddr.Size = new System.Drawing.Size(1009, 711);
            this.listVAddr.TabIndex = 1;
            this.listVAddr.UseCompatibleStateImageBehavior = false;
            this.listVAddr.View = System.Windows.Forms.View.Details;
            this.listVAddr.SelectedIndexChanged += new System.EventHandler(this.listVAddr_SelectedIndexChanged);
            this.listVAddr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listVAddr_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hostname";
            this.columnHeader2.Width = 210;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 152;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(345, 748);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 68);
            this.panel2.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(79, 7);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 39);
            this.lblStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 757);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 42);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(310, 897);
            this.txtIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(310, 49);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.0.1";
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // cmdStop
            // 
            this.cmdStop.Enabled = false;
            this.cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStop.Location = new System.Drawing.Point(999, 897);
            this.cmdStop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(205, 92);
            this.cmdStop.TabIndex = 1;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(187, 1036);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(926, 68);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // conMenuStripIP
            // 
            this.conMenuStripIP.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.conMenuStripIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNetworkFolderToolStripMenuItem,
            this.showInfoToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.rebootToolStripMenuItem});
            this.conMenuStripIP.Name = "conMenuStripIP";
            this.conMenuStripIP.Size = new System.Drawing.Size(285, 148);
            // 
            // openNetworkFolderToolStripMenuItem
            // 
            this.openNetworkFolderToolStripMenuItem.Name = "openNetworkFolderToolStripMenuItem";
            this.openNetworkFolderToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
            this.openNetworkFolderToolStripMenuItem.Text = "Open Network Folder";
            this.openNetworkFolderToolStripMenuItem.Click += new System.EventHandler(this.openNetworkFolderToolStripMenuItem_Click);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(284, 36);
            this.rebootToolStripMenuItem.Text = "Reboot";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
            // 
            // txtIP2
            // 
            this.txtIP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP2.Location = new System.Drawing.Point(634, 897);
            this.txtIP2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(310, 49);
            this.txtIP2.TabIndex = 5;
            this.txtIP2.Text = "192.168.0.255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(541, 840);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 42);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP Range";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 1211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.txtIP2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.listVAddr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Network Scanner - Zac Reese";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.conMenuStripIP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.ListView listVAddr;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip conMenuStripIP;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNetworkFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.Label label1;
    }
}

