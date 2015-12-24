//
// LyricsItemViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;

namespace ProjectX
{
	public class LyricsItemViewController : UIViewController
	{
		List<int> items;

		public LyricsItemViewController(List<int> items)
		{
			this.items = items;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			DesignElement.NormalizeNavigation(NavigationController, Color.Primary);
			View.BackgroundColor = UIColor.White;
			const string text = "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay";
			nfloat y = Metrics.Padding2;
			var scroll = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
			scroll.ShowsHorizontalScrollIndicator = false;
			scroll.IndicatorStyle = UIScrollViewIndicatorStyle.White;
			scroll.AlwaysBounceVertical = false;
			Add(scroll);
			for (int i = 0; i < items.Count; i++) {
				nfloat x = Metrics.Padding2;
//				if ((i % 2) == 1) {
//					x += 40;
//				}
				var item = new LyricsItemViewModel(x, y, items[i] + " - " + text);
				scroll.Add(item);
				y += item.Frame.Height + Metrics.Padding2;
			}
			scroll.ContentSize = new CGSize(View.Frame.Width, y + 2 * Metrics.Padding2);

			const int size = 64;
			var button = new UIButton(new CGRect(Metrics.Width - Metrics.Padding - size, Metrics.Height - Metrics.Padding - size, size, size));
			button.Layer.CornerRadius = size / 2;
			button.BackgroundColor = Color.Primary;
			button.Alpha = 0;
			NavigationController.View.Add(button);

			button.TouchDown += (sender, e) => scroll.SetContentOffset(CGPoint.Empty, true);
			scroll.Scrolled += (sender, e) => {
				var yy = scroll.ContentOffset.Y / View.Frame.Height;
				if (yy < 0) {
					yy = 0;
				}
				if (yy > 0.7f) {
					yy = 0.7f;
				}

				UIView.Animate(0.9, () => {
					button.Alpha = yy;
				});

			};
		}
	}
}

