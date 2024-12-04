using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models.inputs
{
    public interface Query
    {
        public QueryParam ToQuery();
    }

    public class QueryParam
    {
        [JsonProperty("op")]
        public string Op { get; set; }
        [JsonProperty("field")]
        public string? Field { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)] public dynamic? Value { get; set; }
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)] public dynamic[]? Values { get; set; }
        [JsonProperty("list", NullValueHandling = NullValueHandling.Ignore)] public QueryParam[]? list { get; set; }
    }

    public class JoinParams
    {
        [JsonProperty("table_name")]
        public string TableName { get; set; }
        [JsonProperty("local_field")]
        public string localField { get; set; }
        [JsonProperty("foreign_field")]
        public string foreignField { get; set; }
    }

    public class And : Query
    {
        private List<QueryParam> _queries = new List<QueryParam>();

        public And(Query queryOne, params Query?[] queries)
        {
            _queries.Add(queryOne.ToQuery());
            foreach (var q in queries)
            {
                if (q != null) _queries.Add(q.ToQuery());
            }
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "AND",
                list = _queries.ToArray(), // Convert List to Array
            };
        }
    }

    public class Or : Query
    {
        private List<QueryParam> _queries = new List<QueryParam>();

        public Or(Query queryOne, params Query?[] queries)
        {
            _queries.Add(queryOne.ToQuery());
            foreach (var q in queries)
            {
                if (q != null) _queries.Add(q.ToQuery());
            }
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "OR",
                list = _queries.ToArray(), // Convert List to Array
            };
        }
    }

    public class Eq : Query
    {
        private string Field { get; set; }
        private dynamic Value { get; set; }

        public Eq(string field, dynamic value)
        {
            Field = field;
            Value = value;
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "=",
                Field = Field,
                Value = Value
            };
        }
    }

    public class Neq : Query
    {
        public string Field { get; set; }
        public dynamic Value { get; set; }

        public Neq(string field, dynamic value)
        {
            Field = field;
            Value = value;
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "!=",
                Field = Field,
                Value = Value
            };
        }
    }

    public class Compare : Query
    {
        public string Field { get; set; }
        public dynamic Value { get; set; }
        public string Operator { get; set; }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = Operator,
                Field = Field,
                Value = Value
            };
        }
    }

    public class In : Query
    {
        public string Field { get; set; }
        public dynamic[] Values { get; set; }

        public In(string field, dynamic[] values)
        {
            Field = field;
            Values = values;
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "=",
                Field = Field,
                Values = Values
            };
        }
    }

    public class Nin : Query
    {
        public string Field;
        public dynamic[] Values;

        public Nin(string field, dynamic[] values)
        {
            Field = field;
            Values = values;
        }

        public QueryParam ToQuery()
        {
            return new QueryParam
            {
                Op = "!=",
                Field = Field,
                Values = Values
            };
        }
    }
}
