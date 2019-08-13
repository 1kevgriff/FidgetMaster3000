using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FidgetPro.Fidgetmaster.Business.Models
{
    public class Fidget
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public FidgetType Type { get; set; }

        public string Color { get; set; }
    }
}
