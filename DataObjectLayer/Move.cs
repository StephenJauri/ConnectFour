using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public struct Move
	{
		public int Column { get; private set; }
		public int Row { get; private set; }
		public Move(int col, int row)
		{
			this.Column = col;
			this.Row = row;
		}
	}
}
