using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataObjects
{
	public class Theme
	{
		public String Name { get; private set; }
		public Color ButtonColor { get; private set; }
		public Color BackgroundColor { get; private set; }
		public Color ButtonTextColor { get; private set; }
		public Color TextColor { get; private set; }
		public Color SubTextColor { get; private set; }
		public string PlayerOneColorText { get; private set; }
		public string PlayerTwoColorText { get; private set; }
		public string EmptyStateFileName { get; private set; }
		public string PlayerOneFilledStateFileName { get; private set; }
		public string PlayerTwoFilledStateFileName { get; private set; }
		public string PlayerOneHighlightStateFileName { get; private set; }
		public string PlayerTwoHighlightStateFileName { get; private set; }

		public Theme(String name, Color buttonColor, Color backgroundColor,Color buttonTextColor, Color textColor, Color subTextColor,
			String playerOneColorText, String playerTwoColorText,
			String emptyStateFileName, String playerOneFilledStateFileName, String playerTwoFilledStateFileName,
			String playerOneHighlightStateFileName, String playerTwoHighlightStateFileName)
		{
			Name = name;
			ButtonColor = buttonColor;
			BackgroundColor = backgroundColor;
			TextColor = textColor;
			ButtonTextColor = buttonTextColor;
			SubTextColor = subTextColor;
			PlayerOneColorText = playerOneColorText;
			PlayerTwoColorText = playerTwoColorText;
			EmptyStateFileName = emptyStateFileName;
			PlayerOneFilledStateFileName = playerOneFilledStateFileName;
			PlayerTwoFilledStateFileName = playerTwoFilledStateFileName;
			PlayerOneHighlightStateFileName = playerOneHighlightStateFileName;
			PlayerTwoHighlightStateFileName = playerTwoHighlightStateFileName;

		}

		public Theme()
		{
			Name = "light";
			ButtonColor = Color.CornflowerBlue;
			ButtonTextColor = Color.Black;
			BackgroundColor = Color.LightSteelBlue;
			TextColor = Color.RoyalBlue;
			SubTextColor = Color.MediumSlateBlue;
			PlayerOneColorText = "Yellow";
			PlayerTwoColorText = "Blue";
			EmptyStateFileName = "empty";
			PlayerOneFilledStateFileName = "yellow_filled";
			PlayerTwoFilledStateFileName = "blue_filled";
			PlayerOneHighlightStateFileName = "yellow_highlight";
			PlayerTwoHighlightStateFileName = "blue_highlight";
		}
	}
}
