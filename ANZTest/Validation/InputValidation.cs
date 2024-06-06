using ANZTest.Helpers;
using ANZTest.Interfaces;
using static ANZTest.Helpers.UtilityHelper;

namespace ANZTest.Validation
{
    public class InputValidation : IValidation
    {
        private readonly List<string> actionlist = new() { Constants.Place, Constants.Move, Constants.Left, Constants.Right, Constants.Report };
        private readonly List<string> facingList = new() { Facing.NORTH.ToString(), Facing.SOUTH.ToString(), Facing.EAST.ToString(), Facing.WEST.ToString() };
        private readonly ITableModel _table;

        public InputValidation(ITableModel table)
        {
            _table = table;
        }

        public bool IsValid(string input)
        {
            var args = input.Split(' ');
            bool isValid = true;
            string action = args[0].ToUpper();
            if(!actionlist.Contains(action)) { 
                return false;
            }
            if(action == Constants.Place)
            {
                if(args.Length != 2)
                {
                    return false;
                }
                if (args[1].GetType() != typeof(string)) {
                    return false;
                }
                var args2 = args[1].Split(',');
                if (args2.Length != 3) { 
                    return false;
                }
                int x = Convert.ToInt16(args2[0]);
                int y = Convert.ToInt16(args2[1]);
                if (!(x >= _table.XMinPosition && x <= _table.XMaxPosition) || !(y >= _table.YMinPosition && y <= _table.YMaxPosition))
                {
                    return false;
                }

                if (!facingList.Contains(args2[2].ToUpper()))
                {
                    return false;
                }

            }
            else
            {
                if(args.Length != 1)
                {
                    return false;
                }
            }
            return isValid;
        }
    }
}
