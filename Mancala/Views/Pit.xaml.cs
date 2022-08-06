using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mancala.Views
{
    public partial class Pit : Button
    {
        public SolidColorBrush Stroke
        {
            get => (SolidColorBrush)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(nameof(Stroke), typeof(SolidColorBrush), typeof(Pit), new PropertyMetadata(Brushes.Black));

        public int Seed
        {
            get => (int)GetValue(SeedProperty);
            set => SetValue(SeedProperty, value);
        }

        public static readonly DependencyProperty SeedProperty = DependencyProperty.Register(nameof(Seed), typeof(int), typeof(Pit), new PropertyMetadata(0));

        public Pit()
        {
            InitializeComponent();
        }
    }
}
