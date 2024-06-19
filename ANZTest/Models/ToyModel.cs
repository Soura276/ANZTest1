using ANZTest.Interfaces;
using static ANZTest.Helpers.UtilityHelper;

namespace ANZTest.Models
{
    public sealed class ToyModel : IToyModel
    {
        private ITableModel _table;
        public int XPosition { get; private set;}
        public int YPosition { get; private set;}
        public Facing Face { get; private set;} 

        /// <summary>
        /// Toy model constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="face"></param>
        private ToyModel( int x, int y, Facing face) { 
            XPosition = x;
            YPosition = y;
            Face = face;
        }

        /// <summary>
        /// Set table
        /// </summary>
        /// <param name="table"></param>
        public ToyModel(ITableModel table)
        {
            this._table = table;
        }

        private static ToyModel instance = null;

        public void place(int x, int y, Facing face)
        {
            if(instance == null)
            {
                instance = new ToyModel(x, y, face);
            }
            else
            {
                instance.XPosition = x;
                instance.YPosition = y;
                instance.Face = face;
            }
        }

        public ToyModel report()
        {
            return instance;
        }

        public void Move()
        {
            if(instance.Face == Facing.NORTH && instance.XPosition < _table.XMaxPosition)
            {
                instance.XPosition++;
            }
            else if (instance.Face == Facing.SOUTH && instance.XPosition > _table.XMinPosition)
            {
                instance.XPosition--;
            }
            else if (instance.Face == Facing.WEST && instance.YPosition < _table.YMaxPosition)
            {
                instance.YPosition++;
            }
            else if(instance.Face == Facing.EAST && instance.YPosition > _table.YMinPosition)
            {
                instance.YPosition--;
            }
        }

        public void left()
        {
            if (instance.Face == Facing.NORTH)
            {
                instance.Face = Facing.WEST;
            }
            else if (instance.Face == Facing.SOUTH)
            {
                instance.Face = Facing.EAST;
            }
            else if (instance.Face == Facing.WEST)
            {
                instance.Face = Facing.SOUTH;
            }
            else if (instance.Face == Facing.EAST)
            {
                instance.Face = Facing.NORTH;
            }
        }

        public void right()
        {
            if (instance.Face == Facing.NORTH)
            {
                instance.Face = Facing.EAST;
            }
            else if (instance.Face == Facing.SOUTH)
            {
                instance.Face = Facing.WEST;
            }
            else if (instance.Face == Facing.WEST)
            {
                instance.Face = Facing.NORTH;
            }
            else if (instance.Face == Facing.EAST)
            {
                instance.Face = Facing.SOUTH;
            }
        }


    }
}
