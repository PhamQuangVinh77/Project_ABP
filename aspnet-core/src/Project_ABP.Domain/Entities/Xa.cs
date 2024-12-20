using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Project_ABP.Entities
{
    public class Xa : IFullAuditedObject
    {
        [Key]
        public int MaXa { get; set; }
        public string TenXa { get; set; }
        public string Cap { get; set; }
        public int MaTinh { get; set; }
        public int MaHuyen { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? LastModifierId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
