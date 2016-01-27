//
// SongListViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using CoreAnimation;

namespace ProjectX
{
	public class SongListViewController : UIViewController
	{

		public class SongItem
		{
			public object Data { get; set; }
			public Action Action { get; set; }
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.SetNavigationBarHidden(true, false);
			var bar = new CustomBar(() => NavigationController.PopViewController(true), "Hira Fanampiny".ToUpper(), "But for android its not available as far as my");
			var list = new List<Object>();
			list.AddRange(NewsModel.Samples());
			list.AddRange(NewsModel.Samples());
			list.AddRange(NewsModel.Samples());

			var items = list.Select(x => new SongItem { Data = x, Action = () => NavigationController.PushViewController(new SongVerticalViewController(), true)
			});

			var table = new UITableView(View.Frame);
			table.TableHeaderView = bar;
			table.Source = new SongTableSource(items, this);
			View.Add(table);

			table.BackgroundColor = UIColor.FromRGB(28, 10, 48);
		}

		public class SongTableSource : UITableViewSource
		{
			public UIViewController Parent { get; set; }

			public List<SongItem> Models { get; set; }

			public SongTableSource(IEnumerable<SongItem> items, UIViewController parent)
			{
				Models = items.ToList();
				Parent = parent;
			}

			public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
			{
				cell.Alpha = 0;
				UIView.BeginAnimations("translation");
				UIView.SetAnimationDuration(0.5);
				cell.Alpha = 1;
				UIView.CommitAnimations();
			}

			public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				return 64;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				Models[indexPath.Row].Action.Invoke();
				tableView.DeselectRow(indexPath, true);
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Models.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				//var current = Models[indexPath.Row];
				var cell = tableView.DequeueReusableCell(ViewCellTemplate.Key);
				ViewCellTemplate cellController;
				if (cell == null) { 
					//cellController = new ViewCellTemplate(new MenuItemViewModel(current.Title, current.Image));
					var view = new SongViewModel(new CGRect(0, 0, Metrics.Width, 64), "78", "Fanavaozana");
					cellController = new ViewCellTemplate(view);
					cell = cellController.Cell;
					cell.BackgroundColor = UIColor.Clear;
				}
				return cell;
			}

		}
	}
}

