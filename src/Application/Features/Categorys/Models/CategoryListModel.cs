using Application.Features.Categorys.Dtos;
using CoreFramework.Persistence.Paging;

namespace Application.Features.Categorys.Models;
public class CategoryListModel:BasePageableModel
{
    public IList<CategoryDto> Items { get; set; }
}
