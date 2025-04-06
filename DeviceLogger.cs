using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_3
{
    public class DeviceLogger
    {
        public void Subscribe(Device device)
        {
            device.DeviceEvent += OnDeviceEventReceived;
        }

        private void OnDeviceEventReceived(object sender, DeviceEventArgs e)
        {
            Console.WriteLine($"[LOG][{e.DeviceName}]: {e.Message}");
        }
    }
}
