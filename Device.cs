using System;

namespace Laboratory_work_3
{
    public abstract class Device
    {
        public string Name { get; set; }
        public bool IsOn { get; set; }
        public bool HasSoftware { get; set; }
        public bool InternetConnected { get; set; }
        public bool SpeakersConnected { get; set; }

        protected Device(string name)
        {
            Name = name;
        }

        public void PerformTask(string taskName)
        {
            if (!PreconditionsMet(taskName))
            {
                OnDeviceEvent($"Завдання '{taskName}' неможливо виконати через невідповідність умов.");
                return;
            }
            OnDeviceEvent($"Завдання запущено: {taskName}");
            DoTask(taskName);
            OnDeviceEvent($"Завдання виконано: {taskName}");
        }

        protected abstract void DoTask(string taskName);

        protected virtual bool PreconditionsMet(string taskName)
        {
            switch (taskName)
            {
                case "Робота":
                    return IsOn && HasSoftware && InternetConnected;
                case "Ігри":
                    return IsOn && HasSoftware && InternetConnected && SpeakersConnected;
                case "Відео":
                    return IsOn && HasSoftware && SpeakersConnected;
                default:
                    return false;
            }
        }

        public event EventHandler<DeviceEventArgs> DeviceEvent;

        protected void OnDeviceEvent(string message)
        {
            DeviceEvent?.Invoke(this, new DeviceEventArgs { Message = message, DeviceName = Name });
        }
    }

    public class DeviceEventArgs : EventArgs
    {
        public string DeviceName { get; set; }
        public string Message { get; set; }
    }
}