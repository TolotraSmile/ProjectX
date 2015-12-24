//
// UIImagedButton.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace ProjectX
{
	public class UIImagedButton : UIView
	{
		UIImageView image;
		UILabel text;

		public String Text {
			get {
				return text != null ? text.Text : String.Empty;
			}
			set {
				if (text != null && !String.IsNullOrEmpty(value)) {
					text.Text = value;
					if (AutoSize) {
						var attrib = new UIStringAttributes(new NSDictionary(UIStringAttributeKey.Font, text.Font));
						var size = new NSString(value).GetSizeUsingAttributes(attrib);
						System.Diagnostics.Debug.WriteLine("Button Size : " + size.Width);
						text.Frame = new CGRect(text.Frame.X, text.Frame.Y, size.Width, text.Frame.Height);
						Frame = new CGRect(Frame.X, Frame.Y, Frame.Height + text.Frame.Width + 16, Frame.Height);
					}
				}
			}
		}

		public UIImage Image {
			get { return image != null ? image.Image : null; }
			set {
				if (image != null) {
					image.Image = value;
				}
			}
		}

		public void SetButtonColor(UIColor color)
		{
			if (image != null) {
				image.BackgroundColor = color;
			}
		}

		public void SetTextColor(UIColor color)
		{
			if (text != null) {
				text.TextColor = color;
			}
		}

		public void SetButtonRadius(nfloat radius)
		{
			if (image != null) {
				image.Layer.CornerRadius = radius;
			}
		}

		public event EventHandler<EventArgs> Click;

		protected virtual void OnClick(EventArgs e)
		{
			if (Click != null) {
				Click(this, e);
			}
		}

		public bool AutoSize { get; set; }

		public UIImagedButton(CGRect frame, UIFont font, UITextAlignment alignement)
			: base(frame)
		{
			text = new UILabel(new CGRect(0, 0, frame.Width, frame.Height));
			AutoSize = false;
			BackgroundColor = UIColor.Red;
			Layer.CornerRadius = frame.Height / 2;
			text.TextAlignment = UITextAlignment.Center;
			text.Font = font;
			text.TextColor = UIColor.White;
			ClipsToBounds = true;
			Add(text);

			image = alignement == UITextAlignment.Left 
				? new UIImageView(new CGRect(0, 0, frame.Height, frame.Height)) 
				: new UIImageView(new CGRect(frame.Width - frame.Height, 0, frame.Height, frame.Height));
			Add(image);

			var button = new UIButton(new CGRect(0, 0, frame.Width, frame.Height));
			Add(button);

			button.TouchDown += (sender, e) => OnClick(EventArgs.Empty);

		}

	}
}