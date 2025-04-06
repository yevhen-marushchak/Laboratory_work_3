namespace Laboratory_work_1
{
    public class Computer : Device
    {
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string Motherboard { get; set; }
        public string Storage { get; set; }
        public int RAM { get; set; }

        public Computer(string name, string gpu, string cpu, string motherboard, string storage, int ram)
            : base(name)
        {
            GPU = gpu;
            CPU = cpu;
            Motherboard = motherboard;
            Storage = storage;
            RAM = ram;
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
                Console.WriteLine("Не можна грати в ігри! Переконайтеся, що ПК увімкнено, встановлено ПЗ, є інтернет і колонки.");
                return;
            }
            Console.WriteLine("Граємо в ігри...");
        }

        public override void WatchVideos()
        {
            if (!IsPoweredOn || !IsSoftwareInstalled || !AreSpeakersConnected)
            {
                Console.WriteLine("Не можна дивитися відео! Переконайтеся, що ПК увімкнено, встановлено ПЗ і підключені колонки.");
                return;
            }
            Console.WriteLine("Дивимось відео...");
        }
    }
}
