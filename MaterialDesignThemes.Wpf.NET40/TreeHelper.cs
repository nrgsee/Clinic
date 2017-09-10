using System.Windows;
using System.Windows.Media;

namespace MaterialDesignThemes.Wpf
{
    internal static class TreeHelper
    {
        public static Visual FindMainTreeVisual(Visual visual)
        {
            DependencyObject root = null;
            DependencyObject dependencyObject = visual;

            while (dependencyObject != null)
            {
                root = dependencyObject;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            return root as Visual;
        }
    }
}
