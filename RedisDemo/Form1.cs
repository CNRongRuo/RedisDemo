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
        /// 获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (RedisHelper.Exists(textBox1.Text))
                {
                    //读取
                    textBox4.Text = RedisHelper.Get(textBox1.Text).ToString();
                }
                else
                {
                    textBox4.Text = "已过期或不存在";
                }
            }
            else
            {
                textBox4.Text = "请填写键";
            }

        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                textBox4.Text = "请填写键";
                return;
            }
            if (textBox2.Text == "" || textBox2.Text == null)
            {
                textBox4.Text = "请填写值";
                return;
            }
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                textBox4.Text = "请填写过期时间";
                return;
            }
            //设置
            RedisHelper.Set(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));//键,值,过期时间
            textBox4.Text = "添加成功";
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (RedisHelper.Exists(textBox1.Text))
                {
                    //删除
                    RedisHelper.Remove(textBox1.Text).ToString();
                    textBox4.Text = "删除成功";
                }
                else
                {
                    textBox4.Text = "已过期或不存在";
                }
            }
            else
            {
                textBox4.Text = "请填写键";
            }

        }
    }
}