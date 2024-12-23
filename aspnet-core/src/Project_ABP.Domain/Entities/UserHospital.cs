using System;
using System.ComponentModel.DataAnnotations;

namespace Project_ABP.Entities
{
    public class UserHospital
    {
        [Key]
        public Guid UserId { get; set; }
        public int HospitalId { get; set; }
    }
}
