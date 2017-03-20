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
using System.Data;
namespace _1017MyQQ.vae
{
    /// <summary>
    /// Face.xaml 的交互逻辑
    /// </summary>
    public partial class Face : Window
    {
        public Face()
        {
            InitializeComponent();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content = "头像";
            label1.FontSize = 20;
          
            //back.Children.Add(image2);
            int num = 1;
            //生成头像
            for (int i = 0; i < 5;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Image img = new Image();
                    img.Width = img.Height = 80;
                    img.Stretch = Stretch.Fill;
                    img.Tag = num;
                    img.Source = new BitmapImage(new Uri("images/faces/" + num + ".jpg", UriKind.Relative));
                    img.MouseLeftButtonDown += new MouseButtonEventHandler(img_MouseLeftButtonDown);


                    Canvas.SetLeft(img,80 + j * img.Width);
                    Canvas.SetTop(img, back.Height / 2 - img.Height * 5 / 2 + i * img.Height);

                    back.Children.Add(img);
                    num++;
                }
              
                DataSet ds = UserInfo.UserTable;
                image2.Source = new BitmapImage(new Uri("images/faces/" + ds.Tables[0].Rows[0]["FaceId"] + ".jpg", UriKind.Relative));
              
             
              
            
            }
        }

        void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //接收Tag 对象的强转
            Image img = sender as Image;
           
            UserInfo.FaceId =int.Parse (img.Tag.ToString());
            image2. Source = new BitmapImage(new Uri("images/faces/"+UserInfo.FaceId+".jpg",UriKind.Relative));
           

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //最小化
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        //关闭
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
              UserInfo.IsFaClick = false;
        }
    }
}
