using System;

namespace Laboratory_work_3
{
    public class ConsoleMenu
    {
        private DeviceLogger logger = new DeviceLogger();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Головне меню ===");
                Console.WriteLine("1. Комп'ютер");
                Console.WriteLine("2. Смартфон");
                Console.WriteLine("3. Ноутбук");
                Console.WriteLine("0. Вихід");
                Console.Write("Виберіть опцію: ");

                var input = Console.ReadLine();
                Device device = input switch
                {
                    "1" => new Computer("Gaming PC", "RTX 3080", "Intel i9", "ASUS ROG", "1TB SSD", 32),
                    "2" => new Smartphone("Samsung Galaxy S21", 4000),
                    "3" => new Laptop("Gaming Laptop", "RTX 3080", "Intel i9", "ASUS ROG", "1TB SSD", 32, 5000),
                    "0" => null,
                    _ => null
                };

                if (device == null) break;

                logger.Subscribe(device);
                DeviceMenu(device);
            }
        }

        private void DeviceMenu(Device device)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== меню {device.Name} ===");

                if (device is Computer computer)
                {
                    Console.WriteLine($"GPU: {computer.GPU}");
                    Console.WriteLine($"CPU: {computer.CPU}");
                    Console.WriteLine($"Motherboard: {computer.Motherboard}");
                    Console.WriteLine($"Storage: {computer.Storage}");
                    Console.WriteLine($"RAM: {computer.RAM} GB");
                }
                else if (device is Smartphone smartphone)
                {
                    Console.WriteLine($"Battery Capacity: {smartphone.BatteryCapacity} mAh");
                    Console.WriteLine($"Battery Life: {smartphone.BatteryLife} hours");
                }
                else if (device is Laptop laptop)
                {
                    Console.WriteLine($"GPU: {laptop.GPU}");
                    Console.WriteLine($"CPU: {laptop.CPU}");
                    Console.WriteLine($"Motherboard: {laptop.Motherboard}");
                    Console.WriteLine($"Storage: {laptop.Storage}");
                    Console.WriteLine($"RAM: {laptop.RAM} GB");
                    Console.WriteLine($"Battery Capacity: {laptop.BatteryCapacity} mAh");
                    Console.WriteLine($"Battery Life: {laptop.BatteryLife} hours");
                }

                Console.WriteLine($"1. Увімкнути/Вимкнути ({device.IsOn})");
                Console.WriteLine($"2. Встановити/Видалити ПЗ ({device.HasSoftware})");
                Console.WriteLine($"3. Підключити/Відключити Інтернет ({device.InternetConnected})");
                Console.WriteLine($"4. Підключити/Відключити Колонки ({device.SpeakersConnected})");
                Console.WriteLine("5. Робота");
                Console.WriteLine("6. Ігри");
                Console.WriteLine("7. Відео");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш вибір: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1": device.IsOn = !device.IsOn; break;
                    case "2": device.HasSoftware = !device.HasSoftware; break;
                    case "3": device.InternetConnected = !device.InternetConnected; break;
                    case "4": device.SpeakersConnected = !device.SpeakersConnected; break;
                    case "5": device.PerformTask("Робота"); break;
                    case "6": device.PerformTask("Ігри"); break;
                    case "7": device.PerformTask("Відео"); break;
                    case "0": return;
                }

                Console.WriteLine("Натисніть Enter...");
                Console.ReadLine();
            }
        }
    }
}