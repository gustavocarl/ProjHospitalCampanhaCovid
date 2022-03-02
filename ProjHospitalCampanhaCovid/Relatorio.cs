using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjHospitalCampanhaCovid
{
    internal class Relatorio
    {
        public float Febre { get; set; }
        public string Pressao { get; set; }
        public int Saturacao { get; set; }
        public DateTime DstaInicioSintomas { get; set; }
    }
}
