using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public class GameOptions
	{
		public BoardSize BoardSize { get; set; } = BoardSize.NORMAL;
		public Theme Theme { get; set; }
		public AIDifficulty Difficulty { get; set; } = AIDifficulty.NORMAL;
		public bool SinglePlayer { get; set; }

		public GameOptions()
		{
			Theme = new Theme();
		}
		public GameOptions(GameOptions other)
		{
			this.BoardSize = other.BoardSize;
			this.Theme = other.Theme;
			this.Difficulty = other.Difficulty;
			this.SinglePlayer = other.SinglePlayer;
		}

		public void UpdateOptions(GameOptions other)
		{
			this.BoardSize = other.BoardSize;
			this.Theme = other.Theme;
			this.Difficulty = other.Difficulty;
		}

		public bool Equals(GameOptions other)
		{
			return (
			this.BoardSize == other.BoardSize &&
			this.Difficulty == other.Difficulty &&
			this.SinglePlayer == other.SinglePlayer &&
			this.Theme == other.Theme);
		}
	}
}
