using System;
using System.Windows.Forms;

namespace CamOnMacroscop
{
    public partial class Form1 : Form
    {
        private Random randomId = new Random();
        private int id; // принимает значение(номер id камеры которую надо вывести)
        private GetInformationOfConnection getMyParse = new GetInformationOfConnection();
        public Form1() // инициализируем компоненты к кнопкам добавляем имена камер
        {
            getMyParse.ParseIndAndUrl();

            InitializeComponent();

            button1.Text = getMyParse.masNameAndId[1, 4];
            button2.Text = getMyParse.GetName(1);
            button3.Text = getMyParse.GetName(2);
            button4.Text = getMyParse.GetName(3);
            button5.Text = getMyParse.GetName(4);
            
            label1.Text = "Macroscop demo cameras";

            id = axVLCPlugin21.playlist.add
                (

                getMyParse.GetCamUrl(getMyParse.GetId(randomId.Next(0, 4))), // выбираем случайную камеру и зваускаем
                "Cam_1"

                );
            axVLCPlugin21.playlist.playItem(id);

        }
        private void button1_Click(object sender, EventArgs e) // добавляем в плэйлист наш поток по созданному урл и проигрываем его код в других кнопках аналогичен
        {

            id = axVLCPlugin21.playlist.add
                (

                getMyParse.GetCamUrl(getMyParse.GetId(0)),
                "Cam_1"

                );
            axVLCPlugin21.playlist.playItem(id);
            label1.Text = getMyParse.GetName(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            id = axVLCPlugin21.playlist.add
              (

              getMyParse.GetCamUrl(getMyParse.GetId(1)),
              "Cam_2"

              );
            axVLCPlugin21.playlist.playItem(id);
            label1.Text = getMyParse.GetName(1);

        }


        private void button3_Click(object sender, EventArgs e)
        {

            id = axVLCPlugin21.playlist.add
                  (

                  getMyParse.GetCamUrl(getMyParse.GetId(2)),
                  "Cam_3"

                  );
            axVLCPlugin21.playlist.playItem(id);
            label1.Text = getMyParse.GetName(2);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            id = axVLCPlugin21.playlist.add
                (

                getMyParse.GetCamUrl(getMyParse.GetId(3)),
                "Cam_4"

                );
            axVLCPlugin21.playlist.playItem(id);
            label1.Text = getMyParse.GetName(3);

        }


        private void button5_Click(object sender, EventArgs e)
        {


            id = axVLCPlugin21.playlist.add
                (

                getMyParse.GetCamUrl(getMyParse.GetId(4)),
                "Cam_5"

                );
            axVLCPlugin21.playlist.playItem(id);
            label1.Text = getMyParse.GetName(4);

        }
    }
}
