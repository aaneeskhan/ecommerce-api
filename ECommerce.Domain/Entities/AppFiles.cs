using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class AppFiles :BaseEntity
    {
        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public bool IsVideo { get; set; } = false;

        public AppModule AppModule { get; set; }

        public Guid EntityId { get; set; }
    }
}
