namespace DataDisplayForm2
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labOPCState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInstant = new System.Windows.Forms.Button();
            this.labDBState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.btnTestAlarm = new System.Windows.Forms.Button();
            this.btnRefreshDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            this.SuspendLayout();
            // 
            // labOPCState
            // 
            this.labOPCState.AutoSize = true;
            this.labOPCState.BackColor = System.Drawing.Color.Silver;
            this.labOPCState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOPCState.Location = new System.Drawing.Point(797, 193);
            this.labOPCState.Name = "labOPCState";
            this.labOPCState.Size = new System.Drawing.Size(65, 20);
            this.labOPCState.TabIndex = 26;
            this.labOPCState.Text = "状态未知";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(661, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "OPC通信状态";
            // 
            // btnInstant
            // 
            this.btnInstant.Location = new System.Drawing.Point(661, 96);
            this.btnInstant.Name = "btnInstant";
            this.btnInstant.Size = new System.Drawing.Size(107, 34);
            this.btnInstant.TabIndex = 29;
            this.btnInstant.Text = "数据显示";
            this.btnInstant.UseVisualStyleBackColor = true;
            this.btnInstant.Click += new System.EventHandler(this.btnInstant_Click);
            // 
            // labDBState
            // 
            this.labDBState.AutoSize = true;
            this.labDBState.BackColor = System.Drawing.Color.Silver;
            this.labDBState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDBState.Location = new System.Drawing.Point(797, 248);
            this.labDBState.Name = "labDBState";
            this.labDBState.Size = new System.Drawing.Size(65, 20);
            this.labDBState.TabIndex = 32;
            this.labDBState.Text = "状态未知";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(661, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "数据库通信状态";
            // 
            // dgvDB
            // 
            this.dgvDB.AllowUserToAddRows = false;
            this.dgvDB.AllowUserToDeleteRows = false;
            this.dgvDB.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvDB.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDB.Location = new System.Drawing.Point(28, 77);
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDB.RowHeadersVisible = false;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDB.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDB.RowTemplate.Height = 23;
            this.dgvDB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDB.Size = new System.Drawing.Size(607, 255);
            this.dgvDB.TabIndex = 35;
            // 
            // btnTestAlarm
            // 
            this.btnTestAlarm.Location = new System.Drawing.Point(661, 298);
            this.btnTestAlarm.Name = "btnTestAlarm";
            this.btnTestAlarm.Size = new System.Drawing.Size(107, 34);
            this.btnTestAlarm.TabIndex = 36;
            this.btnTestAlarm.Text = "测试报警灯";
            this.btnTestAlarm.UseVisualStyleBackColor = true;
            this.btnTestAlarm.Click += new System.EventHandler(this.btnTestAlarm_Click);
            // 
            // btnRefreshDB
            // 
            this.btnRefreshDB.Location = new System.Drawing.Point(801, 298);
            this.btnRefreshDB.Name = "btnRefreshDB";
            this.btnRefreshDB.Size = new System.Drawing.Size(107, 34);
            this.btnRefreshDB.TabIndex = 37;
            this.btnRefreshDB.Text = "配置情况";
            this.btnRefreshDB.UseVisualStyleBackColor = true;
            this.btnRefreshDB.Click += new System.EventHandler(this.btnRefreshDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 493);
            this.Controls.Add(this.btnRefreshDB);
            this.Controls.Add(this.btnTestAlarm);
            this.Controls.Add(this.dgvDB);
            this.Controls.Add(this.labDBState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labOPCState);
            this.Controls.Add(this.btnInstant);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labOPCState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInstant;
        private System.Windows.Forms.Label labDBState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.Button btnTestAlarm;
        private System.Windows.Forms.Button btnRefreshDB;
    }
}

