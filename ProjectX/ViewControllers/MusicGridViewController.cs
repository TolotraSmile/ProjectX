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

namespace ProjectX
{
	public class MusicGridViewController : UIViewController
	{
		public MusicGridViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			const int padding = 4;
			var size = (Metrics.Width - padding * 3) / 2;

			var flowLayout = new UICollectionViewFlowLayout {
				MinimumLineSpacing = padding,
				MinimumInteritemSpacing = padding,
				ScrollDirection = UICollectionViewScrollDirection.Vertical,
				SectionInset = new UIEdgeInsets(padding, padding, padding, padding), 
				ItemSize = new CGSize(size, size)
			};

			DesignElement.SetNavigationColor(NavigationController);

			var collectionFrame = new CGRect(0, 0, Metrics.Width, Metrics.Height - 64);
			var collection = new UICollectionView(collectionFrame, flowLayout) {
				
			};
			collection.RegisterClassForCell(typeof(MusicGridItemViewModel), MusicGridItemViewModel.UserGridCellId);
			collection.BackgroundColor = UIColor.Black;
			collection.ShowsHorizontalScrollIndicator = false;
			collection.ShowsVerticalScrollIndicator = false;
			collection.Source = new MusicGridSource();
			Add(collection);

			//NavigationController.View.AddSubview(new MusicPlayerViewModel(NavigationController));

		}

		public class MusicGridSource : UICollectionViewSource
		{

			public MusicGridSource()
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
				var cell = collectionView.DequeueReusableCell(MusicGridItemViewModel.UserGridCellId, indexPath);
				MusicGridItemViewModel animalCell;
				animalCell = cell == null ? new MusicGridItemViewModel(CGRect.Empty) : (MusicGridItemViewModel)cell;
				animalCell.SetTitle("Album Title");
				animalCell.SetSubTitle("Artist, Composer");
				animalCell.Layer.MasksToBounds = true;
				return animalCell;
			}
		}

		public class MusicGridItemViewModel : UICollectionViewCell
		{
			public static NSString UserGridCellId = new NSString("UserGridCellId");

			public UIImageView ImageView { get; set; }

			UILabel title;

			UILabel subtitle;

			[Export("initWithFrame:")]
			public MusicGridItemViewModel(CGRect frame) : base(frame)
			{
				var imageBounds = new CGRect(0, 0, ContentView.Frame.Width, ContentView.Frame.Height);
				ImageView = new UIImageView(imageBounds);
				ImageView.Image = UIImage.FromFile("profil.jpeg");
				ImageView.Center = ContentView.Center;
				ContentView.AddSubview(ImageView);

				var bottom = new UIView(new CGRect(0, ContentView.Frame.Height - 68, ContentView.Frame.Width, 68));
				ContentView.AddSubview(bottom);
				var blurView = new UIVisualEffectView(UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark)) {
					Frame = new CGRect(0, 0, bottom.Frame.Width, bottom.Frame.Height),
					Alpha = 0.4f
				};

				bottom.AddSubview(blurView);

				title = new UILabel(new CGRect(16, 16, ContentView.Frame.Width - 32, 20));
				title.Font = Font.Normal(18);
				title.TextColor = UIColor.White;
				bottom.AddSubview(title);

				subtitle = new UILabel(new CGRect(16, 38, ContentView.Frame.Width - 32, 20));
				subtitle.Font = Font.Light(14);
				subtitle.TextColor = UIColor.White;
				bottom.AddSubview(subtitle);
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

