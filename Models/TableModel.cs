using ANZTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANZTest.Models
{
    public class TableModel : ITableModel
    {
        public int XMinPosition { get; }

        public int XMaxPosition { get; }

        public int YMinPosition { get; }

        public int YMaxPosition { get; }

        public TableModel(int xmin, int xmax, int ymin, int ymax) { 
            XMinPosition = xmin;
            XMaxPosition = xmax;
            YMinPosition = ymin;
            YMaxPosition = ymax;
        }
    }
}
