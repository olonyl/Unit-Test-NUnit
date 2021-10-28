using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business.QuotationsProcessor.Refactored
{
    public class FilePersister
    {
        private readonly string _filePath;

        public FilePersister(string filePath)
        {
            _filePath = filePath;
        }

        public List<Record> GetAllRecords()
        {
            return File.ReadAllLines(_filePath)
                .Select(Record.ParseString)
                .ToList();
        }

        public void ApplyAction(FileAction fileAction)
        {
            switch (fileAction.Action)
            {
                case Action.Add:
                    {
                        File.AppendAllLines(_filePath, new[] { fileAction.Record.ToString() });
                        break;
                    }
                case Action.CreateNew:
                    {
                        File.WriteAllLines(_filePath, new[] { fileAction.Record.ToString() });
                        break;
                    }
                case Action.Remove:
                    {
                        File.Delete(_filePath);
                        break;
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
