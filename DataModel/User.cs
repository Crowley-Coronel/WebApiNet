namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Tokens = new HashSet<Tokens>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Tokens> Tokens { get; set; }
    }
}
