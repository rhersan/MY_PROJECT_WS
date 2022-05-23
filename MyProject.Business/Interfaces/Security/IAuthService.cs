using MyProject.Common;
using MyProject.Models.Common;
using MyProject.Models.Security;
using MyProject.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Business.Interfaces.Security
{
    public interface IAuthService
    {
        Task<LoginResponse<Tb_Usuarios>> Login(MyProject.Models.Login.Login login);
        Task<string> Authenticate(UserBase userBase);
        Task<AppSetting> GetAppSettings(UserBase userBase);
        Task<List<Topic>> GetTopics();
        Task<List<Label>> GetLabels(UserBase userBase);
    }
}
