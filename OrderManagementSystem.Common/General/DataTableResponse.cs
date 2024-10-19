namespace OrderManagementSystem.Common.General
{
    public class DataTableResponse
    {
        public DataTableResponse() { }

        public DataTableResponse(int ITotalRecords, object Data)
        {
            this.ITotalRecords = ITotalRecords;
            AaData = Data;
        }

        public int ITotalRecords { get; set; }

        public int ITotalDisplayRecords => ITotalRecords;

        public object AaData { get; set; }

        public object Data => AaData;

    }
}
