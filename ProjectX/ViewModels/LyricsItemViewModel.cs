//
// TextViewModel.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using CoreGraphics;
using UIKit;

namespace ProjectX
{
	public sealed class LyricsItemViewModel : UILabel
	{
		public LyricsItemViewModel(nfloat x, nfloat y, string text)
			: base(new CGRect(x, y, Metrics.Width - x - Metrics.Padding2, 0))
		{
			Text = text;
			Lines = 0;
			Enabled = false;
			Font = ProjectX.Font.Normal(16);
			TextColor = UIColor.DarkGray;
			TextAlignment = UITextAlignment.Left;
			SizeToFit();
		}
	}
}

