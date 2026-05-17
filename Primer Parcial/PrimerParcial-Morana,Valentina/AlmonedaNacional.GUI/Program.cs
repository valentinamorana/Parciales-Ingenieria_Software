using System;
using System.Windows.Forms;

namespace AlmonedaNacional.GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var bienvenida = new frmBienvenida())
            {
                if (bienvenida.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmPrincipal());
            }
        }
    }
}
