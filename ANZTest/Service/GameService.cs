using ANZTest.Helpers;
using ANZTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANZTest.Service
{
    public class GameService
    {
        private readonly IToyModel _toyModel;
        private readonly ITableModel _tableModel;
        private readonly IValidation _validation;

        public GameService(IToyModel toyModel, ITableModel tableModel, IValidation validation = null)
        {
            _toyModel = toyModel;
            _tableModel = tableModel;
            _validation = validation;
        }

        public void StartGame()
        {
            Console.WriteLine("Type PLACE to place your toy");
            Console.WriteLine("Type MOVE,LEFT or RIGHT to move your toy");
            Console.WriteLine("Type REPORT to check your toy position");
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (input == "exit") {
                        return;
                    }
                    ProcessInput(input);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void ProcessInput(string input)
        {
            if (_validation.IsValid(input))
            {
                var args = input.Split(' ');
                var action = args[0].ToUpper();
                if (action == Constants.Place)
                {
                    var args1 = args[1].Split(',');
                    _toyModel.place(Convert.ToInt16(args1[0]), Convert.ToInt16(args1[1]), UtilityHelper.getFacingByString(args1[2].ToUpper()));
                }
                else if (action == Constants.Report)
                {
                    var result = _toyModel.report();
                    Console.WriteLine($"Output : {result?.XPosition},{result?.YPosition}, {result?.Face.ToString()}");
                }
                else if (action == Constants.Move)
                {
                    _toyModel.Move();
                }
                else if (action == Constants.Left)
                {
                    _toyModel.left();
                }
                else if (action == Constants.Right) { _toyModel.right(); }
            }
            else
            {
                Console.WriteLine("Wrong input!! please try again...");
            }
        }
    }
}
