using ANZTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ANZTest.Helpers.UtilityHelper;

namespace ANZTest.Interfaces
{
    public interface IToyModel
    {
        public int XPosition { get; }
        public int YPosition { get; }
        public Facing Face { get; }
        void place(int x, int y, Facing face);
        ToyModel report();
        void Move();
        void left();
        void right();
    }
}
