
using AppCore.Entity;

namespace AppEntity.Entities
{
    public class User : EntityBase
    {
       
        public string  WebSiteName { get; set; }
        public string  WebUserName { get; set; }
        public string  WebPassword { get; set; }
    }
}
