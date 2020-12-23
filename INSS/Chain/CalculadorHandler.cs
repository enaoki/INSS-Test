using INSS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.Chain
{
    class CalculadorHandler : BaseHandler
    {
        public override RequisicaoDTO Handle(RequisicaoDTO requisicao)
        {
            if (requisicao.DescontoCorrente == null)
                throw new ArgumentNullException("Nenhum desconto corrente foi carregado!");

            if (requisicao.DescontoItemCorrente == null)
                throw new ArgumentNullException("Nenhum item de desconto corrente foi carregado!");

            if (requisicao.Salario > requisicao.DescontoCorrente.MaiorSalario)
                requisicao.Resultado = requisicao.DescontoCorrente.Teto;
            else
                requisicao.Resultado = requisicao.DescontoItemCorrente.Aliquota * requisicao.Salario;

            return base.Handle(requisicao);
        }
    }
}
