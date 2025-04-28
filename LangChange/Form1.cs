using System.Media;
using System.Runtime.InteropServices;

namespace LangChange
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint threadId);

        private string currentLanguage = string.Empty;

        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();

            //// ตั้งค่า Form
            //this.TopMost = true; // Always on top
            this.BackColor = Color.Black; // สีพื้นหลัง
            this.TransparencyKey = Color.Black; // ทำให้โปร่งใส

            //this.Size = new Size(100, 100); // ขนาดหน้าต่างเล็ก ๆ
            ////this.StartPosition = FormStartPosition.Manual;
            ////this.Location = new Point( Screen.PrimaryScreen.WorkingArea.Width - 145, Screen.PrimaryScreen.WorkingArea.Height - 110 ); // ตำแหน่งมุมขวาบน
            ///
            //this.Visible = false;

            InitializeNotifyIcon();
            Stream stream = new MemoryStream(Properties.Resources.noti);
            soundPlayer = new SoundPlayer(stream);

            // Timer เพื่อตรวจจับการเปลี่ยนภาษา
            timer.Tick += OnTimerTick;
            timer.Start();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Visible = false;
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            uint threadId = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);
            IntPtr keyboardLayout = GetKeyboardLayout(threadId);
            string newLanguage = keyboardLayout.ToString();

            if (newLanguage != currentLanguage)
            {
                currentLanguage = newLanguage;
                //UpdateLanguageIcon();
                OnInputLanguageChanged();
            }
        }

        private void OnInputLanguageChanged()
        {
            var currentLanguage = InputLanguage.CurrentInputLanguage;

            Lang.Text = currentLanguage.Culture.TwoLetterISOLanguageName;
            PlaySound();
        }


        private void InitializeNotifyIcon()
        {
            // สร้าง NotifyIcon
            notifyIcon.Text = "Lang Change"; // ข้อความที่โชว์เมื่อเมาส์ชี้
            notifyIcon.Visible = true;

            // สร้าง ContextMenuStrip สำหรับ NotifyIcon
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            //contextMenu.Items.Add("เปิดโปรแกรม", null, OpenApp);
            contextMenu.Items.Add("Exit Program", null, ExitApp);
            notifyIcon.ContextMenuStrip = contextMenu;

            // เพิ่มการคลิกสองครั้ง
            //notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }
        private void OpenApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void ExitApp(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void PlaySound()
        {
            // เล่นเสียงเรียบง่าย
            //SystemSounds.Beep.Play(); // หรือใช้ Console.Beep(800, 300);
            try
            {
                soundPlayer.Play(); // เล่นเสียงแบบไม่ต้องรอให้เล่นจบ
            }
            catch {}
        }

        //private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        //{
        //    this.Show();
        //    this.WindowState = FormWindowState.Normal;
        //}

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        this.Hide();
        //    }
        //}

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);
        //    notifyIcon.Dispose();
        //}

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    // ย่อหน้าต่างไปที่ System Tray แทนการปิด
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        e.Cancel = true;
        //        this.Hide();
        //    }
        //}
    }
}
