using Domain.Enums;

namespace Business.Constants
{
    public static class ImageFileType
    {
        public const string BlogFolder = "BlogImages";
        public const string PortfolioFolder = "PortfolioImages";
        public const string ProfileFolder = "ProfileImages";
        public const string CvFolder = "CvFiles";

        public static string GetTypeFromInteger(int value)
        {
            if (Enum.IsDefined(typeof(SendingImageOwnerType), value))
            {
                return Enum.GetName(typeof(SendingImageOwnerType), value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid integer value for image type.");
            }
        }
    }
}
