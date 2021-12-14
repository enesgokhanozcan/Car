using System;
using System.Collections.Generic;

#nullable disable

namespace Car.DB.Entities
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Idate { get; set; }
        public DateTime? Udate { get; set; }
        public int? Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual User IuserNavigation { get; set; }
    }
}
