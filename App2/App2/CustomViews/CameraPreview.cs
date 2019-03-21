using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App2.CustomViews
{
    public enum CameraOptions
    {
        Rear,
        Front
    }

    public class CameraPreview : View, INotifyPropertyChanged
    {
        private byte[] _image;

        public byte[] Image
        {
            get { return _image;  }
            set { _image = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>         
        /// /// Raises the property changed event.         
        /// /// </summary>         
        /// /// <param name="propertyName">Property name.</param>         
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Command cameraClick;

        public static readonly BindableProperty CameraProperty = BindableProperty.Create(
            propertyName: "Camera",
            returnType: typeof(CameraOptions),
            declaringType: typeof(CameraPreview),
            defaultValue: CameraOptions.Front);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }

        public Command CameraClick
        {
            get { return cameraClick; }
            set { cameraClick = value; }
        }

        public void PictureTaken(byte[] imageByte)
        {
            Image = imageByte;
            PictureFinished?.Invoke();
        }

        public event Action PictureFinished;
    }
}
