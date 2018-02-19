
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using static Android.Views.View;

namespace RotatedTextView
{
    public class MyDragShadowBuilder : DragShadowBuilder
    {
        private Drawable shadow;
        private int width, height;

        // Defines the constructor for myDragShadowBuilder
        public MyDragShadowBuilder(View v) : base(v)
        {
            // Creates a draggable image that will fill the Canvas provided by the system.
            shadow = new ColorDrawable(Android.Graphics.Color.LightGray);
        }

        // Defines a callback that sends the drag shadow dimensions and touch point back to the system.
        public override void OnProvideShadowMetrics(Android.Graphics.Point outShadowSize, Android.Graphics.Point outShadowTouchPoint)
        {
            double rotationRad = Java.Lang.Math.ToRadians(View.Rotation);
            int w = (int)(View.Width * View.ScaleX);
            int h = (int)(View.Height * View.ScaleY);
            double s = Java.Lang.Math.Abs(Java.Lang.Math.Sin(rotationRad));
            double c = Java.Lang.Math.Abs(Java.Lang.Math.Cos(rotationRad));


            //calculate the size of the canvas 
            //width = view's width*cos(rad)+height*sin(rad)
            width = (int)(w * c + h * s);
            //height = view's width*sin(rad)+height*cos(rad)
            height = (int)(w * s + h * c);
            
            outShadowSize.Set(width, height);

            // Sets the touch point's position to be in the middle of the drag shadow
            outShadowTouchPoint.Set(outShadowSize.X / 2, outShadowSize.Y / 2);
        }

        // Defines a callback that draws the drag shadow in a Canvas that the system constructs
        // from the dimensions passed in onProvideShadowMetrics().
        public override void OnDrawShadow(Canvas canvas)
        {
            
            canvas.Scale(View.ScaleX, View.ScaleY, width/2 , height/2);
            //canvas.DrawColor(Android.Graphics.Color.White);
            canvas.Rotate(View.Rotation,width/2, height / 2);
            canvas.Translate((width - View.Width)/2, (height - View.Height) / 2);
            base.OnDrawShadow(canvas);
        }

    }
}