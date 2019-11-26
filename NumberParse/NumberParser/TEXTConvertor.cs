using NumberParser.Interfaces;
using System;
using System.IO;

namespace NumberParser
{
    public class TEXTConvertor : IFile
    {
        private readonly string _fileType = "TEXT";
        private readonly int[] _fileData;

        public TEXTConvertor(string fileType, int[] fileData)
        {
            _fileType = fileType;
            _fileData = fileData;
        }


        public void FileCreator()
        {
            var folderpath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())
                           .FullName).FullName, _fileType.ToUpper());

            if (!Directory.Exists(folderpath))  // if it doesn't exist, create
                Directory.CreateDirectory(folderpath);

            File.WriteAllText(Path.Combine(folderpath, "TEXT.txt"), string.Join(" ", _fileData));
            
        }
    }
}
