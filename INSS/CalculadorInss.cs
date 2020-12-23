using INSS.Chain;
using INSS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        private RequisicaoDTO Validar(DateTime data, decimal salario)
        {
            if (data == null)
                throw new ArgumentNullException("Nenhuma data informada");

            if (salario < 0)
                throw new ArgumentOutOfRangeException("Salário informado deve ser maior do que zero");

            return new RequisicaoDTO()
            {
                Data = data,
                Salario = salario
            };
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            RequisicaoDTO requisicao = Validar(data, salario);

            var etapa1 = new DadosHandler();
            var etapa2 = new DefinicaoHandler();
            var etapa3 = new CalculadorHandler();

            etapa1.SetNext(etapa2).SetNext(etapa3);

            etapa1.Handle(requisicao);

            return requisicao.Resultado;
        }
    }
}
