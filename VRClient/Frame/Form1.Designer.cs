﻿namespace VRClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.threadsendmessage = new System.Windows.Forms.Button();
            this.LoadAllVBO = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DeleteAllVBO = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.unity3dControl2 = new VRClient.Unity3dControl();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "测试消息发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // threadsendmessage
            // 
            this.threadsendmessage.Enabled = false;
            this.threadsendmessage.Location = new System.Drawing.Point(6, 49);
            this.threadsendmessage.Name = "threadsendmessage";
            this.threadsendmessage.Size = new System.Drawing.Size(197, 23);
            this.threadsendmessage.TabIndex = 5;
            this.threadsendmessage.Text = "2、线程发送到unity";
            this.threadsendmessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.threadsendmessage.UseVisualStyleBackColor = true;
            this.threadsendmessage.Click += new System.EventHandler(this.threadsendmessage_Click);
            // 
            // LoadAllVBO
            // 
            this.LoadAllVBO.Location = new System.Drawing.Point(6, 20);
            this.LoadAllVBO.Name = "LoadAllVBO";
            this.LoadAllVBO.Size = new System.Drawing.Size(197, 23);
            this.LoadAllVBO.TabIndex = 6;
            this.LoadAllVBO.Text = "1、加载所有文件到VBOBuffer";
            this.LoadAllVBO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadAllVBO.UseVisualStyleBackColor = true;
            this.LoadAllVBO.Click += new System.EventHandler(this.LoadAllVBO_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 55);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DeleteAllVBO);
            this.groupBox3.Controls.Add(this.threadsendmessage);
            this.groupBox3.Controls.Add(this.LoadAllVBO);
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 115);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试2";
            // 
            // DeleteAllVBO
            // 
            this.DeleteAllVBO.Enabled = false;
            this.DeleteAllVBO.Location = new System.Drawing.Point(6, 78);
            this.DeleteAllVBO.Name = "DeleteAllVBO";
            this.DeleteAllVBO.Size = new System.Drawing.Size(197, 23);
            this.DeleteAllVBO.TabIndex = 5;
            this.DeleteAllVBO.Text = "3、删除对象";
            this.DeleteAllVBO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteAllVBO.UseVisualStyleBackColor = true;
            this.DeleteAllVBO.Click += new System.EventHandler(this.DeleteAllVBO_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(12, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 163);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "北京联机调试";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "初始化一个胆囊拆除场景";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.ToolTipText = "Quit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // unity3dControl2
            // 
            this.unity3dControl2.Location = new System.Drawing.Point(344, 31);
            this.unity3dControl2.Name = "unity3dControl2";
            this.unity3dControl2.Size = new System.Drawing.Size(896, 547);
            this.unity3dControl2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 590);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.unity3dControl2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "VR系统";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Unity3dControl unity3dControl2;
        private System.Windows.Forms.Button threadsendmessage;
        private System.Windows.Forms.Button LoadAllVBO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DeleteAllVBO;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button2;
    }
}
