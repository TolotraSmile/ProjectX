//
// ItemViewModelStyle1.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using SDWebImage;
using Foundation;
using CoreAnimation;

namespace ProjectX
{
	public class ShopItemViewModelStyle1 : UIView
	{
		public ShopItemViewModelStyle1(string titleText, string subtitleText)
			: base(new CGRect(0, 0, Metrics.Width, 0))
		{
			nfloat y = Metrics.Ratio(4, 3);
			var image = new UIImageView(new CGRect(0, 0, Metrics.Width, y));
			image.BackgroundColor = UIColor.LightGray;
			//image.Image = UIImage.FromFile("Images/HNCK7938.jpg");
			//image.SetImage(new NSUrl("http://bootstrapbay.com/blog/wp-content/uploads/2014/05/yellow-taxi_vvvjao.png"));
			//http://bootstrapbay.com/blog/wp-content/uploads/2014/05/picjumbo-fashion_ejuahj.jpg
			image.SetImage(new NSUrl("http://bootstrapbay.com/blog/wp-content/uploads/2014/05/picjumbo-fashion_ejuahj.jpg"));
			image.ContentMode = UIViewContentMode.ScaleAspectFill;
			image.Layer.MasksToBounds = true;
			image.ClipsToBounds = true;

			var gradient = new CAGradientLayer { 
				Frame = image.Bounds,
				NeedsDisplayOnBoundsChange = true,
				MasksToBounds = true,
				Colors = new [] {
					UIColor.FromRGBA(128, 128, 128, 64).CGColor,
					UIColor.FromRGBA(68, 68, 68, 128).CGColor,
					UIColor.FromRGBA(32, 32, 32, 255).CGColor
				}
			};

			image.Layer.AddSublayer(gradient);

			Add(image);


			var favorite = new UIButton(new CGRect(0, image.Frame.Bottom - 48, 48, 48));
			favorite.SetImage(UIImage.FromFile(Resource.Icon("icn_star.png")), UIControlState.Normal);
			Add(favorite);

			var like = new UIButton(new CGRect(48, image.Frame.Bottom - 48, 48, 48));
			like.SetImage(UIImage.FromFile(Resource.Icon("icn_heart.png")), UIControlState.Normal);
			Add(like);

			y += Metrics.Padding;
			var title = new UILabel(new CGRect(Metrics.Padding, y, Metrics.Width - Metrics.Padding * 2, 20));
			title.Font = Font.Title(20);
			title.Text = titleText;
			title.TextColor = UIColor.Black;
			title.Lines = 0;
			title.SizeToFit();
			Add(title);
			y += title.Frame.Height + 2;

			var subtitle = new UILabel(new CGRect(Metrics.Padding, y, Metrics.Width - Metrics.Padding * 2, 20));
			subtitle.Font = Font.Normal(14);
			subtitle.TextColor = UIColor.DarkGray;
			subtitle.Text = subtitleText;
			subtitle.Lines = 0;
			subtitle.SizeToFit();
			Add(subtitle);

			y += subtitle.Frame.Height;

			Frame = new CGRect(0, 0, Metrics.Width, y + Metrics.Padding);
		}
	}
}

