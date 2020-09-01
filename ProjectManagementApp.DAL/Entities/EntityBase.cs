using System;
using ProjectManagementApp.DAL.Interfaces;

namespace ProjectManagementApp.DAL.Entities
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}