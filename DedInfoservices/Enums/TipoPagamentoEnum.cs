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

        [Description("Promissória")]
        Promissoria = 4,

        [Description("Dinheiro")]
        Dinheiro = 5,


    }
}
