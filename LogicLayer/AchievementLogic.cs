using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayer;

namespace LogicLayer
{
	public class AchievementLogic
	{
		private Achievement[] _achievements;
		private AchievementAccessor _achievementAccessor = new AchievementAccessor();
		private List<AchievementList> _newAchievements = new List<AchievementList>();

		public AchievementLogic()
		{
			LoadAchievements();
		}

		private void CreateAchievements()
        {
			Achievement achievement1 = new Achievement("generic_sillouette", "lights_out_filled", "Lights Out", "Play a game in dark mode.");
			Achievement achievement2 = new Achievement("generic_sillouette", "double_trouble_filled", "Double Trouble", "Get two 4+ in a row with a single chip.");
			Achievement achievement3 = new Achievement("generic_sillouette", "easy_filled", "That's Easy", "Win a game against The Hard AI.");
			Achievement achievement4 = new Achievement("generic_sillouette", "filled_filled", "All Filled Up", "Tie a game on Absurd mode.");
			Achievement achievement5 = new Achievement("generic_sillouette", "mines_longer_filled", "Mines Bigger", "Get a 5+ in a row.");
			_achievements = new Achievement[] { achievement1, achievement2, achievement3, achievement4, achievement5 };
		}

		public void LoadAchievements()
		{
			CreateAchievements();
			try
			{
				_achievementAccessor.LoadAchievements(_achievements);
			}
			catch (Exception down)
			{
				throw new ApplicationException("Could not create or read achievements file.",down);
			}
		}

		public void SaveAchievements()
		{
			try
			{
				_achievementAccessor.SaveAchievements(_achievements);
			}
			catch (Exception down)
			{
				throw new ApplicationException("Could not save achievement data", down);
			}
		}

		public String GetAchievementText(AchievementList ach)
		{
			return _achievements[((int)ach)].AchievementText;
		}

		public String GetAchievementDescription(AchievementList ach)
		{
			if (_achievements[(int)ach].Achieved)
			{
				return _achievements[(int)ach].AchievementDescription;
			}
			else
			{
				return "Not Completed";
			}
		}

		public String GetAchievementImageName(AchievementList ach)
		{
			if (_achievements[(int)ach].Achieved)
			{
				return _achievements[(int)ach].AchievedImageName;
			}
			else
			{
				return _achievements[(int)ach].NotAchievedImageName;
			}
		}

		public bool HasAchievementsToShow()
		{
			return _newAchievements.Count > 0;
		}

		public AchievementList GetNextNewAchievement()
		{
			try
			{
				AchievementList next = _newAchievements[0];
				_newAchievements.RemoveAt(0);
				return next;
			}
			catch (Exception e)
			{
				throw new ApplicationException("Failed to get new Achievement", e);
			}
		}
		public void UpdateAchievement(AchievementList ach)
		{
			if (_achievements[(int)ach].Achieved == false)
			{
				_achievements[(int)ach].Achieved = true;
				_achievementAccessor.SaveAchievements(_achievements);
				_newAchievements.Add(ach);
			}
		}
	}
}
