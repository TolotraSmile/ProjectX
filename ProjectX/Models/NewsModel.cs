//
// NewsModel.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using System.Collections.Generic;

namespace ProjectX
{
	public class NewsModel
	{

		public DateTime Date { get; set; }
		public NewsModel() { }

		static public List<NewsModel> Samples()
		{
			var list = new List<NewsModel> {
				new NewsModel(),
				new NewsModel(),
				new NewsModel(),
				new NewsModel(),
				new NewsModel(),
			};
			return list;

		}
	}
}

