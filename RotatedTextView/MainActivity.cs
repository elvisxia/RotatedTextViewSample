using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace RotatedTextView
{
    [Activity(Label = "RotatedTextView", MainLauncher = true)]
    public class MainActivity : Activity
    {
        RotatedTextView rtvTest;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            rtvTest = FindViewById<RotatedTextView>(Resource.Id.rtvTest);
            rtvTest.LongClick += RtvTest_LongClick;
        }

        private void RtvTest_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            MyDragShadowBuilder myShadow = new MyDragShadowBuilder(rtvTest);
            (sender as View).StartDrag(null, myShadow, null, 0);
        }
    }
}

