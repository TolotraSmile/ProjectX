//
// XViewModel.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace ProjectX
{
	public static class DesignElement
	{
		static int height = 40;

		static public UITextField MakeTextField(nfloat x, nfloat y, nfloat width, string imageName)
		{
			var image = new UIImageView(new CGRect(0, 0, height, height));
			image.Layer.CornerRadius = image.Frame.Height / 2;
			image.Image = UIImage.FromFile(imageName);
			image.Layer.MasksToBounds = true;

			var left = new UIView(new CGRect(0, 0, height + height / 2, height));
			left.Add(image);

			var line = new UIView(new CGRect(height, (height / 4), 1, height / 2));
			line.BackgroundColor = UIColor.Black;
			left.Add(line);

			var text = new UITextField(new CGRect(x, y, width, height));
			text.Font = Font.Normal(16);
			text.Placeholder = "Votre nom";
			text.LeftView = left;
			text.LeftViewMode = UITextFieldViewMode.Always;
			text.Layer.CornerRadius = image.Frame.Height / 2;
			text.KeyboardAppearance = UIKeyboardAppearance.Dark;
			text.Layer.MasksToBounds = true;
			text.AutocorrectionType = UITextAutocorrectionType.No;
			text.ShouldReturn = (textField) => {
				textField.ResignFirstResponder();
				return true;
			};
			return text;
		}

		static public UIButton MakeTextButton(nfloat x, nfloat y, nfloat width)
		{
			var button = new UIButton(new CGRect(x, y, width, height));
			button.Font = Font.Normal(16);
			button.Layer.CornerRadius = height / 2;
			button.Layer.MasksToBounds = true;
			return button;
		}

		static public void AddShadowAndRounded(UIView view)
		{
			//1. first, create Inner layer with content
			var innerView = new CALayer();
			innerView.Frame = new CGRect(0, 0, view.Bounds.Width, view.Bounds.Height);
			innerView.BorderWidth = 0.0f;
			innerView.CornerRadius = (float)Math.Min(view.Frame.Height, view.Frame.Width) / 2;
			innerView.MasksToBounds = true;
			innerView.BackgroundColor = Color.Primary.CGColor;

			//put the layer to the BOTTOM of layers is also a MUST step...
			//otherwise this layer will overlay the sub uiviews in current uiview...
			//[self.layer insertSublayer:innerView atIndex:0];
			view.Layer.InsertSublayer(innerView, 0);
			//2. then, create shadow with self layer
			view.Layer.MasksToBounds = false;
			view.Layer.ShadowColor = UIColor.Black.CGColor;
			view.Layer.ShadowOpacity = 0.4f;
			//shadow length
			view.Layer.ShadowRadius = 2.0f;
			//no offset
			view.Layer.ShadowOffset = CGSize.Empty;
			//right down shadow
			//[self.layer setShadowOffset: CGSizeMake(1.0f, 1.0f)];

			//3. last but important, MUST clear current view background color, or the color will show in the corner!
			view.BackgroundColor = UIColor.Clear;
		}

		static public UIImagedButton MakeImageButton(nfloat x, nfloat y, nfloat width, string imagename, UITextAlignment alignement)
		{
			var button = new UIImagedButton(new CGRect(x, y, width, height), Font.Title(16), alignement);
			button.Image = UIImage.FromFile(imagename);
			//button.Font = Font.Normal(16);
			//button.Layer.CornerRadius = height / 2;
			//button.Layer.MasksToBounds = true;
			return button;
		}

		static public UIImageView MakeImageView(nfloat y, nfloat width)
		{
			var avatar = new UIImageView(new CGRect(0, y, width, width));
			avatar.Center = new CGPoint(Metrics.Width / 2, avatar.Center.Y);
			avatar.Layer.CornerRadius = avatar.Frame.Height / 2;
			avatar.Layer.MasksToBounds = true;
			return avatar;
		}

		static public void NormalizeNavigation(UINavigationController navigation)
		{
			if (navigation != null) {
				navigation.NavigationBar.BarTintColor = UIColor.Clear;
				navigation.NavigationBar.TintColor = UIColor.White;
				navigation.NavigationBar.BackgroundColor = UIColor.White;
				navigation.NavigationBar.Translucent = false;
				navigation.NavigationBar.BarStyle = UIBarStyle.Black;
			}
		}
		static public void NormalizeNavigation(UINavigationController navigation, UIColor barColor)
		{
			if (navigation != null) {
				navigation.NavigationBar.BarTintColor = barColor;
				navigation.NavigationBar.TintColor = UIColor.White;
				navigation.NavigationBar.BackgroundColor = UIColor.White;
				navigation.NavigationBar.Translucent = false;
				navigation.NavigationBar.BarStyle = UIBarStyle.Black;
			}
		}

		static public void ClearNavigation(UINavigationController navigation)
		{
			if (navigation != null) {
				navigation.NavigationBar.BarTintColor = UIColor.Clear;
				navigation.NavigationBar.TintColor = UIColor.White;
				navigation.NavigationBar.BackgroundColor = UIColor.Clear;
				navigation.NavigationBar.Translucent = false;
				navigation.NavigationBar.BarStyle = UIBarStyle.Black;
			}
		}
	}
}

