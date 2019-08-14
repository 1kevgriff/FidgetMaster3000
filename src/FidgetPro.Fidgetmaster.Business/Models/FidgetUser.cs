using Microsoft.AspNetCore.Identity;

namespace FidgetPro.Fidgetmaster.Business.Models
{
    public class FidgetUser : IdentityUser
    {
        public FidgetUser() : base()
        {
            
        }
        public FidgetUser(string v) : base(v)
        {
        }

        public bool CanApprovedFidgets { get; set; }
    }
}