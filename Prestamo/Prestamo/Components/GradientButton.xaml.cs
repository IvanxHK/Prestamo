using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prestamo.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradientButton : ContentView
    {
        public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create(nameof(ButtonText), typeof(string), typeof(GradientButton), string.Empty, propertyChanged: OnButtonTextChanged);

        private static void OnButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GradientButton gradientButton = (GradientButton)bindable;
            gradientButton.textLabel.Text = (string)newValue;
        }

        public static readonly BindableProperty GlyphProperty =
            BindableProperty.Create(nameof(Glyph), typeof(string), typeof(GradientButton), string.Empty, propertyChanged: GlyphChanged);

        private static void GlyphChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GradientButton gradientButton = (GradientButton)bindable;
            string Glyph = (string)newValue;
            gradientButton.image.Source = new FontImageSource()
            {
                Glyph = Glyph,
                Color = gradientButton.Color,
                FontFamily = gradientButton.FontFamily
            };
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(GradientButton), "Icons", propertyChanged: FontFamilyChanged);

        private static void FontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GradientButton gradientButton = (GradientButton)bindable;
            string fontFamily = (string)newValue;
            gradientButton.image.Source = new FontImageSource()
            {
                Glyph = gradientButton.Glyph,
                Color = gradientButton.Color,
                FontFamily = fontFamily
            };
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
                              nameof(Color),        // the name of the bindable property
                              typeof(Color),
                              typeof(GradientButton),   // the parent object type
                              Color.Black,
                              propertyChanged: OnColorPropertyChanged);      // the default valu

        private static void OnColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Color color = (Color)newValue;
            GradientButton gradientButton = (GradientButton)bindable;

            var linearGradientBrush = new LinearGradientBrush
            {
                EndPoint = new Point(1, 0),
                StartPoint = new Point(0, 0),
            };

            linearGradientBrush.GradientStops.Add(new GradientStop
            {
                Color = color,
                Offset = 0.5f,
            });

            linearGradientBrush.GradientStops.Add(new GradientStop
            {
                Color = Color.FromRgba(10, color.R, color.G, color.B),
                Offset = 0.99f,
            });
            gradientButton.stack.Background = linearGradientBrush;

            gradientButton.image.Source = new FontImageSource()
            {
                Glyph = gradientButton.Glyph,
                Color = color,
                FontFamily = gradientButton.FontFamily
            };
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public string ButtonText
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        public string Glyph
        {
            get => (string)GetValue(GlyphProperty);
            set => SetValue(GlyphProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public GradientButton()
        {
            InitializeComponent();
        }

    }
}