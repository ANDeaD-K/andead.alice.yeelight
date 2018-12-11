using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using andead.alice.yeelight.Models;
using andead.alice.yeelight.Models.Request;
using andead.alice.yeelight.Models.Response;

namespace andead.alice.yeelight.Managers
{
    public class YeelightManager
    {
        private readonly string _address = "10.88.1.6";
        private readonly int _port = 55443;

        private void SetPower(bool on = true)
        {
            SocketManager.SendData(_address, _port, JsonConvert.SerializeObject(new YeelightCommandMessage()
            {
                id = 1,
                method = "set_power",
                @params = new List<object>()
                {
                    on ? "on" : "off", "smooth", 500
                }
            }));
        }

        public async void TurnOn()
        {
            await Task.Run(() => SetPower());
        }

        public async void TurnOff()
        {
            await Task.Run(() => SetPower(false));
        }

        public AliceResponse GetCommand(AliceRequest request)
        {
            List<string> turnOnWords = new List<string>()
            {
                "включить",
                "включи",
                "зажги",
                "зажечь",
                "включай"
            };

            List<string> turnOffWords = new List<string>()
            {
                "отключи",
                "выключи",
                "погаси",
                "выключай",
                "отключай",
                "отключить",
                "погасить",
                "отключить",
                "выключить"
            };

            List<string> endWords = new List<string>()
            {
                "спасибо",
                "пока",
                "благодарю"
            };

            if (request.request.nlu.tokens.Any(word => turnOnWords.Contains(word)))
            {
                TurnOn();
                return new AliceManager().Reply(request, "Включаю свет");
            }

            if (request.request.nlu.tokens.Any(word => turnOffWords.Contains(word)))
            {
                TurnOff();
                return new AliceManager().Reply(request, "Выключаю свет");
            }

            if (request.request.nlu.tokens.Any(word => endWords.Contains(word)))
            {
                return new AliceManager().Reply(request, "Пока!", true);
            }

            return new AliceManager().Reply(request, "Вы должны сказать \"включи свет\" для включения света или \"выключи свет\" для его отключения");
        }
    }
}