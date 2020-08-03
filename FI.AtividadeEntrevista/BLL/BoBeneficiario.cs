using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            return bnf.Incluir(beneficiario);
        }

        /// <summary>
        /// Lista os beneficiários
        /// </summary>
                public List<DML.Beneficiario> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            return bnf.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// Excluir o beneficiario pelo id
        /// </summary>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            bnf.Excluir(id);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            return bnf.VerificarExistencia(CPF);
        }

        /// <summary>
        /// Consulta o beneficiário pelo id
        /// </summary>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            return bnf.Consultar(id);
        }

        /// <summary>
        /// Altera um beneficiário
        /// </summary>
        public void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario bnf = new DAL.DaoBeneficiario();
            bnf.Alterar(beneficiario);
        }

    }
}