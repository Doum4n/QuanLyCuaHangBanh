using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Producer
    {
        public int ID { get; set; }
        public string Name { get; set; } // Name of the producer
        public string PhoneNumber { get; set; } // Contact number of the producer
        public string Address { get; set; } // Address of the producer
        public string Email { get; set; } // Email of the producer
        public string Description { get; set; } // Description of the producer

        public static Producer Copy(Producer producer)
        {
            return new Producer
            {
                Name = producer.Name,
                PhoneNumber = producer.PhoneNumber,
                Address = producer.Address,
                Email = producer.Email,
                Description = producer.Description
            };
        }
    }
}
