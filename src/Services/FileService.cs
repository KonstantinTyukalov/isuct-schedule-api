namespace Services;

public class FileService
{
    private string _filesDir = "";
    public FileService(string filesDir)
    {
        this._filesDir = filesDir;
    }
    public string ReadFile(string fileName)
    {
        var filePath = Path.Combine(this._filesDir, fileName);
        try
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string content = r.ReadToEnd();
                return content;
            }
        }
        catch (IOException e)
        {
            throw new Exception($"Error when reading the file {filePath}: " + e.Message);
        }
    }

    public void WriteFile(string fileName, string content)
    {
        var filePath = Path.Combine(this._filesDir, fileName);

        try
        {
            File.WriteAllText(filePath, content);
        }
        catch (Exception e)
        {
            throw new Exception(@"Error when writing to file: {filePath}: " + e.Message);
        }
    }
}
