using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Infrastructure
{
    public class Response<T>
    {
        public Transaction TransactionStatus { get; set; }

        public T Data { get; set; }

    }

    public class Transaction
    {

        public bool IsSuccess { get; set; }

        public Error Error { get; set; }
    }

    public class Error
    {

        public int Code { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

    }


}
