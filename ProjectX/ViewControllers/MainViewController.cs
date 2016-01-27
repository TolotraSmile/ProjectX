//
// MainViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using System.Linq;

namespace ProjectX
{
	public class MainViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.White;
			DesignElement.SetNavigationColor(NavigationController);
			//NavigationController.SetNavigationBarHidden(false, false);
			var item = ShopModel.Samples().First();
			var news = new ShopItemViewModelStyle1(item.Title, item.SubTitle);
			Add(news);

			var news2 = new NewsViewModel(new CGRect(0, news.Frame.Height + Metrics.Padding, Metrics.Width, 198));
			Add(news2);

			Title = "Main";
		}
	}
}

