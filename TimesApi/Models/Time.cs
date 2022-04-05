using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesApi.Models
{
    public class Time
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        ICollection<TimeJogadores> TimeJogadores { get; set; }
    }
}
