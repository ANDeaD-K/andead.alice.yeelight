using System.Collections.Generic;

namespace andead.alice.yeelight.Models.Request
{
    public class Screen
    {
    }

    public class Interfaces
    {
        public Screen screen { get; set; }
    }

    public class Meta
    {
        public string locale { get; set; }
        public string timezone { get; set; }
        public string client_id { get; set; }
        public Interfaces interfaces { get; set; }
    }

    public class Markup
    {
        public bool dangerous_context { get; set; }
    }

    public class Payload
    {
    }

    public class Tokens
    {
        public int start { get; set; }
        public int end { get; set; }
    }

    public class Entity
    {
        public Tokens tokens { get; set; }
        public string type { get; set; }
        public object value { get; set; }
    }

    public class Nlu
    {
        public List<string> tokens { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class Request
    {
        public string command { get; set; }
        public string original_utterance { get; set; }
        public string type { get; set; }
        public Markup markup { get; set; }
        public Payload payload { get; set; }
        public Nlu nlu { get; set; }
    }

    public class Session
    {
        public bool @new { get; set; }
        public int message_id { get; set; }
        public string session_id { get; set; }
        public string skill_id { get; set; }
        public string user_id { get; set; }
    }

    public class AliceRequest
    {
        public Meta meta { get; set; }
        public Request request { get; set; }
        public Session session { get; set; }
        public string version { get; set; }
    }
}