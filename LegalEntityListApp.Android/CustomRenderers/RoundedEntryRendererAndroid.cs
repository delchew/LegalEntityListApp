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
                gradientDrawable.SetShape(ShapeType.Rectangle);
                //Have to just hardcode this color property, because in Android we get the rectangle over the rounded oval of borders
                gradientDrawable.SetColor(Color.FromHex("#EBEDF1").ToAndroid());
                gradientDrawable.SetCornerRadius(roundedEntry.CornerRadius);
                gradientDrawable.SetStroke((int)roundedEntry.BorderWidth, roundedEntry.BorderColor.ToAndroid());
                Control.SetBackground(gradientDrawable);
            }
        }
    }
}
