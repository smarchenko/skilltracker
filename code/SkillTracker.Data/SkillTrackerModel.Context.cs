﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SkillTrackerContext : DbContext
    {
        public SkillTrackerContext()
            : base("name=SkillTrackerContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<PositionSkillGroup> PositionSkillGroup { get; set; }
        public DbSet<Quarter> Quarter { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillGroup> SkillGroup { get; set; }
        public DbSet<SkillLevel> SkillLevel { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamPosition> TeamPosition { get; set; }
        public DbSet<TeamSkillGroup> TeamSkillGroup { get; set; }
        public DbSet<UserPosition> UserPosition { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
    }
}
