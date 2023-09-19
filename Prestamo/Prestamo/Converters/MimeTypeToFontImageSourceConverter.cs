using Prestamo.Fonts;
using System;
using Xamarin.Forms;

namespace Prestamo.Converters
{
    public class MimeTypeToFontImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string mimeType)
            {
                string glyph = GetFontAwesomeGlyph(mimeType);

                return new FontImageSource
                {
                    Glyph = glyph,
                    FontFamily = "FASolid",
                    Color = Color.White
                };
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetFontAwesomeGlyph(string mimeType)
        {
            switch (mimeType)
            {
                case "application/pdf":
                    return FontAwesomeIcons.FilePdf;
                case "application/msword":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return FontAwesomeIcons.FileWord;
                case "application/vnd.ms-excel":
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    return FontAwesomeIcons.FileExcel;
                case "application/vnd.ms-powerpoint":
                case "application/vnd.openxmlformats-officedocument.presentationml.presentation":
                    return FontAwesomeIcons.FilePowerpoint;
                case "text/xml":
                case "text/plain":
                    return FontAwesomeIcons.FileCode;
                case "image/jpeg":
                case "image/png":
                case "image/gif":
                    return FontAwesomeIcons.FileImage;
                default:
                    return FontAwesomeIcons.File; // Default icon for unknown MIME types
            }
        }
    }
}
