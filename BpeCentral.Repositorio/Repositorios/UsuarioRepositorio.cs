
using BpeCentral.Dominio;
using BpeCentral.Dominio.Interfaces.Repositorio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace BpeCentral.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseCrudDao<BPE_USUARIOS>, IUsuarioRepositorio
    {
        public BPE_USUARIOS Login(string login, string senha)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_USUARIOS>().FirstOrDefault(p => p.EMAIL == login && p.SENHA == senha && p.ATIVO == true);
            }
        }

        public BPE_USUARIOS Obter(string email)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_USUARIOS>().FirstOrDefault(p => p.EMAIL == email);
            }
        }

        public int? ObterCodigoEmitente(int id)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_USUARIOS>().Where(p => p.ID == id).Select(x => x.CODIGO_EMPRESA).FirstOrDefault();
            }
        }

        public void DeletarUsuario(int id)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var usr = context.Set<BPE_USUARIOS>().FirstOrDefault(p => p.ID == id);
                context.Entry(usr).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
