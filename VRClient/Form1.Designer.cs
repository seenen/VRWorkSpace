namespace VRClient
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
            this.unity3dControl1 = new VRClient.Unity3dControl();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.readView = new System.Windows.Forms.ListView();
            this.Read = new System.Windows.Forms.Button();
            this.ReadMMF = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // unity3dControl1
            // 
            this.unity3dControl1.Location = new System.Drawing.Point(460, 12);
            this.unity3dControl1.Name = "unity3dControl1";
            this.unity3dControl1.Size = new System.Drawing.Size(760, 333);
            this.unity3dControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.readView);
            this.groupBox2.Controls.Add(this.ReadMMF);
            this.groupBox2.Controls.Add(this.Read);
            this.groupBox2.Location = new System.Drawing.Point(460, 470);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 253);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内存读对象";
            // 
            // readView
            // 
            this.readView.Location = new System.Drawing.Point(339, 53);
            this.readView.Name = "readView";
            this.readView.Size = new System.Drawing.Size(294, 140);
            this.readView.TabIndex = 2;
            this.readView.UseCompatibleStateImageBehavior = false;
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(54, 78);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 1;
            this.Read.Text = "读取";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // ReadMMF
            // 
            this.ReadMMF.Location = new System.Drawing.Point(54, 156);
            this.ReadMMF.Name = "ReadMMF";
            this.ReadMMF.Size = new System.Drawing.Size(75, 23);
            this.ReadMMF.TabIndex = 1;
            this.ReadMMF.Text = "读一个对象";
            this.ReadMMF.UseVisualStyleBackColor = true;
            this.ReadMMF.Click += new System.EventHandler(this.ReadMMF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 747);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unity3dControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Unity3dControl unity3dControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView readView;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.Button ReadMMF;
    }
}

