using FESVIP.CPA.DATA.classes;
using FESVIP.CPA.DATA.classes.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Cpa _cpa = new Cpa();
            _cpa.DataFim = DateTime.Now.AddDays(10);
            _cpa.DataInicio = DateTime.Now;
            _cpa.PERIODO_LETIVO = 1;

            using(Context contexto = new Context())
            {
                contexto.Cpas.Add(_cpa);
                contexto.SaveChanges();
            }

        }
    }
}
