using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAllegro.Core.Models
{
    public class FilterAuction
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}
