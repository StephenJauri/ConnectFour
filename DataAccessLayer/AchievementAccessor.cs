using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
	public class AchievementAccessor
	{

		public void LoadAchievements(Achievement[] achievements)
		{

            if (!File.Exists(AppData.DataPath + "\\" + AppData.FileName))
			{
				CreateAchievementsFile();
			}
            StreamReader fileReader = null;


			try
            {
                fileReader = new StreamReader(AppData.DataPath + "\\" + AppData.FileName);

				foreach (int i in Enum.GetValues(typeof(AchievementList)))
				{
					string line = fileReader.ReadLine();
					achievements[i].Achieved = line.Trim() == "True";
				}
			}
            catch (Exception)
			{
				if (fileReader != null)
				{
					fileReader.Close();
				}
				CreateAchievementsFile();
            }
			finally
			{
                if (fileReader != null)
				{
                    fileReader.Close();
				}
			}
		}

        private void CreateAchievementsFile()
		{
            StreamWriter writer = null;
			try
			{
                writer = new StreamWriter(AppData.DataPath + "\\" + AppData.FileName);
				foreach (int i in Enum.GetValues(typeof(AchievementList)))
				{
                    writer.WriteLine(false);
				}
			}
            catch (Exception up)
			{
                throw up;
			}
			finally
			{
                if (writer != null)
				{
					writer.Close();
				}
			}
		}

		public void SaveAchievements(Achievement[] achievements)
		{
			StreamWriter writer = null;
			try
			{
				writer = new StreamWriter(AppData.DataPath + "\\" + AppData.FileName);
				foreach (int i in Enum.GetValues(typeof(AchievementList)))
				{
					writer.WriteLine(achievements[i].Achieved);
				}
			}
			catch (Exception up)
			{
				throw up;
			}
			finally
			{
				if (writer != null)
				{
					writer.Close();
				}
			}
		}
	}
}
