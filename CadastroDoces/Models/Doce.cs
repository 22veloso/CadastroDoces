using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDoces.Models
{
    public class Doce
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro{ get; set; }
    }
}
