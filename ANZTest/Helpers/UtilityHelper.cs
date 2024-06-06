namespace ANZTest.Helpers
{
    public static class UtilityHelper
    {
        public enum Facing
        {
            EAST,
            NORTH,
            WEST,
            SOUTH,
        }

        public enum Direction
        {
            Left,
            Right,
        }

        public static Facing getFacingByString(string str){
            if(str == Facing.EAST.ToString())
            {
                return Facing.EAST;
            }
            else if(str == Facing.WEST.ToString()) { return Facing.WEST; }
            else if (str == Facing.NORTH.ToString()) { return Facing.NORTH; }
            else { return Facing.SOUTH; }
        }
    }
}
