using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using BLL;
using DAL;

namespace _1017MyQQ.vae
{
    /// <summary>
    /// Regist.xaml 的交互逻辑
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //在加载时绑定星座和血型
            DataSet star = UserManager.bllGetStar();
            //循环绑定
            foreach( DataRow dr in star.Tables[0].Rows)
            {
                cobStar.Items.Add(dr["Star"]);
            }
            DataSet blood = UserManager.bllGetBlood();
            foreach(DataRow dr in blood.Tables[0].Rows)
            {
                cobBlood.Items.Add(dr["BloodType"]);
            }


           

        }
        //注册
        string name;
        string sex;
        int star, blood;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //选填信息
            if(txtName.Text=="")
            {
                name = ""; star = cobStar.SelectedIndex + 1; blood = cobBlood.SelectedIndex + 1;
            }
            if(txtName.Text!="")
            {
                name = txtName.Text; star = cobStar.SelectedIndex + 1; blood = cobBlood.SelectedIndex + 1;
            }
            //判断密码
            if(txtpwd1.Text!=txtpwd.Text)
            {
                MessageBox.Show("两次输入密码不相同");
                return;
            }
            if(radioButton1.IsChecked==true)
            {
                sex = "男";
            }
            if(radioButton2.IsChecked==true)
            {
                sex = "女";
            }
            int res = UserManager.bllInsertUser(txtpwd1.Text,txtNickName.Text,sex,int.Parse(txtAge.Text),name,star,blood);
            if(res.ToString().Length>=4)
            {
                MessageBox.Show("注册成功，你的帐号为:"+res);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
