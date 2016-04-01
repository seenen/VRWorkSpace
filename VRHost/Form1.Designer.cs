namespace VRHost
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
            this.MemWriteInit = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MemReadInit = new System.Windows.Forms.Button();
            this.Read = new System.Windows.Forms.Button();
            this.writeView = new System.Windows.Forms.ListView();
            this.readView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemWriteInit
            // 
            this.MemWriteInit.Location = new System.Drawing.Point(45, 53);
            this.MemWriteInit.Name = "MemWriteInit";
            this.MemWriteInit.Size = new System.Drawing.Size(75, 23);
            this.MemWriteInit.TabIndex = 0;
            this.MemWriteInit.Text = "启动";
            this.MemWriteInit.UseVisualStyleBackColor = true;
            this.MemWriteInit.Click += new System.EventHandler(this.MemWriteInit_Click);
            // 
            // Write
            // 
            this.Write.Location = new System.Drawing.Point(45, 123);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 23);
            this.Write.TabIndex = 1;
            this.Write.Text = "写入";
            this.Write.UseVisualStyleBackColor = true;
            this.Write.Click += new System.EventHandler(this.Write_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.writeView);
            this.groupBox1.Controls.Add(this.MemWriteInit);
            this.groupBox1.Controls.Add(this.Write);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 216);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内存写对象";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readView);
            this.groupBox2.Controls.Add(this.MemReadInit);
            this.groupBox2.Controls.Add(this.Read);
            this.groupBox2.Location = new System.Drawing.Point(12, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 253);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内存读对象";
            // 
            // MemReadInit
            // 
            this.MemReadInit.Location = new System.Drawing.Point(45, 53);
            this.MemReadInit.Name = "MemReadInit";
            this.MemReadInit.Size = new System.Drawing.Size(75, 23);
            this.MemReadInit.TabIndex = 0;
            this.MemReadInit.Text = "启动";
            this.MemReadInit.UseVisualStyleBackColor = true;
            this.MemReadInit.Click += new System.EventHandler(this.MemWriteInit_Click);
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(45, 123);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 1;
            this.Read.Text = "读取";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // writeView
            // 
            this.writeView.Location = new System.Drawing.Point(339, 53);
            this.writeView.Name = "writeView";
            this.writeView.Size = new System.Drawing.Size(294, 140);
            this.writeView.TabIndex = 2;
            this.writeView.UseCompatibleStateImageBehavior = false;
            // 
            // readView
            // 
            this.readView.Location = new System.Drawing.Point(339, 53);
            this.readView.Name = "readView";
            this.readView.Size = new System.Drawing.Size(294, 140);
            this.readView.TabIndex = 2;
            this.readView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MemWriteInit;
        private System.Windows.Forms.Button Write;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button MemReadInit;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.ListView writeView;
        private System.Windows.Forms.ListView readView;
    }
}

