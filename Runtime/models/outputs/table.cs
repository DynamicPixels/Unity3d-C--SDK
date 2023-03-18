using System.Collections.Generic;
using System.Numerics;
using models.dto;

namespace models.outputs
{
    public class RowListResponse
    {
        public List<Row> List { get; set; }
        public BigInteger TotalCount { get; set; }
    }
    
    public class RowListResponse<T>
    {
        public List<T> List { get; set; }
        public BigInteger TotalCount { get; set; }
    }

    public class RowResponse
    {
        public Row Row { get; set; }
    }

    public class RowResponse<T>
    {
        public T Row { get; set; }
    }
    public class ActionResponse
    {
        public int Affected { get; set; }
    }
}