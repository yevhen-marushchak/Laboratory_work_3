using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_work_3
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

        protected override void DoTask(string taskName)
        {
            switch (taskName)
            {
                case "Робота":
                    OnDeviceEvent("Робота виконується...");
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
        }
    }
}
