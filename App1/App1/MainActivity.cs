using System;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Color = Android.Graphics.Color;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private RelativeLayout _layout;


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


            _layout = FindViewById<RelativeLayout>(Resource.Id.mainRelativeLayout);

            var urlImage = "http://www.kinnhom.com/wp-content/uploads/2016/07/bg-pattern-3.jpg";
            //var urlImage = "https://www.krispygirl.com/wp-content/uploads/2016/08/bg-pot.png";

            var bitImage = await GetImageBitmapFromUrl(urlImage); 

            #region Show This size of image

            // Get resolution Size of Image
            var width = bitImage.Width;
            var height = bitImage.Height;

            var textViewParams = new RelativeLayout.LayoutParams(500, 200)
            {
                LeftMargin = 50,
                TopMargin = 100
            };

            var imageSiaeTextView = new TextView(_layout.Context)
            {
                Text = $" Width(x) {width}    Height(y) {height} "
            };
            imageSiaeTextView.SetTextColor(Color.Blue);
            _layout.AddView(imageSiaeTextView, textViewParams);


            #endregion


            var img = FindViewById<ImageView>(Resource.Id.imageView1);
            img.SetImageBitmap(bitImage);

            //Set Adjust View Bounds  for can modified position
            img.SetAdjustViewBounds(true);

            // Set Max size of Image
            img.SetMaxWidth(650);
            img.SetMaxHeight(400);

            //This is set padding left / top
            img.SetX(100);
            img.SetY(20);

            // Add event for pin coordinates 
            var pinEvent = new MyTouchListener(img, _layout);
            img.SetOnTouchListener(pinEvent);
        }


        public class MyTouchListener : Java.Lang.Object, View.IOnTouchListener
        {

            private readonly ImageView _imgView;
            private readonly RelativeLayout _layout;
            public MyTouchListener(ImageView imgView, RelativeLayout layout)
            {

                _imgView = imgView;
                _layout = layout;
            }

            public bool OnTouch(View v, MotionEvent ev)
            {
                if (ev.Action != MotionEventActions.Down)
                {
                    return false;
                }

                var inverse = new Matrix();
                _imgView.ImageMatrix.Invert(inverse);
                float[] pts = {
                    ev.GetX(), ev.GetY()
                };
                inverse.MapPoints(pts);

                const int pinSizeWidth = 400;
                const int pinSizeHeight = 250;

                var paddingXOfImage = v.GetX();
                var paddingYOfImage = v.GetY();

                var paramTextView = new RelativeLayout.LayoutParams(pinSizeWidth, pinSizeHeight)
                {
                    LeftMargin = Convert.ToInt32(paddingXOfImage + ev.GetX()),
                    TopMargin = Convert.ToInt32(paddingYOfImage + ev.GetY())
                };

                // //var lparams = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                var pinTextView = new TextView(_layout.Context)
                {
                    Text = $"x:{Math.Floor(pts[0])}    y:{Math.Floor(pts[1])}"
                };
                pinTextView.SetTextColor(Color.Red);
                _layout.AddView(pinTextView, paramTextView);

                return true;
            }
        }

        private static async Task<Bitmap> GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = await webClient.DownloadDataTaskAsync(url);
                //var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = await BitmapFactory.DecodeByteArrayAsync(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}

