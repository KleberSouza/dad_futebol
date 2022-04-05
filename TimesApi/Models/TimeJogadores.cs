using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimesApi.Models
{
    public class TimeJogadores
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TimeId { get; set; }
        public Guid JogadorId { get; set; }
    }
}
