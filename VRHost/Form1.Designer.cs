﻿namespace VRHost
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
            this.PersistentWrite = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WriteObj = new System.Windows.Forms.Button();
            this.WriteBat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PersistentRead = new System.Windows.Forms.Button();
            this.Read = new System.Windows.Forms.Button();
            this.writeView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadObj = new System.Windows.Forms.Button();
            this.MemReadInit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PipeStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersistentWrite
            // 
            this.PersistentWrite.Location = new System.Drawing.Point(137, 33);
            this.PersistentWrite.Name = "PersistentWrite";
            this.PersistentWrite.Size = new System.Drawing.Size(75, 23);
            this.PersistentWrite.TabIndex = 0;
            this.PersistentWrite.Text = "持久化 写";
            this.PersistentWrite.UseVisualStyleBackColor = true;
            this.PersistentWrite.Click += new System.EventHandler(this.MemWriteInit_Click);
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(137, 62);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 23);
            this.Write.TabIndex = 1;
            this.Write.Text = "写入";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WriteObj);
            this.groupBox1.Controls.Add(this.WriteBat);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PersistentRead);
            this.groupBox1.Controls.Add(this.PersistentWrite);
            this.groupBox1.Controls.Add(this.Read);
            this.groupBox1.Controls.Add(this.Write);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 245);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内存写对象";
            // 
            // WriteObj
            // 
            this.WriteObj.Location = new System.Drawing.Point(252, 91);
            this.WriteObj.Name = "WriteObj";
            this.WriteObj.Size = new System.Drawing.Size(75, 23);
            this.WriteObj.TabIndex = 4;
            this.WriteObj.Text = "写一个obj文件";
            this.WriteObj.UseVisualStyleBackColor = true;
            this.WriteObj.Click += new System.EventHandler(this.WriteObj_Click);
            // 
            // WriteBat
            // 
            this.WriteBat.Location = new System.Drawing.Point(137, 120);
            this.WriteBat.Name = "WriteBat";
            this.WriteBat.Size = new System.Drawing.Size(75, 23);
            this.WriteBat.TabIndex = 3;
            this.WriteBat.Text = "写一批对象";
            this.WriteBat.UseVisualStyleBackColor = true;
            this.WriteBat.Click += new System.EventHandler(this.WriteBat_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "写一个对象";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "持久化内存";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "批量读写";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "持久化内存另一个写法";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "非持久化内存";
            // 
            // PersistentRead
            // 
            this.PersistentRead.Location = new System.Drawing.Point(252, 33);
            this.PersistentRead.Name = "PersistentRead";
            this.PersistentRead.Size = new System.Drawing.Size(75, 23);
            this.PersistentRead.TabIndex = 0;
            this.PersistentRead.Text = "持久化读";
            this.PersistentRead.UseVisualStyleBackColor = true;
            this.PersistentRead.Click += new System.EventHandler(this.MemWriteInit_Click);
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(252, 62);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 1;
            this.Read.Text = "读取";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // writeView
            // 
            this.writeView.Location = new System.Drawing.Point(424, 88);
            this.writeView.Name = "writeView";
            this.writeView.Size = new System.Drawing.Size(294, 354);
            this.writeView.TabIndex = 2;
            this.writeView.UseCompatibleStateImageBehavior = false;
            this.writeView.View = System.Windows.Forms.View.List;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadObj);
            this.groupBox2.Controls.Add(this.MemReadInit);
            this.groupBox2.Location = new System.Drawing.Point(12, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 129);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内存读对象";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // ReadObj
            // 
            this.ReadObj.Location = new System.Drawing.Point(252, 46);
            this.ReadObj.Name = "ReadObj";
            this.ReadObj.Size = new System.Drawing.Size(75, 23);
            this.ReadObj.TabIndex = 1;
            this.ReadObj.Text = "读一个obj文件";
            this.ReadObj.UseVisualStyleBackColor = true;
            this.ReadObj.Click += new System.EventHandler(this.ReadObj_Click);
            // 
            // MemReadInit
            // 
            this.MemReadInit.Location = new System.Drawing.Point(137, 46);
            this.MemReadInit.Name = "MemReadInit";
            this.MemReadInit.Size = new System.Drawing.Size(75, 23);
            this.MemReadInit.TabIndex = 0;
            this.MemReadInit.Text = "读一个对象";
            this.MemReadInit.UseVisualStyleBackColor = true;
            this.MemReadInit.Click += new System.EventHandler(this.MemWriteInit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PipeStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 420);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 129);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "管道";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // PipeStart
            // 
            this.PipeStart.Location = new System.Drawing.Point(137, 20);
            this.PipeStart.Name = "PipeStart";
            this.PipeStart.Size = new System.Drawing.Size(75, 23);
            this.PipeStart.TabIndex = 0;
            this.PipeStart.Text = "启动管道";
            this.PipeStart.UseVisualStyleBackColor = true;
            this.PipeStart.Click += new System.EventHandler(this.PipeStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.writeView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PersistentWrite;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button MemReadInit;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.ListView writeView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PersistentRead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button WriteObj;
        private System.Windows.Forms.Button ReadObj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button WriteBat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PipeStart;
    }
}

