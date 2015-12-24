//
// FihiranaNumberView.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;

namespace ProjectX
{
	public class FihiranaNumberView : UIView
	{
		public int Index { get; set; }

		bool enabled;
		UIButton button;
		int number;

		public event EventHandler<EventArgs> Click;

		protected virtual void OnClick(EventArgs e)
		{
			if (Click != null) {
				Click(this, e);
			}
		}

		public FihiranaNumberView(nfloat x, nfloat y, nfloat width, int number, int size)
			: base(new CGRect(x, y, width, width))
		{
			this.number = number;
			
			button = new UIButton(new CGRect(0, 0, width, width));
			button.SetTitle(number.ToString(), UIControlState.Normal);
			button.Layer.CornerRadius = width / 2;
			button.Font = Font.UltraLight(size);

			button.BackgroundColor = UIColor.White;
			button.Layer.BorderColor = UIColor.LightGray.CGColor;
			button.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
			button.Layer.BorderWidth = 1;

			button.TouchDown += (sender, e) => {
				OnClick(e);
				//Switch();
				System.Diagnostics.Debug.WriteLine(Index);
			};
			Add(button);
		}

		public void Clear()
		{
			UIView.Animate(0.5, () => {
				button.BackgroundColor = UIColor.White;
				button.Layer.BorderColor = UIColor.LightGray.CGColor;
				button.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
				button.Layer.BorderWidth = 1;
			});
			Index = 0;
			enabled = false;

		}

		public void Switch()
		{
			if (!enabled) {
				UIView.Animate(0.5, () => {
					button.BackgroundColor = Color.Primary;
					button.Layer.BorderColor = UIColor.Clear.CGColor;
					button.SetTitleColor(UIColor.White, UIControlState.Normal);
					button.Layer.BorderWidth = 0;
				});
				Index = number;
			} else {
				UIView.Animate(0.5, () => {
					button.BackgroundColor = UIColor.White;
					button.Layer.BorderColor = UIColor.LightGray.CGColor;
					button.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
					button.Layer.BorderWidth = 1;
				});
				Index = 0;
			}
			enabled = !enabled;
		}

	}
}

