using Android.Graphics.Drawables;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using LegalEntityListApp.Droid.CustomRenderers;
using LegalEntityListApp.CustomControls;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererAndroid))]
namespace LegalEntityListApp.Droid.CustomRenderers
{
    public class RoundedEntryRendererAndroid : EntryRenderer
    {
        public RoundedEntryRendererAndroid(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                var roundedEntry = (RoundedEntry)e.NewElement;

                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(roundedEntry.CornerRadius);
                gradientDrawable.SetStroke((int)roundedEntry.BorderWidth, roundedEntry.BorderColor.ToAndroid());
                gradientDrawable.SetColor(roundedEntry.BackgroundColor.ToAndroid());
                Control.SetBackground(gradientDrawable);

            }
        }
    }
}
