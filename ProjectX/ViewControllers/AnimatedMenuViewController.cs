//
// Ce.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace ProjectX
{
	public class AnimatedMenuViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var buttons = new List<CircularButtonItem> {
				new CircularButtonItem(Resource.Icon("icn_picture.png"), () => NavigationController.PushViewController(new UserGridViewController(), true)),
				new CircularButtonItem(Resource.Icon("icn_star.png"), () => NavigationController.PushViewController(new MusicGridViewController(), true)),
				new CircularButtonItem(Resource.Icon("icn_mail.png"), () => NavigationController.PushViewController(new FeedViewController(), true)),
				new CircularButtonItem(Resource.Icon("icn_mail.png"), () => NavigationController.PushViewController(new MainViewController(), true)),
				//new CircularButtonItem(Resource.Icon("icn_star.png"), () => NavigationController.PushViewController(new MusicGridViewController(), true)),
			};
			View.BackgroundColor = UIColor.Black;
			var view = new CircularMenu(buttons);
			view.Center = new CGPoint(Metrics.Width / 2, (Metrics.Height - 64) / 2);
			Add(view);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			DesignElement.ClearNavigation(NavigationController);
		}
	}

	public class RadialView : UIView
	{
		public RadialView()
			: base(new CGRect(0, 0, 128, 128))
		{
		}


		public nfloat endArc = 0;
		public nfloat arcWidth = 10.0f;
		public UIColor arcColor = UIColor.Yellow;
		public UIColor arcBackgroundColor = UIColor.Black;

		public override void DrawRect(CGRect area, UIViewPrintFormatter formatter)
		{
			base.DrawRect(area, formatter);


			var fullCircle = (nfloat)(2.0 * Math.PI);
			nfloat start = -0.25f * fullCircle;
			nfloat end = endArc * fullCircle + start;

			//  find the centerpoint of the rect
			var centerPoint = new CGPoint(area.GetMidX(), area.GetMidY());

			//  define the radius by the smallest side of the view
			nfloat radius = area.Width > area.Height ? (area.Width - arcWidth) / 2.0f : (area.Height - arcWidth) / 2.0f;
			var context = UIGraphics.GetCurrentContext();

			//	Once you have a context, set the color space. For most purposes just use RGB like this:
			//  set colorspace
			//  set line attributes
			//CGContext.SetLineWidth(context, arcWidth);
			context.SetLineWidth(arcWidth);
			context.SetLineCap(CGLineCap.Round);

			//  make the circle background
			context.SetStrokeColor(arcBackgroundColor.CGColor);
			context.AddArc(centerPoint.X, centerPoint.Y, radius, 0, fullCircle, true);
			context.StrokePath();

			//  draw the arc
			context.SetStrokeColor(arcColor.CGColor);
			context.SetLineWidth(arcWidth * 0.8f);
			context.SetLineWidth(arcWidth);
			context.AddArc(centerPoint.X, centerPoint.Y, radius, start, end, true);
			context.StrokePath();
		}
	}

	class CircularMenu : UIView
	{
		List<UIButton> buttons;
		UIButton button;
		const int size = 70;
		int angle;

		public CircularMenu(IList<CircularButtonItem> items)
			: base(new CGRect(0, 0, Metrics.Width - 40, Metrics.Width - 40))
		{
			buttons = new List<UIButton>();
			angle = 360 / items.Count;
			startAngle = (items.Count % 2 == 0) ? 225 : 270;
			if (items.Count == 2) {
				angle = 90;
			}
			if (items.Count == 3) {
				startAngle = 90;
			}
			if (items.Count > 5) {
				startAngle = 0;
			}
			button = new UIButton(new CGRect(0, 0, 90, 90));
			button.BackgroundColor = Color.Primary;
			button.Center = new CGPoint(Frame.Width / 2, Frame.Height / 2);
			button.Layer.CornerRadius = button.Frame.Height / 2;
			button.SetImage(UIImage.FromFile("profil.jpeg"), UIControlState.Normal);
			button.ClipsToBounds = true;
			for (int i = 0; i < items.Count; i++) {
				AddButton(items[i], i);
			}
			AddSubviews(buttons.ToArray());

			button.TouchDown += (sender, e) => Switch();

			var blank = new UIButton(new CGRect(0, 0, 100, 100));
			blank.BackgroundColor = UIColor.White;
			blank.Center = new CGPoint(Frame.Width / 2, Frame.Height / 2);
			blank.Layer.CornerRadius = blank.Frame.Height / 2;
			blank.Alpha = 0.8f;
			Add(blank);
			Add(button);

			/*
			var animated = new UIButton(new CGRect(0, 0, size / 2, size / 2));
			animated.BackgroundColor = Color.Third;
			animated.Center = Equations.PointOnCircle(Frame.Width / 2 - size / 2, angle, button.Center);
			animated.Layer.CornerRadius = size / 4;
			Add(animated);
			var x = 1;
			var timer = new Timer(10);
			timer.Elapsed += ( sender, e) => {
				timer.Start();
				InvokeOnMainThread(() => {
					animated.Center = Equations.PointOnCircle(Frame.Width / 2 - size / 2, ++x, button.Center);
				});
			};
			timer.Start();
			*/
			Alpha = 0;
			UIView.Animate(0.9, () => {
				Alpha = 1;
			});
		}

		bool open = true;
		float startAngle = 270;
		float finalAngle = 360;

		void AddButton(CircularButtonItem buttonItem, int index)
		{
			var item = new UIButton(new CGRect(0, 0, size, size));
			item.BackgroundColor = Color.Primary;
			item.Layer.CornerRadius = size / 2;

			var currentAngle = (startAngle + angle * index) % 360;
			System.Diagnostics.Debug.WriteLine(currentAngle);
			item.Center = Equations.PointOnCircle(0, currentAngle, button.Center);
			item.TouchDown += (s, e) => {
				Switch();
				if (buttonItem.Action != null) {
					buttonItem.Action.Invoke();
				}
			};
			item.Alpha = 0.8f;
			item.SetImage(UIImage.FromFile(buttonItem.Icon), UIControlState.Normal);
			buttons.Add(item);
		}

		void Switch()
		{
			foreach (var item in buttons) {
				var index = buttons.IndexOf(item);
				UIView.Animate(0.5, () => {
					item.Alpha = (nfloat)(open ? 1.0 : 0.8);
					item.Center = open ? Equations.PointOnCircle(Frame.Width / 2 - size / 2, (startAngle + angle * index) % 360, button.Center) 
						: Equations.PointOnCircle(0, (startAngle + angle * index) % 360, button.Center);
				});
			}
			open = !open;
		}
	}

	public class CircularButtonItem
	{
		public Action Action { get; set; }

		public String Icon { get; set; }

		public CircularButtonItem(string icon, Action action)
		{
			Icon = icon;
			Action = action;
		}
	}

}

