using LegalEntityListApp.CustomControls;
using LegalEntityListApp.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(TransparentEntryRendererIos))]
namespace LegalEntityListApp.iOS.CustomRenderers
{
    public class TransparentEntryRendererIos : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                Control.Layer.BackgroundColor = Color.Transparent.ToCGColor();
            }
        }
    }
}
