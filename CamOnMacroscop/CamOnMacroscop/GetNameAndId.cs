using System.Xml;
using System.Net;
namespace CamOnMacroscop
{
    class GetInformationOfConnection
    {
        // информация об подключаемых url две части урл нужны для более удобной передачи всего урл камеры в форму
        private string _partOfUrl1;
        private string _partOfUrl2;

        //url для парсинга id и name в Xml формате
        private string _url;

        //для работы с xml документом
        private XmlDocument _xDoc = new XmlDocument();
        private XmlElement _xRoot;

        //массив хранит id и name
        private string[,] _masNameAndId = new string[2, 5];

        public GetInformationOfConnection() // задаем стандартные параметры url конструктора
        {
            _partOfUrl1 = "http://demo.macroscop.com:8080/mobile?login=root&channelid=";
            _partOfUrl2 = "&resolutionX=640&resolutionY=480&fps=25";
            _url = "http://demo.macroscop.com:8080/configex?login=root";
        }
        public string GetId(int numberId)
        {
            return _masNameAndId[0, numberId];
        }
        public string GetName(int numberName)
        {

            return _masNameAndId[1, numberName];
        }

        public void ParseIndAndUrl() //парсим урл заполняем Id и Name
        {

            int i = 0, j = 0;
            _xDoc.LoadXml(new WebClient().DownloadString(_url));
            _xRoot = _xDoc.DocumentElement;
            foreach (XmlNode xnode in _xRoot)
            {
                if (xnode.Name == "Channels")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        foreach (XmlNode attr in childnode.Attributes)
                        {
                            if (attr.Name == "Id")
                            {
                                _masNameAndId[0, j] = attr.Value;
                                j++;
                            }
                            if (attr.Name == "Name")
                            {
                                _masNameAndId[1, i] = attr.Value;
                                i++;
                            }
                        }

                    }
                }
            }
        }
        public string GetCamUrl(string Id)  // собираем полученную url для вывода потока mpeg
        {
            return _partOfUrl1 + Id + _partOfUrl2;
        }
    }
}
