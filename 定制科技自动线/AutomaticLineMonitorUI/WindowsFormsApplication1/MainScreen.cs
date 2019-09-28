using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Collections;
using System.Threading; 
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        int WorkList_Thickness;
        int NowWorkList_Index;
        string WorkList_APID;
        MySqlConnection mysql;
        MySqlConnection mysql_again;
        int store_boardnum;
        int store_index;
        int material_enable_1;
        string nowPath;
        Boolean isCarryBoardFinish;
        string[] APIDarray = new string[20];//存放20个工位工单信息
        public MainForm()
        {
            InitializeComponent();      
            mysql = getmysqlcon();
            mysql_again = getmysqlcon_again();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            textLOG.Text = "系统运行中" + "..." + "\r\n";
            bool ensure_main = StoreForm.ensure_button_flag;
            if (ensure_main == true)
            {
                textLOG.Text = StoreForm.strlog;//储料区设置系统日志
            }
            initialize();
            textLOG.Select(textLOG.TextLength, 0);//使 textLOG文本内容不被选中
        }

       public void AppendWord(string word)
        {
           textLOG.Text += word; 
         }          

       public void Store_data_dispaly()//从数据库取store_sheet表单数据，并显示到界面上
        {
            string sql_store_sheet = "SELECT `Index`,  `Store_area_num`,   `Board_thick`,`Board_amount`,  `Datetime` ,`Enable` FROM `store_sheet`";
             MySqlCommand mySqlcommandStoreSheet= getSqlCommand(sql_store_sheet, mysql);
             try
             {
                 mysql.Open();
                 MySqlDataReader reader = mySqlcommandStoreSheet.ExecuteReader();
                 while (reader.Read())
                 {
                     if (reader.HasRows)
                     {
                       int Store_Index = reader.GetInt32(0);
                       int Store_Thickness = reader.GetInt32(2);
                       int Store_BoardNum = reader.GetInt32(3);
                       int material_enable = reader.GetInt32(5);
                         while (true)
                         {
                             if (Store_Index == 1)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup1.BackColor = Color.White;
                                     txtStore1.BackColor = Color.White;
                                     txtStore1.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup1.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup1.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup1.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup1.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup1.BackColor = Color.Gold;
                                     txtStore1.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup1.Height = height_display(Store_BoardNum);
                                     labelStorenum1.ForeColor = Color.Black;
                                     labelStorenum1.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore1.BackColor = Color.Gainsboro;
                                     txtStore1.ForeColor = Color.Gray;
                                     labelStorenum1.ForeColor = Color.Gainsboro;
                                     textCup1.Height = 36;
                                 }
                             }
                             if (Store_Index == 2)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup2.BackColor = Color.White;
                                     txtStore2.BackColor = Color.White;
                                     txtStore2.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup2.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup2.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup2.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup2.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup2.BackColor = Color.Gold;
                                     txtStore2.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup2.Height = height_display(Store_BoardNum);
                                     labelStorenum2.ForeColor = Color.Black;
                                     labelStorenum2.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore2.BackColor = Color.Gainsboro;
                                     txtStore2.ForeColor = Color.Gray;
                                     labelStorenum2.ForeColor = Color.Gainsboro;
                                     textCup2.Height = 36;
                                 }
                             }
                             if (Store_Index == 3)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup3.BackColor = Color.White;
                                     txtStore3.BackColor = Color.White;
                                     txtStore3.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup3.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup3.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup3.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup3.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup3.BackColor = Color.Gold;
                                     txtStore3.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup3.Height = height_display(Store_BoardNum);
                                     labelStorenum3.ForeColor = Color.Black;
                                     labelStorenum3.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore3.BackColor = Color.Gainsboro;
                                     txtStore3.ForeColor = Color.Gray;
                                     labelStorenum3.ForeColor = Color.Gainsboro;
                                     textCup3.Height = 36;
                                 }
                             }
                             if (Store_Index == 4)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup4.BackColor = Color.White;
                                     txtStore4.BackColor = Color.White;
                                     txtStore4.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup4.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup4.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup4.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup4.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup4.BackColor = Color.Gold;
                                     txtStore4.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup4.Height = height_display(Store_BoardNum);
                                     labelStorenum4.ForeColor = Color.Black;
                                     labelStorenum4.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore4.BackColor = Color.Gainsboro;
                                     txtStore4.ForeColor = Color.Gray;
                                     labelStorenum4.ForeColor = Color.Gainsboro;
                                     textCup4.Height = 36;
                                 }
                             }
                             if (Store_Index == 5)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup5.BackColor = Color.White;
                                     txtStore5.BackColor = Color.White;
                                     txtStore5.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup5.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup5.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup5.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup5.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup5.BackColor = Color.Gold;
                                     txtStore5.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup5.Height = height_display(Store_BoardNum);
                                     labelStorenum5.ForeColor = Color.Black;
                                     labelStorenum5.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore5.BackColor = Color.Gainsboro;
                                     txtStore5.ForeColor = Color.Gray;
                                     labelStorenum5.ForeColor = Color.Gainsboro;
                                     textCup5.Height = 36;
                                 }
                             }
                             if (Store_Index == 6)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup6.BackColor = Color.White;
                                     txtStore6.BackColor = Color.White;
                                     txtStore6.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup6.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup6.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup6.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup6.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup6.BackColor = Color.Gold;
                                     txtStore6.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup6.Height = height_display(Store_BoardNum);
                                     labelStorenum6.ForeColor = Color.Black;
                                     labelStorenum6.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore6.BackColor = Color.Gainsboro;
                                     txtStore6.ForeColor = Color.Gray;
                                     labelStorenum6.ForeColor = Color.Gainsboro;
                                     textCup6.Height = 36;
                                 }
                             }
                             if (Store_Index == 7)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup7.BackColor = Color.White;
                                     txtStore7.BackColor = Color.White;
                                     txtStore7.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup7.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup7.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup7.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup7.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup7.BackColor = Color.Gold;
                                     txtStore7.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup7.Height = height_display(Store_BoardNum);
                                     labelStorenum7.ForeColor = Color.Black;
                                     labelStorenum7.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore7.BackColor = Color.Gainsboro;
                                     txtStore7.ForeColor = Color.Gray;
                                     labelStorenum7.ForeColor = Color.Gainsboro;
                                     textCup7.Height = 36;
                                 }
                             }
                             if (Store_Index == 8)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup8.BackColor = Color.White;
                                     txtStore8.BackColor = Color.White;
                                     txtStore8.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup8.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup8.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup8.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup8.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup8.BackColor = Color.Gold;
                                     txtStore8.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup8.Height = height_display(Store_BoardNum);
                                     labelStorenum8.ForeColor = Color.Black;
                                     labelStorenum8.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore8.BackColor = Color.Gainsboro;
                                     txtStore8.ForeColor = Color.Gray;
                                     labelStorenum8.ForeColor = Color.Gainsboro;
                                     textCup8.Height = 36;
                                 }
                             }
                             if (Store_Index == 9)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup9.BackColor = Color.White;
                                     txtStore9.BackColor = Color.White;
                                     txtStore9.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup9.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup9.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup9.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup9.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup9.BackColor = Color.Gold;
                                     txtStore9.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup9.Height = height_display(Store_BoardNum);
                                     labelStorenum9.ForeColor = Color.Black;
                                     labelStorenum9.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore9.BackColor = Color.Gainsboro;
                                     txtStore9.ForeColor = Color.Gray;
                                     labelStorenum9.ForeColor = Color.Gainsboro;
                                     textCup9.Height = 36;
                                 }
                             }
                             if (Store_Index == 10)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup10.BackColor = Color.White;
                                     txtStore10.BackColor = Color.White;
                                     txtStore10.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup10.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup10.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup10.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup10.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup10.BackColor = Color.Gold;
                                     txtStore10.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup10.Height = height_display(Store_BoardNum);
                                     labelStorenum10.ForeColor = Color.Black;
                                     labelStorenum10.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore10.BackColor = Color.Gainsboro;
                                     txtStore10.ForeColor = Color.Gray;
                                     labelStorenum10.ForeColor = Color.Gainsboro;
                                     textCup10.Height = 36;
                                 }
                             }
                             if (Store_Index == 11)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup11.BackColor = Color.White;
                                     txtStore11.BackColor = Color.White;
                                     txtStore11.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup11.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup11.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup11.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup11.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup11.BackColor = Color.Gold;
                                     txtStore11.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup11.Height = height_display(Store_BoardNum);
                                     labelStorenum11.ForeColor = Color.Black;
                                     labelStorenum11.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore11.BackColor = Color.Gainsboro;
                                     txtStore11.ForeColor = Color.Gray;
                                     labelStorenum11.ForeColor = Color.Gainsboro;
                                     textCup11.Height = 36;
                                 }
                             }
                             if (Store_Index == 12)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup12.BackColor = Color.White;
                                     txtStore12.BackColor = Color.White;
                                     txtStore12.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup12.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup12.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup12.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup12.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup12.BackColor = Color.Gold;
                                     txtStore12.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup12.Height = height_display(Store_BoardNum);
                                     labelStorenum12.ForeColor = Color.Black;
                                     labelStorenum12.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore12.BackColor = Color.Gainsboro;
                                     txtStore12.ForeColor = Color.Gray;
                                     labelStorenum12.ForeColor = Color.Gainsboro;
                                     textCup12.Height = 36;
                                 }
                             }
                             if (Store_Index == 13)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup13.BackColor = Color.White;
                                     txtStore13.BackColor = Color.White;
                                     txtStore13.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup13.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup13.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup13.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup13.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup13.BackColor = Color.Gold;
                                     txtStore13.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup13.Height = height_display(Store_BoardNum);
                                     labelStorenum13.ForeColor = Color.Black;
                                     labelStorenum13.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore13.BackColor = Color.Gainsboro;
                                     txtStore13.ForeColor = Color.Gray;
                                     labelStorenum13.ForeColor = Color.Gainsboro;
                                     textCup13.Height = 36;
                                 }
                             }
                             if (Store_Index == 14)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup14.BackColor = Color.White;
                                     txtStore14.BackColor = Color.White;
                                     txtStore14.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup14.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup14.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup14.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup14.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup14.BackColor = Color.Gold;
                                     txtStore14.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup14.Height = height_display(Store_BoardNum);
                                     labelStorenum14.ForeColor = Color.Black;
                                     labelStorenum14.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore14.BackColor = Color.Gainsboro;
                                     txtStore14.ForeColor = Color.Gray;
                                     labelStorenum14.ForeColor = Color.Gainsboro;
                                     textCup14.Height = 36;
                                 }
                             }
                             if (Store_Index == 15)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup15.BackColor = Color.White;
                                     txtStore15.BackColor = Color.White;
                                     txtStore15.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) textCup15.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup15.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup15.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup15.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup15.BackColor = Color.Gold;
                                     txtStore15.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup15.Height = height_display(Store_BoardNum);
                                     labelStorenum15.ForeColor = Color.Black;
                                     labelStorenum15.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore15.BackColor = Color.Gainsboro;
                                     txtStore15.ForeColor = Color.Gray;
                                     labelStorenum15.ForeColor = Color.Gainsboro;
                                     textCup15.Height = 36;
                                 }
                             }
                             if (Store_Index == 16)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup16.BackColor = Color.White;
                                     txtStore16.BackColor = Color.White;
                                     txtStore16.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) textCup16.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup16.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup16.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup16.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup16.BackColor = Color.Gold;
                                     txtStore16.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup16.Height = height_display(Store_BoardNum);
                                     labelStorenum16.ForeColor = Color.Black;
                                     labelStorenum16.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore16.BackColor = Color.Gainsboro;
                                     txtStore16.ForeColor = Color.Gray;
                                     labelStorenum16.ForeColor = Color.Gainsboro;
                                     textCup16.Height = 36;
                                 }
                             }
                             if (Store_Index == 17)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup17.BackColor = Color.White;
                                     txtStore17.BackColor = Color.White;
                                     txtStore17.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup17.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup17.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup17.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup17.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup17.BackColor = Color.Gold;
                                     txtStore17.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup17.Height = height_display(Store_BoardNum);
                                     labelStorenum17.ForeColor = Color.Black;
                                     labelStorenum17.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore17.BackColor = Color.Gainsboro;
                                     txtStore17.ForeColor = Color.Gray;
                                     labelStorenum17.ForeColor = Color.Gainsboro;
                                     textCup17.Height = 36;
                                 }
                             }
                             if (Store_Index == 18)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup18.BackColor = Color.White;
                                     txtStore18.BackColor = Color.White;
                                     txtStore18.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup18.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup18.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup18.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup18.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup18.BackColor = Color.Gold;
                                     txtStore18.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup18.Height = height_display(Store_BoardNum);
                                     labelStorenum18.ForeColor = Color.Black;
                                     labelStorenum18.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore18.BackColor = Color.Gainsboro;
                                     txtStore18.ForeColor = Color.Gray;
                                     labelStorenum18.ForeColor = Color.Gainsboro;
                                     textCup18.Height = 36;
                                 }
                             }
                             if (Store_Index == 19)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup19.BackColor = Color.White;
                                     txtStore19.BackColor = Color.White;
                                     txtStore19.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup19.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup19.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup19.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup19.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup19.BackColor = Color.Gold;
                                     txtStore19.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup19.Height = height_display(Store_BoardNum);
                                     labelStorenum19.ForeColor = Color.Black;
                                     labelStorenum19.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore19.BackColor = Color.Gainsboro;
                                     txtStore19.ForeColor = Color.Gray;
                                     labelStorenum19.ForeColor = Color.Gainsboro;
                                     textCup19.Height = 36;
                                 }
                             }
                             if (Store_Index == 20)
                             {
                                 if (material_enable == 1)//料堆使能
                                 {
                                     textCup20.BackColor = Color.White;
                                     txtStore20.BackColor = Color.White;
                                     txtStore20.ForeColor = Color.Black;
                                     if (Store_Thickness == 9) panelCup20.BackColor = Color.Black;
                                     if (Store_Thickness == 18) panelCup20.BackColor = Color.Red;
                                     if (Store_Thickness == 20) panelCup20.BackColor = Color.Green;
                                     if (Store_Thickness == 22) panelCup20.BackColor = Color.Blue;
                                     if (Store_Thickness == 25) panelCup20.BackColor = Color.Gold;
                                     txtStore20.Text = Convert.ToString(Store_Thickness) + "mm" + "\r\n" + Convert.ToString(Store_BoardNum) + "张";
                                     textCup20.Height = height_display(Store_BoardNum);
                                     labelStorenum20.ForeColor = Color.Black;
                                     labelStorenum20.Font = new Font("宋体", 7.5F, FontStyle.Bold);
                                 }
                                 if (material_enable == 0)//料堆不使能或板材数量为0
                                 {
                                     txtStore20.BackColor = Color.Gainsboro;
                                     txtStore20.ForeColor = Color.Gray;
                                     labelStorenum20.ForeColor = Color.Gainsboro;
                                     textCup20.Height = 36;
                                 }
                             }                 
                             break;
                         }    
                     }
                 }
                 reader.Close();
             }
             catch (MySqlException ex)
             {
                 Console.WriteLine("MySqlException Error:" + ex.ToString());
             }
             finally
             {
                 mysql.Close();
             }
        }

        public int height_display(int boardamount)//板材数量注水显示函数
        {
            int amount_height;
            amount_height = Convert.ToInt16(34 - 0.34 * boardamount);//定义板材数量100时填充为满，即panelBABar.Height=34
            return amount_height;
        }

        //显示工位工单函数
        public string workIDdisplay_1(string APIDstr)
        {
            string[] sarray = APIDstr.Split('_');
            string str_workid = sarray[1];
            string str_workid1 = str_workid.Substring(0, 8);
            return str_workid1;
        }
        public string workIDdisplay_2(string APIDstr)
        {
            string[] sarray = APIDstr.Split('_');
            string str_workid = sarray[1];
            string str_workid1 = str_workid.Substring(0, 8);
            string str_workid2 = str_workid.Substring(str_workid.Length - (str_workid.Length - 8));
            return str_workid2;
        }

        //读满足工单的数据
        public void read_work_list()
        {
            string work_cnc_list = "SELECT `Index`, `AP_id`,`Thickness` FROM `work_cnc_task_list` WHERE `State`=0";
            MySqlCommand mySqlcommandWorkCNCList = getSqlCommand(work_cnc_list, mysql);
            try
           {
                mysql.Open();
                MySqlDataReader reader1 = mySqlcommandWorkCNCList.ExecuteReader();
               if(reader1.Read())
                {
                    if (reader1.HasRows)
                    {                       
                            NowWorkList_Index=  reader1.GetInt32(0);
                            WorkList_APID=reader1.GetString(1);
                            WorkList_Thickness = reader1.GetInt32(2);
                            Console.WriteLine("将要加工板材厚度："+WorkList_Thickness);
                    }
                }
                   reader1.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
                read_store_sheet();
        }

        public void read_store_sheet()
        {
            string sql_store_sheet = "SELECT `Index`,  `Store_area_num`,`Board_amount`,  `Datetime` ,`Enable` FROM `store_sheet` WHERE `Board_thick`='"+WorkList_Thickness+"'";
            MySqlCommand mySqlcommandStoreSheet = getSqlCommand(sql_store_sheet, mysql);         
            try
            {
                mysql.Open();
                MySqlDataReader reader1 = mySqlcommandStoreSheet.ExecuteReader();
                if (reader1.Read())
                {
                    if (reader1.HasRows)
                    {
                        store_index = reader1.GetInt32(0);
                        store_boardnum = reader1.GetInt32(2);
                        material_enable_1 = reader1.GetInt32(4);
                    }
                }
                reader1.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySqlException Error:" + ex.ToString());
            }
            finally
            {
                mysql.Close();
            }
            carry_hit();
        }

        public void carry_hit()
        {
            if (btnlight1.BackColor == Color.Lime)//1号位没有板
            {
                try
                {
                    mysql.Open();//打开数据库
                    if (material_enable_1 == 1)
                    {
                        if (store_boardnum != 0)
                        {
                            PictureInstructure.Visible = false;
                            String AutoLineLog1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "抓取" + store_index.ToString() + "号料区" + WorkList_Thickness.ToString() + "mm板材，" + "抓板中...";
                            MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog1 + "')", mysql);
                            mysqllog.ExecuteNonQuery();
                            textLOG.Text += AutoLineLog1 + "\r\n";
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
            if (btnlight1.BackColor == Color.Red)//1号位有板
            {
                APIDarray[0] = WorkList_APID;
                try
                {
                    mysql.Open();//打开数据库
                    if (material_enable_1 == 1)
                    {
                        if (store_boardnum != 0)
                        {
                            if (isCarryBoardFinish)
                            {
                                labeldisplayworkid1.Visible = true;
                                labeldisplayworkid1.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[0]) + "\r\n" + workIDdisplay_2(APIDarray[0]);
                                store_boardnum--;

                                String sqlUpdate = "UPDATE `store_sheet` SET `Board_amount`=" + store_boardnum + " WHERE `Index`='" + store_index + "'";
                                String Update_Carry_State = "UPDATE `work_cnc_task_list` SET `State`=2 WHERE `Ap_id`='" + APIDarray[0] + "'";
                                String AutoLineLog2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "抓取" + store_index.ToString() + "号料区" + WorkList_Thickness.ToString() + "mm板材，" + store_index.ToString() + "号料区" + "剩余板材数量" + Convert.ToString(store_boardnum) + "张，" + "本次抓取成功！";
                                MySqlCommand mySqlCommandsqlupdate = getSqlCommand(sqlUpdate, mysql);
                                MySqlCommand mySqlCommandUpdate_Carry_State = getSqlCommand(Update_Carry_State, mysql);
                                MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog2 + "')", mysql);
                                mySqlCommandsqlupdate.ExecuteNonQuery();
                                mySqlCommandUpdate_Carry_State.ExecuteNonQuery();
                                mysqllog.ExecuteNonQuery();
                                textLOG.Text += AutoLineLog2 + "\r\n";
                                if (btnlight2.BackColor == Color.Red)
                                {
                                    //Delay(1);
                                    PictureInstructure.Visible = false;
                                }
                                else
                                {
                                    PictureInstructure.Visible = true;
                                }
                            }
                            else
                            {
                                if (btnlight2.BackColor == Color.Red)
                                {
                                    pictureworknum1.Visible = false;
                                    labeldisplayworkid1.Visible = false;
                                    btnlight1.BackColor = Color.Lime;//1号位置绿色
                                    PictureInstructure.Visible = false;
                                    pictureworknum2.Visible = true;
                                    labeldisplayworkid2.Visible = true;
                                    APIDarray[1] = APIDarray[0];
                                    labeldisplayworkid2.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[1]) + "\r\n" + workIDdisplay_2(APIDarray[1]);
                                   
                                    String Update_Hit_State = "UPDATE `work_cnc_task_list` SET `State`=3 WHERE `Ap_id`='" + APIDarray[1] + "'";
                                    String AutoLineLog3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[1] + "，打标操作！";
                                    MySqlCommand mySqlCommandUpdate_Hit_State = getSqlCommand(Update_Hit_State, mysql);
                                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog3 + "')", mysql);
                                    mySqlCommandUpdate_Hit_State.ExecuteNonQuery();
                                    mysqllog.ExecuteNonQuery();
                                    textLOG.Text += AutoLineLog3 + "\r\n";
                                }
                                else
                                { PictureInstructure.Visible = true; }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
            timer2.Enabled = false;
        }

        public void hit_backboard()
        {
            if (btnlight2.BackColor == Color.Red)
            {
                try
                {
                    mysql.Open();
                    if (btnlight3.BackColor == Color.Red)
                    {
                        pictureworknum2.Visible = false;
                        labeldisplayworkid2.Visible = false;
                        btnlight2.BackColor = Color.Lime;//2号位置绿色
                        pictureworknum3.Visible = true;
                        labeldisplayworkid3.Visible = true;
                        APIDarray[2] = APIDarray[1];
                        labeldisplayworkid3.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[2]) + "\r\n" + workIDdisplay_2(APIDarray[2]);

                        String AutoLineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[2] + "，即将背板加工！";
                        String Update_backwait_State = "UPDATE `work_cnc_task_list` SET `State`=4 WHERE `Ap_id`='" + APIDarray[2] + "'";
                        MySqlCommand mySqlCommandUpdate_backwait_State = getSqlCommand(Update_backwait_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog + "')", mysql);
                        mySqlCommandUpdate_backwait_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutoLineLog + "\r\n";
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void cnc_backboard()
        {
            //if (btnlight3.BackColor == Color.Red)
            //{
                try
                {
                    mysql.Open();
                    //if (btnbackboard.BackColor == Color.Red)
                    //{
                        APIDarray[3] = APIDarray[2];
                        backboard_displayworkid.Visible = true;
                        backboard_displayworkid.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[3]) + "\r\n" + workIDdisplay_2(APIDarray[3])+"\r\n" + "背板加工";

                        String AutoLineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[3] + "，背板加工！";
                        String Update_backcnc_State = "UPDATE `work_cnc_task_list` SET `State`=5 WHERE `Ap_id`='" + APIDarray[3] + "'";
                        MySqlCommand mySqlCommandUpdate_backcnc_State = getSqlCommand(Update_backcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog + "')", mysql);
                        mySqlCommandUpdate_backcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutoLineLog + "\r\n";
                    //}

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
        }

        public void milling_type_total_wait()
        {
            if (backboard_displayworkid.Visible ==true)
            {
                try
                {
                    mysql.Open();
                    if (btnlight4.BackColor == Color.Red)
                    {
                        APIDarray[4] = APIDarray[3];
                        labeldisplayworkid4.Visible = true;
                        labeldisplayworkid4.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[4]) + "\r\n" + workIDdisplay_2(APIDarray[4]);

                        String AutoLineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[4] + "，铣型加工等待中...";
                        String Update_millcncwait_State = "UPDATE `work_cnc_task_list` SET `State`=6 WHERE `Ap_id`='" + APIDarray[4] + "'";
                        MySqlCommand mySqlCommandUpdate_millcncwait_State = getSqlCommand(Update_millcncwait_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutoLineLog + "')", mysql);
                        mySqlCommandUpdate_millcncwait_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutoLineLog + "\r\n";
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_cnc_decision()
        {
            if (btnlight15.BackColor == Color.Lime || btnlight16.BackColor == Color.Lime || btnlight17.BackColor == Color.Lime || btnlight18.BackColor == Color.Lime || btnlight19.BackColor == Color.Lime)//先判断1~5号铣型机工位有“0”
            {
                if (btnlight15.BackColor == Color.Lime)//1号铣型机工位为“0”，最高优先级
                {
                    if (btnlight5.BackColor == Color.Lime)
                    {
                        Delay(2);//工单在总决策处显示2秒
                        pictureworknum4.Visible = false;
                        labeldisplayworkid4.Visible = false;
                        btnlight4.BackColor = Color.Lime;
                        pictureworknum5.Visible = true;
                        labeldisplayworkid5.Visible = true;
                        btnlight5.BackColor = Color.Red;
                        StopBoard5.Visible = true;
                        APIDarray[5] = APIDarray[4];
                        labeldisplayworkid5.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[5]) + "\r\n" + workIDdisplay_2(APIDarray[5]);
                    }
                }
                else
                {
                    if (btnlight16.BackColor == Color.Lime)//2号铣型机工位为“0”，第二优先级
                    {
                        if (btnlight5.BackColor == Color.Lime && btnlight7.BackColor == Color.Lime)
                        {
                            Delay(2);//工单在总决策处显示2秒
                            pictureworknum4.Visible = false;
                            labeldisplayworkid4.Visible = false;
                            btnlight4.BackColor = Color.Lime;
                            pictureworknum7.Visible = true;
                            labeldisplayworkid7.Visible = true;
                            btnlight7.BackColor = Color.Red;
                            StopBoard7.Visible = true;
                            APIDarray[7] = APIDarray[4];
                            labeldisplayworkid7.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[7]) + "\r\n" + workIDdisplay_2(APIDarray[7]);
                        }
                    }
                    else
                    {
                        if (btnlight17.BackColor == Color.Lime)//3号铣型机工位为“0”，第三优先级
                        {
                            if (btnlight5.BackColor == Color.Lime && btnlight7.BackColor == Color.Lime && btnlight9.BackColor == Color.Lime)
                            {
                                Delay(2);//工单在总决策处显示2秒
                                pictureworknum4.Visible = false;
                                labeldisplayworkid4.Visible = false;
                                btnlight4.BackColor = Color.Lime;
                                pictureworknum9.Visible = true;
                                labeldisplayworkid9.Visible = true;
                                btnlight9.BackColor = Color.Red;
                                StopBoard9.Visible = true;
                                APIDarray[9] = APIDarray[4];
                                labeldisplayworkid9.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[9]) + "\r\n" + workIDdisplay_2(APIDarray[9]);
                            }
                        }
                        else
                        {
                            if (btnlight18.BackColor == Color.Lime)//4号铣型机工位为“0”，第四优先级
                            {
                                if (btnlight5.BackColor == Color.Lime && btnlight7.BackColor == Color.Lime && btnlight9.BackColor == Color.Lime && btnlight11.BackColor == Color.Lime)
                                {
                                    Delay(2);//工单在总决策处显示2秒
                                    pictureworknum4.Visible = false;
                                    labeldisplayworkid4.Visible = false;
                                    btnlight4.BackColor = Color.Lime;
                                    pictureworknum11.Visible = true;
                                    labeldisplayworkid11.Visible = true;
                                    btnlight11.BackColor = Color.Red;
                                    StopBoard11.Visible = true;
                                    APIDarray[11] = APIDarray[4];
                                    labeldisplayworkid11.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[11]) + "\r\n" + workIDdisplay_2(APIDarray[11]);
                                }
                            }
                            else
                            {
                                if (btnlight19.BackColor == Color.Lime)//5号铣型机工位为“0”，第五优先级
                                {
                                    if (btnlight5.BackColor == Color.Lime && btnlight7.BackColor == Color.Lime && btnlight9.BackColor == Color.Lime && btnlight11.BackColor == Color.Lime)
                                    {
                                        Delay(2);//工单在总决策处显示2秒
                                        pictureworknum4.Visible = false;
                                        labeldisplayworkid4.Visible = false;
                                        btnlight4.BackColor = Color.Lime;
                                        pictureworknum13.Visible = true;
                                        labeldisplayworkid13.Visible = true;
                                        //btnlight9.BackColor = Color.Red;
                                        StopBoard13.Visible = true;
                                        APIDarray[13] = APIDarray[4];
                                        labeldisplayworkid13.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[13]) + "\r\n" + workIDdisplay_2(APIDarray[13]);
                                }
                                }
                            }
                        }
                    }
                }
            }
            else if (btnlight6.BackColor == Color.Lime || btnlight8.BackColor == Color.Lime || btnlight10.BackColor == Color.Lime || btnlight12.BackColor == Color.Lime || btnlight14.BackColor == Color.Lime)//再判断1~5号铣型机等待区工位有“0”
            {
                if (btnlight6.BackColor == Color.Lime)//1号铣型机等待工位为“0”，第六优先级
                {
                    if (btnlight5.BackColor == Color.Lime)
                    {
                        Delay(2);//工单在总决策处显示2秒
                        pictureworknum4.Visible = false;
                        labeldisplayworkid4.Visible = false;
                        btnlight4.BackColor = Color.Lime;
                        pictureworknum5.Visible = true;
                        labeldisplayworkid5.Visible = true;
                        btnlight5.BackColor = Color.Red;
                        StopBoard5.Visible = true;
                        APIDarray[5] = APIDarray[4];
                        labeldisplayworkid5.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[5]) + "\r\n" + workIDdisplay_2(APIDarray[5]);
                    }
                }
                else
                {
                    if (btnlight8.BackColor == Color.Lime)//2号铣型机等待工位为“0”，第七优先级
                    {
                        if (btnlight7.BackColor == Color.Lime)
                        {
                            Delay(2);//工单在总决策处显示2秒
                            pictureworknum4.Visible = false;
                            labeldisplayworkid4.Visible = false;
                            btnlight4.BackColor = Color.Lime;
                            pictureworknum7.Visible = true;
                            labeldisplayworkid7.Visible = true;
                            btnlight7.BackColor = Color.Red;
                            StopBoard7.Visible = true;
                            APIDarray[7] = APIDarray[4];
                            labeldisplayworkid7.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[7]) + "\r\n" + workIDdisplay_2(APIDarray[7]);
                        }
                    }
                    else
                    {
                        if (btnlight10.BackColor == Color.Lime)//3号铣型机等待工位为“0”，第八优先级
                        {
                            if (btnlight9.BackColor == Color.Lime)
                            {
                                Delay(2);//工单在总决策处显示2秒
                                pictureworknum4.Visible = false;
                                labeldisplayworkid4.Visible = false;
                                btnlight4.BackColor = Color.Lime;
                                pictureworknum9.Visible = true;
                                labeldisplayworkid9.Visible = true;
                                btnlight9.BackColor = Color.Red;
                                StopBoard9.Visible = true;
                                APIDarray[9] = APIDarray[4];
                                labeldisplayworkid9.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[9]) + "\r\n" + workIDdisplay_2(APIDarray[9]);
                            }
                        }
                        else
                        {
                            if (btnlight12.BackColor == Color.Lime)//4号铣型机等待工位为“0”，第九优先级
                            {
                                if (btnlight11.BackColor == Color.Lime)
                                {
                                    Delay(2);//工单在总决策处显示2秒
                                    pictureworknum4.Visible = false;
                                    labeldisplayworkid4.Visible = false;
                                    btnlight4.BackColor = Color.Lime;
                                    pictureworknum11.Visible = true;
                                    labeldisplayworkid11.Visible = true;
                                    btnlight11.BackColor = Color.Red;
                                    StopBoard11.Visible = true;
                                    APIDarray[11] = APIDarray[4];
                                    labeldisplayworkid11.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[11]) + "\r\n" + workIDdisplay_2(APIDarray[11]);
                                }
                            }
                            else
                            {
                                if (btnlight14.BackColor == Color.Lime)//5号铣型机等待工位为“0”，第十优先级
                                {
                                    Delay(2);//工单在总决策处显示2秒
                                    pictureworknum4.Visible = false;
                                    labeldisplayworkid4.Visible = false;
                                    btnlight4.BackColor = Color.Lime;
                                    pictureworknum13.Visible = true;
                                    labeldisplayworkid13.Visible = true;
                                    StopBoard13.Visible = true;
                                    APIDarray[13] = APIDarray[4];
                                    labeldisplayworkid13.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[13]) + "\r\n" + workIDdisplay_2(APIDarray[13]);
                                }
                            }
                        }
                    }
                }
            }
            else if (btnlight5.BackColor == Color.Lime && btnlight7.BackColor == Color.Lime && btnlight9.BackColor == Color.Lime && btnlight11.BackColor == Color.Lime)//当判断1~4号铣型机档板区工位均为“0”，板子放5号铣型机档板区
            {
                //5号铣型机挡板区工位为“0”，第十 一 优先级
                Delay(2);//工单在总决策处显示2秒
                pictureworknum4.Visible = false;
                labeldisplayworkid4.Visible = false;
                btnlight4.BackColor = Color.Lime;
                pictureworknum13.Visible = true;
                labeldisplayworkid13.Visible = true;
                StopBoard13.Visible = true;
                APIDarray[13] = APIDarray[4];
                labeldisplayworkid13.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[13]) + "\r\n" + workIDdisplay_2(APIDarray[13]);
            }
            else if (btnlight5.BackColor == Color.Lime || btnlight7.BackColor == Color.Lime || btnlight9.BackColor == Color.Lime || btnlight11.BackColor == Color.Lime)//最后判断1~4号铣型机档板区工位有“0”
            {
                if (btnlight11.BackColor == Color.Lime)
                {
                    //4号铣型机挡板区工位为“0”，第十 二 优先级
                    Delay(2);//工单在总决策处显示2秒
                    pictureworknum4.Visible = false;
                    labeldisplayworkid4.Visible = false;
                    btnlight4.BackColor = Color.Lime;
                    pictureworknum11.Visible = true;
                    labeldisplayworkid11.Visible = true;
                    btnlight11.BackColor = Color.Red;
                    StopBoard11.Visible = true;
                    APIDarray[11] = APIDarray[4];
                    labeldisplayworkid11.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[11]) + "\r\n" + workIDdisplay_2(APIDarray[11]);
                }
                else
                {
                    if (btnlight9.BackColor == Color.Lime)
                    {
                        //3号铣型机挡板区工位为“0”，第十 三 优先级
                        Delay(2);//工单在总决策处显示2秒
                        pictureworknum4.Visible = false;
                        labeldisplayworkid4.Visible = false;
                        btnlight4.BackColor = Color.Lime;
                        pictureworknum9.Visible = true;
                        labeldisplayworkid9.Visible = true;
                        btnlight9.BackColor = Color.Red;
                        StopBoard9.Visible = true;
                        APIDarray[9] = APIDarray[4];
                        labeldisplayworkid9.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[9]) + "\r\n" + workIDdisplay_2(APIDarray[9]);
                    }
                    else
                    {
                        if (btnlight7.BackColor == Color.Lime)
                        {
                            //2号铣型机挡板区工位为“0”，第十 四 优先级
                            Delay(2);//工单在总决策处显示2秒
                            pictureworknum4.Visible = false;
                            labeldisplayworkid4.Visible = false;
                            btnlight4.BackColor = Color.Lime;
                            pictureworknum7.Visible = true;
                            labeldisplayworkid7.Visible = true;
                            btnlight7.BackColor = Color.Red;
                            StopBoard7.Visible = true;
                            APIDarray[7] = APIDarray[4];
                            labeldisplayworkid7.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[7]) + "\r\n" + workIDdisplay_2(APIDarray[7]);
                        }
                        else
                        {
                            if (btnlight5.BackColor == Color.Lime)
                            {
                                //1号铣型机挡板区工位为“0”，最低优先级
                                Delay(2);//工单在总决策处显示2秒
                                pictureworknum4.Visible = false;
                                labeldisplayworkid4.Visible = false;
                                btnlight4.BackColor = Color.Lime;
                                pictureworknum5.Visible = true;
                                labeldisplayworkid5.Visible = true;
                                btnlight5.BackColor = Color.Red;
                                StopBoard5.Visible = true;
                                APIDarray[5] = APIDarray[4];
                                labeldisplayworkid5.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[5]) + "\r\n" + workIDdisplay_2(APIDarray[5]);
                            }
                        }
                    }
                }
            }
        }

        public void milling_line1_1()
        {
            if (btnlight5.BackColor == Color.Red)//检测1号铣型加工线挡板区有板
            {
                try
                {
                    mysql.Open();
                    if (btnlight6.BackColor == Color.Red)
                    {
                        pictureworknum5.Visible = false;
                        labeldisplayworkid5.Visible = false;
                        StopBoard5.Visible = false;
                        btnlight5.BackColor = Color.Lime;
                        pictureworknum6.Visible = true;
                        labeldisplayworkid6.Visible = true;
                        APIDarray[6] = APIDarray[5];
                        labeldisplayworkid6.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[6]) + "\r\n" + workIDdisplay_2(APIDarray[6]);

                        String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[6] + "的板材" + "，在1号铣型加工线等待区！";
                        String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=8 WHERE `Ap_id`='" + APIDarray[6] + "'";
                        MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                        mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutolineLog + "\r\n";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_line1_2()
        {
            //if (btnlight6.BackColor == Color.Red)//检测1号铣型加工线等待区有板
            //{
                    if (btnlight15.BackColor == Color.Lime)
                    {
                        /*pictureworknum6.Visible = false;
                        labeldisplayworkid6.Visible = false;
                        labeldisplayworkid6.Visible = false;
                        btnlight6.BackColor = Color.Lime;
                        labeldisplayworkid15.Visible = true;
                        APIDarray[15] = APIDarray[6];
                        labeldisplayworkid15.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[15]) + "\r\n" + workIDdisplay_2(APIDarray[15]);
                        Delay(2);//铣型加工2秒
                        labeldisplayworkid15.Visible = false;
                        btnlight15.BackColor = Color.Lime;*/
                        BoardMillingAfter1.Visible = true;
                        MillingAfterWorkID1.Visible = true;
                        MillingAfterWorkID1.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[15]) + "\r\n" + workIDdisplay_2(APIDarray[15]);
                    }   
                try
                {
                    mysql.Open();
                    String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[15] + "的板材" + "，在1号铣型机完成加工！";
                    String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=9 WHERE `Ap_id`='" + APIDarray[15] + "'";
                    MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                    mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                    mysqllog.ExecuteNonQuery();
                    textLOG.Text += AutolineLog + "\r\n";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
         }

        public void milling_line2_1()
        {
            if (btnlight7.BackColor == Color.Red)//检测2号铣型加工线挡板区有板
            {
                try
                {
                    mysql.Open();
                    if (btnlight8.BackColor == Color.Red)
                    {
                        pictureworknum7.Visible = false;
                        labeldisplayworkid7.Visible = false;
                        StopBoard7.Visible = false;
                        btnlight7.BackColor = Color.Lime;
                        pictureworknum8.Visible = true;
                        labeldisplayworkid8.Visible = true;
                        APIDarray[8] = APIDarray[7];
                        labeldisplayworkid8.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[8]) + "\r\n" + workIDdisplay_2(APIDarray[8]);

                        String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[8] + "的板材" + "，在2号铣型加工线等待区！";
                        String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=11 WHERE `Ap_id`='" + APIDarray[8] + "'";
                        MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                        mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutolineLog + "\r\n";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_line2_2()
        {
            //if (btnlight8.BackColor == Color.Red)//检测2号铣型加工线等待区有板
            //{
                if (btnlight16.BackColor == Color.Lime)
                {
                    /*pictureworknum8.Visible = false;
                    labeldisplayworkid8.Visible = false;
                    labeldisplayworkid8.Visible = false;
                    btnlight8.BackColor = Color.Lime;
                    labeldisplayworkid16.Visible = true;
                    APIDarray[16] = APIDarray[8];
                    labeldisplayworkid16.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[16]) + "\r\n" + workIDdisplay_2(APIDarray[16]);
                    Delay(2);//铣型加工2秒
                    labeldisplayworkid16.Visible = false;
                    btnlight16.BackColor = Color.Lime;*/
                    BoardMillingAfter2.Visible = true;
                    MillingAfterWorkID2.Visible = true;
                    MillingAfterWorkID2.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[16]) + "\r\n" + workIDdisplay_2(APIDarray[16]);
                }
                try
                {
                    mysql.Open();
                    String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[16] + "的板材" + "，在2号铣型机完成加工！";
                    String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=12 WHERE `Ap_id`='" + APIDarray[16] + "'";
                    MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                    mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                    mysqllog.ExecuteNonQuery();
                    textLOG.Text += AutolineLog + "\r\n";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
        }

        public void milling_line3_1()
        {
            if (btnlight9.BackColor == Color.Red)//检测3号铣型加工线挡板区有板
            {
                try
                {
                    mysql.Open();
                    if (btnlight10.BackColor == Color.Red)
                    {
                        pictureworknum9.Visible = false;
                        labeldisplayworkid9.Visible = false;
                        StopBoard9.Visible = false;
                        btnlight9.BackColor = Color.Lime;
                        pictureworknum10.Visible = true;
                        labeldisplayworkid10.Visible = true;
                        APIDarray[10] = APIDarray[9];
                        labeldisplayworkid10.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[10]) + "\r\n" + workIDdisplay_2(APIDarray[10]);

                        String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[10] + "的板材" + "，在3号铣型加工线等待区！";
                        String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=14 WHERE `Ap_id`='" + APIDarray[10] + "'";
                        MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                        mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutolineLog + "\r\n";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_line3_2()
        {
            //if (btnlight10.BackColor == Color.Red)//检测2号铣型加工线等待区有板
            //{
                if (btnlight17.BackColor == Color.Lime)
                {
                    /*pictureworknum10.Visible = false;
                    labeldisplayworkid10.Visible = false;
                    labeldisplayworkid10.Visible = false;
                    btnlight10.BackColor = Color.Lime;
                    labeldisplayworkid17.Visible = true;
                    APIDarray[17] = APIDarray[10];
                    labeldisplayworkid17.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[17]) + "\r\n" + workIDdisplay_2(APIDarray[17]);
                    Delay(2);//铣型加工2秒
                    labeldisplayworkid17.Visible = false;
                    btnlight17.BackColor = Color.Lime;*/
                    BoardMillingAfter3.Visible = true;
                    MillingAfterWorkID3.Visible = true;
                    MillingAfterWorkID3.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[17]) + "\r\n" + workIDdisplay_2(APIDarray[17]);
                }
                try
                {
                    mysql.Open();
                    String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[17] + "的板材" + "，在3号铣型机完成加工！";
                    String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=15 WHERE `Ap_id`='" + APIDarray[17] + "'";
                    MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                    mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                    mysqllog.ExecuteNonQuery();
                    textLOG.Text += AutolineLog + "\r\n";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
        }

        public void milling_line4_1()
        {
            if (btnlight11.BackColor == Color.Red)//检测3号铣型加工线挡板区有板
            {
                try
                {
                    mysql.Open();
                    if (btnlight12.BackColor == Color.Red)
                    {
                        pictureworknum11.Visible = false;
                        labeldisplayworkid11.Visible = false;
                        StopBoard11.Visible = false;
                        btnlight11.BackColor = Color.Lime;
                        pictureworknum12.Visible = true;
                        labeldisplayworkid12.Visible = true;
                        APIDarray[12] = APIDarray[11];
                        labeldisplayworkid12.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[12]) + "\r\n" + workIDdisplay_2(APIDarray[12]);

                        String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[12] + "的板材" + "，在4号铣型加工线等待区！";
                        String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=17 WHERE `Ap_id`='" + APIDarray[12] + "'";
                        MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                        mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutolineLog + "\r\n";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_line4_2()
        {
            //if (btnlight12.BackColor == Color.Red)//检测2号铣型加工线等待区有板
            //{
                if (btnlight18.BackColor == Color.Lime)
                {
                    /*pictureworknum12.Visible = false;
                    labeldisplayworkid12.Visible = false;
                    labeldisplayworkid12.Visible = false;
                    btnlight12.BackColor = Color.Lime;
                    labeldisplayworkid18.Visible = true;
                    APIDarray[18] = APIDarray[12];
                    labeldisplayworkid18.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[18]) + "\r\n" + workIDdisplay_2(APIDarray[18]);
                    Delay(2);//铣型加工2秒
                    labeldisplayworkid18.Visible = false;
                    btnlight18.BackColor = Color.Lime;*/
                    BoardMillingAfter4.Visible = true;
                    MillingAfterWorkID4.Visible = true;
                    MillingAfterWorkID4.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[18]) + "\r\n" + workIDdisplay_2(APIDarray[18]);
                }
                try
                {
                    mysql.Open();
                    String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[18] + "的板材" + "，在4号铣型机完成加工！";
                    String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=18 WHERE `Ap_id`='" + APIDarray[18] + "'";
                    MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                    mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                    mysqllog.ExecuteNonQuery();
                    textLOG.Text += AutolineLog + "\r\n";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
        }

        public void milling_line5_1()
        {
            if (pictureworknum13.Visible==true)//检测3号铣型加工线挡板区有板
            {
                try
                {
                    mysql.Open();
                    if (btnlight14.BackColor == Color.Red)
                    {
                        pictureworknum13.Visible = false;
                        labeldisplayworkid13.Visible = false;
                        //StopBoard13.Visible = false;
                        pictureworknum14.Visible = true;
                        labeldisplayworkid14.Visible = true;
                        APIDarray[14] = APIDarray[13];
                        labeldisplayworkid14.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[14]) + "\r\n" + workIDdisplay_2(APIDarray[14]);

                        String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[14] + "的板材" + "，在5号铣型加工线等待区！";
                        String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=20 WHERE `Ap_id`='" + APIDarray[14] + "'";
                        MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                        MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                        mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                        mysqllog.ExecuteNonQuery();
                        textLOG.Text += AutolineLog + "\r\n";
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            }
        }

        public void milling_line5_2()
        {
            //if (btnlight14.BackColor == Color.Red)//检测2号铣型加工线等待区有板
            //{
                if (btnlight19.BackColor == Color.Lime)
                {
                    /*pictureworknum14.Visible = false;
                    labeldisplayworkid14.Visible = false;
                    labeldisplayworkid14.Visible = false;
                    btnlight14.BackColor = Color.Lime;
                    labeldisplayworkid19.Visible = true;
                    APIDarray[19] = APIDarray[14];
                    labeldisplayworkid19.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[19]) + "\r\n" + workIDdisplay_2(APIDarray[19]);
                    Delay(2);//铣型加工2秒
                    labeldisplayworkid19.Visible = false;
                    btnlight19.BackColor = Color.Lime;*/
                    BoardMillingAfter5.Visible = true;
                    MillingAfterWorkID5.Visible = true;
                    MillingAfterWorkID5.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[19]) + "\r\n" + workIDdisplay_2(APIDarray[19]);
                }
                try
                {
                    mysql.Open();
                    String AutolineLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "工位工单为：" + APIDarray[19] + "的板材" + "，在5号铣型机完成加工！";
                    String Update_millingcnc_State = "UPDATE `work_cnc_task_list` SET `State`=21 WHERE `Ap_id`='" + APIDarray[19] + "'";
                    MySqlCommand mySqlCommandUpdate_millingcnc_State = getSqlCommand(Update_millingcnc_State, mysql);
                    MySqlCommand mysqllog = new MySqlCommand("insert into store_log(Log_event) values ('" + AutolineLog + "')", mysql);
                    mySqlCommandUpdate_millingcnc_State.ExecuteNonQuery();
                    mysqllog.ExecuteNonQuery();
                    textLOG.Text += AutolineLog + "\r\n";
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySqlException Error:" + ex.ToString());
                }
                finally
                {
                    mysql.Close();
                }
            //}
        }

        public MySqlConnection getmysqlcon()//建立数据库连接
        {
            //string connetStr = "server=192.168.31.250;port=3306;user=XLS;password=12345678;database=autoline_db;Charset=utf8"; //数据库连接字符串
            string connetStr = "server=127.0.0.1;port=3306;user=root;password=;database=autoline_db;Charset=utf8"; //数据库连接字符串
            MySqlConnection mysql = new MySqlConnection(connetStr);
            return mysql;
        }

        public MySqlConnection getmysqlcon_again()//建立数据库连接
        {
            //string connetStr = "server=192.168.31.250;port=3306;user=XLS;password=12345678;database=autoline_db;Charset=utf8"; //数据库连接字符串
            string connetStr = "server=127.0.0.1;port=3306;user=root;password=;database=autoline_db;Charset=utf8"; //数据库连接字符串
            MySqlConnection mysql = new MySqlConnection(connetStr);
            return mysql;
        }

        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)//数据库执行命令
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            return mySqlCommand;
        }

        public void getUpdate(MySqlCommand mySqlCommand)//数据库更新
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
                Console.WriteLine("成功！");
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("修改数据失败了！" + message);
            }
        }

        private void btnlight1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            if (btnlight1.BackColor == Color.Lime)
            {
                btnlight1.BackColor = Color.Red;//1号位为红色，即“1”
                pictureworknum1.Visible = true;
                isCarryBoardFinish = true;
            }
            else
            {
                btnlight1.BackColor = Color.Lime;//1号位为绿色，即“0”
                pictureworknum1.Visible = false;
                labeldisplayworkid1.Visible = false;
                PictureInstructure.Visible = false;
            }
        }

        private void btnlight2_Click(object sender, EventArgs e)
        {
           if (btnlight2.BackColor == Color.Lime)
            {
                btnlight2.BackColor = Color.Red;//2号位为红色，即“1”
                //pictureworknum1.Visible = false;
                //labeldisplayworkid1.Visible = false;
                //PictureInstructure.Visible = false;
                //pictureworknum2.Visible = true;
                isCarryBoardFinish = false;
                carry_hit();
                //btnlight1.BackColor = Color.Lime;//1号位置绿色
                timer2.Enabled = true;
            }
            else
            {
                btnlight2.BackColor = Color.Lime;//2号位为绿色，即“0”
                pictureworknum2.Visible = false;
                labeldisplayworkid2.Visible = false;
            }
        }

        private void btnlight3_Click(object sender, EventArgs e)
        {
            if (btnlight3.BackColor == Color.Lime)
            {
                btnlight3.BackColor = Color.Red;//3号位为红色，即“1”
                //pictureworknum3.Visible = true;
                //pictureworknum2.Visible = false;
                //labeldisplayworkid2.Visible = false;
                hit_backboard();
                //btnlight2.BackColor = Color.Lime;//2号位置绿色
                if (btnlight1.BackColor == Color.Red)
                { 
                    Delay(1); 
                    PictureInstructure.Visible = true;
                }

            }
            else
            {
                btnlight3.BackColor = Color.Lime;//3号位为绿色，即“0”
                pictureworknum3.Visible = false;
                labeldisplayworkid3.Visible = false;
                cnc_backboard();
            }
        }

        private void btnlight4_Click(object sender, EventArgs e)//决策光电开关
        {
            if (btnlight4.BackColor == Color.Lime)
            {
                btnlight4.BackColor = Color.Red;//决策位为红色，即“1”
                //backboard_displayworkid.Visible = false;
                pictureworknum4.Visible = true;
                milling_type_total_wait();//铣型加工决策等待
                backboard_displayworkid.Visible = false;
                //btnbackboard.BackColor = Color.Lime;//决策位置绿色
                milling_cnc_decision();//铣型加工调度决策
            }
            else
            {
                btnlight4.BackColor = Color.Lime;//3号位为绿色，即“0”
                pictureworknum4.Visible = false;
                labeldisplayworkid4.Visible = false;
            }
        }

        private void btnlight5_Click(object sender, EventArgs e)//1号铣型线档板区
        {
            if (btnlight5.BackColor == Color.Lime)
            {
                btnlight5.BackColor = Color.Red;
            }
            else
            {
                btnlight5.BackColor = Color.Lime;
                pictureworknum5.Visible = false;
                labeldisplayworkid5.Visible = false;
                StopBoard5.Visible = false;
            }
        }

        private void btnlight6_Click(object sender, EventArgs e)//1号铣型线等待区
        {
            if (btnlight6.BackColor == Color.Lime)
            {
                btnlight6.BackColor = Color.Red;
                milling_line1_1();
            }
            else
            {
                btnlight6.BackColor = Color.Lime;
                pictureworknum6.Visible = false;
                labeldisplayworkid6.Visible = false;
            }
        }

        private void btnlight15_Click(object sender, EventArgs e)//1号铣型机
        {
            if (btnlight15.BackColor == Color.Lime)
            {
                btnlight15.BackColor = Color.Red;//3号位为红色，即“1”
                if (btnlight6.BackColor == Color.Red)//检测1号铣型加工线等待区有板
                {
                        pictureworknum6.Visible = false;
                        labeldisplayworkid6.Visible = false;
                        labeldisplayworkid6.Visible = false;
                        btnlight6.BackColor = Color.Lime;
                        labeldisplayworkid15.Visible = true;
                        APIDarray[15] = APIDarray[6];
                        labeldisplayworkid15.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[15]) + "\r\n" + workIDdisplay_2(APIDarray[15])+"\r\n"+"铣型加工";
                    }   
                //milling_line1_2();
            }
            else
            {
                btnlight15.BackColor = Color.Lime;//3号位为绿色，即“0”
                labeldisplayworkid15.Visible = false;
                milling_line1_2();
            }
        }

        private void btnlight7_Click(object sender, EventArgs e)
        {
            if (btnlight7.BackColor == Color.Lime)
            {
                btnlight7.BackColor = Color.Red;
            }
            else
            {
                btnlight7.BackColor = Color.Lime;
                pictureworknum7.Visible = false;
                labeldisplayworkid7.Visible = false;
                StopBoard7.Visible = false;
            }
        }

        private void btnlight8_Click(object sender, EventArgs e)
        {
            if (btnlight8.BackColor == Color.Lime)
            {
                btnlight8.BackColor = Color.Red;
                milling_line2_1();
            }
            else
            {
                btnlight8.BackColor = Color.Lime;
                pictureworknum8.Visible = false;
                labeldisplayworkid8.Visible = false;
            }
        }

        private void btnlight16_Click(object sender, EventArgs e)
        {
            if (btnlight16.BackColor == Color.Lime)
            {
                btnlight16.BackColor = Color.Red;
                if (btnlight8.BackColor == Color.Red)//检测1号铣型加工线等待区有板
                {
                    pictureworknum8.Visible = false;
                    labeldisplayworkid8.Visible = false;
                    labeldisplayworkid8.Visible = false;
                    btnlight8.BackColor = Color.Lime;
                    labeldisplayworkid16.Visible = true;
                    APIDarray[16] = APIDarray[8];
                    labeldisplayworkid16.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[16]) + "\r\n" + workIDdisplay_2(APIDarray[16]) + "\r\n" + "铣型加工";
                }  
                //milling_line2_2();
            }
            else
            {
                btnlight16.BackColor = Color.Lime;
                labeldisplayworkid16.Visible = false;
                milling_line2_2();
            }
        }

        private void btnlight9_Click(object sender, EventArgs e)
        {
            if (btnlight9.BackColor == Color.Lime)
            {
                btnlight9.BackColor = Color.Red;
            }
            else
            {
                pictureworknum9.Visible = false;
                labeldisplayworkid9.Visible = false;
                StopBoard9.Visible = false;
            }
        }

        private void btnlight10_Click(object sender, EventArgs e)
        {
            if (btnlight10.BackColor == Color.Lime)
            {
                btnlight10.BackColor = Color.Red;
                milling_line3_1();
            }
            else
            {
                btnlight10.BackColor = Color.Lime;
                pictureworknum10.Visible = false;
                labeldisplayworkid10.Visible = false;
            }
        }

        private void btnlight17_Click(object sender, EventArgs e)
        {
            if (btnlight17.BackColor == Color.Lime)
            {
                btnlight17.BackColor = Color.Red;
                if (btnlight10.BackColor == Color.Red)//检测1号铣型加工线等待区有板
                {
                    pictureworknum10.Visible = false;
                    labeldisplayworkid10.Visible = false;
                    labeldisplayworkid10.Visible = false;
                    btnlight10.BackColor = Color.Lime;
                    labeldisplayworkid17.Visible = true;
                    APIDarray[17] = APIDarray[10];
                    labeldisplayworkid17.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[17]) + "\r\n" + workIDdisplay_2(APIDarray[17]) + "\r\n" + "铣型加工";
                }  
                //milling_line3_2();
            }
            else
            {
                btnlight17.BackColor = Color.Lime;
                labeldisplayworkid17.Visible = false;
                milling_line3_2();
            }
        }

        private void btnlight11_Click(object sender, EventArgs e)
        {
            if (btnlight11.BackColor == Color.Lime)
            {
                btnlight11.BackColor = Color.Red;
            }
            else
            {
                btnlight11.BackColor = Color.Lime;
                pictureworknum11.Visible = false;
                labeldisplayworkid11.Visible = false;
                StopBoard11.Visible = false;
            }
        }

        private void btnlight12_Click(object sender, EventArgs e)
        {
            if (btnlight12.BackColor == Color.Lime)
            {
                btnlight12.BackColor = Color.Red;
                milling_line4_1();
            }
            else
            {
                btnlight12.BackColor = Color.Lime;
                pictureworknum12.Visible = false;
                labeldisplayworkid12.Visible = false;
            }
        }

        private void btnlight18_Click(object sender, EventArgs e)
        {
            if (btnlight18.BackColor == Color.Lime)
            {
                btnlight18.BackColor = Color.Red;
                if (btnlight12.BackColor == Color.Red)//检测1号铣型加工线等待区有板
                {
                    pictureworknum12.Visible = false;
                    labeldisplayworkid12.Visible = false;
                    labeldisplayworkid12.Visible = false;
                    btnlight12.BackColor = Color.Lime;
                    labeldisplayworkid18.Visible = true;
                    APIDarray[18] = APIDarray[12];
                    labeldisplayworkid18.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[18]) + "\r\n" + workIDdisplay_2(APIDarray[18]) + "\r\n" + "铣型加工";
                }  
                //milling_line4_2();
            }
            else
            {
                btnlight18.BackColor = Color.Lime;
                labeldisplayworkid18.Visible = false;
                milling_line4_2();
            }
        }

        private void btnlight14_Click(object sender, EventArgs e)
        {
            if (btnlight14.BackColor == Color.Lime)
            {
                btnlight14.BackColor = Color.Red;
                milling_line5_1();
            }
            else
            {
                btnlight14.BackColor = Color.Lime;
                pictureworknum14.Visible = false;
                labeldisplayworkid14.Visible = false;
            }
        }

        private void btnlight19_Click(object sender, EventArgs e)
        {
            if (btnlight19.BackColor == Color.Lime)
            {
                btnlight19.BackColor = Color.Red;
                if (btnlight14.BackColor == Color.Red)//检测1号铣型加工线等待区有板
                {
                    pictureworknum14.Visible = false;
                    labeldisplayworkid14.Visible = false;
                    labeldisplayworkid14.Visible = false;
                    btnlight14.BackColor = Color.Lime;
                    labeldisplayworkid19.Visible = true;
                    APIDarray[19] = APIDarray[14];
                    labeldisplayworkid19.Text = "WOID" + "\r\n" + workIDdisplay_1(APIDarray[19]) + "\r\n" + workIDdisplay_2(APIDarray[19]) + "\r\n" + "铣型加工";
                }  
                //milling_line5_2();
            }
            else
            {
                btnlight19.BackColor = Color.Lime;
                labeldisplayworkid19.Visible = false;
                milling_line5_2();
            }
        }

        public void initialize()
        {
            pictureworknum1.Visible = false;
            pictureworknum2.Visible = false;
            pictureworknum3.Visible = false;
            pictureworknum4.Visible = false;
            pictureworknum5.Visible = false;
            pictureworknum6.Visible = false;
            pictureworknum7.Visible = false;
            pictureworknum8.Visible = false;
            pictureworknum9.Visible = false;
            pictureworknum10.Visible = false;
            pictureworknum11.Visible = false;
            pictureworknum12.Visible = false;
            pictureworknum13.Visible = false;
            pictureworknum14.Visible = false;
            PictureInstructure.Visible = false;
            BoardMillingAfter1.Visible = false;
            BoardMillingAfter2.Visible = false;
            BoardMillingAfter3.Visible = false;
            BoardMillingAfter4.Visible = false;
            BoardMillingAfter5.Visible = false;
            labeldisplayworkid1.Visible = false;
            labeldisplayworkid2.Visible = false;
            labeldisplayworkid3.Visible = false;
            labeldisplayworkid4.Visible = false;
            labeldisplayworkid5.Visible = false;
            labeldisplayworkid6.Visible = false;
            labeldisplayworkid7.Visible = false;
            labeldisplayworkid8.Visible = false;
            labeldisplayworkid9.Visible = false;
            labeldisplayworkid10.Visible = false;
            labeldisplayworkid11.Visible = false;
            labeldisplayworkid12.Visible = false;
            labeldisplayworkid13.Visible = false;
            labeldisplayworkid14.Visible = false;
            backboard_displayworkid.Visible = false;
            labeldisplayworkid15.Visible = false;
            labeldisplayworkid16.Visible = false;
            labeldisplayworkid17.Visible = false;
            labeldisplayworkid18.Visible = false;
            labeldisplayworkid19.Visible = false;
            MillingAfterWorkID1.Visible = false;
            MillingAfterWorkID2.Visible = false;
            MillingAfterWorkID3.Visible = false;
            MillingAfterWorkID4.Visible = false;
            MillingAfterWorkID5.Visible = false;
            labelStorenum1.ForeColor = Color.Gainsboro;
            labelStorenum2.ForeColor = Color.Gainsboro;
            labelStorenum3.ForeColor = Color.Gainsboro;
            labelStorenum4.ForeColor = Color.Gainsboro;
            labelStorenum5.ForeColor = Color.Gainsboro;
            labelStorenum6.ForeColor = Color.Gainsboro;
            labelStorenum7.ForeColor = Color.Gainsboro;
            labelStorenum8.ForeColor = Color.Gainsboro;
            labelStorenum9.ForeColor = Color.Gainsboro;
            labelStorenum10.ForeColor = Color.Gainsboro;
            labelStorenum11.ForeColor = Color.Gainsboro;
            labelStorenum12.ForeColor = Color.Gainsboro;
            labelStorenum13.ForeColor = Color.Gainsboro;
            labelStorenum14.ForeColor = Color.Gainsboro;
            labelStorenum15.ForeColor = Color.Gainsboro;
            labelStorenum16.ForeColor = Color.Gainsboro;
            labelStorenum17.ForeColor = Color.Gainsboro;
            labelStorenum18.ForeColor = Color.Gainsboro;
            labelStorenum19.ForeColor = Color.Gainsboro;
            labelStorenum20.ForeColor = Color.Gainsboro;
            btnlight1.BackColor = Color.Lime;//初始化1号工位为绿色
            btnlight2.BackColor = Color.Lime;//初始化2号工位为绿色
            btnlight3.BackColor = Color.Lime;//初始化3号工位为绿色
            btnlight4.BackColor = Color.Lime;//初始化4号工位为绿色
            btnlight5.BackColor = Color.Lime;//初始化5号工位为绿色
            btnlight6.BackColor = Color.Lime;//初始化6号工位为绿色
            btnlight7.BackColor = Color.Lime;//初始化7号工位为绿色
            btnlight8.BackColor = Color.Lime;//初始化8号工位为绿色
            btnlight9.BackColor = Color.Lime;//初始化9号工位为绿色
            btnlight10.BackColor = Color.Lime;//初始化10号工位为绿色
            btnlight11.BackColor = Color.Lime;//初始化11号工位为绿色
            btnlight12.BackColor = Color.Lime;//初始化12号工位为绿色
            //btnlight13.BackColor = Color.Lime;//初始化13号工位为绿色
            btnlight14.BackColor = Color.Lime;//初始化14号工位为绿色
            btnlight15.BackColor = Color.Lime;//初始化15号工位为绿色
            btnlight16.BackColor = Color.Lime;//初始化16号工位为绿色
            btnlight17.BackColor = Color.Lime;//初始化17号工位为绿色
            btnlight18.BackColor = Color.Lime;//初始化18号工位为绿色
            btnlight19.BackColor = Color.Lime;//初始化19号工位为绿色
            StopBoard5.Visible = false;
            StopBoard7.Visible = false;
            StopBoard9.Visible = false;
            StopBoard11.Visible = false;
            StopBoard13.Visible = true;
            timer2.Enabled = false;
            read_work_list();//初始化读数据库第一条工单，表示“抓板进行中”
        }

         private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 开始_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

      
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {        
            StoreForm frm3 = new StoreForm(AppendWord);
            //Form myForm = new Form3();
            frm3.BringToFront();
            //frm3.ShowDialog();//出现在 StoreForm不关闭时，主窗体无法关闭现象
            frm3.Show();           
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //Form myForm = new Form2();
            //myForm.ShowDialog();
        }
                                     
          private void 实时监控_Enter(object sender, EventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {
             
          }

        

          private void toolStripSplitButton4_ButtonClick(object sender, EventArgs e)
          {
           
          }

        

          private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void toolStripSplitButton5_ButtonClick(object sender, EventArgs e)
          {
              Application.Exit();
          }

          private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
          {

          }

          private void OperationProgressBar_Click(object sender, EventArgs e)
          {

          }

          private void reallook_PanelClick(object sender, StatusBarPanelClickEventArgs e)
          {

          }

          

          private void label4_Click(object sender, EventArgs e)
          {

          }

          private void label21_Click(object sender, EventArgs e)
          {

          }

          private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
          {
              read_work_list();
              //read_store_sheet();
          }

          private void timer3_Tick(object sender, EventArgs e)
          {
              Store_data_dispaly();
              if (textLOG.GetLineFromCharIndex(textLOG.Text.Length) > 40)//日志超过40行，清除
              {
                  textLOG.Text = ""; 
              }
          }

          private void MillingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)//每2秒查看一下铣型决策处光电开关状态
          {
              if (btnlight4.BackColor == Color.Red)
              {
                  milling_cnc_decision();
              }

          }

          public static bool Delay(int delayTime)//延时delayTime秒
          {
              DateTime now = DateTime.Now;
              int s;
              do
              {
                  TimeSpan spand = DateTime.Now - now;
                  s = spand.Seconds;
                  Application.DoEvents();
              }
              while (s < delayTime);
              return true;
          }

          
 
          private void FileNew_Click_1(object sender, EventArgs e)
          {
              this.Text = ".cs窗体文件";
              nowPath = "";
          }
             
          private void MenuOpenFile_Click_1(object sender, EventArgs e)
          {
              openFileDialog1.Title = "打开文件";
              openFileDialog1.FileName = "*.cs";
              openFileDialog1.Filter = "C源程序文件(*.cs)|*.cs|C#项目文件(*.csproj)|*.csproj|VB项目文件(*.vbproj;*.vbp)|*.vbproj;*.vbp|所有项目(*.*)|*.*";
              openFileDialog1.FilterIndex = 1;
              openFileDialog1.InitialDirectory = "D:\\";

              if (openFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  nowPath = openFileDialog1.FileName;
              }
          }

          private void SaveFile_Click(object sender, EventArgs e)
          {
              string title;
              title = this.Text;
              if (nowPath == "")
              {
                  AsSaveFile_Click(sender, e);
              }
              else
              {
                  MessageBox.Show("文件将保存到原路径：\n"+nowPath);
              }
          }

          private void AsSaveFile_Click(object sender, EventArgs e)
          {
              saveFileDialog1.Title = "保存文件";
              saveFileDialog1.FileName = "default.cs";
              saveFileDialog1.DefaultExt = "cs";
              saveFileDialog1.Filter = "C源程序文件(*.cs)|*.cs|C#项目文件(*.csproj)|*.csproj|VB项目文件(*.vbproj;*.vbp)|*.vbproj;*.vbp|所有项目(*.*)|*.*";
              saveFileDialog1.FilterIndex = 1;
              saveFileDialog1.InitialDirectory = "D:\\";
              if(saveFileDialog1.ShowDialog()==DialogResult.OK)
              {
                  nowPath = saveFileDialog1.FileName;
                  this.Text = getTitle(nowPath);
                  MessageBox.Show("文件将保存到新路径：\n" + nowPath);
              }
          }

          private string getTitle(string fpath)
          {
              string fname;
              int pos;
              pos = fpath.LastIndexOf("\\");
              fname = fpath.Substring(pos + 1);
              return fname + "界面";
          }

          private void MenubtnExit_Click(object sender, EventArgs e)
          {
              Environment.Exit(0);//退出所有程序
          }

          private void MenubtnClose_Click(object sender, EventArgs e)
          {
              this.Close();//关闭当前MainForm窗体
          }

          private void ToolOpenFile_Click(object sender, EventArgs e)
          {
              openFileDialog1.Title = "打开文件";
              openFileDialog1.FileName = "*.cs";
              openFileDialog1.Filter = "C源程序文件(*.cs)|*.cs|C#项目文件(*.csproj)|*.csproj|VB项目文件(*.vbproj;*.vbp)|*.vbproj;*.vbp|所有项目(*.*)|*.*";
              openFileDialog1.FilterIndex = 1;
              openFileDialog1.InitialDirectory = "D:\\";

              if (openFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  nowPath = openFileDialog1.FileName;
              }
          }

          private void ToolAsSaveFile_Click(object sender, EventArgs e)
          {
              saveFileDialog1.Title = "保存文件";
              saveFileDialog1.FileName = "default.cs";
              saveFileDialog1.DefaultExt = "cs";
              saveFileDialog1.Filter = "C源程序文件(*.cs)|*.cs|C#项目文件(*.csproj)|*.csproj|VB项目文件(*.vbproj;*.vbp)|*.vbproj;*.vbp|所有项目(*.*)|*.*";
              saveFileDialog1.FilterIndex = 1;
              saveFileDialog1.InitialDirectory = "D:\\";
              if (saveFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  nowPath = saveFileDialog1.FileName;
                  this.Text = getTitle(nowPath);
                  MessageBox.Show("文件将保存到新路径：\n" + nowPath);
              }
          }

        

          private void labeldisplayworkid15_Click(object sender, EventArgs e)
          {

          }

         

          private void StopBoard5_Paint(object sender, PaintEventArgs e)
          {

          }

          private void PictureMillingAfter4_Click(object sender, EventArgs e)
          {

          }

          private void PictureMillingAfter1_Click(object sender, EventArgs e)
          {

          }

          private void pictureBox10_Click(object sender, EventArgs e)
          {

          }

          private void MainPanel_Paint(object sender, PaintEventArgs e)
          {

          }

          private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

    }
  }  