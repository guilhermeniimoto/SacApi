using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacHostApi.Model
{
    public class Sac
    {
        private int id = 0;
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private int idUsuario = 0;
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private string titulo = string.Empty;
        public string Titulo 
        {
            get { return titulo; }
            set { titulo = value; }
        }        

        private string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }       

        private string solucao = string.Empty;
        public string Solucao
        {
            get { return solucao; }
            set { solucao = value; }
        }

        private string status = string.Empty;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}
