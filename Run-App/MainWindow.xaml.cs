using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Interop;

namespace Run_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            string filePath = this.txtFilePath.Text;
            string appPath = this.txtAppPath.Text;

            List<string> args = new()
            {
                "/A",
                "navpanes=1",
                filePath
            };

            Process p = Process.Start(appPath, args);
            p.EnableRaisingEvents = true;
            p.Exited += P_Exited;
        }

        private void P_Exited(object? sender, EventArgs e)
        {
            MessageBox.Show("app exited");
        }

        private void BtnDetect_Click(object sender, RoutedEventArgs e)
        {
            txtAppPath.Text = Path.Combine( DetectApps.DetectAppInstalledPath(), "Acrobat.exe");
        }
    }
}
