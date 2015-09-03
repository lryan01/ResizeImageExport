using System;

using UIKit;
using Foundation;
using System.IO;
using CoreGraphics;


namespace ResizeImage
{
	public partial class ViewController : UIViewController
	{
		UIImagePickerController imagePicker;
		UIImage originalImage;
		UIImage profileImage;
		UIImage eventImage;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			PhotoPreview.Image = UIImage.FromFile ("default.jpg");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void SelectPhotoButton_TouchUpInside (UIButton sender)
		{
			//Create image picker 
			imagePicker = new UIImagePickerController ();
			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.PhotoLibrary);
			imagePicker.FinishedPickingMedia += HandlePickedMedia;
			imagePicker.Canceled += ImagePickerCanceled;

			NavigationController.PresentModalViewController (imagePicker, true);
		}

		void HandlePickedMedia (object sender, UIImagePickerMediaPickedEventArgs args)
		{

			NSUrl referenceURL = args.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine("Url:"+referenceURL.ToString ());

			originalImage = args.Info[UIImagePickerController.OriginalImage] as UIImage;
			if (originalImage != null) {
				// View the original image on the screen
				Console.WriteLine ("got the original image");
				PhotoPreview.Image = originalImage;
			}
			imagePicker.DismissModalViewController (true);
		}

		void ImagePickerCanceled (object sender, EventArgs e)
		{
			// Dismiss image picker
			imagePicker.DismissModalViewController (true);
		}

		partial void ResizePhotoButton_TouchUpInside(UIButton sender)
		{
			//Scale to largest needed Profile pic size
			profileImage = originalImage.Scale (new CGSize (300, 300));

			//Scale to largest needed Event pic size
			eventImage = originalImage.Scale (new CGSize (960, 708));

			//Merge the two photos into one in order to view both sizes on the screen
			UIGraphics.BeginImageContext(new CGSize(960, 1008));
			profileImage.Draw( new CGRect(0, 0, 300, 300));
			eventImage.Draw( new CGRect ( 0, 300, 960, 708));

			var combinedImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			PhotoPreview.Image = combinedImage;

			//Save photos, adapted from another project. Will save each size indiviually
			var documentsDirectory = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var profileFileName = System.IO.Path.Combine (documentsDirectory, "profile.jpg");
			var eventFileName = System.IO.Path.Combine (documentsDirectory, "event.jpg");

			NSError error = null;
			if (profileImage.AsJPEG().Save (profileFileName, false, out error)) {
				Console.WriteLine ("File written to : {0}", profileFileName);
			} 
			if(eventImage.AsJPEG().Save (eventFileName, false, out error)) {
				Console.WriteLine ("File written to : {0}", eventFileName);
			}
		}
	}
}

