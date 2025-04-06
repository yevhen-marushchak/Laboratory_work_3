namespace Laboratory_work_1
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

        public override void Work()
        {
            if (!IsPoweredOn || !IsSoftwareInstalled || !IsInternetConnected)
            {
                Console.WriteLine("Не можна працювати! Увімкніть пристрій, встановіть ПЗ і підключіть інтернет.");
                return;
            }
            UpdateBatteryLife(false);
            Console.WriteLine($"Виконується робота...");
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
