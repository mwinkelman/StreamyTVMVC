//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StreamyTVMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Show
    {
        public int ShowID { get; set; }
        public string ShowName { get; set; }
        public int NetworkID { get; set; }
        public int Seasons { get; set; }
        public string Genre { get; set; }
        public string ShowImage { get; set; }
        public string ShowDescription { get; set; }
        public string CarouselImage { get; set; }
    
        public virtual Network Network { get; set; }
    }
}
