using Android.Content;
using Android.Graphics.Drawables;
using LegalEntityListApp.CustomControls;
using LegalEntityListApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TransparentEntry), typeof(TransparentEntryRendererAndroid))]
namespace LegalEntityListApp.Droid.CustomRenderers
{
    public class TransparentEntryRendererAndroid : EntryRenderer
    {
        public TransparentEntryRendererAndroid(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Color.Transparent.ToAndroid());
                Control.SetBackground(gradientDrawable);
            }
        }
    }
}
