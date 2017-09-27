using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevelopmentSimplyPut.CommonUtilities;
using System.Globalization;
using DevelopmentSimplyPut.Utilities;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace DevelopmentSimplyPut.ImagesCombiner
{
    public partial class frmImagesCombiner : Form
    {
        public frmImagesCombiner()
        {
            InitializeComponent();
            factors = new List<Factor>();

            openFileDialog1.InitialDirectory = Application.StartupPath;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
        }

        private List<Factor> factors;

        private void btnAddCategoryImages_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileNames.Length > 0)
            {
                Factor factor = new Factor();
                TreeNode factorNode = new TreeNode((factors.Count + 1).ToString());

                openFileDialog1.InitialDirectory = ((openFileDialog1.FileNames)[0].ext_SplitAtLastCharExistance('\\'))[0];

                foreach (string path in openFileDialog1.FileNames)
                {
                    ImageInfo imageInfo = new ImageInfo((path.ext_SplitAtLastCharExistance('\\'))[1].ext_SplitAtLastCharExistance('.')[0], path);
                    factor.ImagesInfo.Add(imageInfo);

                    TreeNode imageNode = new TreeNode(imageInfo.Path);
                    factorNode.Nodes.Add(imageNode);
                }

                factors.Add(factor);
                treeView1.Nodes.Add(factorNode);
                treeView1.ExpandAll();
            }
        }

        private void btnGenerateImages_Click(object sender, EventArgs e)
        {
            if (factors.Count > 1 && folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string direcotryPath = folderBrowserDialog1.SelectedPath;

                List<Int64> lengths = new List<Int64>();

                foreach (Factor factor in factors)
                {
                    lengths.Add(factor.ImagesInfo.Count);
                }

                if (lengths.Count > 1)
                {
                    PossibilitiesCube container = new PossibilitiesCube(1, lengths.ToArray());
                    container.BuildPossibilitiesMatrix();

                    for (Int64 i = 0; i <= container.InstancesCombinationsMaxRowIndex; i++)
                    {
                        if (container.CombinationsExist)
                        {
                            for (Int64 k = 0; k <= container.InstancesCombinationsMaxColumnIndex; k++)
                            {
                                string newImageName = string.Empty;

                                int width = 0;
                                int height = 0;
                                ImageInfo imageInfo = null;

                                for (int s = 0; s < lengths.Count; s++)
                                {
                                    imageInfo = ((factors[s].ImagesInfo).ToArray())[container[i, k, s]];
                                    using (var image = Image.FromFile(imageInfo.Path))
                                    {
                                        width += image.Width;
                                        height = Math.Max(height, image.Height);
                                        imageInfo = null;
                                    }
                                }

                                using (var bitmap = new System.Drawing.Bitmap(width, height, PixelFormat.Format32bppPArgb))
                                {
                                    using (var graphicsObject = System.Drawing.Graphics.FromImage(bitmap))
                                    {
                                        graphicsObject.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                        graphicsObject.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                        graphicsObject.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                                        int xOffset = 0;
                                        ImageInfo imageInfo1 = null;

                                        for (int s = 0; s < lengths.Count; s++)
                                        {
                                            imageInfo1 = ((factors[s].ImagesInfo).ToArray())[container[i, k, s]];
                                            using (Image image1 = Image.FromFile(imageInfo1.Path))
                                            {
                                                graphicsObject.DrawImage(image1, xOffset, 0);
                                                newImageName += imageInfo1.Name;
                                                xOffset += image1.Width;
                                            }
                                        }

                                        bitmap.Save(direcotryPath + "\\" + newImageName + ".png", ImageFormat.Png);
                                        imageInfo1 = null;
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Done");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            factors.Clear();
        }
    }

    public class ImageInfo
    {
        public string Path { set; get; }
        public string Name { set; get; }

        public ImageInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }

    public class Factor
    {
        private List<ImageInfo> imagesInfo;

        public List<ImageInfo> ImagesInfo
        {
            get { return imagesInfo; }
            set { imagesInfo = value; }
        }

        public Factor()
        {
            imagesInfo = new List<ImageInfo>();
        }
    }
}
