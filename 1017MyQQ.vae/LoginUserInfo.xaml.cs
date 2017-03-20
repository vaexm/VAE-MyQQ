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
using MODEL;
using System.Windows.Threading;

namespace _1017MyQQ.vae
{
    /// <summary>
    /// LoginUserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class LoginUserInfo : Window
    {
        public LoginUserInfo()
        {
            InitializeComponent();
        }
        DispatcherTimer dt;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
            wp.Visibility = System.Windows.Visibility.Visible;
            wp1.Visibility = System.Windows.Visibility.Hidden;
            //在加载时绑定星座和血型
            DataSet star = UserManager.bllGetStar(); 
            foreach(DataRow dr in star.Tables[0].Rows)
            {
                cobstar.Items.Add(dr["Star"]);
            }
            DataSet blood = UserManager.bllGetBlood();
            foreach(DataRow dr in blood.Tables[0].Rows)
            {
                cobblood.Items.Add(dr["BloodType"]);
            }
            Show1();
       
        }
        //控制头像的刷新
        void dt_Tick(object sender, EventArgs e)
        {
          if(UserInfo.IsFaClick==false)
          {
              image1.Source = new BitmapImage(new Uri("images/faces/"+UserInfo.FaceId+".jpg",UriKind.Relative));
             
             
          }
        }
        int type;
        private void Show1()
        {
            //绑定个人数据
            DataSet ds = UserInfo.UserTable;
            //UserInfo.FaceId=int.Parse(ds.Tables[0].Rows[0]["FaceId"].ToString());
            image1.Source = new BitmapImage(new Uri("images/faces/" + ds.Tables[0].Rows[0]["FaceId"] + ".jpg", UriKind.Relative));
            txtNickName.Text = ds.Tables[0].Rows[0]["NickName"].ToString();
            txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            txtAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
            cobblood.SelectedIndex = int.Parse(ds.Tables[0].Rows[0]["BloodTypeId"].ToString()) - 1;
            cobstar.SelectedIndex = int.Parse(ds.Tables[0].Rows[0]["StarId"].ToString()) - 1;
            cobSex.Text = ds.Tables[0].Rows[0]["Sex"].ToString();
            //image1.Source = new BitmapImage(new Uri("images/faces/"+UserInfo.FaceId+".jpg",UriKind.Relative));

             type = int.Parse(ds.Tables[0].Rows[0]["FriendshipPolicyId"].ToString());
            if (type == 1)
            {
                radioButton1.IsChecked = true;

            }
            else if (type == 2)
            {
                radioButton2.IsChecked = true;
            }
            else if(type==3)
            {
                radioButton3.IsChecked = true;
            }
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label la = sender as Label;
            if(la.Tag.ToString()=="less")
            {
                wp.Visibility = System.Windows.Visibility.Visible;
                wp1.Visibility = System.Windows.Visibility.Hidden;
                label1.Background = Brushes.AliceBlue;
                label2.Background = Brushes.Honeydew;


            }
            else if(la.Tag.ToString()=="more")
            {
                wp.Visibility = System.Windows.Visibility.Hidden;
                wp1.Visibility = System.Windows.Visibility.Visible;
                label2.Background = Brushes.AliceBlue;
                label1.Background = Brushes.Honeydew;
            }

        }

        private void label1_MouseEnter(object sender, MouseEventArgs e)
        {
            Label la = sender as Label;
            if(la.Tag.ToString()=="less")
            {
                label1.Background = Brushes.AliceBlue;
            }
            else if(la.Tag.ToString()=="more")
            {
                label2.Background = Brushes.AliceBlue;
            }
        }

        private void label1_MouseLeave(object sender, MouseEventArgs e)
        {
            //Label la = sender as Label;
            //if (la.Tag.ToString() == "less")
            //{
            //    label1.Background = Brushes.Honeydew;
            //}
            //else if (la.Tag.ToString() == "more")
            //{
            //    label2.Background = Brushes.Honeydew;
            //}
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //确定修改
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            if(radioButton1.IsChecked==true)
            {
                type = 1;
            }
            else if(radioButton2.IsChecked==true)
            {
                type = 2;
            }
            else if(radioButton3.IsChecked==true)
            {
                type=3;
            }
            if(txtPwd.Text!="")
            {
                //string str = "update Users set LoginPwd='"+pasPwd.Password+"',FriendshipPolicyId="+type+",NickName='"+txtNickName.Text+"',Sex='"+cobSex.Text+"',Age='"+txtAge.Text+"' ,Name='"+txtName.Text+"',StarId="+int.Parse(cobstar.SelectedIndex.ToString())+"+1,BloodTypeId="+int.Parse(cobblood.SelectedIndex.ToString())+"+1 where Id='"+UserInfo.LoginId+"'";
               
                
                    //判断两次输入密码是否相同
                    if (pasPwd1.Password != pasPwd.Password)
                    {
                        MessageBox.Show("两次输入密码不相同，请重新输入");
                        return;
                    }
                    int res = UserManager.bllUpLoUsInfo(pasPwd.Password, type, txtNickName.Text, UserInfo.FaceId, cobSex.Text, int.Parse(txtAge.Text), txtName.Text, (cobstar.SelectedIndex + 1), (cobblood.SelectedIndex + 1));

                    if (res == 1)
                    {
                        MessageBox.Show("修改信息成功");
                        //image1.Source = new BitmapImage(new Uri("images/face/" + UserInfo.FaceId + ".jpg", UriKind.Relative));
                        Show1();
                    }
                

               
            }
            else 
            {
                //string str = "update Users set FriendshipPolicyId=" + type + ",NickName='" + txtNickName.Text + "',Sex='" + cobSex.Text + "',Age='" + txtAge.Text + "' ,Name='" + txtName.Text + "',StarId=" + int.Parse(cobstar.SelectedIndex.ToString()) + "+1,BloodTypeId=" + int.Parse(cobblood.SelectedIndex.ToString()) + "+1 where Id='" + UserInfo.LoginId + "'";
                int res = UserManager.bllUpLoUsInfo(UserInfo.LoginPwd, type, txtNickName.Text, UserInfo.FaceId, cobSex.Text, int.Parse(txtAge.Text), txtName.Text, (cobstar.SelectedIndex + 1), (cobblood.SelectedIndex + 1));

                if (res == 1)
                {
                    MessageBox.Show("修改信息成功");
                    //image1.Source = new BitmapImage(new Uri("images/face/" + UserInfo.FaceId + ".jpg", UriKind.Relative));
                    Show1();
                }
            }
         
        }
        //取消修改
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
     
        //修改头像
        private void label14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            label4.Background = Brushes.AliceBlue;
            Face f = new Face();
            f.Show();
        }

        private void label14_MouseEnter(object sender, MouseEventArgs e)
        {
            label4.Background = Brushes.AliceBlue;
        }

        private void label14_MouseLeave(object sender, MouseEventArgs e)
        {
            label4.Background = Brushes.White;
        }
        //原密码文本框失焦事件
        private void txtPwd_LostFocus(object sender, RoutedEventArgs e)
        {
            //判断输入的密码是否正确
            if(txtPwd.Text!=UserInfo.LoginPwd)
            {
                MessageBox.Show("你输入的密码不正确，请重新输入");
            }
        }

      

        private void pasPwd1_LostFocus(object sender, RoutedEventArgs e)
        {
            if(pasPwd1.Password!=pasPwd.Password)
            {
                MessageBox.Show("你两次输入密码不相同，请重新输入");
            }

        }
    }
}
