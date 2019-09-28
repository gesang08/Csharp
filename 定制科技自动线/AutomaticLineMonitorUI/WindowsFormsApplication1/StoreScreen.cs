using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public delegate void writelog(string word);
    public partial class StoreForm : Form
    {
        public static string strlog;
        private writelog _writelog;
        string logtime;
        int[] Store_num = new int[21];//记忆使能的料区和异常操作，用于写日志
        public static bool ensure_button_flag = false;
        public static bool cancel_button_flag = false;
        MySqlConnection mysql;
        //Thread store_sql_thread;//线程

        public StoreForm(writelog wlog)
        {
            InitializeComponent();
           this._writelog = wlog;
            mysql = getmysqlcon();
           //store_sql_thread = new Thread(new ThreadStart(mysql_update));
           //store_sql_thread.Start();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            ensure_button_flag = true;
            store_data_update();
            writelog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ensure_button_flag = false;
            this.Close();
        }
        /*******************************储料区参数设置数据更新到数据库*******************************/
                public void store_data_update()
                { 
                    while (true)
                    {
                        if (MAcheck1.Checked || MAcheck2.Checked || MAcheck3.Checked || MAcheck4.Checked || MAcheck5.Checked || MAcheck6.Checked || MAcheck7.Checked || MAcheck8.Checked || MAcheck9.Checked || MAcheck10.Checked || MAcheck11.Checked || MAcheck12.Checked || MAcheck13.Checked || MAcheck14.Checked || MAcheck15.Checked || MAcheck16.Checked || MAcheck17.Checked || MAcheck18.Checked || MAcheck19.Checked || MAcheck20.Checked)
                        {
                            try
                            {
                                mysql.Open();//打开数据库
                                while (true)
                                {
                                    if (MAcheck1.Checked)//1号material area is checked
                                    {
                                        if (BoardAmount1.Value != 0 && BoardAmount1.Value <= 100)
                                        {
                                            BoardThick1.Enabled = false;
                                            if (BoardThick1.Text != "")
                                            {
                                                Store_num[0] = 1;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick1.Text.ToString()) + ",`Board_amount`= " + BoardAmount1.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck1.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount1.Value == 0)
                                        { BoardThick1.Enabled = true; }
                                        else if (BoardAmount1.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount1.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck1.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck2.Checked)//2号储料区
                                    {
                                        if (BoardAmount2.Value != 0 && BoardAmount2.Value <= 100)
                                        {
                                            BoardThick2.Enabled = false;
                                            if (BoardThick2.Text != "")
                                            {
                                                Store_num[1] = 2;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick2.Text.ToString()) + ",`Board_amount`= " + BoardAmount2.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck2.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount2.Value == 0)
                                        { BoardThick2.Enabled = true; }
                                        else if (BoardAmount2.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount2.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck2.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck3.Checked)//1号储料区
                                    {
                                        if (BoardAmount3.Value != 0 && BoardAmount3.Value <= 100)
                                        {
                                            BoardThick3.Enabled = false;
                                            if (BoardThick3.Text != "")
                                            {
                                                Store_num[2] = 3;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick3.Text.ToString()) + ",`Board_amount`= " + BoardAmount3.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck3.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount3.Value == 0)
                                        { BoardThick3.Enabled = true; }
                                        else if (BoardAmount3.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount3.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck3.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck4.Checked)//1号储料区
                                    {
                                        if (BoardAmount4.Value != 0 && BoardAmount4.Value <= 100)
                                        {
                                            BoardThick4.Enabled = false;
                                            if (BoardThick4.Text != "")
                                            {
                                                Store_num[3] = 4;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick4.Text.ToString()) + ",`Board_amount`= " + BoardAmount4.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck4.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount4.Value == 0)
                                        { BoardThick4.Enabled = true; }
                                        else if (BoardAmount4.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount4.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck4.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck5.Checked)//1号储料区
                                    {
                                        if (BoardAmount5.Value != 0 && BoardAmount5.Value <= 100)
                                        {
                                            BoardThick5.Enabled = false;
                                            if (BoardThick5.Text != "")
                                            {
                                                Store_num[4] = 5;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick5.Text.ToString()) + ",`Board_amount`= " + BoardAmount5.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck5.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount5.Value == 0)
                                        { BoardThick5.Enabled = true; }
                                        else if (BoardAmount5.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount5.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck5.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck6.Checked)//1号储料区
                                    {
                                        if (BoardAmount6.Value != 0 && BoardAmount6.Value <= 100)
                                        {
                                            BoardThick6.Enabled = false;
                                            if (BoardThick6.Text != "")
                                            {
                                                Store_num[5] = 6;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick6.Text.ToString()) + ",`Board_amount`= " + BoardAmount6.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck6.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount6.Value == 0)
                                        { BoardThick6.Enabled = true; }
                                        else if (BoardAmount6.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount6.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck6.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck7.Checked)//1号储料区
                                    {
                                        if (BoardAmount7.Value != 0 && BoardAmount7.Value <= 100)
                                        {
                                            BoardThick7.Enabled = false;
                                            if (BoardThick7.Text != "")
                                            {
                                                Store_num[6] = 7;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick7.Text.ToString()) + ",`Board_amount`= " + BoardAmount7.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck7.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount7.Value == 0)
                                        { BoardThick7.Enabled = true; }
                                        else if (BoardAmount7.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount7.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck7.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck8.Checked)//1号储料区
                                    {
                                        if (BoardAmount8.Value != 0 && BoardAmount8.Value <= 100)
                                        {
                                            BoardThick8.Enabled = false;
                                            if (BoardThick8.Text != "")
                                            {
                                                Store_num[7] = 8;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick8.Text.ToString()) + ",`Board_amount`= " + BoardAmount8.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck8.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount8.Value == 0)
                                        { BoardThick8.Enabled = true; }
                                        else if (BoardAmount8.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount8.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck8.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck9.Checked)//1号储料区
                                    {
                                        if (BoardAmount9.Value != 0 && BoardAmount9.Value <= 100)
                                        {
                                            BoardThick9.Enabled = false;
                                            if (BoardThick9.Text != "")
                                            {
                                                Store_num[8] = 9;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick9.Text.ToString()) + ",`Board_amount`= " + BoardAmount9.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck9.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount9.Value == 0)
                                        { BoardThick9.Enabled = true; }
                                        else if (BoardAmount9.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount9.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck9.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck10.Checked)//1号储料区
                                    {
                                        if (BoardAmount10.Value != 0 && BoardAmount10.Value <= 100)
                                        {
                                            BoardThick10.Enabled = false;
                                            if (BoardThick10.Text != "")
                                            {
                                                Store_num[9] = 10;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick10.Text.ToString()) + ",`Board_amount`= " + BoardAmount10.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck10.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount10.Value == 0)
                                        { BoardThick10.Enabled = true; }
                                        else if (BoardAmount10.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount10.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck10.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck11.Checked)//1号储料区
                                    {
                                        if (BoardAmount11.Value != 0 && BoardAmount11.Value <= 100)
                                        {
                                            BoardThick11.Enabled = false;
                                            if (BoardThick11.Text != "")
                                            {
                                                Store_num[10] = 11;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick11.Text.ToString()) + ",`Board_amount`= " + BoardAmount11.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck11.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount11.Value == 0)
                                        { BoardThick11.Enabled = true; }
                                        else if (BoardAmount11.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount11.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck11.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck12.Checked)//2号储料区
                                    {
                                        if (BoardAmount12.Value != 0 && BoardAmount12.Value <= 100)
                                        {
                                            BoardThick12.Enabled = false;
                                            if (BoardThick12.Text != "")
                                            {
                                                Store_num[11] = 12;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick12.Text.ToString()) + ",`Board_amount`= " + BoardAmount12.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck12.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount12.Value == 0)
                                        { BoardThick12.Enabled = true; }
                                        else if (BoardAmount12.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount12.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck12.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck13.Checked)//1号储料区
                                    {
                                        if (BoardAmount13.Value != 0 && BoardAmount13.Value <= 100)
                                        {
                                            BoardThick13.Enabled = false;
                                            if (BoardThick13.Text != "")
                                            {
                                                Store_num[12] = 13;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick13.Text.ToString()) + ",`Board_amount`= " + BoardAmount13.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck13.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount13.Value == 0)
                                        { BoardThick13.Enabled = true; }
                                        else if (BoardAmount13.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount13.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck13.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck14.Checked)//1号储料区
                                    {
                                        if (BoardAmount14.Value != 0 && BoardAmount14.Value <= 100)
                                        {
                                            BoardThick14.Enabled = false;
                                            if (BoardThick14.Text != "")
                                            {
                                                Store_num[13] = 14;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick14.Text.ToString()) + ",`Board_amount`= " + BoardAmount14.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck14.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount14.Value == 0)
                                        { BoardThick14.Enabled = true; }
                                        else if (BoardAmount14.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount14.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck14.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck15.Checked)//1号储料区
                                    {
                                        if (BoardAmount15.Value != 0 && BoardAmount15.Value <= 100)
                                        {
                                            BoardThick15.Enabled = false;
                                            if (BoardThick15.Text != "")
                                            {
                                                Store_num[14] = 15;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick15.Text.ToString()) + ",`Board_amount`= " + BoardAmount15.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck15.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount15.Value == 0)
                                        { BoardThick15.Enabled = true; }
                                        else if (BoardAmount15.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount15.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck15.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck16.Checked)//1号储料区
                                    {
                                        if (BoardAmount16.Value != 0 && BoardAmount16.Value <= 100)
                                        {
                                            BoardThick16.Enabled = false;
                                            if (BoardThick16.Text != "")
                                            {
                                                Store_num[15] = 16;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick16.Text.ToString()) + ",`Board_amount`= " + BoardAmount16.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck16.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount16.Value == 0)
                                        { BoardThick16.Enabled = true; }
                                        else if (BoardAmount16.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount16.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck16.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck17.Checked)//1号储料区
                                    {
                                        if (BoardAmount17.Value != 0 && BoardAmount17.Value <= 100)
                                        {
                                            BoardThick17.Enabled = false;
                                            if (BoardThick17.Text != "")
                                            {
                                                Store_num[16] = 17;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick17.Text.ToString()) + ",`Board_amount`= " + BoardAmount17.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck17.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount17.Value == 0)
                                        { BoardThick17.Enabled = true; }
                                        else if (BoardAmount17.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount17.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck17.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck18.Checked)//1号储料区
                                    {
                                        if (BoardAmount18.Value != 0 && BoardAmount18.Value <= 100)
                                        {
                                            BoardThick18.Enabled = false;
                                            if (BoardThick18.Text != "")
                                            {
                                                Store_num[17] = 18;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick18.Text.ToString()) + ",`Board_amount`= " + BoardAmount18.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck18.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount18.Value == 0)
                                        { BoardThick18.Enabled = true; }
                                        else if (BoardAmount18.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount18.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck18.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck19.Checked)//1号储料区
                                    {
                                        if (BoardAmount19.Value != 0 && BoardAmount19.Value <= 100)
                                        {
                                            BoardThick19.Enabled = false;
                                            if (BoardThick19.Text != "")
                                            {
                                                Store_num[18] = 19;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick19.Text.ToString()) + ",`Board_amount`= " + BoardAmount19.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck19.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount19.Value == 0)
                                        { BoardThick19.Enabled = true; }
                                        else if (BoardAmount19.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount19.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck19.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                                while (true)
                                {
                                    if (MAcheck20.Checked)//1号储料区
                                    {
                                        if (BoardAmount20.Value != 0 && BoardAmount20.Value <= 100)
                                        {
                                            BoardThick20.Enabled = false;
                                            if (BoardThick20.Text != "")
                                            {
                                                Store_num[19] = 20;
                                                string update_store_sheet = "update `store_sheet` set `Board_thick`=" + Convert.ToInt16(BoardThick20.Text.ToString()) + ",`Board_amount`= " + BoardAmount20.Value + ",`Enable`=1,`State`=35 where `Store_area_num`='" + MAcheck20.Text.ToString() + "'";
                                                MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                                mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                            }
                                        }
                                        else if (BoardAmount20.Value == 0)
                                        { BoardThick20.Enabled = true; }
                                        else if (BoardAmount20.Value > 100)
                                        { MessageBox.Show("板材数量最多只能设置100！", "提示信息"); }
                                    }
                                    else
                                    {
                                        string update_store_sheet = "update `store_sheet` set `Board_thick`=0,`Board_amount`= " + BoardAmount20.Value + ",`Enable`=0,`State`=0 where `Store_area_num`='" + MAcheck20.Text.ToString() + "'";
                                        MySqlCommand mysqlcommand = new MySqlCommand(update_store_sheet, mysql);
                                        mysqlcommand.ExecuteNonQuery(); //存储料参数到数据库    
                                    }
                                    break;
                                }

                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("MySqlException Error:" + ex.ToString());
                                Store_num[20] = 21;
                            }
                            finally
                            {
                                mysql.Close();
                            }
                        }
                        else
                        {
                            Store_num[20] = 21;
                            MessageBox.Show("未选择料区号，请选择！","提示信息"); 
                        }
                        break;
                    }
                }
                /*******************************写储料区系统日志和MySQL数据库日志函数*******************************/
                public void writelog()
                {
                    string SqlLog;
                    logtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");
                    try //写日志到数据库
                    {
                        mysql.Open();
                        for (int i = 0; i < 21; i++)//写日志到主界面和MySQL数据库
                        {
                            switch (Store_num[i])
                            {
                                case 1:
                                    {
                                        strlog += logtime + "储料1号区参数设置[板材厚度(mm):" + BoardThick1.Text + "、" + "板材数量(个):" + BoardAmount1.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料1号区参数设置[板材厚度(mm):" + BoardThick1.Text + "、" + "板材数量(个):" + BoardAmount1.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 2:
                                    {
                                        strlog += logtime + "储料2号区参数设置[板材厚度(mm):" + BoardThick2.Text + "、" + "板材数量(个):" + BoardAmount2.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料2号区参数设置[板材厚度(mm):" + BoardThick2.Text + "、" + "板材数量(个):" + BoardAmount2.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 3:
                                    {
                                        strlog += logtime + "储料3号区参数设置[板材厚度(mm):" + BoardThick3.Text + "、" + "板材数量(个):" + BoardAmount3.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料3号区参数设置[板材厚度(mm):" + BoardThick3.Text + "、" + "板材数量(个):" + BoardAmount3.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 4:
                                    {
                                        strlog += logtime + "储料4号区参数设置[板材厚度(mm):" + BoardThick4.Text + "、" + "板材数量(个):" + BoardAmount4.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料4号区参数设置[板材厚度(mm):" + BoardThick4.Text + "、" + "板材数量(个):" + BoardAmount4.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 5:
                                    {
                                        strlog += logtime + "储料5号区参数设置[板材厚度(mm):" + BoardThick5.Text + "、" + "板材数量(个):" + BoardAmount5.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料5号区参数设置[板材厚度(mm):" + BoardThick5.Text + "、" + "板材数量(个):" + BoardAmount5.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 6:
                                    {
                                        strlog += logtime + "储料6号区参数设置[板材厚度(mm):" + BoardThick6.Text + "、" + "板材数量(个):" + BoardAmount6.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料6号区参数设置[板材厚度(mm):" + BoardThick6.Text + "、" + "板材数量(个):" + BoardAmount6.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 7:
                                    {
                                        strlog += logtime + "储料7号区参数设置[板材厚度(mm):" + BoardThick7.Text + "、" + "板材数量(个):" + BoardAmount7.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料7号区参数设置[板材厚度(mm):" + BoardThick7.Text + "、" + "板材数量(个):" + BoardAmount7.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 8:
                                    {
                                        strlog += logtime + "储料8号区参数设置[板材厚度(mm):" + BoardThick8.Text + "、" + "板材数量(个):" + BoardAmount8.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料8号区参数设置[板材厚度(mm):" + BoardThick8.Text + "、" + "板材数量(个):" + BoardAmount8.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 9:
                                    {
                                        strlog += logtime + "储料9号区参数设置[板材厚度(mm):" + BoardThick9.Text + "、" + "板材数量(个):" + BoardAmount9.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料9号区参数设置[板材厚度(mm):" + BoardThick9.Text + "、" + "板材数量(个):" + BoardAmount9.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 10:
                                    {
                                        strlog += logtime + "储料10号区参数设置[板材厚度(mm):" + BoardThick10.Text + "、" + "板材数量(个):" + BoardAmount10.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料10号区参数设置[板材厚度(mm):" + BoardThick10.Text + "、" + "板材数量(个):" + BoardAmount10.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 11:
                                    {
                                        strlog += logtime + "储料11号区参数设置[板材厚度(mm):" + BoardThick11.Text + "、" + "板材数量(个):" + BoardAmount11.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料11号区参数设置[板材厚度(mm):" + BoardThick11.Text + "、" + "板材数量(个):" + BoardAmount11.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 12:
                                    {
                                        strlog += logtime + "储料12号区参数设置[板材厚度(mm):" + BoardThick12.Text + "、" + "板材数量(个):" + BoardAmount12.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料12号区参数设置[板材厚度(mm):" + BoardThick12.Text + "、" + "板材数量(个):" + BoardAmount12.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 13:
                                    {
                                        strlog += logtime + "储料13号区参数设置[板材厚度(mm):" + BoardThick13.Text + "、" + "板材数量(个):" + BoardAmount13.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料13号区参数设置[板材厚度(mm):" + BoardThick13.Text + "、" + "板材数量(个):" + BoardAmount13.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 14:
                                    {
                                        strlog += logtime + "储料14号区参数设置[板材厚度(mm):" + BoardThick14.Text + "、" + "板材数量(个):" + BoardAmount14.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料14号区参数设置[板材厚度(mm):" + BoardThick14.Text + "、" + "板材数量(个):" + BoardAmount14.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 15:
                                    {
                                        strlog += logtime + "储料15号区参数设置[板材厚度(mm):" + BoardThick15.Text + "、" + "板材数量(个):" + BoardAmount15.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料15号区参数设置[板材厚度(mm):" + BoardThick15.Text + "、" + "板材数量(个):" + BoardAmount15.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 16:
                                    {
                                        strlog += logtime + "储料16号区参数设置[板材厚度(mm):" + BoardThick16.Text + "、" + "板材数量(个):" + BoardAmount16.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料16号区参数设置[板材厚度(mm):" + BoardThick16.Text + "、" + "板材数量(个):" + BoardAmount16.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 17:
                                    {
                                        strlog += logtime + "储料17号区参数设置[板材厚度(mm):" + BoardThick17.Text + "、" + "板材数量(个):" + BoardAmount17.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料17号区参数设置[板材厚度(mm):" + BoardThick17.Text + "、" + "板材数量(个):" + BoardAmount17.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 18:
                                    {
                                        strlog += logtime + "储料18号区参数设置[板材厚度(mm):" + BoardThick18.Text + "、" + "板材数量(个):" + BoardAmount18.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料18号区参数设置[板材厚度(mm):" + BoardThick18.Text + "、" + "板材数量(个):" + BoardAmount18.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 19:
                                    {
                                        strlog += logtime + "储料19号区参数设置[板材厚度(mm):" + BoardThick19.Text + "、" + "板材数量(个):" + BoardAmount19.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料19号区参数设置[板材厚度(mm):" + BoardThick19.Text + "、" + "板材数量(个):" + BoardAmount19.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 20:
                                    {
                                        strlog += logtime + "储料20号区参数设置[板材厚度(mm):" + BoardThick20.Text + "、" + "板材数量(个):" + BoardAmount20.Value + "]" + "，" + "设置成功！" + "\r\n";
                                        SqlLog = logtime + "储料20号区参数设置[板材厚度(mm):" + BoardThick20.Text + "、" + "板材数量(个):" + BoardAmount20.Value + "]" + "，" + "设置成功！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                                case 21:
                                    {
                                        strlog += logtime + "储料区参数设置" + "，" + "设置异常！" + "\r\n";
                                        SqlLog = logtime + "储料区参数设置" + "，" + "设置异常！";
                                        MySqlCommand MysqlLog = new MySqlCommand("insert into store_log(Log_event) values ('" + SqlLog + "')", mysql);
                                        MysqlLog.ExecuteNonQuery();
                                        break;
                                    }
                            }
                        }
                
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("MySqlException Error:" + ex.ToString());
                        writelog();
                    }
                    finally
                    {
                        mysql.Close();
                    }   
                    MainForm myform = new MainForm();
                    _writelog(strlog);        
                }

                public MySqlConnection getmysqlcon()//建立数据库连接
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

                /*int i=1;
                   MySqlCommand cmd = new MySqlCommand("delete from chuliaotable where liaoduinum="+i, conn);
                   cmd.ExecuteNonQuery();
                   MessageBox.Show("删除成功！");
                   conn.Close();//数据库删除*/
    }
}
