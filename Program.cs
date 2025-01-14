﻿using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var databaseConfig = new DatabaseConfig();

        var databaseSetup = new DatabaseSetup(databaseConfig);

        var computerRepository = new ComputerRepository(databaseConfig);


        // Routing
        var modelName = args[0];
        var modelAction = args[1];

        if (modelName == "Computer")
        {
            if (modelAction == "List")
            {
                Console.WriteLine("List Computer");
                foreach (var computer in computerRepository.GetAll())
                {
                    Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
                }
            }
            if (modelAction == "New")
            {
                var id = Convert.ToInt32(args[2]);
                var ram = args[3];
                var processor = args[4];

                var computer = new Computer(id, ram, processor);
                computerRepository.Save(computer);
            }
        }
    }
}