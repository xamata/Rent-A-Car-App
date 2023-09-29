using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAppLibrary.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public int CarTypeId { get; set; }
        public string License { get; set; }
    }
}
