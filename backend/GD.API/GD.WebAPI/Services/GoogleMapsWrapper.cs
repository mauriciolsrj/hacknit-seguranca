using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace GD.WebAPI.Services
{
    public class GoogleMapsWrapper
    {
        public static GeocodeResponse Obter(string endereco)
        {
            string url = "https://maps.google.com/maps/api/geocode/xml?address=" + endereco + "&key=AIzaSyDgD8wlqFoNS8SsupBFHR-9LzIxCrfSVuo&sensor=false";

            var webclient = new WebClient();
            var texto = webclient.DownloadString(url);
            //9117

            return Deserialize<GeocodeResponse>(texto);
        }

        internal static T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        internal static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }


}
