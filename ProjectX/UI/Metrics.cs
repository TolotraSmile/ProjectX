//  Meter.cs
//
//  Author:
//       TMS Consulting <>
//
//  Copyright (c) 2015 TMS Consulting
using System;
using CoreGraphics;
using UIKit;

namespace ProjectX
{
	static public class Metrics
	{
		static public int Padding { get { return 16; } }

		static public int Padding2 { get { return 32; } }

		static public int Heading { get { return 10; } }

		static public CGSize Size { get { return new CGSize(Width, Height); } }

		static public nfloat Width { get { return UIScreen.MainScreen.Bounds.Width; } }

		static public nfloat Height { get { return UIScreen.MainScreen.Bounds.Height; } }

		static public nfloat Ratio(double x, double y)
		{
			return Width / (nfloat)(x / y);
		}
	}
}

