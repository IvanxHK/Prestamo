using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Prestamo.Components
{
    public class BorderlessEntry : Entry
    {
        public BorderlessEntry()
        {
            this.Effects.Add(new RemoveBorderEffect());
        }
    }
}
