//
// SongNumberView.cs
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
	public class SongNumberView : UIView
	{
		public int Index { get; private set; }

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

		public SongNumberView(nfloat x, nfloat y, nfloat width, int index, int size)
			: base(new CGRect(x, y, width, width))
		{
			Index = index;

			button = new UIButton(new CGRect(0, 0, width, width));
			button.SetTitle(index.ToString(), UIControlState.Normal);
			button.Layer.CornerRadius = width / 2;
			button.Font = Font.UltraLight(size);

			button.BackgroundColor = UIColor.White;
			button.Layer.BorderColor = UIColor.White.CGColor;
			button.SetTitleColor(UIColor.White, UIControlState.Normal);

			button.TouchDown += (sender, e) => OnClick(e);
			Add(button);
		}

		public bool Enabled {
			get{ return enabled; }
			set {
				if (value) {
					UIView.Animate(0.5, () => {
						button.BackgroundColor = Color.Primary;
						button.Layer.BorderColor = UIColor.Clear.CGColor;
						button.SetTitleColor(UIColor.White, UIControlState.Normal);
					});
				} else {
					UIView.Animate(0.5, () => {
						button.BackgroundColor = UIColor.White;
						button.Layer.BorderColor = UIColor.White.CGColor;
						button.SetTitleColor(UIColor.LightGray, UIControlState.Normal);
					});
				}
				enabled = value;
			}
		}
	}
}

