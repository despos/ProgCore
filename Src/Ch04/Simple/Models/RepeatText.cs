//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch04 - ASP.NET MVC Controllers
//   Simple
//

namespace Ch04.Simple.Models
{
    public class RepeatText
    {
        public RepeatText()
        {
            Options = new RepeatTextOptions();
        }
        public string Text { get; set; }
        public int Number { get; set; }
        public RepeatTextOptions Options { get; set; }
    }

    public class RepeatTextOptions
    {
        public RepeatTextOptions()
        {
            Factor = 1;
        }
        public int Factor { get; set; }
    }
}
