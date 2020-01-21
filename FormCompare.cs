using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparePPTX
{
    public partial class FormCompare : Form
    {
        private ComparisonWork currentWork { get; set; }

        public FormCompare()
        {
            InitializeComponent();
        }

        private void buttonBrowseNewFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textNewFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonBrowseOldFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textOldFile.Text = openFileDialog.FileName;
            }
        }
        private void buttonBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textOutputFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            if (backgroundComparator.IsBusy)
            {
                MessageBox.Show("아직 이전 작업이 끝나지 않았습니다!");
                return;
            }

            var newWork = new ComparisonWork
            {
                NewFile = textNewFile.Text,
                OldFile = textOldFile.Text,
                OutputPath = textOutputFolder.Text
            };
            if (!File.Exists(newWork.NewFile))
            {
                MessageBox.Show("새 파일을 선택해주세요.");
                textNewFile.Focus();
                return;
            }
            if (!File.Exists(newWork.OldFile))
            {
                MessageBox.Show("새 파일을 선택해주세요.");
                textOldFile.Focus();
                return;
            }
            if (!Directory.Exists(newWork.OutputPath))
            {
                MessageBox.Show("결과를 저장할 폴더를 선택해주세요.");
                textOutputFolder.Focus();
                return;
            }

            currentWork = newWork;
            buttonCompare.Enabled = false;
            backgroundComparator.RunWorkerAsync();
        }

        private void backgroundComparator_DoWork(object sender, DoWorkEventArgs e)
        {
            var background = sender as BackgroundWorker;
            if (currentWork != null)
            {
                var comparator = new Comparator();
                comparator.OnLogMessage += message =>
                {
                    Console.WriteLine(message);
                };
                comparator.OnProgress += (totalCount, progress) =>
                {
                    background.ReportProgress(progress * 100 / totalCount);
                };
                comparator.CompareTwoPowerpointFiles(currentWork.NewFile, currentWork.OldFile, currentWork.OutputPath);
            }
        }
        private void backgroundComparator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonCompare.Enabled = true;
            labelProgress.Text = "";
            if (currentWork != null)
            {
                OpenSubfolder(currentWork.OutputPath);
                currentWork = null;
            }
        }

        private void backgroundComparator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgress.Text = e.ProgressPercentage.ToString() + "%";
        }

        private static void OpenSubfolder(string folder)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = @"explorer.exe",
                Arguments = folder
            });
        }
    }
}
