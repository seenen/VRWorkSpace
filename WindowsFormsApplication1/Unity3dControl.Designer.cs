namespace WindowsFormsApplication1
{
    partial class Unity3dControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Unity3dControl));
            this.axUnityWebPlayer1 = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axUnityWebPlayer1
            // 
            this.axUnityWebPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axUnityWebPlayer1.Enabled = true;
            this.axUnityWebPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axUnityWebPlayer1.Name = "axUnityWebPlayer1";
            this.axUnityWebPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnityWebPlayer1.OcxState")));
            this.axUnityWebPlayer1.Size = new System.Drawing.Size(150, 150);
            this.axUnityWebPlayer1.TabIndex = 0;
            // 
            // Unity3dControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axUnityWebPlayer1);
            this.Name = "Unity3dControl";
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxUnityWebPlayerAXLib.AxUnityWebPlayer axUnityWebPlayer1;
    }
}
