using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik5_0.Models.WebModel
{
    public class Excercise
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public int Solution { get; set; } 
        public int Answer { get; set; }
        public int ExcerciseCategoryID { get; set; }

        //Navigation Properties
        public ExcerciseCategory ExcerciseCategory { get; set; }
        
        

    }
}
