// See https://aka.ms/new-console-template for more information

using ANZTest.Helpers;
using ANZTest.Models;
using ANZTest.Service;
using ANZTest.Validation;
using Microsoft.Extensions.Logging;

namespace ANZTest.Root
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var tableModel = new TableModel(0, 5, 0, 5);
                var toyModel = new ToyModel(tableModel);
                var validation = new InputValidation(tableModel);
                var gameService = new GameService(toyModel,tableModel,validation);
                gameService.StartGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
