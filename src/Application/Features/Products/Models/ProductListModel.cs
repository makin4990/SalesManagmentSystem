using Application.Features.Products.Dtos;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Products.Models;
public class ProductListModel:BasePageableModel
{
    public IList<ProductDto> Items { get; set; }
}
