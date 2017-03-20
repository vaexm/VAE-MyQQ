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
using DAL;
using BLL;
using MODEL;
using System.Windows.Threading;

namespace _1017MyQQ.vae
{
    /// <summary>
    /// MainUser.xaml 的交互逻辑
    /// </summary>
    public partial class MainUser : Window
    {
        public MainUser()
        {
            InitializeComponent();
        }
        Random r = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(3);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
            //在窗体加载时获取登录人的信息
          
            DataSet dsUsers= UserManager.bllGetUser(UserInfo.LoginId);
            UserInfo.UserTable = dsUsers;
            //绑定头像和信息
            //UserInfo.IsFaClick = false;
            
            image1.Source = new BitmapImage(new Uri("images/faces/"+UserInfo.UserTable.Tables[0].Rows[0]["FaceId"]+".jpg",UriKind.Relative));
            label1.Content=dsUsers.Tables[0].Rows[0]["NickName"];
            ShowFriend();



        }

        private void ShowFriend()
        {
            //开始添加好友
            //先获取好友列表
            DataSet dsFriends = UserManager.bllGetFriend();
            //获取好友Id
            StackPanel sp = new StackPanel();
            for (int i = 0; i < dsFriends.Tables[0].Rows.Count; i++)
            {
                int id = int.Parse(dsFriends.Tables[0].Rows[i]["FriendId"].ToString());
                DataSet dsFriends1 = UserManager.bllGetUser(id);
                StackPanel sp1 = new StackPanel();
                //sp1.Background = new LinearGradientBrush(Color.FromArgb((byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256)), Color.FromArgb((byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256), (byte)r.Next(256)), 45);
                sp1.Orientation = Orientation.Horizontal;
                sp1.MouseLeftButtonDown += new MouseButtonEventHandler(sp1_MouseLeftButtonDown);
                sp1.MouseRightButtonDown += new MouseButtonEventHandler(sp1_MouseRightButtonDown);
                //存好友的Id
                sp1.Tag = dsFriends1.Tables[0].Rows[0]["Id"];
                //画头像
                Image img = new Image();
                //foreach (DataRow dr in dsFriends1.Tables[0].Rows)
                //{
                //    img.Width = img.Height = 40;
                //    img.Source = new BitmapImage(new Uri("image/face/" + dr["faceid"] + ".png", UriKind.Relative));

                //}
                img.Width = img.Height = 40;

                img.Source = new BitmapImage(new Uri("images/faces/" + dsFriends1.Tables[0].Rows[0]["FaceId"] + ".jpg", UriKind.Relative));
                //昵称
                Label la = new Label();
                //foreach (DataRow dr in dsFriends1.Tables[0].Rows)
                //{
                //    la.Content = dr["NickName"].ToString();
                //}
                la.Content = dsFriends1.Tables[0].Rows[0]["NickName"];
                sp1.Children.Add(img);
                sp1.Children.Add(la);

                sp.Children.Add(sp1);


            }
            group1.Content = sp;
        }
        //右键点击好友删除该好友
        void sp1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp2 = sender as StackPanel;
            MessageBoxResult result = MessageBox.Show("你确定删除该好友吗？", "删除好友", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                //执行删除
                int res3 = UserManager.DeleteFriend(int.Parse(sp2.Tag.ToString()));
                ShowFriend();
            }
         
        }
        //点击好友开始聊天
        void sp1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //判断点击的是哪个朋友
            StackPanel sp = sender as StackPanel;
            UserInfo.ToUserId =int.Parse( sp.Tag.ToString());
            Chat ch = new Chat();
            ch.Show();

        }

        void dt_Tick(object sender, EventArgs e)
        {
             if(UserInfo.IsFaClick==false)
             {
                 //UserInfo.IsFaClick = true;
                 image1.Source = new BitmapImage(new Uri("images/faces/"+UserInfo.FaceId+".jpg",UriKind.Relative));
             }
            if(UserInfo.IsUpdateFri==true)
            {
                UserInfo.IsUpdateFri = false;
                ShowFriend();

            }
        }
        //点击用户的头像
        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoginUserInfo lu = new LoginUserInfo();
            lu.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //查找好友
        private void image2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddFriend af = new AddFriend();
            af.Show();
        }

      
        //关闭按钮
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

       
    }
}
