using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.QuotationsProcessor.Refactored
{
    public class FileManager
    {
        public FileAction AddQuotation(List<Record> records, Record newRecord)
        {
            Record record;
            Action action;

            if (records.Count > 0)
            {
                record = new Record(records.Last().Id + 1, newRecord.CurrencyPair, newRecord.Rate, newRecord.Stamp);
                action = Action.Add;
            }
            else
            {
                record = new Record( 1, newRecord.CurrencyPair, newRecord.Rate, newRecord.Stamp);
                action = Action.CreateNew;
            }
            return new FileAction(record, action);
        }
    }
}
