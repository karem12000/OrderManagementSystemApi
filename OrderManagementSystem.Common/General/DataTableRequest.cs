using Microsoft.Data.SqlClient;

namespace OrderManagementSystem
{
    public class DataTableRequest
    {
        #region Private

        private int _length = 0;
        private int _start;
        private string? _search = null;

        #endregion


        public int IColumns { get; set; }

        public string SColumns { get; set; }


        public int IDisplayStart
        {
            get => _start;
            set
            {
                if (value != 0)
                {
                    _start = value;
                }
            }
        }

        public int Start
        {
            get => _start;
            set
            {
                if (value != 0)
                {
                    _start = value;
                }
            }
        }

        public int IDisplayLength
        {
            get => _length; set
            {
                if (value != 0)
                {
                    _length = value;
                }
            }
        }

        public int Length
        {
            get => _length; set
            {
                if (value != 0)
                {
                    _length = value;
                }
            }
        }

        public string MDataProp_0 { get; set; }

        public bool BSortable_0 { get; set; }

        public int ISortCol_0 { get; set; }

        public SortingDir SSortDir_0 { get; set; }

        public int ISortingCols { get; set; }

        public string SSearch
        {
            get => _search;
            set
            {
                if (value != null)
                {
                    _search = value;
                }
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                if (value != null)
                {
                    _search = value;
                }
            }
        }




        public SqlParameter[] ToSqlParameter(params SqlParameter[] sqlParameters)
        {
            List<SqlParameter> _list = new List<SqlParameter>
            {
                new SqlParameter() { ParameterName = "@DisplayLength", Value = IDisplayLength },
                new SqlParameter() { ParameterName = "@DisplayStart", Value = IDisplayStart },
                new SqlParameter() { ParameterName = "@SortCol", Value = ISortCol_0 },
                new SqlParameter() { ParameterName = "@SortDir", Value = SSortDir_0.ToString().ToLower() },
                new SqlParameter() { ParameterName = "@Search", Value = SSearch },
            };


            if (sqlParameters != null)
            {
                _list.AddRange(sqlParameters);
            }
            return _list.ToArray();
        }


    }

    public enum SortingDir { asc, Desc }
}
