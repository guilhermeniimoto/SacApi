using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using SacHostApi.Model;
using SacHostApi.DAL;



namespace SacHostApi.Controller
{
    public class SacController : ApiController
    {
        
        [HttpGet]
        public IEnumerable<Sac> Get()
        {
            List<Sac> _sac = new List<Sac>();
            SacDal _sacDal = new SacDal();
            _sac = _sacDal.retornaSac();
            return _sac;
        }

        [HttpGet]
        public Sac Get(int id)
        {
            List<Sac> _sac = new List<Sac>();
            SacDal _sacDal = new SacDal();
            _sac = _sacDal.retornaSac();
            return _sac.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public string Post(Sac _sac) 
        {            
            SacDal _sacDal = new SacDal();            
            _sac.Solucao = string.Empty;
            _sac.Status = "Em aberto";
            bool retorno = _sacDal.InsertSac(_sac);
            return retorno.ToString();
        }

        [HttpPut]
        public string Put(int id, Sac _sac)
        {            
            SacDal _sacDal = new SacDal();
            _sac.Id = id;
            bool retorno = _sacDal.UpdateSac(_sac);
            return retorno.ToString();
        }



    }
}
