using System;
using System.Windows.Forms;

namespace CamOnMacroscop
{
    public partial class Form1 : Form
    {
        private Random _randomId = new Random();
        private int _id; // принимает значение(номер id камеры которую надо вывести)
        private GetInformationOfConnection _getMyParse = new GetInformationOfConnection();
        public Form1() // инициализируем компоненты к кнопкам добавляем имена камер
        {
            _getMyParse.ParseIndAndUrl();

            InitializeComponent();

            button1.Text = _getMyParse.GetName(0);
            button2.Text = _getMyParse.GetName(1);
            button3.Text = _getMyParse.GetName(2);
            button4.Text = _getMyParse.GetName(3);
            button5.Text = _getMyParse.GetName(4);
            
            label1.Text = "Macroscop demo cameras";

            _id = axVLCPlugin21.playlist.add
                (

                _getMyParse.GetCamUrl(_getMyParse.GetId(_randomId.Next(0, 4))), // выбираем случайную камеру и зваускаем
                "Cam_1"

                );
            axVLCPlugin21.playlist.playItem(_id);

        }
        private void button1_Click(object sender, EventArgs e) // добавляем в плэйлист наш поток по созданному урл и проигрываем его код в других кнопках аналогичен
        {

            _id = axVLCPlugin21.playlist.add
                (

                _getMyParse.GetCamUrl(_getMyParse.GetId(0)),
                "Cam_1"

                );
            axVLCPlugin21.playlist.playItem(_id);
            label1.Text = _getMyParse.GetName(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            _id = axVLCPlugin21.playlist.add
              (

              _getMyParse.GetCamUrl(_getMyParse.GetId(1)),
              "Cam_2"

              );
            axVLCPlugin21.playlist.playItem(_id);
            label1.Text = _getMyParse.GetName(1);

        }


        private void button3_Click(object sender, EventArgs e)
        {

            _id = axVLCPlugin21.playlist.add
                  (

                  _getMyParse.GetCamUrl(_getMyParse.GetId(2)),
                  "Cam_3"

                  );
            axVLCPlugin21.playlist.playItem(_id);
            label1.Text = _getMyParse.GetName(2);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            _id = axVLCPlugin21.playlist.add
                (

                _getMyParse.GetCamUrl(_getMyParse.GetId(3)),
                "Cam_4"

                );
            axVLCPlugin21.playlist.playItem(_id);
            label1.Text = _getMyParse.GetName(3);

        }


        private void button5_Click(object sender, EventArgs e)
        {


            _id = axVLCPlugin21.playlist.add
                (

                _getMyParse.GetCamUrl(_getMyParse.GetId(4)),
                "Cam_5"

                );
            axVLCPlugin21.playlist.playItem(_id);
            label1.Text = _getMyParse.GetName(4);

        }
    }
}
