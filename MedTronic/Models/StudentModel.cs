using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTronic.Models
{
    [Table("tbl_Students")]
    public class StudentModel
    {
         public string FirstName { get; set; }

         public string LastName { get; set; }

         [Key]
         public Int32 RollNumber { get; set; }

         public string IdNum { get; set; }

    }

}
