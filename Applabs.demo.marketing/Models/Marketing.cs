//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Applabs.demo.marketing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    
    public partial class Marketing
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string MarketerName { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
        public string CaseStatus { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CloseDate { get; set; }

        public List<Employee> emplo { get; set; }
        public List<Employee> market { get; set; }
    }
}