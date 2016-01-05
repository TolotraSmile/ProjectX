//
// Ressource.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;

namespace ProjectX
{
	public static class Resource
	{
		static public UIImage  Icon(string filename)
		{
			return UIImage.FromFile( "Icones/" + filename);
		}

		static public UIImage  Image(string filename)
		{
			return UIImage.FromFile("Images/" + filename);
		}

		static public string  File(string filename)
		{
			return "Files/" + filename;
		}

		static public string  Audio(string filename)
		{
			return "Audios/" + filename;
		}
	}
}

