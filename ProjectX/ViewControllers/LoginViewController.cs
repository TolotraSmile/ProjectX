//
// LoginViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using ProjectX.SlideoutNavigation;
using CoreGraphics;

namespace ProjectX
{
	public class LoginViewController : UIKeyboardNotifViewController
	{
		JBKenBurnsView imageView;
		public override void ViewDidLoad()
		{
			NavigationController.SetNavigationBarHidden(true, false);

			base.ViewDidLoad();

			var background = new UIImageView(UIScreen.MainScreen.Bounds);
			background.Image = UIImage.FromFile("Images/login_back.png");
			background.ContentMode = UIViewContentMode.ScaleToFill;
			//Add(background);


			 imageView = new JBKenBurnsView {
				Frame = UIScreen.MainScreen.Bounds,
				Images = new System.Collections.Generic.List<UIImage> { UIImage.FromFile("Images/login_back.png") },
				UserInteractionEnabled = false,
			};
			Add(imageView);

			var mask = new UIView(UIScreen.MainScreen.Bounds);
			mask.BackgroundColor = Color.Primary;
			mask.Alpha = 0.3f;
			View.Add(mask);

			var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
			var blurView = new UIVisualEffectView(blur) {
				Frame = UIScreen.MainScreen.Bounds
			};
			blurView.Alpha = 0.1f;
			mask.Add(blurView);

			y = Metrics.Height - 100;

			var signup = DesignElement.MakeTextButton(20, y, Metrics.Width - 40);
			signup.BackgroundColor = Color.Warning;
			signup.SetTitle("Signup", UIControlState.Normal);
			AddElement(signup, 15);
			TranslateFrom(signup, Metrics.Height);
			signup.TouchDown += (sender, e) => NavigationController.PushViewController(new SongVerticalViewController(), true);

			var signin = DesignElement.MakeImageButton(20, y, Metrics.Width - 40, Resource.Icon("icn_login.png"), UITextAlignment.Right);
			signin.BackgroundColor = Color.Primary;
			signin.Text = "Signin";
			signin.Click += Button_TouchDown;

			AddElement(signin, 20);
			TranslateFrom(signin, Metrics.Height);

			var password = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_locked.png"));
			password.Placeholder = "Password";
			password.SecureTextEntry = true;
			password.BackgroundColor = UIColor.White;
			AddElement(password, 15);
			TranslateFrom(password, Metrics.Height);

			var login = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_user_light.png"));
			login.Placeholder = "Login";
			login.BackgroundColor = UIColor.White;
			AddElement(login, 0);
			TranslateFrom(login, Metrics.Height);

			var image = DesignElement.MakeImageView(y, 128);
			image.Center = new CGPoint(Metrics.Width / 2, password.Frame.Y / 2);
			image.BackgroundColor = Color.Primary;
			AddElement(image, 64);
			TranslateFrom(image, Metrics.Height);

			Add(ScrollView);
			//InitializeSocial();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			imageView.Animate();
		}

		static void TranslateFrom(UIView view, nfloat y)
		{
			var rect = view.Frame;
			view.Alpha = 0;
			view.Frame = new CGRect(view.Frame.X, y, view.Frame.Width, view.Frame.Height);
			UIView.SetAnimationCurve(UIViewAnimationCurve.EaseIn);
			UIView.Animate(0.5, () => {
				view.Frame = rect;
				view.Alpha = 1;
			});
		}


		void Button_TouchDown(object sender, EventArgs e)
		{
			var RootController = new SlideoutNavigationController();
			RootController.MainViewController = new MainNavigationController(new AnimatedMenuViewController(), RootController, null, true);
			RootController.MenuViewController = new MenuNavigationController(new SideMenuController(NavigationController), RootController, null) { NavigationBarHidden = true };
			NavigationController.PushViewController(RootController, true);
		}

		nfloat y;

		void AddElement(UIView view, int after)
		{
			ScrollView.Add(view);
			y -= (view.Frame.Height + after);
		}

		void InitializeSocial()
		{
			var socialView = new UIView(new CGRect(0, Metrics.Height, Metrics.Width, 256));
			var facebook = new UIButton(new CGRect(0, 0, Metrics.Width, 128));
			facebook.BackgroundColor = UIColor.Blue;
			socialView.Add(facebook);

			var google = new UIButton(new CGRect(0, 128, Metrics.Width, 128));
			google.BackgroundColor = UIColor.Red;
			socialView.Add(google);

			Add(socialView);

			var button = new UIButton(new CGRect(0, 0, 64, 64));
			button.BackgroundColor = Color.Primary;
			button.SetBackgroundImage(UIImage.FromFile(Resource.Icon("icn_arrow_up.png")), UIControlState.Normal);
			button.Layer.CornerRadius = button.Frame.Height / 2;
			View.Add(button);

			var collapsed = true;

			var angle = 0.0f;

			button.TouchDown += (sender, e) => {
				if (collapsed) {
					angle += (float)Math.PI;
					UIView.Animate(0.7, () => {
						button.Transform = CGAffineTransform.MakeRotation(angle);
						socialView.Frame = new CGRect(0, Metrics.Height - 256, Metrics.Width, socialView.Frame.Height);
						System.Diagnostics.Debug.WriteLine("Open");
					});
				} else {
					angle -= (float)Math.PI;
					UIView.Animate(0.7, () => {
						button.Transform = CGAffineTransform.MakeRotation(angle);
						socialView.Frame = new CGRect(0, Metrics.Height, Metrics.Width, socialView.Frame.Height);
						System.Diagnostics.Debug.WriteLine("Close");
					});
				}

				System.Diagnostics.Debug.WriteLine(angle);
				collapsed = !collapsed;
			};
		}
	}
}

