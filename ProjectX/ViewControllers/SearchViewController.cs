//
// SearchViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using AVFoundation;
using System.Drawing;

namespace ProjectX
{
	public class SearchViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DesignElement.NormalizeNavigation(NavigationController);
			View.BackgroundColor = UIColor.White;
			var searhBar = new UISearchView(20);
			NavigationItem.TitleView = searhBar;
		}
	}

	public class UISearchView : UIView
	{
		public UISearchView(nfloat y)
			: base(new CGRect(0, y, Metrics.Width, 44))
		{
			var seachView = new UIView(new CGRect(0, 0, Frame.Width - Metrics.Padding * 2, 32));
			seachView.Center = new CGPoint(Frame.Width / 2, Frame.Height / 2);
			seachView.BackgroundColor = UIColor.White;
			Add(seachView);

			var image = new UIImageView(new CGRect(0, 0, 32, 32));
			image.Image = UIImage.FromFile(Resource.Icon("icn_search.png"));
			image.BackgroundColor = UIColor.Clear;
			image.Layer.MasksToBounds = true;

			var text = new UITextField(new CGRect(0, 0, seachView.Frame.Width - 32, 32));
			text.Font = Font.Title(18);
			text.TextColor = text.TintColor = Color.Primary;
			text.LeftView = image;
			text.LeftViewMode = UITextFieldViewMode.Always;
			text.Layer.CornerRadius = text.Frame.Height / 2;
			text.KeyboardAppearance = UIKeyboardAppearance.Dark;
			text.Layer.MasksToBounds = true;
			text.AutocorrectionType = UITextAutocorrectionType.No;
			text.AttributedPlaceholder = new NSAttributedString("Search...", null, UIColor.LightGray);

			seachView.Add(text);

			var right = new UIView(new CGRect(seachView.Frame.Width - 32, 0, 32, 32));
			right.Alpha = 0;

			var button = new UIButton(new CGRect(0, 0, 24, 24));
			button.Center = new Point(16, 16);
			button.Layer.CornerRadius = button.Frame.Height / 2;
			button.SetImage(UIImage.FromFile(Resource.Icon("icn_cancel_filled.png")), UIControlState.Normal);

			right.Add(button);
			button.TouchDown += (sender, e) => {
				text.Text = String.Empty;
				text.ResignFirstResponder();
				UIView.Animate(0.3, () => {
					right.Alpha = 0;
				});
			};
			seachView.Add(right);

			text.ShouldReturn = textField => {
				text.Text = String.Empty;
				textField.ResignFirstResponder();
				UIView.Animate(0.3, () => {
					right.Alpha = 0;
				});
				return true;
			};
			text.EditingDidBegin += (sender, e) => UIView.Animate(0.3, () => {
				right.Alpha = 1;
			});

			seachView.Layer.CornerRadius = seachView.Frame.Height / 2;
			seachView.ClipsToBounds = true;
		}
	}


}

