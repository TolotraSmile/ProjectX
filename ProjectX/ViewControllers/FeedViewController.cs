//
// FeedViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using CoreGraphics;
using CoreAnimation;

namespace ProjectX
{
	public class FeedViewController : UITableViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DesignElement.SetNavigationColor(NavigationController);

			var list = new List<Object>();
			list.AddRange(NewsModel.Samples());
			list.AddRange(ShopModel.Samples());
			list.AddRange(UserModel.Samples());
			list.Shuffle(new Random());

			TableView.Source = new FeedTableSource(list, this);

			var transition = new CATransition();
			transition.Type = CAAnimation.TransitionFade;
			transition.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			transition.FillMode = CAFillMode.Forwards;//kCAFillModeForwards
			transition.Duration = 1;
			TableView.Layer.AddAnimation(transition,  "UITableViewReloadDataAnimationKey");
			// Update your data source here
			//self.tableView.reloadData()
			TableView.ReloadData();

			TableView.IndicatorStyle = UIScrollViewIndicatorStyle.White;
		}

		public class FeedTableSource : UITableViewSource
		{
			public UIViewController Parent { get; set; }

			public List<Object> Models { get; set; }

			public FeedTableSource(IEnumerable<Object> items, UIViewController parent)
			{
				Models = items.ToList();
				Parent = parent;
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return GetViewPrototype(Models[indexPath.Row]).Frame.Height;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);
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
					//cellController = new ViewCellTemplate(new MenuItemViewModel(current.Title, current.Image));
					var view = GetViewPrototype(current);
					cellController = new ViewCellTemplate(view);
					cell = cellController.Cell;
					cell.BackgroundColor = UIColor.Clear;
				}
				return cell;
			}

			public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
			{
				cell.Alpha = 0;
				UIView.BeginAnimations("translation");
				UIView.SetAnimationDuration(1);
				cell.Alpha = 1;
				UIView.CommitAnimations();
			}

			static UIView GetViewPrototype(object item)
			{
				var view = new UIView(CGRect.Empty);
				if (item is UserModel) {
					view = new UserViewModel(new CGRect(0, 0, Metrics.Width, 64 + 2 * Metrics.Padding));
				}
				if (item is ShopModel) {
					var model = item as ShopModel;
					view = new ShopItemViewModelStyle1(model.Title, model.SubTitle);
				}
				if (item is NewsModel) {
					view = new NewsViewModel(new CGRect(0, 0, Metrics.Width, 198));
				}
				return view;
			}
		}
	}
}

