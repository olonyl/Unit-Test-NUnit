using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.QuotationsProcessor.Refactored;
using NUnit.Framework;

namespace Business.Tests.QuotationsProcessor
{
    class RecordTests
    {
        [Test]
        public void ParseString_ValidString_ReturnsCorrectRecord()
        {
            int id = 1;
            string currency = "USD/EUR";
            decimal rate = 1.25m;
            string dt = "2017-01-24";

            string input = $"{id};{currency};{rate};{dt}";

            Record result = Record.ParseString(input);

            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.CurrencyPair, Is.EqualTo(currency));
            Assert.That(result.Rate, Is.EqualTo(rate));
            Assert.That(result.Stamp, Is.EqualTo(DateTime.Parse(dt)));
        }

        [TestCaseSource(typeof(QuotationSource))]
        public void FileManage_AddQuotation_ValidateAction_ReturnsCorrectAction(Business.QuotationsProcessor.Refactored.Action expectedAction,List<Record> records, Record record )
        {
            FileManager fileManager = new FileManager();
            var act = fileManager.AddQuotation(records, record);

            Assert.That(act.Action, Is.EqualTo(expectedAction));

        }

        private class QuotationSource : IEnumerable
        {
            private Record GetSingleRecord(int id)
            {
                string currency = "USD/EUR";
                decimal rate = 1.25m;
                string dt = "2017-01-24";

                return Record.ParseString($"{id};{currency};{rate};{dt}");
            }
            public IEnumerator GetEnumerator()
            {
                yield return new dynamic[] {Business.QuotationsProcessor.Refactored.Action.CreateNew, new List<Record>(), GetSingleRecord(1) };
                yield return new dynamic[] {Business.QuotationsProcessor.Refactored.Action.Add, new List<Record>() { GetSingleRecord(1) }, GetSingleRecord(2) };
            }
        }
    }
}
