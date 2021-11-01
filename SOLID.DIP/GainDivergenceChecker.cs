using System;

namespace SOLID.DIP
{
    public class GainDivergenceChecker
    {
        private readonly IAccounter _accounter;
        private readonly IFiscalRegistrator _fiscalRegistrator;

        public GainDivergenceChecker(IAccounter accounter , IFiscalRegistrator fiscalRegistrator)
        {
            _accounter = accounter;
            _fiscalRegistrator = fiscalRegistrator;
        }

        public bool HasDivergence()
        {
            decimal salesSum = _accounter.GetSalesSum();
            decimal sumOfReturnedTickets = _accounter.GetSumOfReturnedTickets();

            decimal salesSumByFiscalRegistrator = _fiscalRegistrator.GetSalesSum();
            decimal sumOfReturnedTicketsByFiscalRegistrator = _fiscalRegistrator.GetSumOfReturnedTickets();

            return salesSum == salesSumByFiscalRegistrator && sumOfReturnedTickets == sumOfReturnedTicketsByFiscalRegistrator;

        }

        private void ValidateDependencies(Accounter accounter, FiscalRegistrator fiscalRegistrator)
        {
            if (accounter == null) throw new ArgumentNullException(nameof(accounter));
            if (fiscalRegistrator == null ) throw new ArgumentNullException(nameof(fiscalRegistrator));
        }
    }

   
}
