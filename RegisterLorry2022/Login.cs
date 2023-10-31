using MySql.Data.MySqlClient;
using System.Data;

namespace RegisterLorry2022
{

    public partial class Login : Form
    {
        Register register = new Register();
        public Login()
        {
            InitializeComponent();
        }


        //创建一个string类型用于存储生成的验证码
        string Yzm;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            GenerateAndDisplayCaptcha();
           
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = System.DateTime.Now.ToString();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            //判断用户是否输入，如果未输入提示用户！
            if (txtName.Text.Length == 0 || txtPsw.Text.Length == 0 || txtYzm.Text.Length == 0)
            {
                MessageBox.Show("文本框不能为空！");
                return;
            }
            
            if (txtYzm.Text.ToUpper() ==Yzm)
            {
                MessageBox.Show("验证码正确");

            }
            else
            {
                MessageBox.Show("验证码错误，请重新输入");
                return;
            }




        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer2.Stop();

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register.ShowDialog();
        }



        /// <summary>
        /// 读取单个数据的方法
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable SqlSeachI(string query, string str)
        {
            string connectString = "server=localhost;database=lorry_registersql;uid=root;pwd=root;";
            using (MySqlConnection connect = new MySqlConnection(connectString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connect.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connect))
                    {
                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                    //将读取的DataTable数据与给定的字符串str进行比较
                    if (IsDataTableEqualToString(dataTable, str))
                    {

                        MessageBox.Show("登录成功。");


                    }
                    else
                    {
                        MessageBox.Show("密码错误");
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return dataTable;
            }

        }
        public string ConvertDataTableToString(DataTable dataTable)
        {
            // 创建一个空字符串 dataTableAsString，用于保存转换后的 DataTable 数据
            string dataTableAsString = string.Empty;
            //遍历 DataTable 中的每一行
            foreach (DataRow row in dataTable.Rows)
            {
                //遍历 DataTable 中的每一列
                foreach (DataColumn col in dataTable.Columns)
                {
                    //将当前行、当前列的值转换为字符串，并添加到 dataTableAsString 中。每个值之间用空格分隔
                    dataTableAsString += row[col].ToString() + " ";
                }
                //在每一行的末尾添加一个换行符，以便在字符串中表示不同的行。
                dataTableAsString += Environment.NewLine;
            }
            return dataTableAsString;
        }


        //用于将读取的 DataTable 数据与给定的字符串进行比较。
        public bool IsDataTableEqualToString(DataTable dataTable, string str)
        {
            string dataTableAsString = ConvertDataTableToString(dataTable).Trim();

            return dataTableAsString == str;
        }


        /// <summary>
        /// 验证码生成
        /// </summary>
        private void GenerateAndDisplayCaptcha()
        {
            string captcha = GenerateRomdomCaptcha();
            Yzm = captcha;
            Image captchaImage = GenerateCaptchaImage(captcha);//生成验证码图像
            pictureBoxCaptcha.Image = captchaImage;
        }
        private string GenerateRomdomCaptcha()
        {
            //生成随机的验证码字符，例如包括数字和字母的组合
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private Image GenerateCaptchaImage(string captcha)
        {
            //创建一个bitmap对象，作为验证码的容器
            int width = 150;
            int height = 50;
            Bitmap image = new Bitmap(width, height);

            //创建一个Graphics对象，用于绘制图像 
            Graphics graphics = Graphics.FromImage(image);

            //绘制图像的背景色和前景色

            Color backgroundColor = Color.White;
            Color foregroundColor = Color.Black;

            graphics.Clear(backgroundColor);

            //创建一个Font对象，用于绘制验证文本
            Font font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel);

            //创建一个Brush对象，用于绘制验证码文本的颜色
            Brush brush = new SolidBrush(foregroundColor);


            //在图像上绘制验证码文本

            PointF point = new PointF(1, 1);
            graphics.DrawString(captcha, font, brush, point);

            //释放资源
            font.Dispose();
            brush.Dispose();
            graphics.Flush();
            graphics.Dispose();


            return image;


        }

        private void pictureBoxCaptcha_Click(object sender, EventArgs e)
        {
            
            GenerateAndDisplayCaptcha();
           
        }
    }
}