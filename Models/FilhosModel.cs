using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMvcArthur.Models
{



    [Table("Filhos")]
    public class FilhosModel
    {
        [Key]
        public int FilhoId { get; set; }
        [Required]
        public string Nome { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [Required]
        public int FuncionarioId { get; set; }

    }
}
