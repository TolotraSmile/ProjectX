//
// MenuTableSource.cs
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
	public class MenuTableSource : UITableViewSource
	{
		public UIViewController Parent { get; set; }

		public List<MenuItem> Models { get; set; }

		public MenuTableSource(IEnumerable<MenuItem> items, UIViewController parent)
		{
			Models = items.ToList();
			Parent = parent;
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 24 + Metrics.Padding * 2;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			var current = Models[indexPath.Row];

			if (current.Action != null) {
				current.Action.Invoke();
			}

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
				cellController = new ViewCellTemplate(new MenuItemViewModel(current.Title, current.Image));
				cell = cellController.Cell;
				cell.BackgroundColor = UIColor.Clear;
				cell.SelectedBackgroundView = new UIView { BackgroundColor = Color.Primary };
			}
			return cell;
		}

		static public List<MenuItem> Items(UINavigationController navigation, UINavigationController parent)
		{
			var list = new List<MenuItem> {
				new MenuItem("Profile", Resource.Icon("icn_user_dark.png"), () => navigation.PushViewController(new FeedViewController(), true)),
				new MenuItem("Photos", Resource.Icon("icn_picture.png"), () => navigation.PushViewController(new MusicGridViewController(), true)),
				new MenuItem("Messages", Resource.Icon("icn_message.png"), () => navigation.PushViewController(new ShopListViewController(), true)),
				new MenuItem("Historic", Resource.Icon("icn_clock.png"), null),
				new MenuItem("Logout", Resource.Icon("icn_logout.png"), () => parent.PopViewController(true)),
			};
			return list;
		}

		internal class MenuItemViewModel : UIView
		{
			public MenuItemViewModel(string title, UIImage imageName)
				: base(new CGRect(0, 0, Metrics.Width, 24 + Metrics.Padding * 2))
			{
				var image = new UIImageView(new CGRect(Metrics.Padding / 2, 0, 44, 44));
				image.Center = new CGPoint(image.Center.X, Frame.Height / 2);
				image.Image = imageName;
				Add(image);

				var x = Metrics.Padding + 44;
				var text = new UILabel(new CGRect(x, 0, Metrics.Width - x - Metrics.Padding, Frame.Height));
				text.Font = Font.Title(16);
				text.TextColor = UIColor.White;
				text.Text = title;

				if (title.Equals("Logout")) {
					text.TextColor = UIColor.FromRGB(255, 59, 48);
				}
				Add(text);
			}
		}

		public class MenuItem
		{
			public string Title { get; set; }

			public UIImage Image { get; set; }

			public Action Action { get; set; }

			public MenuItem(string title, UIImage image, Action action)
			{
				Title = title;
				Image = image;
				Action = action;
			}
		}

	}
}

