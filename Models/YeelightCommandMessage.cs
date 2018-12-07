using System.Collections.Generic;

namespace andead.alice.yeelight.Models
{
    public class YeelightCommandMessage
    {
        public int id { get; set; }
        public string method { get; set; }
        public List<object> @params { get; set; }
    }
}