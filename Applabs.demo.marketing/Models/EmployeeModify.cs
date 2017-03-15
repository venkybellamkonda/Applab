using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Applabs.demo.marketing.Models
{
    [MetadataType(typeof(EmployeeModify))]
    public partial class Employee
    {

    }
    public class EmployeeModify
    {
        [DataType(DataType.Date)]
        public System.DateTime DateofBirth { get; set; }
    }
}