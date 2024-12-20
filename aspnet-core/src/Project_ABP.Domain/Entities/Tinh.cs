using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Project_ABP.Entities
{
    public class Tinh : IFullAuditedObject
    {
        [Key]
        public int MaTinh { get; set; }
        public string TenTinh { get; set; }
        public string Cap { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? LastModifierId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
