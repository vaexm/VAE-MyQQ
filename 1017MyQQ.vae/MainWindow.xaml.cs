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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using DAL;
using MODEL;
using System.Data;


namespace _1017MyQQ.vae
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //登陆
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            UserInfo.LoginId = int.Parse(txtLoginId.Text);
            UserInfo.LoginPwd = pasLoginPwd.Password;
            int res = UserManager.LoginUser(int.Parse(txtLoginId.Text),pasLoginPwd.Password);
            if (res == 1)
            {
                MessageBox.Show("登陆成功");
                this.Hide();
                MainUser mu = new MainUser();
                mu.Show();
            }
            else
            {
                MessageBox.Show("你输入的账号或密码有误");
            }
        }
        // 注册
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Regist wc = new Regist();
            wc.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //文本框失焦事件
        private void txtLoginId_LostFocus(object sender, RoutedEventArgs e)
        {
            DataSet dsUsers = UserManager.bllGetUser(int.Parse(txtLoginId.Text));
            UserInfo.UserTable = dsUsers;


            image1.Source = new BitmapImage(new Uri("images/faces/" + UserInfo.UserTable.Tables[0].Rows[0]["FaceId"] + ".jpg", UriKind.Relative));
            
        }
        //关闭
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
