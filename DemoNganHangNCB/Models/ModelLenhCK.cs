using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class ModelLenhCK<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public DataWrapper<T> data { get; set; }
    }

    public class DataWrapper<T>
    {
        public Pagination pagination { get; set; }
        public List<T> content { get; set; }
        public bool canShowPayrollDetail { get; set; }
    }

    public class Pagination
    {
        public int currentPage { get; set; }
        public int size { get; set; }
        public int totalPages { get; set; }
        public int numberOfElements { get; set; }
        public int totalElements { get; set; }
    }

}
