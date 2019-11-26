using Newtonsoft.Json;
using NumberParser.Interfaces;
using System.IO;

namespace NumberParser
{
    public class JOSNConvertor : IFile
    {
        private readonly string _fileType = "JSON";
        private readonly int[] _fileData;

        public JOSNConvertor(string fileType, int[] fileData)
        {
            _fileType = fileType;
            _fileData = fileData;
        }


        public void FileCreator()
        {
            string json = JsonConvert.SerializeObject(_fileData);

            var folderpath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())
                            .FullName).FullName, _fileType);

            if (!Directory.Exists(folderpath))  // if it doesn't exist, create
                Directory.CreateDirectory(folderpath);

            File.WriteAllText(Path.Combine(folderpath, "JSON.json"), json);
        }
    }
}
