using System.ComponentModel;

namespace DedInfoservices.Enums
{
    public enum TipoPagamentoEnum
    {
        [Description("Débito")]
        Debito = 1,

        [Description("Crédito")]
        Credito = 2,

        [Description("´Pix")]
        Pix = 3,

        [Description("Promissria")]
        Promissoria = 3

    }
}
