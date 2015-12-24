using UIKit;

namespace ProjectX.SlideoutNavigation
{
	public class MainNavigationController : UINavigationController
	{
		static public SlideoutNavigationController _slideoutNavigationController;

		/// <summary>
		/// Initializes a new instance of the <see cref="MonoTouch.SlideoutNavigation.MenuNavigationController"/> class.
		/// </summary>
		/// <param name="rootViewController">Root view controller.</param>
		/// <param name="slideoutNavigationController">Slideout navigation controller.</param>
		public MainNavigationController(UIViewController rootViewController, SlideoutNavigationController slideoutNavigationController)
			: this(rootViewController, slideoutNavigationController, 
			       new UIBarButtonItem(UIImage.FromBundle("MonoTouch.SlideoutNavigation.bundle/three_lines"), UIBarButtonItemStyle.Plain, (s, e) => {
			}))
		{
		}

		public MainNavigationController(UIViewController rootViewController,
		                                SlideoutNavigationController slideoutNavigationController, 
		                                UIBarButtonItem rightMenuButton, bool animated)
			: this(rootViewController, slideoutNavigationController, 
			       new UIBarButtonItem(UIImage.FromBundle("MonoTouch.SlideoutNavigation.bundle/three_lines"), UIBarButtonItemStyle.Plain, (s, e) => {

			}), rightMenuButton)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MonoTouch.SlideoutNavigation.MainNavigationController"/> class.
		/// </summary>
		/// <param name="rootViewController">Root view controller.</param>
		/// <param name="slideoutNavigationController">Slideout navigation controller.</param>
		/// <param name="openMenuButton">Open menu button.</param>
		public MainNavigationController(UIViewController rootViewController, SlideoutNavigationController slideoutNavigationController, UIBarButtonItem openMenuButton)
			: base(rootViewController)
		{
			_slideoutNavigationController = slideoutNavigationController;
			openMenuButton.Clicked += (s, e) => _slideoutNavigationController.Open(true);
			rootViewController.NavigationItem.LeftBarButtonItem = openMenuButton;
		}

		public MainNavigationController(UIViewController rootViewController, SlideoutNavigationController slideoutNavigationController, UIBarButtonItem openMenuButton, UIBarButtonItem rightMenuButton)
			: base(rootViewController)
		{
			_slideoutNavigationController = slideoutNavigationController;
			openMenuButton.Clicked += (s, e) => _slideoutNavigationController.Open(true);
			rootViewController.NavigationItem.LeftBarButtonItem = openMenuButton;
			rootViewController.NavigationItem.RightBarButtonItem = rightMenuButton;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Delegate = new NavigationControllerDelegate();
			InteractivePopGestureRecognizer.Enabled = true;
		}

		/// <Docs>The view controller to push onto the navigation stack</Docs>
		/// <summary>
		/// Pushes a view controller onto the UINavigationController's navigation stack.
		/// </summary>
		/// <see cref="T:MonoTouch.UIKit.UITabBarController"></see>
		/// <param name="viewController">View controller.</param>
		/// <param name="animated">If set to <c>true</c> animated.</param>
		public override void PushViewController(UIViewController viewController, bool animated)
		{
			// To avoid corruption of the navigation stack during animations disabled the pop gesture
			if (InteractivePopGestureRecognizer != null)
				InteractivePopGestureRecognizer.Enabled = false;
			base.PushViewController(viewController, animated);
		}

		class NavigationControllerDelegate : UINavigationControllerDelegate
		{
			public override void DidShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
			{
				// Enable the gesture after the view has been shown
				navigationController.InteractivePopGestureRecognizer.Enabled = true;
			}
		}
	}
}

