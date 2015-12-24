//
// UserViewModel.cs
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
	public class UserViewModel : UIView
	{
		public UserViewModel(CGRect frame)
			: base(frame)
		{
			var avatar = new UIImageView(new CGRect(Metrics.Padding, Metrics.Padding, 64, 64));
			avatar.Image = UIImage.FromFile("profil.jpeg");
			avatar.Layer.CornerRadius = avatar.Frame.Height / 2;
			avatar.Layer.MasksToBounds = true;
			Add(avatar);

			var point = new UIView(new CGRect(0, 0, 20, 20));
			point.Center = Equations.PointOnCircle(avatar.Layer.CornerRadius, 45, avatar.Center);
			point.Layer.CornerRadius = point.Frame.Height / 2;
//			point.Layer.BorderColor = UIColor.White.CGColor;
//			point.Layer.BorderWidth = 2;
			point.BackgroundColor = Color.Primary;
			Add(point);

			var x = Metrics.Padding * 2 + avatar.Frame.Width;

			var view = new UIView(new CGRect(x,Metrics.Padding, frame.Width - x - Metrics.Padding, 46));

			var title = new UILabel(new CGRect(0, 0, view.Frame.Width, 26));
			title.Font = Font.Title(20);
			title.Text = "Tolotra Raharison";
			view.Add(title);

			var subtitle = new UILabel(new CGRect(0, 26, view.Frame.Width, 20));
			subtitle.Text = "@TolotraSmile";
			subtitle.Font = Font.Light(16);
			subtitle.TextColor = Color.Primary;
			view.Add(subtitle);

			view.Center = new CGPoint(view.Center.X, Frame.Height / 2);
			Add(view);
		}
	}
}
