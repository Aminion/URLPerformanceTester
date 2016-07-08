using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLPerformanceTester.Models.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<string> TestedLinks { get; set; }
    }
}