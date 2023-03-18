using System.Collections.Generic;
using models.dto;

namespace models.inputs
{
    public class AggregationInput
    {
        public string TableId { get; set; }
        public string[] Stack { get; set; }
    }

    public class FindInput
    {
        public string tableId { get; set; }
        public FindOptions options { get; set; }
    }

    public class FindByIdInput
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
    }

    public class FindByIdAndDeleteInput
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
    }
    
    public class FindByIdAndUpdateInput
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
        public Row Data { get; set; }
    }

    public class InsertInput
    {
        public string TableId { get; set; }
        public Row Data { get; set; }
    }

    public class InsertManyInput
    {
        public string TableId { get; set; }
        public List<Row> Data { get; set; }
    }

    public class UpdateManyInput
    {
        public string TableId { get; set; }
        public UpdateOptions Options { get; set; }
        public Row Data { get; set; }
    }

    public class DeleteInput
    {
        public string TableId { get; set; }
        public int[] RowIds { get; set; }
    }

    public class DeleteManyInput
    {
        public string TableId { get; set; }
        public DeleteOptions Options { get; set; }
    }
}