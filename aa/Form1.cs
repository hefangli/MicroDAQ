using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace aa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInstant_Click(object sender, EventArgs e)
        {
            ShowItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        DataTable dtItems = null;
        public void ShowItems()
        {
            dtItems.Columns.Clear();
            dtItems = new DataTable();
            dtItems.Columns.AddRange(new DataColumn[]{
                new DataColumn("参数ID"),
                new DataColumn("参数名称"),
                new DataColumn("参数类型"),
                new DataColumn("采集值1"),
                new DataColumn("采集值2"),
                new DataColumn("采集值3"),
                new DataColumn("单位"),
                new DataColumn("刷新时间"),
                new DataColumn("存储点"),
                new DataColumn("PLC数据值1"),
                new DataColumn("PLC设备类型"),
                new DataColumn("PLC状态"),
                new DataColumn("plc可信度"),
            });


            string sql = @"SELECT  v.id AS 参数ID,
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

            for (int i = 0; i < Program.M.Items.Count; i++)
            {
                DataRow row = dtItems.NewRow();

                //DataItem meter = Program.M.Items[i];
                //DataRow tmp = dt.Rows[i];

                //row["参数ID"]=tmp[0].ToString();
                //row["参数名称"]=tmp[1].ToString();
                //row["参数类型"]=tmp[2].ToString();
                //row["采集值1"]=tmp[3].ToString();
                //row["采集值2"]=tmp[4].ToString();
                //row["采集值3"]=tmp[5].ToString();
                //row["单位"] = tmp[6].ToString();
                //row["刷新时间"] = tmp[7].ToString();
                //row["存储点"] = tmp[8].ToString();

                //row["PLC数据值1"] = meter.Value.ToString();
                //row["PLC设备类型"] = meter.Type.ToString();
                //row["PLC状态"] = meter.State.ToString();
                //row["plc可信度"] = meter.Quality.ToString();


                row["参数ID"] = 1;
                row["参数名称"] = "a";
                row["参数类型"] = "b";
                row["采集值1"] = 1;
                row["采集值2"] = 1;
                row["采集值3"] = 1;
                row["单位"] = "cvb";
                row["刷新时间"] = DateTime.Now;
                row["存储点"] = "asb";

                row["PLC数据值1"] = 1;
                row["PLC设备类型"] = "asd";
                row["PLC状态"] = "bbnn";
                row["plc可信度"] = "cbgvhi";

            }
            dgvDB.DataSource = dtItems;
            dgvDB.Columns["刷新时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
            dgvDB.Columns["存储点"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";

        }
    }
}
