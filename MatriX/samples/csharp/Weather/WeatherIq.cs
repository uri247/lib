using Matrix.Xmpp.Client;

namespace Weather
{
    public class WeatherIq : Iq
    {
        public WeatherIq()
        {
            GenerateId();
        }

        public Weather Weather
        {
            get { return Element<Weather>(); }
            set { Replace(value); }
        }
    }
}