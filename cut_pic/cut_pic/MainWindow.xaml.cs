using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace cut_pic
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSource img_src;
        public MainWindow()
        {
            InitializeComponent();

            load(""+System.AppDomain.CurrentDomain.BaseDirectory+"\\target.jpg");//이미지 불러오기
        }

        public void load(string path)
        {
            try
            {
                img_src = new BitmapImage(new Uri(path));//사용할 이미지 경로와 객체 생성
                img.Source = img_src;//ui image 파트에 객체 전달
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e);
            }
        }

        public CroppedBitmap part_img(BitmapSource src , int x , int y , int width , int height)
        {
            try
            {
                CroppedBitmap result = new CroppedBitmap(src, new Int32Rect(x, y, width, height));//이미지를 원하는 부분 원하는 크기 만큼 자름

                return result;//자른 결과를 반환
            }
            catch(Exception e)
            {
                MessageBox.Show("Error : " + e);
                return null;
            }
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)//그리드 뷰를 임의로 마우스 클릭 했을 시 이벤트 발생
        {
            img.Source = part_img(img_src as BitmapSource, 40, 40, 240, 320);//원하는 모양으로 잘려진 이미지가 ui image 파트에 갱신
        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
