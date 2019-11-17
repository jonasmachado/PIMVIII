using BpeCentral.Dominio;
using System.Data.Entity.ModelConfiguration;


namespace BpeCentral.Repositorio.EntityConfiguracao
{
    public class ConfiguracaoDeUsuario : EntityTypeConfiguration<BPE_USUARIOS>
    {
        public ConfiguracaoDeUsuario()
        {
            Property(c => c.NOME)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
