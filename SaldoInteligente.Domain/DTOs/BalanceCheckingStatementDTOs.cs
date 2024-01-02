using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs
{
    public class FindRangeDateDTO
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }

    public class AddLooseEntryDTO
    {
        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Valor é obrigatório ")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Not Equal to Zero")]
        public decimal Value { get; set; }
    }

    public class AddNotLooseEntryDTO : AddLooseEntryDTO
    {
        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime InputDate { get; set; }
    }

    public class ChangeDTO
    {
        [Required(ErrorMessage = "Id do item do extrato obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime InputDate { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório ")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Not Equal to Zero")]
        public decimal Value { get; set; }
    }
}
