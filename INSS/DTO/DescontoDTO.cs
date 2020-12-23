using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS.DTO
{
    class DescontoDTO
    {
        public int Ano { get; set; }

        public decimal Teto { get; set; }

        public decimal MaiorSalario { get; set; }

        private List<DescontoItemDTO> _Itens;
        public List<DescontoItemDTO> Itens
        {
            get
            {
                if (_Itens == null)
                    _Itens = new List<DescontoItemDTO>();

                return _Itens;
            }
        }
    }
}
