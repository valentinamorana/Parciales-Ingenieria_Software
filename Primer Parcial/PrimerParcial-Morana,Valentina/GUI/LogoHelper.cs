using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GUI
{
    internal static class LogoHelper
    {
        private static Icon _icono;
        public static Icon Icono => _icono ?? (_icono = Dibujar());

        private static Icon Dibujar()
        {
            var bmp = new Bitmap(64, 64, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode    = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);

                // Fondo: círculo rosa
                using (var fill = new SolidBrush(Color.FromArgb(210, 100, 135)))
                    g.FillEllipse(fill, 1, 1, 62, 62);
                using (var border = new Pen(Color.FromArgb(160, 60, 100), 2.5f))
                    g.DrawEllipse(border, 2, 2, 60, 60);

                // Rotamos +45° alrededor del centro (32,32)
                g.TranslateTransform(32, 32);
                g.RotateTransform(45);

                // Cabeza del martillo (blanco)
                using (var br = new SolidBrush(Color.White))
                    g.FillRectangle(br, -15, -18, 30, 14);

                // Franja central decorativa en la cabeza
                using (var br = new SolidBrush(Color.FromArgb(235, 185, 200)))
                    g.FillRectangle(br, -15, -9, 30, 4);

                // Borde sutil de la cabeza
                using (var pen = new Pen(Color.FromArgb(180, 100, 130), 1f))
                    g.DrawRectangle(pen, -15, -18, 30, 14);

                // Mango (dorado-cálido)
                using (var br = new LinearGradientBrush(
                    new Rectangle(-4, -4, 8, 26),
                    Color.FromArgb(250, 210, 120),
                    Color.FromArgb(200, 150, 60),
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(br, -4, -4, 8, 26);
                }
                using (var pen = new Pen(Color.FromArgb(180, 130, 50), 0.8f))
                    g.DrawRectangle(pen, -4, -4, 8, 26);

                g.ResetTransform();

                // Bloque de golpe (esquina inferior-izquierda)
                using (var br = new SolidBrush(Color.White))
                    g.FillRectangle(br, 5, 46, 22, 9);
                using (var pen = new Pen(Color.FromArgb(180, 100, 130), 1f))
                    g.DrawRectangle(pen, 5, 46, 22, 9);
                // Línea de detalle en el bloque
                using (var pen = new Pen(Color.FromArgb(235, 185, 200), 1f))
                    g.DrawLine(pen, 7, 50, 25, 50);
            }

            return Icon.FromHandle(bmp.GetHicon());
        }
    }
}
