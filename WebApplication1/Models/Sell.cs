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
    
    public partial class Sell
    {
        public int Id { get; set; }
        [Required]
        public string Sell_name { get; set; }
        [Required]
        public string Sell_contact { get; set; }
        [Required]
        public string Sell_group { get; set; }
        [Required]
        public string Sell_count { get; set; }
        [Required]
        public string Sell_fee { get; set; }
        public Nullable<System.DateTime> Sell_date { get; set; }
    }
}
