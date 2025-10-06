using System.Reflection;

namespace AMartinezTech.WinForms.Utils;

internal static class DataGridViewExtensions
{
    public static void EnableDoubleBuffering(this DataGridView dgv)
    {
        typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dgv,
            new object[] { true }
        );
    }
}
