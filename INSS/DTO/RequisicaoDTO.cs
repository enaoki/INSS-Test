using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.DTO
{
    /// <summary>
    /// DTO de contexto para fluir pela cadeia de responsabilidades
    /// Ideia é manter a memória de cálculo
    /// </summary>
    class RequisicaoDTO
    {
        public DateTime Data { get; set; }

        public decimal Salario { get; set; }

        private Dictionary<int, DescontoDTO> _Descontos;
        public Dictionary<int, DescontoDTO> Descontos
        {
            get
            {
                if (_Descontos == null)
                    _Descontos = new Dictionary<int, DescontoDTO>();

                return _Descontos;
            }
        }

        public DescontoDTO DescontoCorrente { get; set; }
        public DescontoItemDTO DescontoItemCorrente { get; set; }

        public decimal Resultado { get; set; }
    }
}
