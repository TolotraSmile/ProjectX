//
// SongVerticalViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting

using System;
using System.Collections.Generic;

using CoreAnimation;
using CoreGraphics;

using UIKit;

namespace ProjectX
{
	public class SongVerticalViewController : UIViewController
	{
		int index = 0;
		const int max = 6;

		List<UIView> views = new List<UIView>();
		List<SongNumberView> buttons = new List<SongNumberView>();
		UIView containnerView;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.SetNavigationBarHidden(true, false);
			View.BackgroundColor = UIColor.White;


			//View.Add(prev);

			var background = new UIImageView(UIScreen.MainScreen.Bounds);
			background.Image = UIImage.FromFile("Images/login_back.png");
			background.ContentMode = UIViewContentMode.ScaleToFill;
			View.Add(background);

			var gradient = new CAGradientLayer { 
				Frame = background.Bounds,
				NeedsDisplayOnBoundsChange = true,
				MasksToBounds = true,
				Colors = new [] {
					UIColor.FromRGBA(22, 0, 38, 64).CGColor,
					UIColor.FromRGBA(28, 10, 48, 64).CGColor,
					UIColor.FromRGBA(24, 9, 12, 64).CGColor,
					UIColor.FromRGBA(24, 9, 12, 64).CGColor,
				}
			};

			background.Layer.AddSublayer(gradient);

			var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
			var blurView = new UIVisualEffectView(blur) {
				Frame = background.Bounds
			};
			background.AddSubview(blurView);

			nfloat xOffset = 0;
			const int size = 40;
			for (int i = 0; i < max; i++) {

				const string text = "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n"
				                    + "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n"
				                    + "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n"
				                    + "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n"
				                    + "Ilay ISPM tena maminay\nTsy mba foinay tokoa rahatrizay\nToerana nanabeazana ny tenanay\nMba ho tena olom-banona mahay\n\n";

				var view = new SongItemViewer(i, text);
				views.Add(view);

				var button = new SongNumberView(xOffset, 0, 16, i, 0);
				button.Alpha = 1;
				xOffset += 20;

				buttons.Add(button);
				button.Click += (sender, e) => {
					Index = button.Index;
				};
			}

			containnerView = new UIView(new CGRect(0, 0, Metrics.Width, Metrics.Height));
			containnerView.AddSubviews(views.ToArray());

			View.AddSubview(containnerView);

			var bottomview = new UIScrollView(new CGRect(20, Metrics.Height - 30, xOffset - 4, 20));
			bottomview.ShowsVerticalScrollIndicator = false;
			bottomview.ShowsHorizontalScrollIndicator = false;
			bottomview.Center = new CGPoint(Metrics.Width / 2, bottomview.Center.Y);
			bottomview.ContentSize = new CGSize(xOffset + 10, size);
			bottomview.AddSubviews(buttons.ToArray());
			View.AddSubview(bottomview);
			Index = 0;

			var rightGesture = new UISwipeGestureRecognizer(Previous){ Direction = UISwipeGestureRecognizerDirection.Right };
			var leftGesture = new UISwipeGestureRecognizer(Next){ Direction = UISwipeGestureRecognizerDirection.Left };
			View.AddGestureRecognizer(rightGesture);
			View.AddGestureRecognizer(leftGesture);

			var next = new UIButton(new CGRect(0, Metrics.Height - 40, 40, 40));
			next.TouchDown += (sender, e) => Next();

			next.BackgroundColor = UIColor.Red;
			//View.Add(next);

			var prev = new UIButton(new CGRect(0, 0, 40, 40));
			prev.TouchDown += (sender, e) => Previous();

			prev.BackgroundColor = UIColor.Red;
			View.Add(new CustomBar(() => NavigationController.PopViewController(true), "787", "But for android its not available as far as my"));

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
							views[i].Frame = new CGRect((x * Metrics.Width) + Metrics.Padding2, 
								64 + Metrics.Padding * 3, Metrics.Width - 2 * Metrics.Padding2, Metrics.Height - Metrics.Padding2);
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

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			containnerView.Alpha = 0;
			UIView.Animate(0.7, () => {
				containnerView.Alpha = 1;
			});
		}
	}
}

