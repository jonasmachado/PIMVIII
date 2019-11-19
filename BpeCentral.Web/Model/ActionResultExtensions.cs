using System;
using System.Linq;
using System.Web.Mvc;
using HomeworkBuddy.Dominio.Comum.Enum;

namespace HomeworkBuddy.Web.Model
{
    public static class ActionResultExtensions
    {
        public static ActionResult ComMensagem(this ActionResult actionResult, StatusSistemaEnum status, params string[] mensagens)
        {
            string mensagem = String.Empty;
            string classeAlert = String.Empty;

            switch (status)
            {
                case StatusSistemaEnum.Sucesso:
                    mensagem = "Salvo com sucesso.";
                    classeAlert = "alert-success";
                    break;
                case StatusSistemaEnum.Erro:
                    mensagem = "Ocorreu um erro.";
                    classeAlert = "alert-danger";
                    break;
                case StatusSistemaEnum.NaoEncontrado:
                    mensagem = "Nenhum registro encontrado.";
                    classeAlert = "alert-warning";
                    break;
                case StatusSistemaEnum.CadastradoComSucesso:
                    mensagem = "Cadastrado com Sucesso";
                    classeAlert = "alert-success";
                    break;
                default:
                    mensagem = "Mensagem não especificada.";
                    classeAlert = "alert-warning";
                    break;
            }

            if (mensagens != null && mensagens.Any())
            {
                if (mensagem.Count() > 1)
                    mensagem = String.Join("; ", mensagens);
                else
                    mensagem = mensagens.FirstOrDefault();
            }

            return new TempDataActionResult(actionResult, mensagem, classeAlert);
        }
    }
}