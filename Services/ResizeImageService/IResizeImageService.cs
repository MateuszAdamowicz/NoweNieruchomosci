using System.Drawing;

namespace Services.ResizeImageService
{
    public interface IResizeImageService
    {
        Image ResizeImage(Image image, int maxWidth, int maxHeight);
    }
}