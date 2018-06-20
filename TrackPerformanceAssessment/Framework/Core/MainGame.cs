using System;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using TPA.Framework.Core.Manager;
using TPA.Framework.Core.Scene;

namespace TPA.Framework.Core
{
    public class MainGame : Singleton<MainGame>
    {
        public MainForm form { get; private set; } = null;
        public Device device { get; private set; } = null;
        public Texture texture { get; private set; } = null;
        public PresentParameters presentParameters { get; private set; } = null;

        // On Device reset
        public event Action onReset = () => { };

        public bool Init(MainForm form)
        {
            this.form = form;

            presentParameters = new PresentParameters();
            presentParameters.SwapEffect = SwapEffect.Discard;
            presentParameters.EnableAutoDepthStencil = true;
            presentParameters.AutoDepthStencilFormat = DepthFormat.D16;

            bool ret = InitGraphics();

            // Resize Event
            form.Resize += new EventHandler((object sender, EventArgs e) =>
            {
                InitGraphics();
                onReset();
            });

            // Key Event
            form.KeyDown += InputManager.Get.onKeyDown;
            form.KeyUp += InputManager.Get.onKeyUp;

            // Mouse Event
            form.MouseDown += InputManager.Get.onMouseDown;
            form.MouseUp += InputManager.Get.onMouseUp;
            form.MouseMove += InputManager.Get.onMouseMove;
            form.MouseWheel += InputManager.Get.onMouseWheel;

            return ret;
        }

        private bool InitGraphics()
        {
            try
            {
                presentParameters.Windowed = true;
                presentParameters.FullScreenRefreshRateInHz = 0;
                presentParameters.PresentationInterval = PresentInterval.Default;
                CreateDevice();
                //SetLight(true);
            }
            catch (DirectXException ex)
            {
                MessageBox.Show(ex.ToString(), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CreateDevice()
        {
            presentParameters.BackBufferHeight = 0;
            presentParameters.BackBufferWidth = 0;

            presentParameters.DeviceWindow = form;
            presentParameters.DeviceWindowHandle = form.Handle;

            presentParameters.BackBufferFormat = Format.Unknown;
            presentParameters.BackBufferCount = 0;

            presentParameters.MultiSample = MultiSampleType.None;
            presentParameters.MultiSampleQuality = 0;

            presentParameters.ForceNoMultiThreadedFlag = false;
            presentParameters.PresentFlag = PresentFlag.None;

            try
            {
                device = new Device(0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, presentParameters);
            }
            catch (DirectXException)
            {
                device = new Device(0, DeviceType.Reference, form.Handle, CreateFlags.HardwareVertexProcessing, presentParameters);
            }
        }

        public void Update()
        {
            SceneManager.Get?.Update();
        }

        public void Render()
        {
            if (device == null) return;
            if (!device.CheckCooperativeLevel()) return;

            device.Clear(ClearFlags.Target, Color.PowderBlue, 1.0f, 0);
            device.BeginScene();
            {
                SceneManager.Get?.Render();
            }
            device.EndScene();
            device.Present();
        }

        public override void Dispose()
        {
            SceneManager.Get?.Dispose();
            InputManager.Get?.Dispose();
            base.Dispose();

            device?.Dispose();
            texture?.Dispose();
        }
    }
}
