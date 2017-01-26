
using System.Text;

namespace HelloWorld
{
    public class App {

        IRandomGenerator _rg;
        
        public App(IRandomGenerator r) {
            _rg = r;
        }

        public string getWelcomeMessage() {
            var s = new StringBuilder("Hello fella from ASP.NET Core! Running on host ");
            s.Append(System.Net.Dns.GetHostName());
            s.Append("\n\nHere is a random integer between 1 and 10 : ");
            s.AppendFormat("{0} ", _rg.getRandomInt(1, 10).ToString());
            return s.ToString();
        }
    }
}