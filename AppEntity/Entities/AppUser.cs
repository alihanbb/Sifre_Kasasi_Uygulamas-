using AppCore.Entity;
using Microsoft.AspNetCore.Identity;

namespace AppEntity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string Name { get; set; }
        public string SurName { get; set; }
      
   
    }
}
