//

// ShopGridViewController.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using System.Runtime.Remoting.Contexts;

namespace ProjectX
{
	public class UserGridViewController : UIViewController
	{
		public UserGridViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			int padding = Metrics.Padding;
			var width = (Metrics.Width - padding * 4) / 3;
			var height = width + 40;

			var flowLayout = new UICollectionViewFlowLayout {
				MinimumLineSpacing = padding,
				MinimumInteritemSpacing = padding,
				ScrollDirection = UICollectionViewScrollDirection.Vertical,
				SectionInset = new UIEdgeInsets(padding, padding, padding, padding), 
				ItemSize = new CGSize(width, height)
			};

			DesignElement.NormalizeNavigation(NavigationController);

			var collectionFrame = new CGRect(0, 0, Metrics.Width, Metrics.Height - 64);
			var collection = new UICollectionView(collectionFrame, flowLayout);
			collection.RegisterClassForCell(typeof(UserGridItemViewModel), UserGridItemViewModel.UserGridCellId);
			collection.BackgroundColor = UIColor.White;
			collection.ShowsHorizontalScrollIndicator = false;
			collection.ShowsVerticalScrollIndicator = false;
			collection.Source = new UserGridSource();
			Add(collection);
			View.BackgroundColor = UIColor.White;

			//NavigationController.View.AddSubview(new MusicPlayerViewModel(NavigationController));

		}

		public class UserGridSource : UICollectionViewSource
		{

			public UserGridSource()
			{
			}

			public override nint NumberOfSections(UICollectionView collectionView)
			{
				return 1;
			}


			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return 10;
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				var cell = collectionView.DequeueReusableCell(UserGridItemViewModel.UserGridCellId, indexPath);
				UserGridItemViewModel animalCell;
				animalCell = cell == null ? new UserGridItemViewModel(CGRect.Empty) : (UserGridItemViewModel)cell;
				animalCell.SetTitle("Tolotra");
				animalCell.SetSubTitle("Artist, Composer");
				animalCell.Layer.MasksToBounds = true;
				return animalCell;
			}
		}

		public class UserGridItemViewModel : UICollectionViewCell
		{
			public static NSString UserGridCellId = new NSString("UserGridCellId");

			public UIImageView ImageView { get; set; }

			UILabel title;

			UILabel subtitle;

			[Export("initWithFrame:")]
			public UserGridItemViewModel(CGRect frame)
				: base(frame)
			{
				var imageBounds = new CGRect(0, 0, ContentView.Frame.Width - 10, ContentView.Frame.Width - 10);
				ImageView = new UIImageView(imageBounds);
				ImageView.Image = UIImage.FromFile("profil.jpeg");
				ImageView.Layer.CornerRadius = imageBounds.Height / 2;
				ImageView.ClipsToBounds = true;

				ContentView.AddSubview(ImageView);

				var badge = new UIView(new CGRect(0, 0, 16, 16));
				badge.Center = Equations.PointOnCircle(ImageView.Layer.CornerRadius, 315, ImageView.Center);
				badge.Layer.CornerRadius = badge.Frame.Height / 2;
				badge.BackgroundColor = Color.Primary;
				badge.Layer.MasksToBounds = true;
				//ContentView.AddSubview(badge);
				ContentView.BackgroundColor = UIColor.Clear;

				title = new UILabel(new CGRect(0, ContentView.Frame.Width, ContentView.Frame.Width, 20));
				title.Font = Font.Title(20);
				title.TextColor = Color.Primary;
				title.TextAlignment = UITextAlignment.Center;
				ContentView.AddSubview(title);

				subtitle = new UILabel(new CGRect(0, ContentView.Frame.Height - 18, ContentView.Frame.Width, 18));
				subtitle.Font = Font.Title(12);
				subtitle.TextColor = UIColor.Gray;
				subtitle.TextAlignment = UITextAlignment.Center;
				ContentView.AddSubview(subtitle);
			}

			public void SetTitle(string text)
			{
				if (title != null) {
					title.Text = text;
				}
			}

			public void SetSubTitle(string text)
			{
				if (subtitle != null) {
					subtitle.Text = text;
				}
			}
		}
	}
}

