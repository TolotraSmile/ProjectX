//
// ImageFilter.cs
//
// Author:
//       TMS Consulting <tolotra.raharison@gmail.com>
//
// Copyright (c) 2015 TMS Consulting
using UIKit;
using CoreImage;

namespace ProjectX
{
	public static class ImageFilter
	{
		public static UIImage Sepia(UIImage image)
		{
			if (image != null) {
				using (var ciimage = new CIImage(image)) {
					var hueAdjust = new CIHueAdjust();   // first filter
					hueAdjust.Image = ciimage;
					hueAdjust.Angle = 2.094f;
					var sepia = new CISepiaTone();
					sepia.Image = hueAdjust.OutputImage;
					sepia.Intensity = 0.3f;
					var color = new CIColorControls {
						// third filter
						Saturation = 2,
						Brightness = 1,
						Contrast = 3,
						Image = sepia.OutputImage
						// output from last filter, input to this one
					};
					// second filter
					// output from last filter, input to this one
					var output = color.OutputImage;
					var context = CIContext.FromOptions(null);
					// ONLY when CreateCGImage is called do all the effects get rendered
					return UIImage.FromImage(context.CreateCGImage(output, output.Extent));
				} 
			}
			return null;
		}
	}
}

