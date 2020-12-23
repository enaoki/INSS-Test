using INSS.DTO;
using System;

namespace INSS.Chain
{
    /// <summary>
    /// Apenas para ilustrar step para carregar os dados em memória
    /// para servir como cache e poder ser reutilizado em N chamadas do cálculo.
    /// 
    /// Deveria vir de algum storage como um banco de dados, por ex.
    /// </summary>
    class DadosHandler : BaseHandler
    {
        public override RequisicaoDTO Handle(RequisicaoDTO requisicao)
        {
            var item = new DescontoDTO()
            {
                Ano = 2011,
                Teto = 405.86m,
                MaiorSalario = 3689.66m
            };
            item.Itens.Add(new DescontoItemDTO() { Minimo = 0, Maximo = 1106.9m, Aliquota = 0.08m });
            item.Itens.Add(new DescontoItemDTO() { Minimo = 1106.91m, Maximo = 1844.83m, Aliquota = 0.09m });
            item.Itens.Add(new DescontoItemDTO() { Minimo = 1844.84m, Maximo = 3689.66m, Aliquota = 0.11m });

            requisicao.Descontos.Add(2011, item);

            item = new DescontoDTO()
            {
                Ano = 2012,
                Teto = 500,
                MaiorSalario = 4000
            };

            item.Itens.Add(new DescontoItemDTO() { Minimo = 0, Maximo = 1000, Aliquota = 0.07m });
            item.Itens.Add(new DescontoItemDTO() { Minimo = 1000.01m, Maximo = 1500, Aliquota = 0.08m });
            item.Itens.Add(new DescontoItemDTO() { Minimo = 1500.01m, Maximo = 3000, Aliquota = 0.09m });
            item.Itens.Add(new DescontoItemDTO() { Minimo = 3000.01m, Maximo = 4000, Aliquota = 0.11m });

            requisicao.Descontos.Add(2012, item);

            return base.Handle(requisicao);
        }
    }
}
