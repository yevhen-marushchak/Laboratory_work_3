namespace Laboratory_work_1
{
    public class Laptop : Device
    {
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string Motherboard { get; set; }
        public string Storage { get; set; }
        public int RAM { get; set; }
        public int BatteryCapacity { get; private set; }
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
                BatteryLife = intensiveUsage ? 4 : 12;
            else
                BatteryLife = intensiveUsage ? 16 : 48;
        }

        public override void Work()
        {
            if (!IsPoweredOn || !IsSoftwareInstalled || !IsInternetConnected)
            {
                Console.WriteLine("Не можна працювати! Переконайтеся, що ПК увімкнено, встановлено ПЗ та є підключення до інтернету.");
                return;
            }
            Console.WriteLine("Робота виконується...");
        }

        public override void PlayGames()
        {
            if (!IsPoweredOn || !IsSoftwareInstalled || !IsInternetConnected || !AreSpeakersConnected)
            {
                Console.WriteLine("Не можна грати в ігри! Увімкніть пристрій, встановіть ПЗ, підключіть інтернет і колонки.");
                return;
            }
            UpdateBatteryLife(true);
            Console.WriteLine($"Граємо в ігри...");
        }

        public override void WatchVideos()
        {
            if (!IsPoweredOn || !IsSoftwareInstalled || !AreSpeakersConnected)
            {
                Console.WriteLine("Не можна дивитися відео! Увімкніть пристрій, встановіть ПЗ і підключіть колонки.");
                return;
            }
            UpdateBatteryLife(true);
            Console.WriteLine($"Дивимось відео...");
        }
    }
}