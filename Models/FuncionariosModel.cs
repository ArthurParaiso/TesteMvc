using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace TesteMvcArthur.Models
{
    [Table("Funcionarios")]
    public class FuncionariosModel
    {

        [Key]
        public int FuncionarioId { get; set; }
        [Required]
        public string Nome { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }

        [Required]
        [Range(1200, 9999999999999999.99)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Salario { get; set; }
    }

}
