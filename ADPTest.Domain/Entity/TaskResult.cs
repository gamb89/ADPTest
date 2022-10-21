using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Domain.Entity
{

    [Table("TASK")]
    public class TaskResult
    {
        [Required(ErrorMessage = "ID is required")]
        public string Id { get; set; }

        [Column("Operation")]
        public string Operation { get; set; }

        [Column("Left")]
        public double Left { get; set; }

        [Column("Right")]
        public double Right { get; set; }

        [Column("Result")]
        public double Result { get; set; }
    }
}
