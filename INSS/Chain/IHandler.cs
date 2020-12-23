using INSS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.Chain
{
    interface IHandler
    {
        IHandler SetNext(IHandler h);

        RequisicaoDTO Handle(RequisicaoDTO requisicao);
    }
}
