using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Imaging;
using System.Xml.Serialization;
namespace PhotoEditor
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap;
        private Bitmap modifiedBitmap;
        string imagePath;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Set the value of trackBar4 (Saturation) to its midpoint
            trackBar4.Value = trackBar4.Maximum / 2;
            //FOR OPACITY
            trackBar5.Value = trackBar5.Maximum;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                    pictureBox1.Image = Image.FromFile(fileNames[0]);
            }

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        //GRAYSCALE FILTER
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Check if the pictureBox1 contains an image
                // Proceed if it's not null

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Get the default RGB values of the pixel
                        int defaultR = pixelColorBefore.R;
                        int defaultG = pixelColorBefore.G;
                        int defaultB = pixelColorBefore.B;

                        // Calculate grayscale intensity using weighted averages of the RGB components,
                        // reflecting the perceived brightness of each color channel
                        int avg = (int)(0.2989 * defaultR + 0.5870 * defaultG + 0.1140 * defaultB);

                        // Create a new grayscale color using the calculated intensity
                        Color setPixelColor = Color.FromArgb(avg, avg, avg);

                        // Set the pixel in the bitmap to the grayscale color
                        bmp.SetPixel(x, y, setPixelColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }


        //BLACK AND WHITE FILTER
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // If the image in pictureBox1 is not null (i.e., it contains an image)
                // then proceed with processing.

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Set the threshold value for converting the image to binary (black and white)
                int threshold = 128;

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColor = bmp.GetPixel(x, y);

                        // Convert the color to grayscale using the luminance method:
                        // Y = 0.299R + 0.587G + 0.114B
                        int grayscale = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                        // Apply thresholding: if grayscale value is less than threshold, set pixel to black; otherwise, set to white
                        Color newColor = (grayscale < threshold) ? Color.Black : Color.White;

                        // Set the color of the pixel at position (x, y) to the new color
                        bmp.SetPixel(x, y, newColor);
                    }
                }

                // Assign the modified bitmap to pictureBox2's Image property
                // Clone the bitmap to avoid altering the original
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        //IMPORT BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadImage(openFileDialog.FileName);
            }
        }

        private void LoadImage(string filename)
        {
            try
            {
                Image image = Image.FromFile(filename);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ensure the image fits properly
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the image: " + ex.Message);
            }
        }


        //CLEAR BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
            // Clear pictureBox1
            pictureBox1.Image = null;

            // Clear pictureBox2
            pictureBox2.Image = null;
        }


        //SAVE BUTTON
        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                saveFileDialog.Title = "Save an Image File";

                // Show the save file dialog and check if the user selected a file name
                if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    // Create a bitmap from the image in pictureBox2
                    Bitmap bmp = new Bitmap(pictureBox2.Image);

                    // Save the bitmap as a JPEG file
                    bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Dispose the bitmap to release resources
                    bmp.Dispose();
                }
            }
            else
            {
                MessageBox.Show("There is no image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //SEPIA FILTER
        private void button6_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Calculate sepia values for each color channel
                        int sepiaR = (int)(0.393 * pixelColorBefore.R + 0.769 * pixelColorBefore.G + 0.189 * pixelColorBefore.B);
                        int sepiaG = (int)(0.349 * pixelColorBefore.R + 0.686 * pixelColorBefore.G + 0.168 * pixelColorBefore.B);
                        int sepiaB = (int)(0.272 * pixelColorBefore.R + 0.534 * pixelColorBefore.G + 0.131 * pixelColorBefore.B);

                        // Cap values at 255
                        sepiaR = (sepiaR > 255) ? 255 : sepiaR;
                        sepiaG = (sepiaG > 255) ? 255 : sepiaG;
                        sepiaB = (sepiaB > 255) ? 255 : sepiaB;

                        // Create a new color using the sepia values
                        Color setPixelColor = Color.FromArgb(sepiaR, sepiaG, sepiaB);

                        // Set the pixel in the bitmap to the sepia color
                        bmp.SetPixel(x, y, setPixelColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        //YOSEMITE FILTER
        private void button7_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Enhance warm tones (e.g., red, orange, yellow)
                        int newR = (int)(pixelColorBefore.R * 1.1); // Increase red component
                        int newG = (int)(pixelColorBefore.G * 1.05); // Slightly increase green component
                        int newB = pixelColorBefore.B; // Keep blue component unchanged

                        // Cap values to ensure they stay within the valid range (0-255)
                        newR = Math.Min(255, newR);
                        newG = Math.Min(255, newG);

                        // Create a new color using the adjusted components
                        Color setPixelColor = Color.FromArgb(newR, newG, newB);

                        // Set the pixel in the bitmap to the new color
                        bmp.SetPixel(x, y, setPixelColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }
        //THIS 3 ARE BEING CALLED OUT BY THE CODE BELOW
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateDisplayedImage();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateDisplayedImage();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UpdateDisplayedImage();
        }

        //FUNCTION CODE FOR THE SLIDERS
        private void UpdateDisplayedImage()
        {
            if (pictureBox1.Image != null)
            {
                // THIS CODE WILL KEEP ON TRACK OF THE POSITION OF EACH TRACKBARS
                int redAdjustment = trackBar1.Value;
                int greenAdjustment = trackBar2.Value;
                int blueAdjustment = trackBar3.Value;

                // Transform the adjustment values into scaling factors
                float redFactor = 1 + redAdjustment / 100f;
                float greenFactor = 1 + greenAdjustment / 100f;
                float blueFactor = 1 + blueAdjustment / 100f;

                // Create a clone of the original image in pictureBox1 for setting up in picturebox2
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap modifiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                // Loop through each pixel in the original image
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColor = originalBitmap.GetPixel(x, y);

                        // Determine the updated values for the red, green, and blue color channels.
                        int newR = (int)(pixelColor.R * redFactor);
                        int newG = (int)(pixelColor.G * greenFactor);
                        int newB = (int)(pixelColor.B * blueFactor);

                        // Ensure the new color component values stay within the valid range (0 to 255)
                        newR = Math.Max(0, Math.Min(255, newR));
                        newG = Math.Max(0, Math.Min(255, newG));
                        newB = Math.Max(0, Math.Min(255, newB));

                        // Create a new color with the modified color component values
                        Color newColor = Color.FromArgb(newR, newG, newB);

                        // Set the pixel in the modified bitmap to the new color
                        modifiedBitmap.SetPixel(x, y, newColor);
                    }
                }

                // Set the modified image to pictureBox2 and adjust the size mode
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = modifiedBitmap;
            }

        }


        //THIS IS THE PART WHERE I OPTIMIZE THE PROCESS WHEN ENGAGING WITH THE TRACKBAR
        private void LoadLowerResolutionImage(string imagePath, int resolutionAdjustment)
        {
            // If the resolution adjustment is less than or equal to zero, there's no need to proceed further
            // as negative or zero adjustments would not make sense in this context
            if (resolutionAdjustment <= 0)
                return;

            // Load the original image
            originalBitmap = new Bitmap(imagePath);

            // Calculate the resolution based on the adjustment value
            int resolutionFactor = resolutionAdjustment * 10; // Adjust the factor as needed
            int lowerResolutionWidth = originalBitmap.Width / resolutionFactor;
            int lowerResolutionHeight = originalBitmap.Height / resolutionFactor;

            // Create a lower-resolution version for display
            Bitmap lowerResolutionImage = new Bitmap(originalBitmap, lowerResolutionWidth, lowerResolutionHeight);

            // Display the lower-resolution image in pictureBox1
            pictureBox1.Image = lowerResolutionImage;
        }

        // Function to update the displayed image based on trackbar adjustments
        private void UpdateDisplayedImage(int redAdjustment, int greenAdjustment, int blueAdjustment)
        {
            if (originalBitmap == null)
                return;

            // Convert the resolution adjustment value into factors for lowering the image resolution
            float redFactor = 1 + redAdjustment / 100f;
            float greenFactor = 1 + greenAdjustment / 100f;
            float blueFactor = 1 + blueAdjustment / 100f;

            // Create a clone of the lower-resolution original image
            modifiedBitmap = new Bitmap(originalBitmap);

            // Apply adjustments to the modified image
            for (int x = 0; x < modifiedBitmap.Width; x++)
            {
                for (int y = 0; y < modifiedBitmap.Height; y++)
                {
                    Color pixelColor = modifiedBitmap.GetPixel(x, y);

                    // Calculate new color components
                    int newR = (int)(pixelColor.R * redFactor);
                    int newG = (int)(pixelColor.G * greenFactor);
                    int newB = (int)(pixelColor.B * blueFactor);

                    // Ensure the new color component values stay within the valid range (0 to 255)
                    newR = Math.Max(0, Math.Min(255, newR));
                    newG = Math.Max(0, Math.Min(255, newG));
                    newB = Math.Max(0, Math.Min(255, newB));

                    // Create a new color with the modified color component values
                    Color newColor = Color.FromArgb(newR, newG, newB);

                    modifiedBitmap.SetPixel(x, y, newColor);
                }
            }

            // Display the modified image in pictureBox2
            pictureBox2.Image = modifiedBitmap;
        }

        // Event handler for trackbar value change for trackBar1
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            // Load lower resolution image with trackBar1 adjustment
            LoadLowerResolutionImage(imagePath, trackBar1.Value);

            // Update displayed image with adjustments from all trackbars
            UpdateDisplayedImage(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        // Event handler for trackbar value change for trackBar2
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            // Update displayed image with adjustments from all trackbars
            UpdateDisplayedImage(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        // Event handler for trackbar value change for trackBar3
        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            // Update displayed image with adjustments from all trackbars
            UpdateDisplayedImage(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }


        //SATURATION SLIDER
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the saturation adjustment value from trackBar4
                float saturationFactor = trackBar4.Value / 100f;

                // Apply the saturation adjustment to the image in pictureBox1
                pictureBox2.Image = AdjustImageSaturation((Bitmap)pictureBox1.Image, saturationFactor);
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }



        //OPACITY SLIDER
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the opacity value from the trackbar
                int opacityValue = trackBar5.Value;

                // Create a clone of the original image
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap modifiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                // Loop through each pixel in the original image
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColor = originalBitmap.GetPixel(x, y);

                        // Normalize the opacity value to be within the range of 0 to 255
                        int normalizedOpacity = Math.Max(0, Math.Min(255, opacityValue));

                        // Create a new color with the adjusted opacity
                        Color newColor = Color.FromArgb(normalizedOpacity, pixelColor.R, pixelColor.G, pixelColor.B);

                        // Set the pixel in the modified bitmap to the new color
                        modifiedBitmap.SetPixel(x, y, newColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = modifiedBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }



        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the blur value from the trackbar
                int blurValue = trackBar6.Value;

                // Apply the blur effect to the image
                pictureBox2.Image = ApplyBlurEffect((Bitmap)pictureBox1.Image, blurValue);
            }
            // Display the modified image in pictureBox2
            
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //CODE FOR SATURATION SLIDER
        private Bitmap AdjustImageSaturation(Bitmap image, float saturationFactor)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);

            // Loop through each pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Get the color of the pixel at position (x, y)
                    Color originalColor = image.GetPixel(x, y);

                    // Adjust the saturation of the color
                    Color adjustedColor = AdjustSaturation(originalColor, saturationFactor);

                    // Set the adjusted color to the corresponding pixel in the new image
                    adjustedImage.SetPixel(x, y, adjustedColor);
                }
            }

            return adjustedImage;
        }

        // Function to adjust saturation of a color
        private Color AdjustSaturation(Color color, float saturationFactor)
        {
            // Convert RGB color to HSL
            float h, s, l;
            RGBtoHSL(color, out h, out s, out l);

            // Adjust the saturation component
            s *= saturationFactor;

            // Ensure saturation stays within [0, 1] range
            s = Math.Max(0, Math.Min(1, s));

            // Convert HSL back to RGB
            return HSLtoRGB(h, s, l);
        }

        // Function to convert RGB color to HSL
        private void RGBtoHSL(Color color, out float h, out float s, out float l)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));

            // Hue calculation
            h = 0;
            if (max != min)
            {
                if (max == r)
                    h = (60 * (g - b) / (max - min) + 360) % 360;
                else if (max == g)
                    h = (60 * (b - r) / (max - min) + 120);
                else
                    h = (60 * (r - g) / (max - min) + 240);
            }

            // Lightness calculation
            l = (max + min) / 2;

            // Saturation calculation
            if (max == min)
                s = 0;
            else if (l <= 0.5f)
                s = (max - min) / (max + min);
            else
                s = (max - min) / (2 - max - min);
        }

        // Function to convert HSL color to RGB
        private Color HSLtoRGB(float h, float s, float l)
        {
            float c = (1 - Math.Abs(2 * l - 1)) * s;
            float x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            float m = l - c / 2;

            float r, g, b;
            if (h < 60) { r = c; g = x; b = 0; }
            else if (h < 120) { r = x; g = c; b = 0; }
            else if (h < 180) { r = 0; g = c; b = x; }
            else if (h < 240) { r = 0; g = x; b = c; }
            else if (h < 300) { r = x; g = 0; b = c; }
            else { r = c; g = 0; b = x; }

            return Color.FromArgb((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }

        //BLUR CODE (HAVING TROUBLE IN THIS PART SINCE IT CRASHES
        private Bitmap ApplyBlurEffect(Bitmap originalBitmap, int blurValue)
        {
            if (blurValue <= 0)
            {
                return originalBitmap; // No blur needed
            }

            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            Bitmap blurredBitmap = new Bitmap(width, height);

            // Apply box blur algorithm
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Calculate average color of surrounding pixels within blurValue radius
                    int totalR = 0, totalG = 0, totalB = 0, count = 0;
                    for (int offsetX = -blurValue; offsetX <= blurValue; offsetX++)
                    {
                        for (int offsetY = -blurValue; offsetY <= blurValue; offsetY++)
                        {
                            int newX = x + offsetX;
                            int newY = y + offsetY;

                            // Ensure coordinates are within image bounds
                            if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                            {
                                Color pixelColor = originalBitmap.GetPixel(newX, newY);
                                totalR += pixelColor.R;
                                totalG += pixelColor.G;
                                totalB += pixelColor.B;
                                count++;
                            }
                        }
                    }

                    // Calculate average color
                    int avgR = totalR / count;
                    int avgG = totalG / count;
                    int avgB = totalB / count;

                    // Set pixel color in blurred bitmap
                    blurredBitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurredBitmap;
        }

        private void trackBar6_MouseUp(object sender, MouseEventArgs e)
        {
            //DO NOT TOUCH THIS 
        }


        //CONTRAST SLIDER
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the contrast value from the trackbar
                float contrastValue = (float)trackBar7.Value / 10.0f; // Assuming trackBar7 ranges from 0 to 100

                // Create a clone of the original image
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap modifiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                // Loop through each pixel in the original image
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColor = originalBitmap.GetPixel(x, y);

                        // Adjust contrast for each color channel individually
                        int newRed = AdjustContrastComponent(pixelColor.R, contrastValue);
                        int newGreen = AdjustContrastComponent(pixelColor.G, contrastValue);
                        int newBlue = AdjustContrastComponent(pixelColor.B, contrastValue);

                        // Create a new color with the adjusted contrast
                        Color newColor = Color.FromArgb(pixelColor.A, newRed, newGreen, newBlue);

                        // Set the pixel in the modified bitmap to the new color
                        modifiedBitmap.SetPixel(x, y, newColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = modifiedBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        //CONTRAST CODE
        private int AdjustContrastComponent(int colorComponent, float contrast)
        {
            // Adjust the contrast of a single color component (R, G, or B)
            // Assuming colorComponent ranges from 0 to 255

            // Normalize the color component to the range [0, 1]
            float normalizedComponent = colorComponent / 255.0f;

            // Apply contrast adjustment
            normalizedComponent = ((normalizedComponent - 0.5f) * contrast) + 0.5f;

            // Clamp the value to stay within [0, 1]
            normalizedComponent = Math.Max(0, Math.Min(1, normalizedComponent));

            // Convert back to the range [0, 255]
            return (int)(normalizedComponent * 255);
        }

        //BRIGHTNESS SLIDER
        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Get the brightness value from the trackbar
                int brightnessValue = trackBar8.Value; // Assuming trackBar8 ranges from -255 to 255

                // Create a clone of the original image
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap modifiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                // Loop through each pixel in the original image
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColor = originalBitmap.GetPixel(x, y);

                        // Adjust brightness for each color channel individually
                        int newRed = AdjustBrightnessComponent(pixelColor.R, brightnessValue);
                        int newGreen = AdjustBrightnessComponent(pixelColor.G, brightnessValue);
                        int newBlue = AdjustBrightnessComponent(pixelColor.B, brightnessValue);

                        // Create a new color with the adjusted brightness
                        Color newColor = Color.FromArgb(pixelColor.A, newRed, newGreen, newBlue);

                        // Set the pixel in the modified bitmap to the new color
                        modifiedBitmap.SetPixel(x, y, newColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = modifiedBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

            //BRIGHTNESS CODE
            int AdjustBrightnessComponent(int colorComponent, int brightness)
            {
                // Adjust the brightness of a single color component (R, G, or B)
                // Assuming colorComponent ranges from 0 to 255

                // Apply brightness adjustment
                int newComponent = colorComponent + brightness;

                // Clamp the value to stay within [0, 255]
                newComponent = Math.Max(0, Math.Min(255, newComponent));

                return newComponent;
            }
        }

        //MOOSE FILTER
        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Check if the pictureBox1 contains an image
                // Proceed if it's not null

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Invert the RGB values
                        int invertedR = 255 - pixelColorBefore.R;
                        int invertedG = 255 - pixelColorBefore.G;
                        int invertedB = 255 - pixelColorBefore.B;

                        // Create a new color with inverted RGB values
                        Color invertedColor = Color.FromArgb(invertedR, invertedG, invertedB);

                        // Set the pixel in the bitmap to the inverted color
                        bmp.SetPixel(x, y, invertedColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }





        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Check if the pictureBox1 contains an image
                // Proceed if it's not null

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Define the emboss kernel
                int[,] embossKernel = new int[,]
                {
        { -2, -1, 0 },
        { -1, 1, 1 },
        { 0, 1, 2 }
                };

                // Calculate the size of the kernel
                int kernelSize = 3;
                int kernelOffset = kernelSize / 2;

                // Create a new Bitmap to store the embossed image
                Bitmap embossedImage = new Bitmap(bmp.Width, bmp.Height);

                // Loop through each pixel in the bitmap
                for (int x = kernelOffset; x < bmp.Width - kernelOffset; x++)
                {
                    for (int y = kernelOffset; y < bmp.Height - kernelOffset; y++)
                    {
                        // Initialize variables to store the accumulated values for each channel
                        int embossR = 0, embossG = 0, embossB = 0;

                        // Apply the kernel to the neighborhood of the current pixel
                        for (int i = 0; i < kernelSize; i++)
                        {
                            for (int j = 0; j < kernelSize; j++)
                            {
                                // Get the color of the pixel at the current kernel position
                                Color pixelColor = bmp.GetPixel(x + i - kernelOffset, y + j - kernelOffset);

                                // Multiply the color components by the corresponding kernel value
                                embossR += pixelColor.R * embossKernel[i, j];
                                embossG += pixelColor.G * embossKernel[i, j];
                                embossB += pixelColor.B * embossKernel[i, j];
                            }
                        }

                        // Clamp the color values to the valid range [0, 255]
                        embossR = Math.Min(Math.Max(embossR, 0), 255);
                        embossG = Math.Min(Math.Max(embossG, 0), 255);
                        embossB = Math.Min(Math.Max(embossB, 0), 255);

                        // Create a new color with the embossed values
                        Color embossColor = Color.FromArgb(embossR, embossG, embossB);

                        // Set the pixel in the embossed image
                        embossedImage.SetPixel(x, y, embossColor);
                    }
                }

                // Display the embossed image in pictureBox2
                pictureBox2.Image = (Image)embossedImage.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Check if the pictureBox1 contains an image
                // Proceed if it's not null

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Enhance colors by adjusting RGB values
                        int r = Math.Min((int)(pixelColorBefore.R * 1.2), 255);
                        int g = (int)(pixelColorBefore.G * 0.8);
                        int b = (int)(pixelColorBefore.B * 1.5);

                        // Apply contrast adjustment
                        int avg = (int)((r + g + b) / 3);
                        r = (int)(avg + 0.1 * (r - avg));
                        g = (int)(avg + 0.1 * (g - avg));
                        b = (int)(avg + 0.1 * (b - avg));

                        // Clamp RGB values to stay within [0, 255]
                        r = Math.Max(0, Math.Min(255, r));
                        g = Math.Max(0, Math.Min(255, g));
                        b = Math.Max(0, Math.Min(255, b));

                        // Create a new color using the adjusted RGB values
                        Color setPixelColor = Color.FromArgb(r, g, b);

                        // Set the pixel in the bitmap to the new color
                        bmp.SetPixel(x, y, setPixelColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Check if the pictureBox1 contains an image
                // Proceed if it's not null

                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Convert the color to grayscale
                        int avg = (pixelColorBefore.R + pixelColorBefore.G + pixelColorBefore.B) / 3;

                        // Apply a sepia tone
                        int newR = Math.Min((int)(avg * 1.2), 255);
                        int newG = Math.Min((int)(avg * 1.1), 255);
                        int newB = Math.Min(avg, 255);

                        // Create a new color using the adjusted RGB values
                        Color setPixelColor = Color.FromArgb(newR, newG, newB);

                        // Set the pixel in the bitmap to the new color
                        bmp.SetPixel(x, y, setPixelColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Check if the pictureBox1 contains an image
            if (pictureBox1.Image != null)
            {
                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Separate RGB components of the pixel color
                        int defaultR = pixelColorBefore.R;
                        int defaultG = pixelColorBefore.G;
                        int defaultB = pixelColorBefore.B;

                        // Apply the Kodak filter transformation
                        int avgR = (int)(0.5 * defaultR + 0.5 * defaultG); // Average of red and green channels
                        int avgG = (int)(0.5 * defaultR + 0.5 * defaultG); // Average of red and green channels
                        int avgB = (int)(0.6 * defaultB + 0.4 * defaultG); // Adjusted blue channel

                        // Create a new color with the transformed RGB values
                        Color newColor = Color.FromArgb(avgR, avgG, avgB);

                        // Set the pixel in the bitmap to the new color
                        bmp.SetPixel(x, y, newColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }


        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Check if the pictureBox1 contains an image
            if (pictureBox1.Image != null)
            {
                // Create a new Bitmap object named 'bmp' from the image in pictureBox1
                Bitmap bmp = new Bitmap(pictureBox1.Image);

                // Loop through each pixel in the bitmap
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        // Get the color of the pixel at position (x, y)
                        Color pixelColorBefore = bmp.GetPixel(x, y);

                        // Separate RGB components of the pixel color
                        int defaultR = pixelColorBefore.R;
                        int defaultG = pixelColorBefore.G;
                        int defaultB = pixelColorBefore.B;

                        // Apply the Holiday filter transformation
                        int avgR = (int)(0.7 * defaultR + 0.3 * defaultB); // Increase red channel
                        int avgG = (int)(0.8 * defaultG); // Increase green channel
                        int avgB = (int)(0.8 * defaultB); // Increase blue channel

                        // Create a new color with the transformed RGB values
                        Color newColor = Color.FromArgb(avgR, avgG, avgB);

                        // Set the pixel in the bitmap to the new color
                        bmp.SetPixel(x, y, newColor);
                    }
                }

                // Display the modified image in pictureBox2
                pictureBox2.Image = (Image)bmp.Clone();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }
    }
}






