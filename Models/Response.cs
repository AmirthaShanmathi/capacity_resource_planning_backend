using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public tblcrpdb user { get; set; }
        public List<tblcrpdb> listUsers { get; set; }
    }
}