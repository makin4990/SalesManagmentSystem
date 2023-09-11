using CoreFramework.Persistence.Paging;

namespace Application.Features.Auths.Models;
public class UserListModel:BasePageableModel
{
    public IList<UserListModel> Items { get; set; }
}
