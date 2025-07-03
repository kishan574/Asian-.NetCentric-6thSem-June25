using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1LanguagePreliminaries2
{
    public class FileReaders
    {
        public List<string> DataSet { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public FileReaders(string FileName, string FilePath, List<string> DataSet)
        {
            this.DataSet = DataSet;
            this.FileName = FileName;
            this.FilePath = FilePath;
        }

        public async Task<bool> CreateTXTFile()
        {
            //var fullPath = string.Join("/",filePath, fileName);
            var fullpath = Path.Combine(FilePath, FileName);
            var file = File.WriteAllLinesAsync(fullpath, DataSet);

            return File.Exists(fullpath);
        }

        public async Task<string[]> ReadTxtFile()
        {
            var fullpath = Path.Combine(FilePath, FileName);
            var file = await File.ReadAllLinesAsync(fullpath);
            return file;
        }
    }
}
