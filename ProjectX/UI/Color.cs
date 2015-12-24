//  Color.cs
//
//  Author:
//       TMS Consulting <>
//
//  Copyright (c) 2015 TMS Consulting
using System;
using UIKit;

namespace ProjectX
{
	public class Color
	{
		static public UIColor Primary { get { return UIColor.FromRGB(0, 185, 255); } }

		static public UIColor Secondary { get { return UIColor.FromRGB(219, 238, 248); } }

		static public UIColor Third { get { return UIColor.FromRGB(167, 208, 152); } }

		static public UIColor Title { get { return UIColor.DarkGray; } }

		static public UIColor SubTitle { get { return UIColor.Gray; } }

		static public UIColor Warning { get { return UIColor.FromRGB(255, 59, 48); } }

		static public UIColor PrimaryWithAlpha(int alpha)
		{
			return UIColor.FromRGBA(0, 185, 255, alpha);
		}
	}
}

