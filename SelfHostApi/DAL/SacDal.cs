using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SacHostApi.Model;

namespace SacHostApi.DAL
{
    public class SacDal
    {
        //private string connectionString = "server=localhost;User Id = root;database=sac; password=150290";
        private string connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public List<Sac> retornaSac()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand comando = new MySqlCommand("SELECT * FROM `sac`.`sac`", conn);
            List<Sac> lista = new List<Sac>();

            try
            {
                conn.Open();
                MySqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Sac sac = new Sac();

                        sac.Id = Convert.ToInt32(dr.GetValue(0));
                        sac.IdUsuario = Convert.ToInt32(dr.GetValue(1));
                        sac.Titulo = dr.GetValue(2).ToString();
                        sac.Descricao = dr.GetValue(3).ToString();
                        sac.Solucao = dr.GetValue(4).ToString();
                        sac.Status = dr.GetValue(5).ToString();

                        lista.Add(sac);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return lista;
        }

        //Insert
        public bool InsertSac(Sac objeto) 
        {
            bool retorno = false;
            MySqlConnection conn = new MySqlConnection(connectionString);            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" INSERT INTO `sac`.`sac` ");
            sb.AppendLine("            (`id`, ");            
            sb.AppendLine("            `idUsuario`, ");
            sb.AppendLine("            `titulo`, ");
            sb.AppendLine("            `descricao`, ");
            sb.AppendLine("            `solucao`, ");
            sb.AppendLine("            `status`) ");
            sb.AppendLine("            VALUES ");
            sb.AppendLine("            (null, ");
            sb.AppendFormat("            {0}, ", objeto.IdUsuario);
            sb.AppendFormat("            '{0}', ", objeto.Titulo);
            sb.AppendFormat("            '{0}', ", objeto.Descricao);
            sb.AppendFormat("            '{0}', ", objeto.Solucao);
            sb.AppendFormat("            '{0}'); ", objeto.Status);

            MySqlCommand comando = new MySqlCommand(sb.ToString(), conn);

            try
            {
                conn.Open();                
                comando.ExecuteNonQuery();
                long id = comando.LastInsertedId;

                if (id != 0)
                    retorno = true;
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally 
            {
                conn.Close();                
            }

            return retorno;
        }

        public bool UpdateSac(Sac objeto)
        {
            bool retorno = false;
            MySqlConnection conn = new MySqlConnection(connectionString);            
            StringBuilder sb = new StringBuilder();

            sb.Append(" UPDATE `sac`.`sac` ");
            sb.Append(" SET ");
            sb.AppendFormat(" `id` = {0}, ", objeto.Id);
            sb.AppendFormat(" `idUsuario` = {0}, ", objeto.IdUsuario);
            sb.AppendFormat(" `titulo` = '{0}', ", objeto.Titulo);
            sb.AppendFormat(" `descricao` = '{0}', ", objeto.Descricao);
            sb.AppendFormat(" `solucao` = '{0}', ", objeto.Solucao);
            sb.AppendFormat(" `status` = '{0}' ", objeto.Status);
            sb.AppendFormat(" WHERE `id` = {0}", objeto.Id);

            MySqlCommand comando = new MySqlCommand(sb.ToString(), conn);

            try
            {
                conn.Open();                
                comando.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception)
            {

                retorno =  false;
            }
            finally 
            {
                conn.Close();
            }

            return retorno;
        }
    }
}
