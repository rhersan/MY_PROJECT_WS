using AutoMapper;
using MyProject.Business.Interfaces.Security;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MyProject.Common;
using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using MyProject.Models.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.Security
{
    public class AuthService : IAuthService
    {

        private const string collectionName = nameof(MyProject.Models.Users);
        //private const string collectionNameRole = nameof(Models.Roles);
        //private const string collectionNameAppVersion = nameof(Models.AppVersions);

        //private readonly IMongoCollection<Models.Roles.Role> rolesCollection;

        private readonly IMapper _mapper;

        public AuthService(IMapper mapper)
        {
            _mapper = mapper;

            var client = new MongoClient(StaticConfig.MongoDBConnectionString);
            var database = client.GetDatabase(StaticConfig.MongoDBDatabaseName);
        }

        public async Task<string> Authenticate(MyProject.Models.Users.Tb_Usuarios user)
        {
            try
            {
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(StaticConfig.JWTSecret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(nameof(user.Id), user.Id.ToString()),
                            new Claim(nameof(user.Nombre), (user.Nombre==null)?"":user.Nombre),
                            new Claim(nameof(user.Usuario), user.Usuario.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddHours(StaticConfig.JWTExpirationTime),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                if (user.Token == null)
                {
                    throw new Exception(SystemCodes.GetTokenError.ToString());
                }

                return await Task.FromResult<string>(user.Token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<AppSetting> GetAppSettings(UserBase userBase)
        {
            throw new NotImplementedException();
        }


        public Task<List<Topic>> GetTopics()
        {
            throw new NotImplementedException();
        }

        public Task<List<Label>> GetLabels(UserBase userBase)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizaSesion(UserBase userBase, LogType logType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidaSesion(UserBase userBase)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidaEmpresa(string Alias)
        {
            throw new NotImplementedException();
        }

        public Task<string> Authenticate(UserBase userBase)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Opción 1: LogIn desde BackOffice.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<LoginResponse<MyProject.Models.Users.Tb_Usuarios>> Login(MyProject.Models.Login.Login login)
        {
            //hacer consulta a la BD
            ResultStoredProcedure response = new ResultStoredProcedure();
            var result = new GenericResponse<MyProject.Models.Users.Tb_Usuarios>();
            MyProject.Models.Users.Tb_Usuarios objUsuario = new MyProject.Models.Users.Tb_Usuarios();
            try
            {

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@Usuario", login.username);
                    param.Add("@Password", login.password);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var query = await con.QueryAsync<MyProject.Models.Users.Tb_Usuarios>("sp_login",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    objUsuario = query.FirstOrDefault();
                    response.retur_value = param.Get<int>("@return_value");
                    if (response.retur_value == 0 && objUsuario.Usuario != null)
                    {
                        result.Data = new Models.Users.Tb_Usuarios();
                        result.Data.Id = objUsuario.Id;
                        result.Data.Nombre = objUsuario.Nombre;
                        result.Data.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        result.Data.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        result.Data.Usuario = objUsuario.Usuario;
                        result.Data.Status = objUsuario.Status;

                    }

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        con.Dispose();
                    }

                }
            }
            catch (Exception ex)
            {
                // guardar log
            }

            if (response.errorCode == 0 && result.Data != null)
            {
                if (result.Data.Status == 0)
                {
                    result.Code = SystemCodes.InactiveProfile;
                    result.Message = SystemCodes.InactiveProfile.ToString();
                }
                else if (result.Data.Status == 1)
                {
                    result.Code = SystemCodes.SuccessfulLogin;
                    result.Message = SystemCodes.SuccessfulLogin.ToString();

                    result.Data.Token = await Authenticate(result.Data);
                    if (result.Data.Token == null)
                    {
                        throw new Exception(SystemCodes.GetTokenError.ToString());
                    }
                }
            }
            else
            {
                result.Data = new Models.Users.Tb_Usuarios();
                result.Code = SystemCodes.InvalidCredentials;
                result.Message = SystemCodes.InvalidCredentials.ToString();
            }
            return new LoginResponse<Models.Users.Tb_Usuarios>(
                    result.Code,
                    result.Data,
                    result.Code.ToString(),
                    result.TotalRows);

        }


    }
}
