using System;
using System.ComponentModel.DataAnnotations;

namespace FidgetPro.Fidgetmaster.Business.Models
{
    public class FidgetType
    {
        [Key]
        public long Id { get; set; }
        public string TypeName { get; set; }
        public DateTime DesignedDate { get; set; }

        public bool IsSpinning { get; set; }
        public bool IsBouncing { get; set; }
        public bool IsFlying { get; set; }
    }
}