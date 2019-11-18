using AutoMapper;

namespace MyPOS.Dominio.Mappers
{
    public class AutoMapperConfiguracao
    {
        public static void RegistraMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DTOparaEntidade>();
                x.AddProfile<EntidadeParaDTO>();
            });
        }
    }
}
