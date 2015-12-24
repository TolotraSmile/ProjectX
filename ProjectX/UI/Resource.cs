//
// Ressource.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;

namespace ProjectX
{
	public class Resource
	{
		static public string  Icon(string filename)
		{
			return "Icones/" + filename;
		}

		static public string  Image(string filename)
		{
			return "Images/" + filename;
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

