using System.Collections.Generic;
using Newtonsoft.Json;
using andead.alice.yeelight.Models;

namespace andead.alice.yeelight.Managers
{
    public class YeelightManager
    {
        private readonly string _address = "192.168.88.251";
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

        public void TurnOn()
        {
            SetPower();
        }

        public void TurnOff()
        {
            SetPower(false);
        }
    }
}