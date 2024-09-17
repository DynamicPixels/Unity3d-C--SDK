using System.Collections.Generic;

namespace DynamicPixels.GameService.Models.inputs
{
    public interface Aggregarion
    {
        // public Tuple<string, Dictionary<string, dynamic>> ToString(int index);
    }

    public class Match : Aggregarion
    {
        private Query query;
        public Match(Query query)
        {
            this.query = query;
        }
    }

    public class Skip : Aggregarion
    {
        private int skip;
        public Skip(int skip)
        {
            this.skip = skip;
        }
    }

    public class Limit : Aggregarion
    {
        private int limit;
        public Limit(int limit)
        {
            this.limit = limit;
        }
    }

    public class Select : Aggregarion
    {
        public Select(int select)
        {

        }
    }

    public class Sort : Aggregarion
    {
        private Dictionary<string, Order> sorts = new Dictionary<string, Order>();
        public Sort(Dictionary<string, Order> sorts)
        {
            this.sorts = sorts;
        }
    }

    public class Join : Aggregarion
    {
        private string tableName;
        private Query condition;
        public Join(string tableName, Query condition)
        {
            this.tableName = tableName;
            this.condition = condition;
        }
    }
}