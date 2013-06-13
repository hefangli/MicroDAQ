﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MicroDAQ
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
             InitializeComponent();                   
           
        }
        SqlConnection connection = new SqlConnection(Program.DatabaseManager.ConnectionString);            
        private void btnInstant_Click(object sender, EventArgs e)
        {
            //显示即时数据
            ShowItems();
        }
        /// <summary>
        /// PLC与OPCMES即时数据的显示
        /// </summary>
        DataTable dtItems = null;
        public void ShowItems()
        {            
            //PLC关闭的情况            
            if (Program.M.ConnectionState != ConnectionState.Open)
            {                
                MessageBox.Show("PLC连接失败，尚未加载PLC数据！");
                return;
            }
            else
            {            
               if (connection.State == ConnectionState.Open)
               {
                   this.labDBState.BackColor = Color.Green;
                   this.labDBState.ForeColor = Color.White;
                   this.labDBState.Text = "通信正常";

                   this.labOPCState.BackColor = Color.Green;
                   this.labOPCState.ForeColor = Color.White;
                   this.labOPCState.Text = "通信正常";

                   string sql = @"SELECT v.id AS 参数ID,
                                       p.name AS 参数名称,
                                       t.name AS 参数类型,
                                       v.value1 AS 采集值1,
                                       v.value2 AS 采集值2,
                                       v.value3 AS 采集值3,
                                       p.unit AS 单位,
                                       v.time AS 刷新时间,
                                       v.zztime AS 存储点
                        FROM ProcessItem p 
                        LEFT JOIN meter_uuid m ON p.id = m.uuid 
                        LEFT JOIN meter_type t ON p.protocolType = t.protocol 
                        RIGHT JOIN meters_value v ON m.id = v.id 
                        ORDER BY v.id ";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);                    
                    
                        dtItems = new DataTable();
                        dtItems.Columns.AddRange(new DataColumn[]{
                        new DataColumn("参数ID"),
                        new DataColumn("参数名称"),
                        new DataColumn("参数类型"),
                        new DataColumn("数据采集值1"),
                        new DataColumn("PLC数据值1"),
                        new DataColumn("数据采集值2"),
                        new DataColumn("数据采集值3"),
                        new DataColumn("单位"),
                        new DataColumn("刷新时间"),
                        new DataColumn("存储点"),             
                        new DataColumn("PLC设备类型"),
                        new DataColumn("PLC状态"),
                        new DataColumn("PLC可信度") });            
                                    

                        for (int i = 0; i < dt.Rows.Count; i++)
                        //for (int i = 0; i < Program.M.Items.Count; i++)
                        {
                             DataRow row = dtItems.NewRow();
                             DataItem meter = Program.M.Items[i];
                             DataRow tmp = dt.Rows[i];

                             row["参数ID"] = tmp[0].ToString();
                             row["参数名称"] = tmp[1].ToString();
                             row["参数类型"] = tmp[2].ToString();
                             row["数据采集值1"] = tmp[3].ToString();
                             row["PLC数据值1"] = meter.Value.ToString();
                           // row["PLC数据值1"] = 1;
                             row["数据采集值2"] = tmp[4].ToString();
                             row["数据采集值3"] = tmp[5].ToString();
                             row["单位"] = tmp[6].ToString();
                             row["刷新时间"] = tmp[7].ToString();

                             row["PLC设备类型"] = meter.Type.ToString();
                             row["PLC状态"] = meter.State.ToString();
                             row["plc可信度"] = meter.Quality.ToString();

                            //row["PLC设备类型"] = 1;
                            //row["PLC状态"] = 1;
                            //row["plc可信度"] = 192;

                             dtItems.Rows.Add(row);
                             dgvDB.DataSource = dtItems;
                             dgvDB.Columns["刷新时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
                             dgvDB.Columns["存储点"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";

                            //比较数据是否相等，如果不相等数据背景色改变
                            for (int j = 0; j < dgvDB.Rows.Count; j++)
                            {
                                string a = this.dgvDB.Rows[j].Cells[3].Value.ToString();
                                string b = this.dgvDB.Rows[j].Cells[4].Value.ToString();
                                if (a != b)
                                {
                                    this.dgvDB.Rows[j].Cells[3].Style.BackColor = Color.Red;
                                    this.dgvDB.Rows[j].Cells[4].Style.BackColor = Color.Red;
                                }

                            }
                        }
                        //dtItems.Columns.Clear(); 

                    }

                    else
                    {
                        
                            this.labOPCState.BackColor = Color.Green;
                            this.labOPCState.ForeColor = Color.White;
                            this.labOPCState.Text = "通信正常";

                            this.labDBState.BackColor = Color.Red;
                            this.labDBState.ForeColor = Color.Yellow;
                            this.labDBState.Text = "通信错误";

                            DataTable table = new DataTable();
                            table.Columns.AddRange(new DataColumn[]{
                            new DataColumn("PLC数据值1"),
                            new DataColumn("PLC设备类型"),
                            new DataColumn("PLC状态"),
                            new DataColumn("PLC可信度")});
                            DataRow row = table.NewRow();
                            //row["PLC数据值1"] = 1;
                            //row["PLC设备类型"] = 1;
                            //row["PLC状态"] = 1;
                            //row["plc可信度"] = 192;
                            //table.Rows.Add(row);
                            //this.dgvDB.DataSource = table;    
                            if (Program.M == null)
                            {
                                MessageBox.Show("尚未加载plc数据！");
                                return;
                            }
                            else
                            {
                                foreach (var item in Program.M.Items)
                                {
                                    DataItem meter = item as DataItem;
                                    row["plc编号"] = meter.ID.ToString();
                                    row["plc数据值1"] = meter.Value.ToString();
                                    row["plc设备类型"] = meter.Type.ToString();
                                    row["plc状态"] = meter.State.ToString();
                                    row["plc可信度"] = meter.Quality.ToString();
                                    table.Rows.Add(row);
                                }
                                this.dgvDB.DataSource = table;
                            }

                            if (Program.M_flowAlert.Items != null)
                            {
                                foreach (var item in Program.M_flowAlert.Items)
                                {
                                    DataItem meter = item as DataItem;
                                    row["plc编号"] = meter.ID.ToString();
                                    row["plc数据值1"] = meter.Value.ToString();
                                    row["plc设备类型"] = meter.Type.ToString();
                                    row["plc状态"] = meter.State.ToString();
                                    row["plc可信度"] = meter.Quality.ToString();
                                    table.Rows.Add(row);
                                }
                                this.dgvDB.DataSource = table;

                            }
                                        
                                                
                    }          
                                                      

              }       
                   
              

       }
        /// <summary>
        /// 加载form窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void FormDemo_Load(object sender, EventArgs e)
        {           
           
            //数据库连接的情况
            //connection.Open();
            //plc连接情况
            //Program.M.Connect(); 
            bkwConnect.DoWork += new DoWorkEventHandler(bkwConnect_DoWork);
            bkwConnect.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bkwConnect_RunWorkerCompleted);
            bkwConnect.RunWorkerAsync();            
           
            if(Program.RemoteCycle != null)
            Program.RemoteCycle.SetPause = true;               
                      
        }   
        //打开数据库连接
        void bkwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               connection.Open();
            }
            catch
            { }

        }

        void bkwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ShowItems();
            ShowDB();
            GetOder();

        }
        /// <summary>
        /// 指令查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void button1_Click(object sender, EventArgs e)
        {
            GetOder();
        }
        /// <summary>
        /// 指令查询
        /// </summary>
        public void GetOder()
        {
            if (connection.State == ConnectionState.Open)
            {
                this.labDBState2.BackColor = Color.Green;
                this.labDBState2.ForeColor = Color.White;
                this.labDBState2.Text = "通信正常";
                string selectRemoteControl = @"select id as 编号,name as 名称,code as 编码,slave as 控制 ,cycle ,ip as ip地址 ,port as 端口,type as 类型,command as 命令,cmdstate as 命令状态,remainSecond ,state as 状态 from RemoteControl";
                SqlDataAdapter adapter = new SqlDataAdapter(selectRemoteControl, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                this.dataGridView3.DataSource = dt;
            }
            else
            {
                this.labDBState2.BackColor = Color.Red;
                this.labDBState2.ForeColor = Color.Yellow;
                this.labDBState2.Text = "通信错误";
            }

        }
        /// <summary>
        /// 测试报警灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int initSlave = 200;
        private int alarmIndex = 0;
        private List<AlarmControl> alarms=new List<AlarmControl>();
      
        private AlarmControl AddAlarm(int slave, byte alertCode)
        {            
            AlarmControl alarm = new AlarmControl(slave, alertCode);
            alarms.Add(alarm);            
            this.tabPage2.Controls.Add(alarm);
            return alarm;
        }
        private void RemoveAlarm()
        {           
            AlarmControl alarm = alarms[alarms.Count - 1];            
            this.tabPage2.Controls.Remove(alarm);
            alarms.RemoveAt(alarms.Count - 1);
            alarm.Dispose();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AlarmControl alarm = AddAlarm(alarmIndex++ + initSlave, 0);
            alarm.Location = new Point(30, 40 + 29 * alarmIndex);           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveAlarm();
            alarmIndex--;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int slave;
            int.TryParse(this.textBox1.Text, out slave);
            this.initSlave = slave;
        }
        int runningNum = 0;
        int ctrlIndex = 0;
        private void tmrRemoteCtrl_Tick(object sender, EventArgs e)
        {            
            if (this.alarms.Count > 0)
            {
                AlarmControl alarm = this.alarms[ctrlIndex % this.alarms.Count];
                ctrlIndex++;
                foreach (var mt in Program.MeterManager.CTMeters.Values)
                {
                    runningNum = ++runningNum % ushort.MaxValue;
                    mt.SetCommand(runningNum, alarm.Slave, 1, (int)alarm.AlertCode);
                }
            }
        }

        private void FormDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            try
            {
                connection.Close();               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Program.RemoteCycle != null)
                Program.RemoteCycle.SetPause = false;

        }

        /// <summary>
        /// 配置情况
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DataTable dt;
        private void ShowDB()
        {            
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    this.labDBState1.BackColor = Color.Green;
                    this.labDBState1.ForeColor = Color.White;
                    this.labDBState1.Text = "通信正常";
                    string sql = @"SELECT  m.id AS 参数ID,
                                    p.name AS 参数名称,
                                    t.name AS 参数类型,
                                    p.unit AS 单位,
                                    p.updateRate AS 存储频率,
                                    p.minimum AS 下限,
                                    p.maximum AS 上限,
                                    p.yellowMin AS 低警告,
                                    p.yellowMax AS 高警告  
                        FROM ProcessItem p 
                        LEFT JOIN meter_uuid m ON p.id = m.uuid 
                        LEFT JOIN meter_type t ON p.protocolType = t.protocol 
                        LEFT JOIN meters_value v ON m.id = v.id 
                        ORDER BY m.id ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);              
                dt = new DataTable();
                adapter.Fill(dt);
                this.dataGridView2.DataSource = dt;
                }
                else 
                {
                        this.labDBState1.BackColor = Color.Red;
                        this.labDBState1.ForeColor = Color.Yellow;
                        this.labDBState1.Text = "通信错误";

                }             


            }
            catch
            { };
         
        }      
        private void btnRefreshDB_Click(object sender, EventArgs e)
        {
             ShowDB();                        
        }                   



    }
}
