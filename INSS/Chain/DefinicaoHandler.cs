using INSS.DTO;
using System;

namespace INSS.Chain
{
    class DefinicaoHandler : BaseHandler
    {
        public override RequisicaoDTO Handle(RequisicaoDTO requisicao)
        {
            if (requisicao.Descontos.Count == 0)
                throw new ArgumentException("Nenhum desconto carregado!");

            if (!requisicao.Descontos.ContainsKey(requisicao.Data.Year))
                throw new ArgumentException($"Nenhum dado encontrado para o ano {requisicao.Data.Year}");

            var desconto = requisicao.Descontos[requisicao.Data.Year];

            requisicao.DescontoCorrente = desconto;

            //  Se salário for maior, não precisa buscar alíquota
            if (requisicao.Salario <= desconto.MaiorSalario)
                foreach (var descontoItem in desconto.Itens)
                {
                    if (descontoItem.Minimo <= requisicao.Salario && requisicao.Salario <= descontoItem.Maximo)
                        requisicao.DescontoItemCorrente = descontoItem;
                }

            return base.Handle(requisicao);
        }
    }
}
