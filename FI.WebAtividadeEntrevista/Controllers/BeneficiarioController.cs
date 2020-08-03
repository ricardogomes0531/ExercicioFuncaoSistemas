using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        // GET: Beneficiario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            string message = string.Empty;
            BoBeneficiario bnf = new BoBeneficiario();
            model.Id = bnf.Incluir(new Beneficiario()
            {
                CPF = model.CPF,
                IdCliente = model.IdCliente,
                Nome = model.Nome
            });
                if (model.Id > 0)
                message = "Beneficiário cadastrado com sucesso!";
            return Json(new { message = message });
        }

        
        public JsonResult BeneficiarioList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Beneficiario> beneficiarios = new BoBeneficiario().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd).Where(x => x.IdCliente == Convert.ToInt64(Session["idCliente"].ToString())).ToList();

                //Return result to jTable
                return Json(new { Result = "OK", Records = beneficiarios, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public ActionResult Excluir(long id)
        {
            BoBeneficiario bnf = new BoBeneficiario();
            bnf.Excluir(id);
            return View("Index");
        }

            public JsonResult VerificarCPF(string cpf)
            {
                string message = string.Empty;
                BoBeneficiario beneficiario = new BoBeneficiario();
                if (beneficiario.VerificarExistencia(cpf))
                {
                    message = "Este CPF já existe no sistema.";
                }
                return Json(new { message = message }, JsonRequestBehavior.AllowGet);
            }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoBeneficiario bnf = new BoBeneficiario();
            Beneficiario beneficiario = bnf.Consultar(id);
            Models.BeneficiarioModel model = null;

            if (beneficiario != null)
            {
                model = new BeneficiarioModel()
                {
                    Id = beneficiario.Id,
                    CPF = beneficiario.CPF,
                    Nome = beneficiario.Nome,
                    IdCliente = beneficiario .IdCliente
                };
            }
            return View(model);
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            BoBeneficiario bo = new BoBeneficiario();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Beneficiario()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    IdCliente = model.IdCliente,
                    CPF = model.CPF
                });

                return Json("Cadastro do beneficiário alterado com sucesso");
            }
        }

    }
}