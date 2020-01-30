using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTronic.Models
{
    [Table("tbl_l_teacher_students")]
    public class TeacherStudentLinkModel
    {
        [Key]
        public int LinkId { get; set; }

        public int TeacherId { get; set; }

        public int StudentId { get; set; }

    }
}
