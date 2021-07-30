using Android.Views;
using Android.Widget;
using LegalEntityListApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName("Effects")]
[assembly:ExportEffect(typeof(ClearedEntryEffect), "ClearEntryEffect")]
namespace LegalEntityListApp.Droid.Effects
{
    public class ClearedEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            var editText = (EditText)Control;
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.clear_button, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());
        }
    }

    internal class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (v is EditText editText && e.Action == MotionEventActions.Up)
            {
                if(e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    editText.Text = string.Empty;
                    return true;
                }
            }
            return false;
        }
    }
}
