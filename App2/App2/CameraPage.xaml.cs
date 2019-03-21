using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
		public CameraPage ()
		{
			InitializeComponent ();
            CameraPreview.PictureFinished += OnPictureFinished;
        }
        void OnCameraClicked(object sender, EventArgs e)
        {
            CameraPreview.CameraClick.Execute(null);
        }

        private void OnPictureFinished()
        {
            ByteArrayToImage byteArrayToImage = new ByteArrayToImage();
            PhotoCaptured.Source = (ImageSource)byteArrayToImage.Convert(CameraPreview.Image, typeof(ImageSource), null,null);

           CameraPreview.Image = null;
        }
	}
}