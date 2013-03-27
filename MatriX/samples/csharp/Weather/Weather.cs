using Matrix.Xml;

namespace Weather
{
    public class Weather : XmppXElement
    {
        public Weather() : base("ag-software:weather", "weather")
        {
        }

        public int Humidity
        {
            get { return GetTagInt("humidity"); }
            set { SetTag("humidity", value); }
        }

        public int Temperature
        {
            get { return GetTagInt("temperature");}
            set { SetTag("temperature", value); }
        }

        public string Zip
        {
            get { return GetTag("zip"); }
            set { SetTag("zip", value); }
        }
    }
}