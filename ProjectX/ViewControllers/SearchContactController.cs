//
// SearchContactController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;

namespace ProjectX
{
	public class SearchContactController : UIViewController
	{
		public SearchContactController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.White;

			var searchBar = new UISearchBar(new CGRect(0, 20, Metrics.Width, 42));
			searchBar.Placeholder = "Text";
			searchBar.TintColor = UIColor.White;
			searchBar.BarTintColor = UIColor.Clear;
			foreach (var item in searchBar.Subviews) {
				item.BackgroundColor = Color.Primary;
			}
			Add(searchBar);
		}
	}
}

