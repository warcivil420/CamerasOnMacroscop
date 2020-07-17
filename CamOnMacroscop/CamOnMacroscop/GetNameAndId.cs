using System.Xml;
using System.Net;
namespace CamOnMacroscop
{
    class GetInformationOfConnection
    {
        // информация об подключаемых url две части урл нужны для более удобной передачи всего урл камеры в форму
        private string partOfUrl1;
        private string partOfUrl2;

        //url для парсинга id и name в Xml формате
        private string url;

        //для работы с xml документом
        private XmlDocument xDoc = new XmlDocument();
        private XmlElement xRoot;

        //массив хранит id и name
        private string[,] masNameAndId = new string[2, 5];
        
        public GetInformationOfConnection() // задаем стандартные url конструктора
        {
            partOfUrl1 = "http://demo.macroscop.com:8080/mobile?login=root&channelid=";
            partOfUrl2 = "&resolutionX=640&resolutionY=480&fps=25";
          // две части урл для удобного возврата всего урл вместе c id

            url = "http://demo.macroscop.com:8080/configex?login=root"; // url для xml
        }
        public string GetId(int numberId)
        {
            return masNameAndId[0, numberId];
        }
        public string GetName(int numberName)  
        {
          
            return masNameAndId[1, numberName];
        }

        public void ParseIndAndUrl() //парсим урл заполняем Id и Name
        {

            int i = 0, j = 0;
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
                            if (attr.Name == "Id")
                            {
                                masNameAndId[0, j] = attr.Value;
                                j++;
                            }
                            if (attr.Name == "Name")
                            {
                                masNameAndId[1, i] = attr.Value;
                                i++;
                            }
                        }

                    }
                }
            }
        }
        public string GetCamUrl(string Id)  // собираем полученную url для вывода потока mpeg
        {
            return partOfUrl1 + Id + partOfUrl2;
        }
    }
}
