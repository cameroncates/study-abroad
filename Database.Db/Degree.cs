//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Degree
    {
        public int degreeId { get; set; }
        public string degreeTitle { get; set; }
        public string duration { get; set; }
        public string graduation { get; set; }
        public Nullable<int> courseId { get; set; }
        public Nullable<int> universityId { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual University University { get; set; }
    }
}
