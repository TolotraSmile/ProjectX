//
// ShopItemViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace ProjectX
{
	public class ShopItemViewController : UIKeyboardNotifViewController
	{
		ShopModel item;
		
		public ShopItemViewController(ShopModel item)
		{
			this.item = item;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var header = new ShopItemViewModelStyle1(item.Title, item.SubTitle);
			View.BackgroundColor = UIColor.White;
			ScrollView.Add(header);
			View.Add(ScrollView);
		}

	}
}

