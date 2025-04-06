namespace Laboratory_work_1
{
    using System;

    public class ConsoleMenu
    {
        private Computer _computer;
        private Laptop _laptop;
        private Smartphone _smartphone;

        public ConsoleMenu()
        {
            _computer = new Computer("Gaming PC", "RTX 3080", "Intel i9", "ASUS ROG", "1TB SSD", 32);
            _laptop = new Laptop("Gaming Laptop", "RTX 3080", "Intel i9", "ASUS ROG", "1TB SSD", 32, 5000);
            _smartphone = new Smartphone("Samsung Galaxy S21", 4000);
        }

        public void ShowMainMenu()
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
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowDeviceMenu(_computer);
                        break;
                    case "2":
                        ShowDeviceMenu(_smartphone);
                        break;
                    case "3":
                        ShowDeviceMenu(_laptop);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір! Натисніть будь-яку клавішу для продовження...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowDeviceMenu(Device device)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Меню пристрою: {device.Name} ===");

                if (device is Computer computer)
                {
                    Console.WriteLine($"Відеокарта: {computer.GPU}");
                    Console.WriteLine($"Процесор: {computer.CPU}");
                    Console.WriteLine($"Материнська плата: {computer.Motherboard}");
                    Console.WriteLine($"Диск: {computer.Storage}");
                    Console.WriteLine($"ОЗУ: {computer.RAM} ГБ");
                }
                else if (device is Laptop laptop)
                {
                    Console.WriteLine($"Відеокарта: {laptop.GPU}");
                    Console.WriteLine($"Процесор: {laptop.CPU}");
                    Console.WriteLine($"Материнська плата: {laptop.Motherboard}");
                    Console.WriteLine($"Диск: {laptop.Storage}");
                    Console.WriteLine($"ОЗУ: {laptop.RAM} ГБ");
                    Console.WriteLine($"Ємність акумулятора: {laptop.BatteryCapacity} мАг");
                    Console.WriteLine($"Заряд: {laptop.BatteryLife} год");
                }
                else if (device is Smartphone smartphone)
                {
                    Console.WriteLine($"Ємність акумулятора: {smartphone.BatteryCapacity} мАг");
                    Console.WriteLine($"Заряд: {smartphone.BatteryLife} год");
                }

                Console.WriteLine($"1. Увімкнути/Вимкнути ({device.IsPoweredOn})");
                Console.WriteLine($"2. Встановити/Видалити ПЗ ({device.IsSoftwareInstalled})");
                Console.WriteLine($"3. Підключити/Відключити Інтернет ({device.IsInternetConnected})");
                Console.WriteLine($"4. Підключити/Відключити Колонки ({device.AreSpeakersConnected})");
                Console.WriteLine($"5. Робота");
                Console.WriteLine($"6. Ігри");
                Console.WriteLine($"7. Відео");
                Console.WriteLine("0. Назад");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        device.TogglePower();
                        break;
                    case "2":
                        if (device.IsSoftwareInstalled)
                            device.UninstallSoftware();
                        else
                            device.InstallSoftware();
                        break;
                    case "3":
                        if (device.IsInternetConnected)
                            device.DisconnectInternet();
                        else
                            device.ConnectInternet();
                        break;
                    case "4":
                        if (device.AreSpeakersConnected)
                            device.DisconnectSpeakers();
                        else
                            device.ConnectSpeakers();
                        break;
                    case "5":
                        device.Work();
                        Console.ReadKey();
                        break;
                    case "6":
                        device.PlayGames();
                        Console.ReadKey();
                        break;
                    case "7":
                        device.WatchVideos();
                        Console.ReadKey();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір! Натисніть будь-яку клавішу для продовження...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
