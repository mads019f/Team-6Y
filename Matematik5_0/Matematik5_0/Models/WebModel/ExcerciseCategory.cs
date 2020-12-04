using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matematik5_0.Models.WebModel
{

    public class ExcerciseCategory
    {
        public int ID { get; set; }
        public enum Difficulty {Easy, Medium, Hard}
        public string Title { get; set; }

        //Navigation Properties
        public List<Excercise> Excercises { get; set; }


       
    }
}
