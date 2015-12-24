//
// NewsView.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using SDWebImage;

namespace ProjectX
{
	public class NewsViewModel : UIView
	{
		public NewsViewModel(CGRect frame)
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
			point.BackgroundColor = Color.Primary;
			//Add(point);

			var x = Metrics.Padding * 2 + avatar.Frame.Width;
			nfloat y = Metrics.Padding;
			var title = new UILabel(new CGRect(x, y, frame.Width - x - Metrics.Padding, 20));
			title.Font = Font.Title(18);
			title.Text = "Tolotra Raharison";
			Add(title);
			y += 20;

			var subtitle = new UILabel(new CGRect(x, y, frame.Width - x - Metrics.Padding, 20));
			subtitle.Text = "@TolotraSmile";
			subtitle.Font = Font.Title(14);
			subtitle.TextColor = Color.Primary;
			Add(subtitle);

			y += Metrics.Padding + 10;

			var text = new UILabel(new CGRect(x, y, frame.Width - x - Metrics.Padding, 40));
			text.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
			"labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
			" ut aliquip ex ea commodo consequat";
			text.Font = Font.Light2(14);
			text.Lines = 0;
			text.SizeToFit();
			text.TextColor = Color.SubTitle;
			Add(text);
			y += text.Frame.Height + Metrics.Padding;

			var image = new UIImageView(new CGRect(x, y, frame.Width - x - Metrics.Padding, 128));
			image.Layer.CornerRadius = 8;
			image.Layer.MasksToBounds = true;
			image.BackgroundColor = UIColor.LightGray;
			//image.Image = UIImage.FromFile("Images/HNCK7938.jpg");
			image.SetImage(new NSUrl("http://bootstrapbay.com/blog/wp-content/uploads/2014/05/yellow-taxi_vvvjao.png"));
			image.ContentMode = UIViewContentMode.ScaleAspectFill;
			Add(image);

			Frame = new CGRect(Frame.X, Frame.Y, Frame.Width, image.Frame.Bottom + Metrics.Padding);
		}
	}
}