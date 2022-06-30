using System;
using System.Collections.Generic;
namespace DoFactory.GangOfFour.Builder.RealWorld
{

    /// <summary>
    /// The 'Director' class - магазин
    /// </summary>
    class TechService
    {
        //Конструююємо через об'єкт Builder, складна серія процесів
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }
    /// <summary>
    /// The 'Builder' abstract class який конструюює частини продукта
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;
        // Сутність транспорта
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }
        // Абстрактні методи 
        public abstract void BuildFrame(); //каркас
        public abstract void BuildEngine(); //двигун
        public abstract void BuildWheels(); //колеса
        public abstract void BuildDoors(); //двері
    }
    /// <summary>
    /// The 'ConcreteBuilder1', який збирає мотоцикл (збирає і наповнює складові Продукта)
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "500 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder2', який збирає машину
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Car Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "2500 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "4";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "4";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder3', який збирає скутер
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Scooter");
        }
        public override void BuildFrame()
        {
            vehicle["frame"] = "Scooter Frame";
        }
        public override void BuildEngine()
        {
            vehicle["engine"] = "50 cc";
        }
        public override void BuildWheels()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'Product', який ми збираємо і демонструє свої властивоті
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();
        // Constructor
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
        // Indexer
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame : {0}", _parts["frame"]);
            Console.WriteLine(" Engine : {0}", _parts["engine"]);
            Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
            Console.WriteLine(" #Doors : {0}", _parts["doors"]);
        }
    }

    /// <summary>
    /// MainApp startup class for Real-World 
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        public static void Main()
        {
            VehicleBuilder builder;

            // Створюємо сервіс (директора) з білдерами
            TechService service = new TechService();

            // Констрююємо і демонструємо техніку
            builder = new ScooterBuilder();
            service.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            service.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            service.Construct(builder);
            builder.Vehicle.Show();

            // Wait for user
            Console.ReadKey();
        }
    }
}
