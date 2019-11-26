using NumberParser.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace NumberParser
{
    public class XMLConvertor : IFile
    {
        private readonly string _fileType = "XML";
        private readonly int[] _fileData;

        public XMLConvertor(string fileType, int[] fileData)
        {
            _fileType = fileType;
            _fileData = fileData;
        }


        public void FileCreator()
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(int[]));


            var folderpath = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory())
                           .FullName).FullName, _fileType);

            if (!Directory.Exists(folderpath))  // if it doesn't exist, create
                Directory.CreateDirectory(folderpath);

            TextWriter filestream = new StreamWriter(Path.Combine(folderpath, "XML.xml"));

            //write to the file
            serialiser.Serialize(filestream, _fileData);

            // Close the file
            filestream.Close();

        }
    }
}
