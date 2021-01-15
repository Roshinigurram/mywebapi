using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.Models
{
    [Table("Employee")]
    public class Employees
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string EmpName { get; set; }
            public decimal Salary { get; set; }
            public int DeptNo { get; set; }
        
    }
}
