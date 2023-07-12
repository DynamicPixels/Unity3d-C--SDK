using System.Collections.Generic;

namespace models.inputs
{
    public class FindUserParams
    {
        public Dictionary<string, string> Query { get; set; }
    }

    public class FindUserByIdParams
    {
        public int UserId { get; set; }
    }

    public class EditCurrentUserParams
    {
        public string Name { get; set; }
    }
    
    public class BanUserByIdParams
    {
        public int UserId { get; set; }
        public bool Status { get; set; }
    }
    
}