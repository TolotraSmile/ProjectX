//
// UserListViewModel.cs
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
	public class UserListViewModel : UIView
	{
		public UserListViewModel(CGRect frame)
			: base(frame)
		{
			var avatar = new UIImageView(new CGRect(Metrics.Padding, Metrics.Padding, 64, 64));
			avatar.Image = UIImage.FromFile("profil.jpeg");
			avatar.Layer.CornerRadius = avatar.Frame.Height / 2;
			avatar.Layer.MasksToBounds = true;
			Add(avatar);

			var point = new UIView(new CGRect(0, 0, 20, 20));
			point.Center = Equations.PointOnCircle(avatar.Layer.CornerRadius, -45, avatar.Center);
			point.Layer.CornerRadius = point.Frame.Height / 2;
			point.BackgroundColor = Color.Primary;
			Add(point);

			var x = Metrics.Padding * 2 + avatar.Frame.Width;
			var title = new UILabel(new CGRect(x, Metrics.Padding, frame.Width - x - Metrics.Padding, frame.Height - 2 * Metrics.Padding));
			title.Font = Font.Normal(20);
			title.Text = "Tolotra Raharison";
			Add(title);
		}
	}
}

