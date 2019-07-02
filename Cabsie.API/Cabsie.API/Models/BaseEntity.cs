using System;
using System.ComponentModel.DataAnnotations;

namespace Cabsie.API.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

}
