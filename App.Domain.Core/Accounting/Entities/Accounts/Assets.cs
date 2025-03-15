using App.Domain.Core.Accounting.Entities.Accounts.Sub;
using App.Domain.Core.Accounting.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Accounting.Entities.Accounts
{
    public class Assets
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<AddAssets> AddAsset { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
