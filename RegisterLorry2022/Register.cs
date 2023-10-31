using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace RegisterLorry2022
{
    public partial class Register : Form
    {
        Register_User register_User = new Register_User();
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString();
        }

        private void Register_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!register_User.CanDoNext(txtName.Text, txtPsw.Text, txtPsw2.Text, txtPhone.Text, txtYzm.Text))
            {
                return;
            }

            register_User.UserWhetherExsit(txtName.Text, txtPsw.Text, txtPhone.Text);

            /*  string connect = "server=localhost;database=lorry_registersql;uid=root;pwd=root;";
              string txt = txtName.Text;
              string DatatableName = "'" + txt.Replace("'", "''") + "'";
              string sql = "SELECT  * FROM registerdbl WHERE 用户名=" + DatatableName;
              if (SqlSeachI(connect, sql))
              {
                  MessageBox.Show("用户已存在,请重新输入");
                  return;
              }
              else
              {
                  register_User.InsertDataTable(txtName.Text, txtPsw.Text, txtPhone.Text);
                  //InsertDataTable();
                  MessageBox.Show("注册成功");
              }
              //打开数据库并查询*/

        }





    }
}
