namespace SuperMes
{
    partial class SuperMesServer
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
            this.dgvOnLineInfo = new System.Windows.Forms.DataGridView();
            this.labOnLineCount = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnLineInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOnLineInfo
            // 
            this.dgvOnLineInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOnLineInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvOnLineInfo.Location = new System.Drawing.Point(0, 95);
            this.dgvOnLineInfo.Name = "dgvOnLineInfo";
            this.dgvOnLineInfo.RowTemplate.Height = 23;
            this.dgvOnLineInfo.Size = new System.Drawing.Size(924, 458);
            this.dgvOnLineInfo.TabIndex = 0;
            // 
            // labOnLineCount
            // 
            this.labOnLineCount.AutoSize = true;
            this.labOnLineCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOnLineCount.Location = new System.Drawing.Point(13, 27);
            this.labOnLineCount.Name = "labOnLineCount";
            this.labOnLineCount.Size = new System.Drawing.Size(55, 21);
            this.labOnLineCount.TabIndex = 1;
            this.labOnLineCount.Text = "label1";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(606, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 37);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动服务";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(731, 27);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 37);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止服务";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // SuperMesServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 553);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labOnLineCount);
            this.Controls.Add(this.dgvOnLineInfo);
            this.Name = "SuperMesServer";
            this.Text = "SuperMes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOnLineInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOnLineInfo;
        private System.Windows.Forms.Label labOnLineCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}

