//  Font.cs
//
//  Author:
//       TMS Consulting <>
//
//  Copyright (c) 2015 TMS Consulting
using System;
using UIKit;

namespace ProjectX
{
	public static class Font
	{
		public static UIFont Bold(int size)
		{
			return UIFont.FromName("AvenirLTStd-Black", size);
		}

		public static UIFont Light(int size)
		{
			return UIFont.FromName("AvenirLTStd-Light", size);
		}

		public static UIFont Light2(int size)
		{
			return UIFont.FromName("HelveticaNeue-Light", size);
		}

		public static UIFont Title(int size)
		{
			return UIFont.FromName("AvenirLTStd-Medium", size);
		}

		public static UIFont Normal(int size)
		{
			return UIFont.FromName("HelveticaNeue", size);
		}

		public static UIFont UltraLight(int size)
		{
			return UIFont.FromName("HelveticaNeue-UltraLight", size);
		}

	}
}
