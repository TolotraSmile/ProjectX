
//
// TinderView.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using UIKit;
using CoreGraphics;
using System;

namespace ProjectX
{
	public sealed class TinderView : UIView
	{
		UIPanGestureRecognizer panGesture;
		UIRotationGestureRecognizer rotateGesture;

		nfloat xFromCenter;
		nfloat yFromCenter;


		int ACTION_MARGIN = 120;
		//%%% distance from center where the action applies. Higher = swipe further in order for the action to be called
		int SCALE_STRENGTH = 4;
		//%%% how quickly the card shrinks. Higher = slower shrinking
		nfloat SCALE_MAX = 0.93f;
		//%%% upper bar for how much the card shrinks. Higher = shrinks less
		int ROTATION_MAX = 1;
		//%%% the maximum rotation allowed in radians.  Higher = card can keep rotating longer
		int ROTATION_STRENGTH = 320;
		//%%% strength of rotation. Higher = weaker rotation
		double ROTATION_ANGLE = Math.PI / 8;
		//%%% Higher = stronger rotation angle

		CGPoint originalPoint = CGPoint.Empty;

		public TinderView(CGRect frame)
			: base(frame)
		{


			Layer.CornerRadius = 10;

			if (panGesture == null) {
				panGesture = new UIPanGestureRecognizer(() => {

					xFromCenter = panGesture.TranslationInView(this).X; //%%% positive for right swipe, negative for left
					yFromCenter = panGesture.TranslationInView(this).X; //%%% positive for up, negative for down
					if ((panGesture.State == UIGestureRecognizerState.Changed) && (panGesture.NumberOfTouches == 1)) {

						var rotationStrength = Math.Min(xFromCenter / ROTATION_STRENGTH, ROTATION_MAX);

						//%%% degree change in radians
						var rotationAngel = (nfloat)(ROTATION_ANGLE * rotationStrength);

						//%%% amount the height changes when you move the card up to a certain point
						var scale = Math.Max(1 - Math.Abs(rotationStrength) / SCALE_STRENGTH, SCALE_MAX);

						//%%% move the object's center by center + gesture coordinate
						Center = new CGPoint(originalPoint.X + xFromCenter, originalPoint.Y + yFromCenter);

						//%%% rotate by certain amount
						CGAffineTransform transform = CGAffineTransform.MakeRotation(rotationAngel);

						//%%% scale by certain amount
						CGAffineTransform scaleTransform = CGAffineTransform.Scale(transform, (nfloat)scale, (nfloat)scale);

						//%%% apply transformations
						Transform = scaleTransform;
						//[self updateOverlay:xFromCenter];

						return;
					}
					if (panGesture.State == UIGestureRecognizerState.Began) {
						originalPoint = Center;
					}
					if (panGesture.State == UIGestureRecognizerState.Ended) {
						AfterSwipe();
					}
					System.Diagnostics.Debug.WriteLine(panGesture.State);
				});
				AddGestureRecognizer(panGesture);
			}


			BackgroundColor = UIColor.White;
		}

		void AfterSwipe()
		{
			if (xFromCenter > ACTION_MARGIN) {
				RightAction();
			} else if (xFromCenter < -ACTION_MARGIN) {
				LeftAction();
			} else { //%%% resets the card
				UIView.Animate(0.3, () => {
					Center = originalPoint;
					Transform = CGAffineTransform.MakeRotation(0);
					//overlayView.alpha = 0;
				});
			}
		}

		//

		void RightAction()
		{
			var finishPoint = new CGPoint(500, 2 * yFromCenter + originalPoint.Y);

			UIView.Animate(0.3, () => {
				Center = finishPoint;
				Transform = CGAffineTransform.MakeRotation(0);
				//overlayView.alpha = 0;
			});
//			[UIView animateWithDuration:0.3
//				animations:^{
//					self.center = finishPoint;
//				}completion:^(BOOL complete){
//					[self removeFromSuperview];
//				}];
		}

		void LeftAction()
		{
			
			var finishPoint = new CGPoint(-500, 2 * yFromCenter + originalPoint.Y);

			UIView.Animate(0.3, () => {
				Center = finishPoint;
				Transform = CGAffineTransform.MakeRotation(0);
				//overlayView.alpha = 0;
			});

			//NSLog(@"NO");
		}
	}
}

