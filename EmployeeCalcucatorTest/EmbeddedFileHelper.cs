using System.Reflection;

namespace EmployeeCalcucatorTest;

public static class EmbeddedFileHelper
{
    public static string ReadEmbeddedFile(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream(fileName)!;
        using StreamReader reader = new StreamReader(stream);
        string result = reader.ReadToEnd();
        return result;
    }

    public static byte[] ReadAsBytes(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using Stream resFilestream = assembly.GetManifestResourceStream(filename)!;
        var ms = new MemoryStream();
        resFilestream!.CopyTo(ms);
        return ms.ToArray();
    }
}
