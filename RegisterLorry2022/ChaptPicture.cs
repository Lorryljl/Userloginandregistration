using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLorry2022
{
    internal class ChaptPicture
    {

        public string GenerateRomdomCaptcha()
        {
            Random random = new Random();
            const string chars= "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Image GenerateCaptchaImage(string captcha) {

            int width = 150;
            int height = 150;
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);

            Color Background = Color.Purple;
            Color Text = Color.DarkCyan;
            g.Clear(Background);

            Font font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Strikeout);
            Brush brush = new SolidBrush(Text);

            PointF pointF = new PointF(1, 1);

            g.DrawString(captcha, font, brush, pointF);
            return image;
        }
    }
}
