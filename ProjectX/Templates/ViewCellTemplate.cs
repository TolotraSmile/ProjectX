//
// ShopViewCell.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using UIKit;
using Foundation;

namespace ProjectX
{

	public class ViewCellTemplate :  UIViewController
	{
		public static readonly NSString Key = new NSString("ShopItemCell");

		public UITableViewCell Cell {
			get { return cell; }
		}
		readonly UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Default, "ShopItemCellModel");

		public ViewCellTemplate(UIView model)
		{
			View.AddSubview(cell);
			cell.AddSubview(model);
		}
	}
}