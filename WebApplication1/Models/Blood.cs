//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Blood
    {
        public int Id { get; set; }
        [Required]
        public string Blood_group { get; set; }
        [Required]
        public string Blood_quantity { get; set; }
        [Required]
        public string Blood_fee { get; set; }
    }
}
