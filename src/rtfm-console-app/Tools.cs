using System.ComponentModel;
using System.Text;

namespace rtfm_console_app;

public static class Tools
{
    [Description("Read all documentation.")]
    public static string GetDocumentation()
    {
        var sb = new StringBuilder();

        foreach (var file in Directory.GetFiles("../../docs", "*.md", SearchOption.AllDirectories))
        {
            sb.AppendLine($"// --- {Path.GetFileName(file)} ---");
            sb.AppendLine(File.ReadAllText(file));
            sb.AppendLine();
        }

        return sb.ToString();
    }
}