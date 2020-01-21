using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ComparePPTX
{
    class Comparator
    {
        public Action<string> OnLogMessage;
        public Action<int, int> OnProgress;
        /**
         * 같은 순서
         * - 같음
         * - 내용이 변경됨
         * 
         * 다른 순서
         * - 위로 옮겨짐 (위의 것이 삭제)
         * - 아래로 옮겨짐 (위에 무언가 추가)
         * - 위로 옮겨짐 (이동)
         * - 아래로 옮겨짐 (이동)
         * 
         * 같은 index로 진행하고 있을 때,
         * - 같다? OK
         * - 다르다?
         *     - 변경 O/X  이동 위/아래 삭제 의 5가지 상황을 검증
         *     - 근데 만약 이전까지 동일했다면 위도 이동되었거나 위로 이동된 후 변경된 가능성은 없다
         *     - 근데 한 번 달라지기 시작했다면 그 지점부터 고민해야 한다. 나는 위로 안 갔겠지만 내 다음 것은 위로 왔을 수도 있으니까.
         *     - 순서가 동일할 때야 비교해서 찾을 수 있겠지만, 이동과 변경을 동시에 수반하는 경우 유사도 계산이 필요할 수도 있는 것은 아닐까? 
         */

        private int totalCount;
        private int progressCount;

        public List<string> CompareTwoPowerpointFiles(string currentPptxFile, string oldPptxFile, string outputPath)
        {
            Directory.Delete(outputPath, true);
            EnsureDirectory(new DirectoryInfo(outputPath));

            var outputFiles = new List<string>();
            var currentRoot = CreateTempDirectory();
            var oldRoot = CreateTempDirectory();
            OnLogMessage($"Diff start [Current::{currentRoot}][Old::{oldRoot}]");
            try
            {
                var currentSlideFiles = ExportPowerpointFileAsPngs(currentPptxFile, currentRoot);
                var oldSlideFiles = ExportPowerpointFileAsPngs(oldPptxFile, oldRoot);

                OnLogMessage($"Load old bitmaps: {oldRoot}");
                var oldSlideImages = LoadBitmapsFromFiles(oldSlideFiles);

                foreach (var currentSlideFile in currentSlideFiles)
                {
                    ReportProgress();
                    OnLogMessage($"Diff current slide[{currentSlideFile}] with old slides");

                    var currentSlideImage = (Bitmap)Image.FromFile(currentSlideFile);
                    if (oldSlideImages.Any(rightSlideImage => CompareBitmapsFast(currentSlideImage, rightSlideImage)))
                    {
                        OnLogMessage($"Current slide[{currentSlideFile}] is same with old one");
                        continue;
                    }

                    OnLogMessage($"Current slide[{currentSlideFile}] is new one");
                    var outputFile = Path.Combine(outputPath, Path.GetFileName(currentSlideFile));
                    File.Copy(currentSlideFile, outputFile);
                    outputFiles.Add(outputFile);
                }
            }
            finally
            {
                try { Directory.Delete(currentRoot, true); } catch { }
                try { Directory.Delete(oldRoot, true); } catch { }
            }
            return outputFiles;
        }

        private void ReportProgress()
        {
            OnProgress(totalCount, Math.Min(totalCount, progressCount++));
        }

        private List<string> ExportPowerpointFileAsPngs(string pptxFile, string outputPath)
        {
            OnLogMessage($"Load Powerpoint: {pptxFile}");
            var pngFiles = new List<string>();
            var app = new Application { };
            try
            {
                var pres = app.Presentations.Open(pptxFile, WithWindow: MsoTriState.msoFalse);
                if (totalCount == 0)
                {
                    totalCount = pres.Slides.Count * 3 + 2;
                }
                try
                {
                    var index = 0;
                    foreach (Slide slide in pres.Slides)
                    {
                        var pngFile = Path.Combine(outputPath, index.ToString("D3") + ".png");
                        slide.Export(pngFile, "png", ScaleWidth: 1920);
                        pngFiles.Add(pngFile);
                        OnLogMessage($"Export slide[{index}] as File[{pngFile}]");
                        ReportProgress();

                        ++index;
                    }
                }
                finally
                {
                    pres.Close();
                }
            }
            finally
            {
                app.Quit();
            }
            return pngFiles;
        }

        private List<Bitmap> LoadBitmapsFromFiles(List<string> filePaths)
        {
            return filePaths.Select(filePath => (Bitmap)Image.FromFile(filePath)).ToList();
        }

        private bool CompareBitmapsFast(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }

        private string CreateTempDirectory()
        {
            var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
            Directory.CreateDirectory(tempPath);
            return tempPath;
        }

        private void EnsureDirectory(DirectoryInfo directory)
        {
            if (!directory.Parent.Exists) EnsureDirectory(directory.Parent);
            if (!directory.Exists) directory.Create();
        }
    }
}
