using INSS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.Chain
{
    abstract class BaseHandler : IHandler
    {
        private IHandler next;

        public virtual RequisicaoDTO Handle(RequisicaoDTO requisicao)
        {
            if (next != null)
                return next.Handle(requisicao);
            
            return requisicao;
        }

        public IHandler SetNext(IHandler h)
        {
            next = h;

            return h;
        }
    }
}
