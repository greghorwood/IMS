using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interface
{
    public interface IViewProductByIdUseCase
    {
        Task<Product?> ExecuteAsync(int productId);
    }
}