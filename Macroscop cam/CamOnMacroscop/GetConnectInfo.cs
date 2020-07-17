using System.Xml;
using System.Net;
namespace CamOnMacroscop
{
    class GetInformationOfConnection
    {
        // информация об подключаемых url две части урл нужны для более удобной передачи всего урл камеры в форму
        private string partOfUrl1 = "http://demo.macroscop.com:8080/mobile?login=root&channelid=";
        private string partOfUrl2 = "&resolutionX=640&resolutionY=480&fps=25";

        //url для парсинга id и name в Xml формате
        private string url = "http://demo.macroscop.com:8080/configex?login=root";

        //для работы с xml документом
        private XmlDocument xDoc = new XmlDocument();
        private XmlElement xRoot;

        //массив хранит id и name
        private int j = 0;
        public string[,] masNameAndId = new string[2, 5];

        public string GetId(int numberId)
        {
            j = 0;
            xDoc.LoadXml(new WebClient().DownloadString(url)); // загружаем xml файл
            xRoot = xDoc.DocumentElement; // получаем данные об xml элементаъ
            foreach (XmlNode xnode in xRoot) // делаем проход по xml документу
            {
                if (xnode.Name == "Channels") // в теге channel нужная  нам информация, а именно id и name
                {
                    foreach (XmlNode childnode in xnode.ChildNodes) // проходим по потомкам
                    {
                        foreach (XmlNode attr in childnode.Attributes) // получаем все атрибуты 
                        {
                            if (attr.Name == "Id") // записываем id  (не самый лучший способ ибо id каждый раз записывает в массив 5 элементов)
                            {
                                masNameAndId[0, j] = attr.Value;
                                j += 1;
                            }
                        }
                    }
                }

            }
            return masNameAndId[0, numberId];
        }
        public string GetName(int numberName)  // все почти тоже самое как в GetId и тоже не самый лучший алгоритм
        {
            j = 0;
            xDoc.LoadXml(new WebClient().DownloadString(url));
            xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "Channels")
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        foreach (XmlNode attr in childnode.Attributes)
                        {
                            if (attr.Name == "Name")
                            {
                                masNameAndId[1, j] = attr.Value;
                                j++;
                            }
                        }

                    }
                }
            }
            return masNameAndId[1, numberName];
        }

        public string GetCamUrl(string Id)  // собираем полученную url для вывода потока mpeg
        {
            return partOfUrl1 + Id + partOfUrl2;
        }
    }
}
