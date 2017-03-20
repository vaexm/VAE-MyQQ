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
namespace _1017MyQQ.vae
{
    /// <summary>
    /// AddFriend.xaml 的交互逻辑
    /// </summary>
    public partial class AddFriend : Window
    {
        public AddFriend()
        {
            InitializeComponent();
        }
        //附近的人
        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //img1.Visibility = System.Windows.Visibility.Hidden; img2.Visibility = System.Windows.Visibility.Hidden;
            //la.Visibility = System.Windows.Visibility.Hidden;
            back.Children.Remove(img1);
            back.Children.Remove(img2);
            back.Children.Remove(la);
            dataGrid1.Visibility = System.Windows.Visibility.Visible;
            DataSet NearFriend = UserManager.SelectNearBy();
            dataGrid1.ItemsSource = NearFriend.Tables[0].DefaultView;
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }
       

       
        //详细查找好友
        DataSet ds;
        int id;
        Label lb1, lb2,la;
        Button btn, btn1;
        Image img1, img2;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            back.Children.Remove(img1);
            back.Children.Remove(img2);
            back.Children.Remove(la);
        
            la = new Label();
            la.Width = 120;
            la.Height = 30;
            Canvas.SetLeft(la, 170);
            Canvas.SetTop(la, 130);
            la.Content = "";
            dataGrid1.Visibility = System.Windows.Visibility.Hidden;
             img1 = new Image();
            img1.Width = img1.Height = 100;
            img1.Stretch = Stretch.Fill;
            Canvas.SetLeft(img1,50);
            Canvas.SetTop(img1,120);
             img2 = new Image();
            img2.Width = 60;
            img2.Height = 25;
            img2.Source = new BitmapImage(new Uri("images/play/Fri1.jpg",UriKind.Relative));
            img2.MouseLeftButtonDown += new MouseButtonEventHandler(img2_MouseLeftButtonDown);
            Canvas.SetTop(img2,180);
            Canvas.SetLeft(img2,170);
           
          
            back.Children.Add(img2);
            back.Children.Add(img1);
            back.Children.Add(la);
            if (comboBox1.Text == "按昵称查找")
            {
                ds = UserManager.FindFriendN(textBox1.Text);
                img1.Source = new BitmapImage(new Uri("images/faces/"+ds.Tables[0].Rows[0]["FaceId"]+".jpg",UriKind.Relative));
                la.Content = ds.Tables[0].Rows[0]["NickName"];
                
            }
            else if (comboBox1.Text == "按帐号查找")
            {
                int a = int.Parse(textBox1.Text);
                ds = UserManager.FindFriendI(a);
                img1.Source = new BitmapImage(new Uri("images/faces/" + ds.Tables[0].Rows[0]["FaceId"] + ".jpg", UriKind.Relative));
                la.Content = ds.Tables[0].Rows[0]["NickName"];

            }
            //dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
        }
        //添加好友
        void img2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            id =int.Parse( ds.Tables[0].Rows[0]["Id"].ToString());
            int res = UserManager.IsFriend(id);
            if(res>=1)
            {
                MessageBox.Show("你们已经是好友了");
            }
            else if(int.Parse(ds.Tables[0].Rows[0]["FriendshipPolicyid"].ToString())==3)
            {
                int res1 = UserManager.AddFriend(id);
                MessageBox.Show("你已成功添加对方为好友");
                UserInfo.IsUpdateFri = true;
            }
            else if (int.Parse(ds.Tables[0].Rows[0]["FriendshipPolicyid"].ToString()) == 1)
            {
                MessageBox.Show("对方不允许任何人添加他为好友");
            }
            else if (int.Parse(ds.Tables[0].Rows[0]["FriendshipPolicyid"].ToString()) == 2)
            {
               lb1 = new Label();
                lb1.Width = 300;
                lb1.Height = 100;
                lb1.Background = Brushes.AliceBlue;
                lb1.Content = "对方需要你的验证信息";
                lb1.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                Canvas.SetLeft(lb1,back.Width/2-lb1.Width/2);
                Canvas.SetTop(lb1,back.Height/2-lb1.Height/2);
                lb2 = new Label();
                lb2.Width = 300;
                lb2.Height = 25;
                lb2.Background = Brushes.HotPink;
                lb2.Content = "添加好友";
                lb2.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                Canvas.SetLeft(lb2,Canvas.GetLeft(lb1));
                Canvas.SetTop(lb2,Canvas.GetTop(lb1)-25);
                btn = new Button();
                btn.Width = 60;
                btn.Height = 30;
                btn.Content = "确定";
                btn.Click += new RoutedEventHandler(btn_Click);
                Canvas.SetLeft(btn,Canvas.GetLeft(lb1)+100);
                Canvas.SetTop(btn,Canvas.GetTop(lb1)+lb1.Height-btn.Height);
                //Canvas.SetLeft(lb2, Canvas.GetLeft(lb1));
                //Canvas.SetTop(lb2, Canvas.GetTop(lb1));
                btn1 = new Button();
                btn1.Width = 60;
                btn1.Height = 30;
                btn1.Content = "取消";
                Canvas.SetLeft(btn1, Canvas.GetLeft(btn)+100);
                Canvas.SetTop(btn1, Canvas.GetTop(lb1) + lb1.Height - btn.Height);
                btn1.Click += new RoutedEventHandler(btn1_Click);
                back.Children.Add(lb1);
                back.Children.Add(lb2);
                back.Children.Add(btn);
                back.Children.Add(btn1);
                
            }
            
        }

        void btn1_Click(object sender, RoutedEventArgs e)
        {
            lb1.Visibility =  System.Windows.Visibility.Hidden; lb2.Visibility =  System.Windows.Visibility.Hidden; btn.Visibility =  System.Windows.Visibility.Hidden ; btn1.Visibility =System.Windows.Visibility.Hidden;
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            int res2 = UserManager.AddFriend(id);
            if(res2==1)
            {
                MessageBox.Show("你已经成功添加对方为好友");
            }
            UserInfo.IsUpdateFri = true;
            back.Children.Remove(btn);
            back.Children.Remove(btn1);
            back.Children.Remove(lb1);
            back.Children.Remove(lb2);
            
        }
        //添加好友
        private void button2_Click(object sender, RoutedEventArgs e)
           
        {
            DataRowView drv = dataGrid1.SelectedItem as DataRowView;
            int id = int.Parse(drv["Id"].ToString());
            int res = UserManager.IsFriend(id);
            if (res >= 1)
            {
                MessageBox.Show("对方已经是你的好友");
            }
            else if (int.Parse(drv["FriendshipPolicyId"].ToString()) == 3)
            {
                //直接添加res
                int res1 = UserManager.AddFriend(id);
                UserInfo.IsUpdateFri = true;
            }
            else if (int.Parse(drv["FriendshipPolicyId"].ToString()) == 1)
            {
                MessageBox.Show("对方不允许任何人添加他为好友");
            }
            else if (int.Parse(drv["FriendshipPolicyId"].ToString()) == 2)
            {
                MessageBoxResult result = MessageBox.Show("你确定要添加该人为好友吗？", "对方需要你的身份验证", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    int res2 = UserManager.AddFriend(id);
                    UserInfo.IsUpdateFri = true;
                }
            }

                   
                

                
                
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
  
    }
}
