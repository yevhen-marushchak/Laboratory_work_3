using System;

namespace Laboratory_work_3
{
    public class Smartphone : Device
    {
        public int BatteryCapacity { get; private set; }
        public int BatteryLife { get; private set; }

        public Smartphone(string name, int batteryCapacity) : base(name)
        {
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

        protected override bool PreconditionsMet(string taskName)
        {
            bool isBatterySufficient = BatteryLife > 0;
            switch (taskName)
            {
                case "Робота":
                    return base.PreconditionsMet(taskName) && isBatterySufficient;
                case "Ігри":
                    return base.PreconditionsMet(taskName) && isBatterySufficient;
                case "Відео":
                    return base.PreconditionsMet(taskName) && isBatterySufficient;
                default:
                    return false;
            }
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