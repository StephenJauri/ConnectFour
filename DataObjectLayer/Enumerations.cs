using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public enum AchievementList
	{
		LIGHTS_OUT,
		DOUBLE_TROUBLE,
		THATS_EASY,
		ALL_FILLED,
		MINES_BIGGER
	}
	public enum AIDifficulty
	{
		EASY,
		NORMAL,
		HARD
	}
	public enum BoardSize
	{
		SMALL,
		NORMAL,
		LARGE,
		ABSURD
	}
	public enum PositionState
	{
		EMPTY,
		PLAYER_ONE,
		PLAYER_TWO
	}
}
