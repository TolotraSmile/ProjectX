//
// AppDelegate.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using Foundation;
using UIKit;
using CoreGraphics;
using System;

namespace ProjectX
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	public class SideMenuController : UITableViewController
	{
		UINavigationController parent;

		public SideMenuController(UINavigationController parent)
		{
			this.parent = parent;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DesignElement.SetNavigationColor(NavigationController);

			TableView.TableHeaderView = HeaderView();
			TableView.Source = new MenuTableSource(MenuTableSource.Items(NavigationController, parent), this);
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			TableView.ShowsVerticalScrollIndicator = false;
			TableView.BackgroundView = BackView();
			TableView.BackgroundColor = UIColor.Clear;
			View.BackgroundColor = UIColor.Clear;
		}


		nfloat width = Metrics.Width - 55;

		UIView HeaderView()
		{
			const int height = 288;
			var header = new UIView(new CGRect(0, -20, width, height - 20));
			var avatar = new UIImageView(new CGRect(20, 30, 108, 108));
			avatar.Center = new CGPoint(width / 2, avatar.Center.Y);
			avatar.Image = UIImage.FromFile("profil.jpeg");
			avatar.Layer.CornerRadius = avatar.Frame.Height / 2;
			avatar.ClipsToBounds = true;
			header.Add(avatar);

			var point = new UIView(new CGRect(0, 0, 20, 20));
			point.Center = Equations.PointOnCircle(avatar.Layer.CornerRadius, 45, avatar.Center);
			point.Layer.CornerRadius = point.Frame.Height / 2;
			//			point.Layer.BorderColor = UIColor.White.CGColor;
			//			point.Layer.BorderWidth = 2;
			point.BackgroundColor = Color.Primary;
			header.Add(point);

			var nom = new UILabel(new CGRect(0, 148, width, 20));
			nom.Font = Font.Title(20);
			nom.TextColor = UIColor.White;
			nom.TextAlignment = UITextAlignment.Center;
			nom.Text = "Tolotra Raharison";
			header.Add(nom);

			var prenom = new UILabel(new CGRect(0, 168, width, 20));
			prenom.Font = Font.Light(16);
			prenom.TextColor = Color.Primary;
			prenom.Text = "@TolotraSmile";
			prenom.TextAlignment = UITextAlignment.Center;
			header.Add(prenom);

			var button = new UIButton(new CGRect(0, 210, 140, 32));
			button.SetTitle("Voir", UIControlState.Normal);
			button.Font = Font.Light(14);
			button.BackgroundColor = Color.Primary;
			button.Layer.CornerRadius = 16;
			button.Center = new CGPoint(width / 2, button.Center.Y);
			header.Add(button);
			return header;
		}

		UIView BackView()
		{
			var back = new UIView(new CGRect(0, -20, width, Metrics.Height + 20));
			back.BackgroundColor = UIColor.Clear;
			var backProfile = new UIImageView(new CGRect(0, 0, width, back.Frame.Height));
			backProfile.Image = UIImage.FromFile("profil.jpeg");
			var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
			var blurView = new UIVisualEffectView(blur) {
				Frame = new CGRect(0, 0, width, back.Frame.Height)
			};
			backProfile.AddSubview(blurView);
			back.Add(backProfile);

			return back;
		}

	}

}
