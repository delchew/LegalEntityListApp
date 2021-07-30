﻿using LegalEntityListApp.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName("Effects")]
[assembly:ExportEffect(typeof(ClearEntryEffect), "ClearEntryEffect")]
namespace LegalEntityListApp.iOS.Effects
{
    public class ClearEntryEffect : PlatformEffect
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
            ((UITextField)Control).ClearButtonMode = UITextFieldViewMode.WhileEditing;
        }
    }
}
