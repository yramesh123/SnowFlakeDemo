using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTronic.Models
{
    [Table("tbl_teachers")]
    public class TeacherModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Column("ClassSubject")]
        public string Subject { get; set; }

        [Key]
        public Int32 EmpId { get; set; }
    }
}
