using WebDriverPhelps.Data;
using WebDriverPhelps.Models;

namespace WebDriverPhelps.Repository
{
    public interface ISeleniumWeb
    {
        public void ExtrairRelatorioIndividual(int arId, DateTime dataini, DateTime datafim);
        public void RelatorioCompletoPorAC(int arId, DateTime dataini, DateTime datafim);
        public ArModel ListarPorId(int id);
        public IQueryable<ArModel> BuscarTodos();
        public IQueryable<ArModel> BuscarPorAC(int ac_id);
    }
}
