//
// SongViewModel.cs
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
	public class SongViewModel : UIView
	{
		public SongViewModel(CGRect frame, string title, string description)
			: base(frame)
		{
			var avatar = new UILabel(new CGRect(12, 12, 48, 40));
			avatar.Text = title;
			avatar.Font = Font.Light2(30);
			avatar.TextAlignment = UITextAlignment.Center;
			avatar.TextColor = UIColor.White;
			avatar.Center = new CGPoint(avatar.Center.X, Frame.Height / 2);
			Add(avatar);

			var x = 24 + avatar.Frame.Width;

			var view = new UIView(new CGRect(x, 12, frame.Width - x - 12, 40));
			var label = new UILabel(new CGRect(0, 0, view.Frame.Width, 22));
			label.Font = Font.Normal(18);
			label.TextColor = UIColor.White;
			label.Text = description;
			view.Add(label);

			var subtitle = new UILabel(new CGRect(0, 22, view.Frame.Width, 18));
			subtitle.Text = "Auteur du livre";
			subtitle.TextColor = UIColor.LightGray;
			subtitle.Font = Font.Normal(14);
			view.Add(subtitle);
			Add(view);
		}
	}
}

