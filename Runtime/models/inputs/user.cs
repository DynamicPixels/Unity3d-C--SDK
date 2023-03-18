using System.Collections.Generic;

namespace models.inputs
{
    public class FindUserParams
    {
        
    }

    public class FindUserByIdParams
    {
        public int UserId { get; set; }
    }

    public class EditUserByIdParams
    {
        public int UserId { get; set; }
        public Dictionary<string, dynamic> Values { get; set; }
    }
    
    public class BanUserByIdParams
    {
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
    
}