using CoreFramework.Persistence.Paging;

namespace Application.Features.Users.Models;
public class UserListModel:BasePageableModel
{
    public IList<UserListModel> Items { get; set; }
}
