using System.Collections.Generic;

namespace andead.alice.yeelight.Models.Response
{
    public class Payload
    {
    }

    public class Button
    {
        public string title { get; set; }
        public Payload payload { get; set; }
        public string url { get; set; }
        public bool hide { get; set; }
    }

    public class Response
    {
        public string text { get; set; }
        public string tts { get; set; }
        public List<Button> buttons { get; set; }
        public bool end_session { get; set; }
    }

    public class Session
    {
        public string session_id { get; set; }
        public int message_id { get; set; }
        public string user_id { get; set; }
    }

    public class AliceResponse
    {
        public Response response { get; set; }
        public Session session { get; set; }
        public string version { get; set; }
    }
}