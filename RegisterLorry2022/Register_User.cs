using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RegisterLorry2022
{
    internal class Register_User
    {
        public bool SqlSeachI(string connect, string query) {
            using (MySqlConnection con = new MySqlConnection(connect))
            {
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return (result != null);

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("出现错误404");
                    throw;

                }

            }

        }


        /// <summary>
        /// User whether input text       用户是否输入文本
        /// </summary>
        /// <returns></returns>
        public bool TextIsEmpty(string txtName,string txtPsw,string txtPsw2,string txtPhone,string txtYzm)
        {
            if (txtName.Trim() == "" || txtPsw.Trim() == "" || txtPsw2.Trim() == "" || txtPhone.Trim() == "" || txtYzm.Trim() == "")
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Insert query in Mysql    //插入用户注册进数据库中
        /// </summary>
        public void InsertDataTable(string txtName, string txtPsw, string txtPhone)
        {
            string connect = "server=localhost;database=lorry_registersql;uid=root;pwd=root;";
            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();

                    string myInsert = "INSERT INTO registerdbl(用户编号,用户名,密码,手机号,注册时间,注销时间,是否注销) values(null,'"
                        + txtName + "','" + txtPsw + "','" + txtPhone + "','" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "',null,0)";

                    using (MySqlCommand cmd = new MySqlCommand(myInsert, con))
                    {
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public bool PswIsSame(string txtPsw,string txtPsw2)
        {

            return txtPsw == txtPsw2;
        }

        /// <summary>
        /// 验证用户名（必须以字母开头，组合（字符+数字+下划线）长度5-20位）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsValidUserName(string userName)
        {
            return Regex.IsMatch(userName, @"^[a-zA-Z][a-zA-Z0-9_]{4,19}$", RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// 验证密码（必须是数字+字母组合并且不含中文 长度6至20位）
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsPasswordValid(string password)
        {
            //匹配帐号是否合法(字母开头，允许5 - 16字节，允许字母数字下划线)：^[a-zA-Z][a-zA-Z0-9_]{4,15}$  

            //验证用户密码:“^[a - zA - Z]\w{ 5,17}$”正确格式为：以字母开头，长度在6 - 18之间， 只能包含字符、数字和下划线。
            return Regex.IsMatch(password, "^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z][^\u4e00-\u9fa5]{5,19}$", RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// 验证手机号是否正确
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsMobile(string source)
        {
            return Regex.IsMatch(source, @"^1[3456789]\d{9}$", RegexOptions.IgnoreCase);
        }
        public static bool HasMobile(string source)
        {
            return Regex.IsMatch(source, @"1[3456789]\d{9}$", RegexOptions.IgnoreCase);
        }



        public  bool CanDoNext(string txtName, string txtPsw, string txtPsw2, string txtPhone, string txtYzm) {

            //判断用户是否输入
            if (TextIsEmpty(txtName,txtPsw,txtPsw2,txtPhone,txtYzm))
            {
                MessageBox.Show("文本框不能为空");
                return false;
            }
            //判断用户密码长度，低于八位不允许注册
            if (txtPsw.Length < 6)
            {
                MessageBox.Show("密码不能少于八位");
                return false;
            }
            //判断密码是否相同
            if (!PswIsSame(txtPsw,txtPsw2))
            {

                MessageBox.Show("两次输入密码不同，请重新输入");
                return false;
            }
            if (!IsValidUserName(txtName))
            {
                MessageBox.Show("用户名必须以字母开头，长度6-20位");
                return false;

            }
            if (!IsPasswordValid(txtPsw))
            {
                MessageBox.Show("密码必须是数字+字母组合并且不含中文 长度6至20位");
                return false;
            }
            if (!IsMobile(txtPhone))
            {
                MessageBox.Show("手机号填写错误！请重新输入");
                return false;
            }
            return true;
        }

        public void UserWhetherExsit(string txtName,string txtPsw,string txtPhone)
        {
            string connect = "server=localhost;database=lorry_registersql;uid=root;pwd=root;";
            string txt = txtName;
            string DatatableName = "'" + txt.Replace("'", "''") + "'";
            string sql = "SELECT  * FROM registerdbl WHERE 用户名=" + DatatableName;
            if (SqlSeachI(connect, sql))
            {
                MessageBox.Show("用户已存在,请重新输入");
                return;
            }
            else
            {
               InsertDataTable(txtName, txtPsw, txtPhone);
                //InsertDataTable();
                MessageBox.Show("注册成功");
            }
        }
    }

}
