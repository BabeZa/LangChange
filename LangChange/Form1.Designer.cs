namespace LangChange
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Lang = new Label();
            notifyIcon = new NotifyIcon(components);
            timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // Lang
            // 
            Lang.AutoSize = true;
            Lang.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            Lang.ForeColor = Color.SteelBlue;
            Lang.Location = new Point(0, 0);
            Lang.Name = "Lang";
            Lang.Size = new Size(69, 32);
            Lang.TabIndex = 0;
            Lang.Text = "Lang";
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "notifyIcon";
            notifyIcon.Visible = true;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 500;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(39, 37);
            ControlBox = false;
            Controls.Add(Lang);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lang;
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer;
    }
}
