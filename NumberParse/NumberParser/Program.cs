using NumberParser.Interfaces;
using System;
using System.Collections.Generic;

namespace NumberParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("NumberParser :");
            var input = Console.ReadLine();
           
            try
            {
                string fileType = input.Substring(input.LastIndexOf(',') + 1);
                var fileDataRaw = input.Substring(0, input.LastIndexOf(","));
                int[] fileData = FileFactory.sortArry(fileDataRaw);
                IFile fileInstance = FileFactory.GetFileCreatorClass(fileType.ToLower(), fileData);

                if (fileInstance != null)
                {
                    fileInstance.FileCreator();
                    Console.WriteLine("Operation Completed Successfully");
                }
                else
                {
                    Console.WriteLine("File Type Not found");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Occured while processing your request.{0}" +Environment.NewLine, ex.Message);
                Console.Read();
            }

        }
        public static class FileFactory
        {
            public static int[] sortArry(string fileData)
            {
                var ArrayList = new List<int>();
                foreach (var item in fileData.Split(','))
                {
                    ArrayList.Add(Convert.ToInt32(item));
                }

                int[] terms = ArrayList.ToArray();


                Array.Sort(terms);
                Array.Reverse(terms);
                return terms;
            }
            public static IFile GetFileCreatorClass(string FileType, int[] fileData)
            {
                switch (FileType)
                {
                    case "json":
                        return new JOSNConvertor("json", fileData);
                    case "xml":
                        return new XMLConvertor("xml", fileData);
                    case "text":
                        return new TEXTConvertor("text", fileData);
                    default:
                        return null;
                }
            }
        }





    }
}
