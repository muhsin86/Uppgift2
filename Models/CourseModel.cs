using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgift2.Models
{
    public class CourseModel
    {
        // Properties
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Progression { get; set; }
        public CourseModel()
        {
        }
    }
}
