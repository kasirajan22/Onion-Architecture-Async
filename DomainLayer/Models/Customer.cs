using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Models
{
   public class Customer
   {
        [Key]
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        
   }
}
