namespace RedisDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                string redisconf = "127.0.0.1:6379,password=123456,DefaultDatabase=15";
                RedisHelper.SetCon(redisconf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

        }

        /// <summary>
        /// ��ȡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (RedisHelper.Exists(textBox1.Text))
                {
                    //��ȡ
                    textBox4.Text = RedisHelper.Get(textBox1.Text).ToString();
                }
                else
                {
                    textBox4.Text = "�ѹ��ڻ򲻴���";
                }
            }
            else
            {
                textBox4.Text = "����д��";
            }

        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                textBox4.Text = "����д��";
                return;
            }
            if (textBox2.Text == "" || textBox2.Text == null)
            {
                textBox4.Text = "����дֵ";
                return;
            }
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                textBox4.Text = "����д����ʱ��";
                return;
            }
            //����
            RedisHelper.Set(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));//��,ֵ,����ʱ��
            textBox4.Text = "��ӳɹ�";
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (RedisHelper.Exists(textBox1.Text))
                {
                    //ɾ��
                    RedisHelper.Remove(textBox1.Text).ToString();
                    textBox4.Text = "ɾ���ɹ�";
                }
                else
                {
                    textBox4.Text = "�ѹ��ڻ򲻴���";
                }
            }
            else
            {
                textBox4.Text = "����д��";
            }

        }
    }
}