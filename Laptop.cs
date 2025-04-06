using System;

namespace Laboratory_work_3
{
    public class Laptop : Device
    {
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string Motherboard { get; set; }
        public string Storage { get; set; }
        public int RAM { get; set; }
        public int BatteryCapacity { get; set; }
        public int BatteryLife { get; private set; }

        public Laptop(string name, string gpu, string cpu, string motherboard, string storage, int ram, int batteryCapacity)
            : base(name)
        {
            GPU = gpu;
            CPU = cpu;
            Motherboard = motherboard;
            Storage = storage;
            RAM = ram;
            BatteryCapacity = batteryCapacity;
            UpdateBatteryLife(false);
        }

        private void UpdateBatteryLife(bool intensiveUsage)
        {
            if (BatteryCapacity >= 5000)
                BatteryLife = intensiveUsage ? 4 : 12; // 5000+ мАг: 4 год для ігор/відео, 12 год для роботи
            else
                BatteryLife = intensiveUsage ? 16 : 48; // 2000-3000 мАг: 16 год для ігор/відео, 48 год для роботи
        }

        protected override void DoTask(string taskName)
        {
            bool intensiveUsage = taskName == "Ігри" || taskName == "Відео";

            if (intensiveUsage)
                UpdateBatteryLife(true);
            else
                UpdateBatteryLife(false);

            switch (taskName)
            {
                case "Робота":
                    OnDeviceEvent("Виконується робота...");
                    break;
                case "Ігри":
                    OnDeviceEvent("Граємо в ігри...");
                    break;
                case "Відео":
                    OnDeviceEvent("Дивимось відео...");
                    break;
                default:
                    OnDeviceEvent("Невідоме завдання.");
                    break;
            }
            OnDeviceEvent($"Рівень заряду: {BatteryLife} год");
        }
    }
}