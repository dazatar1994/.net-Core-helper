using System.Net;
using System.Xml;

namespace Helper
{
       class WeatherData
       {
           public WeatherData(string City)
           {
               city = City;
           }
           private string city;
           private float temp;
           private float tempMax;
           private float tempMin;

           public void CheckWeather()
           {
               WeatherAPI DataAPI = new WeatherAPI(City);
               temp = DataAPI.GetTemp();
           }

           public string City { get => city; set => city = value; }
           public float Temp { get => temp; set => temp = value; }
           public float TempMax { get => tempMax; set => tempMax = value; }
           public float TempMin { get => tempMin; set => tempMin = value; }
       }
       class WeatherAPI
       {
           public WeatherAPI(string city)
           {
               SetCurrentURL(city);
               xmlDocument = GetXML(CurrentURL);
           }

           public float GetTemp()
           {
               XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
               XmlAttribute temp_value = temp_node.Attributes["value"];
               string temp_string = temp_value.Value;
               return float.Parse(temp_string);
           }

           private const string APIKEY = "254be7c1e982fc33250c809f7cb0162a";
           private string CurrentURL;
           private XmlDocument xmlDocument;

           private void SetCurrentURL(string location)
           {
               CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=xml&units=metric&APPID=" + APIKEY;
           }

           private XmlDocument GetXML(string CurrentURL)
           {
               using (WebClient client = new WebClient())
               {
                   string xmlContent = client.DownloadString(CurrentURL);
                   XmlDocument xmlDocument = new XmlDocument();
                   xmlDocument.LoadXml(xmlContent);
                   return xmlDocument;
               }
           }
       }
}