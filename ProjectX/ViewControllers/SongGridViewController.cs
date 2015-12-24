//
// FihiranaGridView.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;

namespace ProjectX
{
	public class SongGridViewController : UIViewController
	{
		int count;

		public List<int> Items { get; set; }

		public SongGridViewController(int count)
		{
			Items = new List<int>(count);
			this.count = count;

		}

		List<FihiranaNumberView> views;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.White;

			DesignElement.NormalizeNavigation(NavigationController, Color.Primary);
			Title = "417";

			var scroll = new UIScrollView(new CGRect(0, 0, Metrics.Width, Metrics.Height));
			nfloat x = Metrics.Padding2;
			nfloat y = Metrics.Padding2;
			var width = (Metrics.Width - (2 * x + 2 * Metrics.Padding)) / 3;
			var j = 0;
			int k = 0;

			views = new List<FihiranaNumberView>();

			for (int i = 0; i < count; i++) {
				if (j > 2) {
					x = Metrics.Padding2;
					y += width + Metrics.Padding;
					j = 0;
					k++;
				}
				views.Add(new FihiranaNumberView(x, y, width, i + 1, 44));
				x += width + Metrics.Padding;
				j++;
			}
			y += width + Metrics.Padding2;
			scroll.AddSubviews(views.ToArray());
			Add(scroll);

			var open = DesignElement.MakeTextButton(Metrics.Padding2, y, Metrics.Width - 2 * Metrics.Padding2);
			open.Layer.CornerRadius = open.Frame.Height / 2;
			open.Font = Font.Light2(20);
			open.Layer.BorderWidth = 1;
			open.Layer.BorderColor = UIColor.DarkGray.CGColor;
			open.SetTitleColor(UIColor.DarkGray, UIControlState.Normal);
			open.SetTitle("OK", UIControlState.Normal);
			open.TouchDown += (sender, e) => {
				Items.Clear();
				foreach (var item in views) {
					if (item.Index > 0) {
						Items.Add(views.IndexOf(item) + 1);
						System.Diagnostics.Debug.WriteLine(views.IndexOf(item) + 1);
					}
				}
				if (Items.Count > 0) {
					NavigationController.PushViewController(new LyricsItemViewController(Items), true);
				}
			};
			scroll.Add(open);

			y += open.Frame.Height + Metrics.Padding;
			var all = DesignElement.MakeTextButton(Metrics.Padding2, y, Metrics.Width - 2 * Metrics.Padding2);
			all.Layer.CornerRadius = all.Frame.Height / 2;
			all.Font = Font.Light2(20);
			all.Layer.BorderWidth = 1;
			all.Layer.BorderColor = UIColor.DarkGray.CGColor;
			all.SetTitleColor(UIColor.DarkGray, UIControlState.Normal);
			all.SetTitle("TOUS", UIControlState.Normal);
			all.TouchDown += (sender, e) => {
				Items.Clear();
				for (int i = 0; i < count; i++) {
					Items.Add(i + 1);
					System.Diagnostics.Debug.WriteLine(i + 1);
				}

				if (Items.Count > 0) {
					NavigationController.PushViewController(new LyricsItemViewController(Items), true);
				}
			};
			scroll.Add(all);

			y += open.Frame.Height + Metrics.Padding;
			var clear = DesignElement.MakeTextButton(Metrics.Padding2, y, Metrics.Width - 2 * Metrics.Padding2);
			clear.Layer.CornerRadius = clear.Frame.Height / 2;
			clear.Font = Font.Light2(20);
			clear.BackgroundColor = Color.Warning;
			clear.SetTitle("CLEAR", UIControlState.Normal);
			clear.TouchDown += (sender, e) => {
				Items.Clear();
				for (int i = 0; i < views.Count; i++) {
					views[i].Clear();
				}
			};
			scroll.Add(clear);
			y += clear.Frame.Height + Metrics.Padding;
			scroll.ContentSize = new CGSize(Metrics.Width, y + Metrics.Padding2);
		}
	}
}