using System;
using System.ComponentModel.DataAnnotations;

namespace Cabsie.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

}
