using GolrangSystemFinalExam.Core.Domains.Common;

namespace GolrangSystemFinalExam.Core.Domains
{
    public class Customer : BaseDomain
    {
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public IEnumerable<PreInvoiceHeader> PreInvoiceHeaders { get; set; }
    }
}
