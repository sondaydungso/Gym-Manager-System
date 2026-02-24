using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Gym_Manager_System.Face_Recognition;

namespace Gym_Manager_System.Forms
{
    public partial class FaceCaptureForm : Form
    {
        private CameraService? _camera;
        private readonly System.Windows.Forms.Timer _previewTimer;

        /// <summary>Set after user clicks Take Photo; null if cancelled.</summary>
        public MemoryStream? CapturedImageStream { get; private set; }

        public FaceCaptureForm()
        {
            InitializeComponent();
            _previewTimer = new System.Windows.Forms.Timer { Interval = 33 }; // ~30 fps
            _previewTimer.Tick += PreviewTimer_Tick;
        }

        private void FaceCaptureForm_Load(object sender, EventArgs e)
        {
            try
            {
                _camera = new CameraService();
                _camera.Start();
                _previewTimer.Start();
            }
            catch (Exception ex)
            {
                var message = "Could not start camera. This is often due to missing Emgu.CV native runtimes.\r\n\r\n" +
                    "You can upload a face photo from a file instead.";
                MessageBox.Show(message, "Camera unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
                    dlg.Title = "Select face photo";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var bytes = File.ReadAllBytes(dlg.FileName);
                            CapturedImageStream = new MemoryStream(bytes);
                            CapturedImageStream.Position = 0;
                            DialogResult = DialogResult.OK;
                        }
                        catch (Exception readEx)
                        {
                            MessageBox.Show($"Could not read file: {readEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                        DialogResult = DialogResult.Cancel;
                }
                Close();
            }
        }

        private void PreviewTimer_Tick(object? sender, EventArgs e)
        {
            if (_camera == null) return;
            var frame = _camera.GetFrame();
            if (frame != null && previewPictureBox.IsDisposed == false)
            {
                var old = previewPictureBox.Image;
                previewPictureBox.Image = frame;
                old?.Dispose();
            }
        }

        private void TakePhotoButton_Click(object sender, EventArgs e)
        {
            if (_camera == null) return;
            var frame = _camera.GetFrame();
            if (frame == null)
            {
                MessageBox.Show("Could not capture frame.", "Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _previewTimer.Stop();
            _camera.Stop();
            _camera.Dispose();
            _camera = null;

            // Convert to JPEG stream for Azure
            var ms = new MemoryStream();
            frame.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            CapturedImageStream = ms;
            frame.Dispose();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void FaceCaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _previewTimer.Stop();
            _camera?.Stop();
            _camera?.Dispose();
            _camera = null;
        }
    }
}
