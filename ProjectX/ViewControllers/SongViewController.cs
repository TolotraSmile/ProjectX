//
// HiraViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using CoreText;
using System.Runtime.Remoting.Messaging;


namespace ProjectX
{
	public class SongViewController : UIViewController
	{
		int index = 0;
		int max = 20;

		List<UIView> views = new List<UIView>();
		List<SongNumberView> buttons = new List<SongNumberView>();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			nfloat xOffset = 0;
			const int size = 40;
			for (int i = 0; i < max; i++) {
				var view = new UILabel(new CGRect(0, Metrics.Height * i, Metrics.Width, Metrics.Height - 64));
				view.Text = i.ToString();
				view.Font = Font.Light2(50);
				view.BackgroundColor = UIColor.Clear;
				view.TextAlignment = UITextAlignment.Center;
				view.Layer.CornerRadius = 10;
				views.Add(view);

				var button = new SongNumberView(0, xOffset, size, i, 20);
				button.Alpha = 0.5f;
				xOffset += size + 5;

				buttons.Add(button);
				button.Click += (sender, e) => {
					Index = button.Index;
				};
			}

			View.AddSubviews(views.ToArray());

			var bottomview = new UIScrollView(new CGRect(Metrics.Width - 8 - size, 24, size, Metrics.Height - 24));
			bottomview.ShowsVerticalScrollIndicator = false;
			bottomview.ContentSize = new CGSize(size, xOffset + 10);
			bottomview.AddSubviews(buttons.ToArray());
			View.AddSubview(bottomview);
			Index = 0;

			var rightGesture = new UISwipeGestureRecognizer(Previous){ Direction = UISwipeGestureRecognizerDirection.Down };
			var leftGesture = new UISwipeGestureRecognizer(Next){ Direction = UISwipeGestureRecognizerDirection.Up };
			View.AddGestureRecognizer(rightGesture);
			View.AddGestureRecognizer(leftGesture);

			var next = new UIButton(new CGRect(Metrics.Width - 40, 0, 40, 40));
			next.TouchDown += (sender, e) => Next();

			next.BackgroundColor = UIColor.Red;
			//View.Add(next);

			var prev = new UIButton(new CGRect(0, 0, 40, 40));
			prev.TouchDown += (sender, e) => Previous();

			prev.BackgroundColor = UIColor.Red;

			View.BackgroundColor = UIColor.White;
			//View.Add(prev);
		}

		void Next()
		{
			Index++;
		}

		void Previous()
		{
			Index--;
		}

		public int Index { 
			get { return index; } 
			set {
				UIView.Animate(0.5, () => {
					if (value >= 0 && value < max) {
						for (int i = 0; i < max; i++) {
							var x = (i - value);
							System.Diagnostics.Debug.WriteLine("target = " + value);
							System.Diagnostics.Debug.WriteLine("x = " + x);
							views[i].Frame = new CGRect(0, x * Metrics.Height, Metrics.Width, Metrics.Height);
							views[i].Alpha = x == 0 ? 1 : 0;
							//views[i].Alpha = (nfloat)Math.Abs(x/(max-target));
						}
						index = value;
						for (int i = 0; i < max; i++) {
							buttons[i].Enabled = (i == value);
						}
					}
				});
			}
		}
	}
}

