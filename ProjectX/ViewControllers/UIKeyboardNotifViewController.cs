//
// EmptyClass.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace ProjectX
{
	public abstract class UIKeyboardNotifViewController : UIViewController
	{
		protected UIKeyboardNotifViewController()
		{
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
		}

		protected nfloat KeyboardHeight { get; private set; }

		protected UIScrollView ScrollView { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ScrollView = new UIScrollView(new CGRect(0, 0, Metrics.Width, Metrics.Height));
			ScrollView.ShowsHorizontalScrollIndicator = false;
			ScrollView.ShowsVerticalScrollIndicator = false;
			viewHeight = ScrollView.Frame.Height;
			ScrollView.ContentSize = new CGSize(Metrics.Width, Metrics.Height);
		}

		nfloat viewHeight;

		void OnKeyboardNotification(NSNotification notification)
		{
			if (IsViewLoaded) {
				bool visible = notification.Name == UIKeyboard.WillShowNotification;
				bool landscape = InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft ||
				                 InterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
				var keyboardFrame = UIKeyboard.FrameEndFromNotification(notification);
				OnKeyboardChanged(visible, landscape ? keyboardFrame.Width : keyboardFrame.Height);
			}
		}

		protected virtual void OnKeyboardChanged(bool visible, nfloat height)
		{
			KeyboardHeight = height;

			UIView.Animate(0.7, () => {
				ScrollView.Frame = visible ? 
					new CGRect(ScrollView.Frame.X, ScrollView.Frame.Y, ScrollView.Frame.Width, viewHeight - height) 
					: new CGRect(ScrollView.Frame.X, ScrollView.Frame.Y, ScrollView.Frame.Width, Metrics.Height);
			});

		}
	}
}

