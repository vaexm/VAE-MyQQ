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
using MODEL;
using BLL;
using System.Windows.Threading;
using System.Data;

namespace _1017MyQQ.vae
{
    /// <summary>
    /// Chat.xaml 的交互逻辑
    /// </summary>
    public partial class Chat : Window
    {
        public Chat()
        {
            InitializeComponent();
        }
        //发送
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text+=UserInfo.UserTable.Tables[0].Rows[0]["NickName"]+" "+DateTime.Now+"\r\n"+textBox2.Text+"\r\n";
            //Time = DateTime.Now;
            //将消息添加到数据库里
            //UserInfo.Time = DateTime.Now;
            int res = UserManager.SendMessage(UserInfo.LoginId,UserInfo.ToUserId,textBox2.Text,1,1,DateTime.Now);
            textBox2.Text = "";
        }
 
            
        //控制读取消息  
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(3);
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //获取你要聊天的好友信息
            DataSet dsChatF = UserManager.bllGetUser(UserInfo.ToUserId);
            UserInfo.ChatTable= dsChatF;
            image2.Source = new BitmapImage(new Uri("images/faces/"+dsChatF.Tables[0].Rows[0]["FaceId"]+".jpg",UriKind.Relative));
            label1.Content = dsChatF.Tables[0].Rows[0]["NickName"];
           
         
           
            
        }

        

        
        void dt_Tick(object sender, EventArgs e)
        {
            DispatcherTimer dt = sender as DispatcherTimer;
            //读取消息的表
            DataSet dtMessage = UserManager.ReadMessage();
            foreach(DataRow dr in dtMessage.Tables[0].Rows)
            {
                if(int.Parse(dr["MessageState"].ToString())==1)
                {
                    if(int.Parse(dr["MessageTypeId"].ToString())==3)
                    {
                        textBox1.Text += UserInfo.ChatTable.Tables[0].Rows[0]["NickName"] +" "+ "给你发送了一个窗口抖动"+dr["MessageTime"]+"\r\n";
                        ZhenDong();
                    }
                    else if(int.Parse(dr["MessageTypeId"].ToString())==1)
                    {
                        textBox1.Text+=UserInfo.ChatTable.Tables[0].Rows[0]["NickName"]+" "+dr["MessageTime"]+"\r\n"+dr["Message"].ToString()+"\r\n";
                    }
                }
                //读完消息，修改消息状态
                int id = int.Parse(dr["Id"].ToString());
                int res = UserManager.UpdateMessage(id);
            }
           
           
        }
        //震动消息
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //textBox1.TextAlignment = TextAlignment.Right;
            textBox1.Text += "你发送了一个窗口抖动"+" "+DateTime.Now+"\r\n";
            int res = UserManager.SendMessage(UserInfo.LoginId, UserInfo.ToUserId, "窗口抖动",3,1,DateTime.Now);

            ZhenDong();

                
           
            

           
            
            

        }

        private void ZhenDong()
        {
            int x = (int)this.Left;
            int y = (int)this.Top;

            for (int i = 0; i < 3; i++)
            {
                this.Left = x; this.Top = y - 10;
                System.Threading.Thread.Sleep(30);
                this.Left = x + 10; this.Top = y - 10;
                System.Threading.Thread.Sleep(30);
                this.Left = x + 10; this.Top = y;
                System.Threading.Thread.Sleep(30);
                this.Left = x + 10; this.Top = y + 10;
                System.Threading.Thread.Sleep(30);
                this.Left = x; this.Top = y + 10;
                System.Threading.Thread.Sleep(30);
                this.Left = x - 10; this.Top = y + 10;
                System.Threading.Thread.Sleep(30);
                this.Left = x - 10; this.Top = y;
                System.Threading.Thread.Sleep(30);
                this.Left = x - 10; this.Top = y - 10;
                System.Threading.Thread.Sleep(30);
            }
            this.Left = x;
            this.Top = y;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //最小化
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //关闭
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
