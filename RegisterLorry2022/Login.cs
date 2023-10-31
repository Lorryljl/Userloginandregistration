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


        //����һ��string�������ڴ洢���ɵ���֤��
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
            //�ж��û��Ƿ����룬���δ������ʾ�û���
            if (txtName.Text.Length == 0 || txtPsw.Text.Length == 0 || txtYzm.Text.Length == 0)
            {
                MessageBox.Show("�ı�����Ϊ�գ�");
                return;
            }
            
            if (txtYzm.Text.ToUpper() ==Yzm)
            {
                MessageBox.Show("��֤����ȷ");

            }
            else
            {
                MessageBox.Show("��֤���������������");
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
        /// ��ȡ�������ݵķ���
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
                    //����ȡ��DataTable������������ַ���str���бȽ�
                    if (IsDataTableEqualToString(dataTable, str))
                    {

                        MessageBox.Show("��¼�ɹ���");


                    }
                    else
                    {
                        MessageBox.Show("�������");
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
            // ����һ�����ַ��� dataTableAsString�����ڱ���ת����� DataTable ����
            string dataTableAsString = string.Empty;
            //���� DataTable �е�ÿһ��
            foreach (DataRow row in dataTable.Rows)
            {
                //���� DataTable �е�ÿһ��
                foreach (DataColumn col in dataTable.Columns)
                {
                    //����ǰ�С���ǰ�е�ֵת��Ϊ�ַ���������ӵ� dataTableAsString �С�ÿ��ֵ֮���ÿո�ָ�
                    dataTableAsString += row[col].ToString() + " ";
                }
                //��ÿһ�е�ĩβ���һ�����з����Ա����ַ����б�ʾ��ͬ���С�
                dataTableAsString += Environment.NewLine;
            }
            return dataTableAsString;
        }


        //���ڽ���ȡ�� DataTable ������������ַ������бȽϡ�
        public bool IsDataTableEqualToString(DataTable dataTable, string str)
        {
            string dataTableAsString = ConvertDataTableToString(dataTable).Trim();

            return dataTableAsString == str;
        }


        /// <summary>
        /// ��֤������
        /// </summary>
        private void GenerateAndDisplayCaptcha()
        {
            string captcha = GenerateRomdomCaptcha();
            Yzm = captcha;
            Image captchaImage = GenerateCaptchaImage(captcha);//������֤��ͼ��
            pictureBoxCaptcha.Image = captchaImage;
        }
        private string GenerateRomdomCaptcha()
        {
            //�����������֤���ַ�������������ֺ���ĸ�����
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private Image GenerateCaptchaImage(string captcha)
        {
            //����һ��bitmap������Ϊ��֤�������
            int width = 150;
            int height = 50;
            Bitmap image = new Bitmap(width, height);

            //����һ��Graphics�������ڻ���ͼ�� 
            Graphics graphics = Graphics.FromImage(image);

            //����ͼ��ı���ɫ��ǰ��ɫ

            Color backgroundColor = Color.White;
            Color foregroundColor = Color.Black;

            graphics.Clear(backgroundColor);

            //����һ��Font�������ڻ�����֤�ı�
            Font font = new Font(FontFamily.GenericSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel);

            //����һ��Brush�������ڻ�����֤���ı�����ɫ
            Brush brush = new SolidBrush(foregroundColor);


            //��ͼ���ϻ�����֤���ı�

            PointF point = new PointF(1, 1);
            graphics.DrawString(captcha, font, brush, point);

            //�ͷ���Դ
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