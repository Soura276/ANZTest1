using ANZTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ANZTest.Helpers.UtilityHelper;

namespace ANZTest.Interfaces
{
    public interface ITableModel
    {
        public int XMinPosition { get; }

        public int XMaxPosition { get; }

        public int YMinPosition { get; }

        public int YMaxPosition { get; }
    }
}
