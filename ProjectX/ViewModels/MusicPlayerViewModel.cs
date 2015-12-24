//
// MusicPlayerViewModel.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using AVFoundation;
using Foundation;
using System.Resources;

namespace ProjectX
{
	public class MusicPlayerViewModel : UIView
	{

		NSTimer timer;

		public MusicPlayerViewModel(UINavigationController navigation)
			: base(new CGRect(0, Metrics.Height - 68, Metrics.Width, 68))
		{
			var image = new UIButton(new CGRect(0, 0, 68, 68));
			image.BackgroundColor = UIColor.White;
			image.SetImage(UIImage.FromFile("profil.jpeg"), UIControlState.Normal);
			Add(image);

			var left = new UIView(new CGRect(68, 0, Frame.Width - 68, 68));
			left.BackgroundColor = UIColor.White;

			var bar = new UIView(new CGRect(0, 0, left.Frame.Width - 80, 4));
			bar.BackgroundColor = Color.Primary;
			left.AddSubview(bar);

			var title = new UILabel(new CGRect(16, 16, left.Frame.Width - 32 - 68, 20));
			title.Font = Font.Normal(18);
			title.Text = "Paradise";
			title.TextColor = UIColor.Black;
			left.AddSubview(title);

			var subtitle = new UILabel(new CGRect(16, 38, left.Frame.Width - 32 - 68, 20));
			subtitle.Font = Font.Light(14);
			subtitle.TextColor = UIColor.Black;
			subtitle.Text = "Coldplay";
			left.AddSubview(subtitle);

			var error = new NSError();
			var player = new AVAudioPlayer(new NSUrl(Resource.Audio("paradise.mp3")), "mp3", out error);
			var control = new UIButton(new CGRect(left.Frame.Width - 68, 0, 68, 68));
			control.SetImage(UIImage.FromFile(Resource.Icon("icn_play.png")), UIControlState.Normal);
			control.TouchDown += (sender, e) => {
				if (player.Playing) {
					UIView.Animate(0.7, () => {
						control.SetImage(UIImage.FromFile(Resource.Icon("icn_play.png")), 
							UIControlState.Normal);
						control.BackgroundColor = UIColor.White;
					});
					player.Pause();
				} else {
					UIView.Animate(0.7, () => {
						control.SetImage(UIImage.FromFile(Resource.Icon("icn_pause.png")), 
							UIControlState.Normal);
						control.BackgroundColor = Color.Primary;
					});
					player.Play();
				}
			};

			UIView.Animate(0.6, () => {
				Frame = new CGRect(0, Metrics.Height-68, Metrics.Width, 68);
			});


			image.TouchDown += (sender, e) => {
				player.Stop();
				UIView.Animate(0.6, () => {
					Frame = new CGRect(0, Metrics.Height, Metrics.Width, 68);
				},()=>{
					RemoveFromSuperview();
				});
			};

			left.Add(control);
			Add(left);
		}
	}
}

