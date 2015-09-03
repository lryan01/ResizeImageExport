// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ResizeImage
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView BaseView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView PhotoPreview { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ResizePhotoButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SelectPhotoButton { get; set; }

		[Action ("ResizePhotoButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ResizePhotoButton_TouchUpInside (UIButton sender);

		[Action ("SelectPhotoButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SelectPhotoButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (BaseView != null) {
				BaseView.Dispose ();
				BaseView = null;
			}
			if (PhotoPreview != null) {
				PhotoPreview.Dispose ();
				PhotoPreview = null;
			}
			if (ResizePhotoButton != null) {
				ResizePhotoButton.Dispose ();
				ResizePhotoButton = null;
			}
			if (SelectPhotoButton != null) {
				SelectPhotoButton.Dispose ();
				SelectPhotoButton = null;
			}
		}
	}
}
