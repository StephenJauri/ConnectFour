using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public class Achievement
	{
		public String NotAchievedImageName { get; private set; }
		public String AchievedImageName { get; private set; }
		public String AchievementText { get; private set; }
		public String AchievementDescription { get; private set; }
		public bool Achieved { get; set; } = false;

		public Achievement(String notAchievedImageName, String achievedImageName, String achievementText, String achievementDescription)
		{
			this.NotAchievedImageName = notAchievedImageName;
			this.AchievedImageName = achievedImageName;
			this.AchievementText = achievementText;
			this.AchievementDescription = achievementDescription;
		}
	}
}
