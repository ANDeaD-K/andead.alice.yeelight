using andead.alice.yeelight.Models.Request;
using andead.alice.yeelight.Models.Response;

namespace andead.alice.yeelight.Managers
{
    public class AliceManager
    {
        public AliceResponse Reply(AliceRequest request, string responseText, bool isEndSession = false)
        {
            return new AliceResponse()
            {
                response = new Response()
                {
                    text = responseText,
                    end_session = isEndSession
                },
                session = new andead.alice.yeelight.Models.Response.Session()
                {
                    session_id = request.session.session_id,
                    message_id = request.session.message_id,
                    user_id = request.session.user_id
                },
                version = "1.0"
            };
        }
    }
}