//
// CustomBar.cs
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
	public class CustomBar : UIView
	{
		public CustomBar(Action action, string title, string subtitle)
			: base(new CGRect(0, 20, Metrics.Width, 64+Metrics.Padding))
		{
			var label1 = new UILabel(new CGRect(64, 0, Frame.Width-128, 30));
			label1.Text = title;
			label1.TextAlignment = UITextAlignment.Left;
			label1.TextColor = UIColor.White;
			label1.Font = Font.Bold(24);
			Add(label1);

			var label2 = new UILabel(new CGRect(64, 28, Frame.Width-128, 24));
			label2.Text = subtitle;
			label2.TextAlignment = UITextAlignment.Left;
			label2.TextColor = UIColor.LightGray;
			label2.Font = Font.Normal(18);
			label2.Lines = 0;
			label2.SizeToFit();
			Add(label2);

			var button = new UIButton(new CGRect(10, 0, 44, 44));
			button.BackgroundColor = Color.Primary;
			button.Layer.CornerRadius = 22;
			Add(button);
			button.SetImage(UIImage.FromFile(Resource.Icon("icn_arrow_left.png")), UIControlState.Normal);
			button.TouchDown+= (sender, e) => {
				if (action!=null) {
					action.Invoke();
				}
			};
		}
	}
}

