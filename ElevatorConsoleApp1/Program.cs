using System;

namespace ElevatorConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var eleObject = new ElevatorSimulator();
            do
            {
                eleObject.PrintElevatorsStatus();
                AddSampleRequest(eleObject, "6", EnumDirection.Up);
                AddSampleRequest(eleObject, "7", EnumDirection.Down);
                Console.WriteLine("Please enter the new 'Down' request floor :");
                AddSampleRequest(eleObject, Console.ReadLine(), EnumDirection.Down);
                Console.WriteLine("Please enter the new 'Up' request floor :");
                AddSampleRequest(eleObject, Console.ReadLine(), EnumDirection.Up);
                Console.WriteLine("Please enter the Elevator Name to pause :");
                eleObject.AddPause(Console.ReadLine());
                Console.WriteLine("Please enter the Elevator Name to start :");
                eleObject.RemovePause(Console.ReadLine());
                Console.ReadKey();
            } while (true);
        }

        private static void AddSampleRequest(ElevatorSimulator eleObject, string floor, EnumDirection direction)
        {
            if (!string.IsNullOrWhiteSpace(floor))
            {
                var floorNumber = Convert.ToInt32(floor);
                var rawFloorNumer = EnumFloorName.Floor1.GetRawFloorNumer(floorNumber);
                string eleNumber = eleObject.AddRequest(rawFloorNumer, direction);
                //eleObject.PrintElevatorsStatus();
                Console.WriteLine($"Request Floor {EnumFloorName.Floor1.GetRawFloorName(rawFloorNumer)} Direction { direction } Elevator Number: {eleNumber} is waiting");
            }
        }
    }
}
