using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Services.ResizeImageService.Implementation
{
    [ExcludeFromCodeCoverage]
    public class ResizeImageService : IResizeImageService
    {
        public Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            using (image)
            {
                var ratioX = (double)maxWidth / image.Width;
                var ratioY = (double)maxHeight / image.Height;

                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                var newImage = new Bitmap(newWidth, newHeight);

                Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
                return newImage;

            }
        }
    }
}