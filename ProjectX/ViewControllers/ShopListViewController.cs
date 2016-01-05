//
// ShopListViewController.cs
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
using CoreGraphics;

namespace ProjectX
{
	public class ShopListViewController : UITableViewController
	{

		UIButton button;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			DesignElement.NormalizeNavigation(NavigationController);
			TableView.Source = new ShopTableSource(ShopModel.Samples(), this);
			TableView.IndicatorStyle = UIScrollViewIndicatorStyle.White;

			button = new UIButton(new CGRect(Metrics.Width - 84, Metrics.Height - 84, 64, 64));
			button.BackgroundColor = Color.Primary;
			button.Alpha = 0;
			button.SetBackgroundImage(Resource.Icon("icn_arrow_up.png"), UIControlState.Normal);
			DesignElement.AddShadowAndRounded(button);
			button.TouchDown += (sender, e) => TableView.SetContentOffset(CGPoint.Empty, true);
		}

		public override void ViewWillAppear(bool animated)
		{
			if (button != null) {
				NavigationController.View.AddSubview(button);
				UIView.Animate(2, () => {
					button.Alpha = 1;
				});
			}
			base.ViewWillAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			UIView.Animate(1, () => {
				button.Alpha = 0;
			});
			button.RemoveFromSuperview();
			base.ViewWillDisappear(animated);
		}

		internal class ShopTableSource : UITableViewSource
		{
			UIViewController Parent { get; set; }

			List<ShopModel> Models { get; set; }

			public ShopTableSource(IEnumerable<ShopModel> items, UIViewController parent)
			{
				Models = items.ToList();
				Parent = parent;
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return GetFromPrototype(Models[indexPath.Row]);
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);
				var current = Models[indexPath.Row];
				Parent.NavigationController.PushViewController(new ShopItemViewController(current), true);
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Models.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var current = Models[indexPath.Row];
				var cell = tableView.DequeueReusableCell(ViewCellTemplate.Key);
				ViewCellTemplate cellController;
				if (cell == null) {
					UIView view;
					if (indexPath.Row % 2 == 0) {
						 view = new NewsViewModel(new CGRect(0, Metrics.Padding, Metrics.Width, 198));
					} else {
						 view = new ShopItemViewModelStyle1(current.Title, current.SubTitle);
					}
					cellController = new ViewCellTemplate(view);
					cell = cellController.Cell;
				}
				return cell;
			}

			static nfloat GetFromPrototype(ShopModel item)
			{
				var prototype = new ShopItemViewModelStyle1(item.Title, item.SubTitle);
				return prototype.Frame.Height;
			}

		}
	}
}

