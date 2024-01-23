using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

       [Column(TypeName = "Date")]
        public DateTime DataNasc { get; set;}
        public int CPF { get; set;}
        public string Endereco { get; set;}
        public int CEP { get; set;}
        public int Telefone { get; set;}
        public string Modalidade { get; set;}

       [Column(TypeName = "Date")]
        public DateTime DataPgto { get; set;}

    }
}
