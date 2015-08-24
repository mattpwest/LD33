using System.IO;

namespace Assets.Scripts.Persistence
{
    public class Files
    {
        public string ReadFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                return string.Empty;
            }

            var contents = File.ReadAllText(fileName);

            return contents;
        }

        public void WriteFile(string fileName, string contents)
        {
            File.WriteAllText(fileName, contents);
        }
    }
}
