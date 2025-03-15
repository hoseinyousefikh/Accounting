using App.Domain.Core.Accounting.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.PMEList
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }

    }
}