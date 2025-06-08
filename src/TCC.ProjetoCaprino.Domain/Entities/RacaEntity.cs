using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.ProjetoCaprino.Domain.Entities
{
    public class RacaEntity
    {
        public Guid Id { get; set; }
        public string Raca { get; set; }
        public bool IsDeleted { get; set; } = false;

        public void Update(string raca)
        {
            Raca = raca;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
