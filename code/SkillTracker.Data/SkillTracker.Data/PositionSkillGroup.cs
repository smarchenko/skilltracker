//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkillTracker.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PositionSkillGroup
    {
        public System.Guid Id { get; set; }
        public System.Guid PositionId { get; set; }
        public System.Guid GroupId { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual SkillGroup SkillGroup { get; set; }
    }
}