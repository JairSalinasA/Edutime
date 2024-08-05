using System.Windows.Forms;

namespace EduTime.Presentation.Helpers
{
    public static class MessageHelper
    {
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
