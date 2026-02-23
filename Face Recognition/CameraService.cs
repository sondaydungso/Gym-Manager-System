using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GymManagerSystem.FaceRecognition
{
    public class CameraService : IDisposable
    {
        private VideoCapture _capture;
        private bool _isRunning;

        public void Start()
        {
            _capture = new VideoCapture(0);

            if (!_capture.IsOpened)
                throw new Exception("Could not open camera. Make sure a webcam is connected.");

            _isRunning = true;
        }

        public Bitmap GetFrame()
        {
            if (!_isRunning || _capture == null)
                return null;

            Mat frame = new Mat();
            _capture.Read(frame);

            if (frame.IsEmpty)
                return null;

            // Convert BGR (OpenCV default) to RGB for WinForms
            Mat rgbFrame = new Mat();
            CvInvoke.CvtColor(frame, rgbFrame, ColorConversion.Bgr2Rgb);

            Bitmap bitmap = new Bitmap(rgbFrame.Width, rgbFrame.Height, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            byte[] data = new byte[rgbFrame.Width * rgbFrame.Height * 3];
            Marshal.Copy(rgbFrame.DataPointer, data, 0, data.Length);
            Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);

            bitmap.UnlockBits(bitmapData);

            frame.Dispose();
            rgbFrame.Dispose();

            return bitmap;
        }

        public void Stop()
        {
            _isRunning = false;
            _capture?.Release();
        }

        public void Dispose()
        {
            Stop();
            _capture?.Dispose();
        }
    }
}