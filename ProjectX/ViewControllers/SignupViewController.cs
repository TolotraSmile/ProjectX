//
// SingupViewController.cs
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
	public class SignupViewController : UIKeyboardNotifViewController
	{
		public override void ViewDidLoad()
		{
			NavigationController.SetNavigationBarHidden(true, false);

			base.ViewDidLoad();

			var background = new UIImageView(UIScreen.MainScreen.Bounds);
			background.Image = UIImage.FromFile("Images/login_back.png");
			background.ContentMode = UIViewContentMode.ScaleToFill;
			Add(background);

			var blur = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
			var blurView = new UIVisualEffectView(blur) {
				Frame = UIScreen.MainScreen.Bounds
			};
			View.Add(blurView);

			y = 32;

			const int padding = 10;

			var image = DesignElement.MakeImageView(y, 128);
			image.Center = new CGPoint(Metrics.Width / 2, image.Center.Y);
			image.BackgroundColor = UIColor.White;
			AddElement(image, 32);

			var photo = new UIButton(new CGRect(0, 0, 64, 64));
			photo.SetImage(Resource.Icon("icn_camera.png"), UIControlState.Normal);
			photo.BackgroundColor = UIColor.FromRGBA(255, 255, 255, 128);
			photo.Center = image.Center;
			photo.Layer.CornerRadius = 32;
			ScrollView.Add(photo);

			var login = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_user_light.png"));
			login.Placeholder = "Login";
			login.BackgroundColor = UIColor.White;
			AddElement(login, padding);

			var firstName = DesignElement.MakeTextField(20, y, Metrics.Width - 40,Resource.Icon("icn_user_light.png"));
			firstName.Placeholder = "First name";
			firstName.BackgroundColor = UIColor.White;
			AddElement(firstName, padding);

			var lastName = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_user_light.png"));
			lastName.Placeholder = "Last name";
			lastName.BackgroundColor = UIColor.White;
			AddElement(lastName, padding);

			var email = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_mail.png"));
			email.Placeholder = "Email";
			email.BackgroundColor = UIColor.White;
			AddElement(email, padding);

			var password = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_locked.png"));
			password.Placeholder = "Password";
			password.SecureTextEntry = true;
			password.BackgroundColor = UIColor.White;
			AddElement(password, padding);

			var confirmation = DesignElement.MakeTextField(20, y, Metrics.Width - 40, Resource.Icon("icn_locked.png"));
			confirmation.Placeholder = "Confirm password";
			confirmation.SecureTextEntry = true;
			confirmation.BackgroundColor = UIColor.White;
			AddElement(confirmation, padding);

			var signup = DesignElement.MakeTextButton(20, y, Metrics.Width - 40);
			signup.BackgroundColor = Color.Warning;
			signup.SetTitle("Get started", UIControlState.Normal);
			AddElement(signup, padding);

			signup.TouchDown += Button_TouchDown;

			var back = DesignElement.MakeImageButton(20, y, Metrics.Width - 40, Resource.Icon("icn_arrow_left.png"), UITextAlignment.Left);
			back.BackgroundColor = Color.Warning;
			back.Text = "Back";
			AddElement(back, padding);

			back.Click += (s, e) => NavigationController.PopViewController(true);

			ScrollView.ContentSize = new CGSize(ScrollView.ContentSize.Width, y);
			Add(ScrollView);

		}

		void Button_TouchDown(object sender, EventArgs e)
		{
			var RootController = new SlideoutNavigationController();
			RootController.MainViewController = new MainNavigationController(new MainViewController(), RootController, null, true);
			RootController.MenuViewController = new MenuNavigationController(new SideMenuController(NavigationController), RootController, null) { NavigationBarHidden = true };
			NavigationController.PushViewController(RootController, true);
		}

		nfloat y;

		void AddElement(UIView view, int after)
		{
			ScrollView.Add(view);
			y += view.Frame.Height + after+5;
		}

	}
}

