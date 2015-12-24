//
// ShopItem.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using System.Collections.Generic;

namespace ProjectX
{
	public class ShopModel
	{
		public string Title { get; set; }

		public string SubTitle { get; set; }

		public ShopModel(string title, string subtitle)
		{
			Title = title;
			SubTitle = subtitle;
		}

		static public List<ShopModel> Samples()
		{
			var list = new List<ShopModel> {
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
				new ShopModel("Shop Item - Start Bootstrap Template",
					"See more snippets like these online store reviews at Bootsnipp."),
			};
			return list;

		}

	}
}

