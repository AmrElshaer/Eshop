using WebMVC.Models;

namespace WebMVC.IServices
{
    public interface ICatalogService
    {
        Task<CatalogModel> CreateCatalog(CatalogModel model);
        Task<IEnumerable<CatalogModel>> GetCatalog();
        Task<CatalogModel> GetCatalog(string id);
        Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category);
    }
}
