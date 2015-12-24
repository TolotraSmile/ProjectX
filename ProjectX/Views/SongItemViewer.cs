//
// SongItemViewer.cs
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
	public class SongItemViewer : UIView
	{
		public SongItemViewer(int index, string text)
			: base(new CGRect((index * Metrics.Width) + Metrics.Padding, 0, Metrics.Width - 2 * Metrics.Padding, Metrics.Height - 64))
		{
			var view = new UIScrollView(new CGRect(0, 0, Frame.Width, Frame.Height));
			var label = new UILabel(view.Frame);
			//"Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n" +
			//"Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay";

			label.Text = text;
			label.Font = Font.Light2(20);
			label.Lines = 0;
			label.TextColor = UIColor.White;
			label.TextAlignment = UITextAlignment.Center;
			label.SizeToFit();
			view.ContentSize = new CGSize(label.Frame.Width, label.Frame.Height);

			if (label.Frame.Height > view.Frame.Height) {
				label.Frame = new CGRect(0, 0, label.Frame.Width, label.Frame.Height);
			} else {
				label.Center = new CGPoint(Frame.Width / 2, Frame.Height / 2);
			}

			Add(view);
		}
	}
}

