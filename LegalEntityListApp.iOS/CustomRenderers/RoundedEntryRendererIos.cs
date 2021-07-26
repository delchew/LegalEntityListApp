using CoreGraphics;
using LegalEntityListApp.CustomControls;
using LegalEntityListApp.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererIos))]
namespace LegalEntityListApp.iOS.CustomRenderers
{
    public class RoundedEntryRendererIos : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var roundedEntry = (RoundedEntry)e.NewElement;
                Control.Layer.CornerRadius = roundedEntry.CornerRadius;
                Control.Layer.BorderWidth = roundedEntry.BorderWidth;
                Control.Layer.BorderColor = roundedEntry.BorderColor.ToCGColor();
                Control.Layer.BackgroundColor = roundedEntry.BackgroundColor.ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }
    }
}
