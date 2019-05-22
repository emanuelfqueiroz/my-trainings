using BlueMine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMine.Services
{
    public class CargoService
    {
        public List<Cargo> Listar(string filtro)
        {
            var ctx = new BlueMine.Model.BluemineContext();

            var cargos = ctx.Cargo.AsQueryable();

            if (!String.IsNullOrEmpty(filtro))
            {
                cargos = cargos.Where(x => x.Nome.StartsWith(filtro));
            }
            return cargos.ToList();

        }
    }
}
