using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interface
{
    public interface IViewProductsByNameUseCase
    {
        Task<IEnumerable<Product>> ExecuteAsync(string name = "");
    }
}