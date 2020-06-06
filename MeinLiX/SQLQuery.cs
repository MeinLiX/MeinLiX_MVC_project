using System;
using System.ComponentModel.DataAnnotations;

namespace MeinLiX
{
    public class SQLQuery
    {
        [Required(ErrorMessage = "Can't be null")]
        public string Symbol; 
        [Required(ErrorMessage = "Can't be null")]
        public int Number;
        [Required(ErrorMessage = "Can't be null")]
        public string Message1;
    }
}
