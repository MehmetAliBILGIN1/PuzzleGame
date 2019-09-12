using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle
{
    public class PuzzleButton : Button
    {

        public List<Button> NeighborList;

        public PuzzleButton()
        {
            NeighborList = new List<Button>();
        }
    }
}
