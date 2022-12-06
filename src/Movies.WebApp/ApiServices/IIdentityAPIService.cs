using Movies.WebApp.ViewModels;

namespace Movies.WebApp.ApiServices;

public interface IIdentityAPIService
{
    Task<UserInfoViewModel> GetUserInfo();
}
