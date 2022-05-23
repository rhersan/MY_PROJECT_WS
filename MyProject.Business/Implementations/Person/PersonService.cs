using Dapper;
using MyProject.Business.Interfaces.Person;
using MyProject.Common;
using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.Person
{
    public class PersonService : IPersonService
    {

        /// <summary>
        /// Servicio para crear una persona física
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HttpGenericResponseNoData> InsertOne(Models.Persons.Tb_PersonasFisicas person)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();
            // Limpiamos caracteres con trim
            person.Nombre = person.Nombre == null ? string.Empty : person.Nombre.Trim();
            person.ApellidoPaterno = person.ApellidoPaterno == null ? string.Empty : person.ApellidoPaterno.Trim();
            person.ApellidoMaterno = person.ApellidoMaterno == null ? string.Empty : person.ApellidoMaterno.Trim();

            try
            {
            
                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@Nombre", person.Nombre);
                    param.Add("@ApellidoPaterno", person.ApellidoPaterno);
                    param.Add("@ApellidoMaterno", person.ApellidoMaterno);
                    param.Add("@RFC", person.RFC);
                    param.Add("@FechaNacimiento", person.FechaNacimiento.ToString("yyyy/MM/dd"));
                    param.Add("@UsuarioAgrega", person.UsuarioAgrega);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("sp_AgregarPersonaFisica",
                            param,
                            commandType: CommandType.StoredProcedure
                            );

                    result.errorCode = res.AsList()[0].ERROR;
                    result.message = res.AsList()[0].MENSAJEERROR;
                    result.retur_value = param.Get<int>("@return_value");

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

            if (result.retur_value == 0)
            {
                return new HttpGenericResponseNoData(Constraints.SystemCodes.Ok, ConstantMessages.SuccessfulInsertMessage);

            }
            else
            {
                return new HttpGenericResponseNoData(Constraints.SystemCodes.RecordCreateInternalError, result.message);

            }

        }


        public async Task<HttpGenericResponse<Models.Persons.Tb_PersonasFisicas>> GetObjectWithRefs(int id)
        {
            ResultStoredProcedure resp = new ResultStoredProcedure();
            var result = new GenericResponse<Models.Persons.Tb_PersonasFisicas>();
            Models.Persons.Tb_PersonasFisicas objPerson = new Models.Persons.Tb_PersonasFisicas();
            try
            {

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdPersonaFisica", id);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var query = await con.QueryAsync<Models.Persons.Tb_PersonasFisicas>("sp_ObtenerPersonaFisica",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    objPerson = query.AsList()[0];
                    resp.retur_value = param.Get<int>("@return_value");
                    if (resp.retur_value == 0 && objPerson.IdPersonaFisica != null && objPerson.IdPersonaFisica > 0)
                    {
                        result.Data = new Models.Persons.Tb_PersonasFisicas();
                        result.Data.IdPersonaFisica = objPerson.IdPersonaFisica;
                        result.Data.Nombre = objPerson.Nombre;
                        result.Data.ApellidoPaterno = objPerson.ApellidoPaterno;
                        result.Data.ApellidoMaterno = objPerson.ApellidoMaterno;
                        result.Data.RFC = objPerson.RFC;
                        result.Data.FechaNacimiento = objPerson.FechaNacimiento;
                        result.Data.Activo = objPerson.Activo;

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

            result.Data = objPerson;
            if (result.Data != null)
            {
                result.Code = SystemCodes.Ok;
            }
            else
            {
                result.Code = SystemCodes.NoContent;
                result.Data = new Models.Persons.Tb_PersonasFisicas();
            }

            return new HttpGenericResponse<Models.Persons.Tb_PersonasFisicas>(result.Code,
                                                              result.Data,
                                                              result.Code.ToString(),
                                                              result.TotalRows);
        }


        public async Task<HttpGenericResponse<List<Models.Persons.Tb_PersonasFisicas>>> GetList(Filter<Models.Persons.Tb_PersonasFisicas> filter)
        {
            var result = new GenericResponse<List<Models.Persons.Tb_PersonasFisicas>>();
            List<Models.Persons.Tb_PersonasFisicas> listPerons = new List<Models.Persons.Tb_PersonasFisicas>();

            try
            {

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var query = await con.QueryAsync<Models.Persons.Tb_PersonasFisicas>("getPersons",
                            null,
                            commandType: CommandType.StoredProcedure
                            );
                    listPerons = query.AsList();

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

            result.TotalRows = listPerons.Count;
            result.Data = listPerons;

            if (result.Data != null)
            {
                result.Code = SystemCodes.Ok;
                result.Message = SystemCodes.Ok.ToString();
            }
            else
            {
                result.Code = SystemCodes.NoContent;
                result.Data = new List<Models.Persons.Tb_PersonasFisicas>();
                result.Message = ConstantMessages.NoContentList;
            }

            return new HttpGenericResponse<List<Models.Persons.Tb_PersonasFisicas>>(result.Code,
                    result.Data,
                    result.Message,
                    result.TotalRows);
        }

        /// <summary>
        /// Servicio para actualizar persona física
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<HttpGenericResponseNoData> UpdateOne(Models.Persons.Tb_PersonasFisicas person)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();
            
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdPersonaFisica", person.IdPersonaFisica);
                    param.Add("@Nombre", person.Nombre);
                    param.Add("@ApellidoPaterno", person.ApellidoPaterno);
                    param.Add("@ApellidoMaterno", person.ApellidoMaterno);
                    param.Add("@RFC", person.RFC);
                    param.Add("@FechaNacimiento", person.FechaNacimiento.ToString("yyyy/MM/dd"));
                    param.Add("@UsuarioAgrega", person.UsuarioAgrega);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("sp_ActualizarPersonaFisica",
                            param,
                            commandType: CommandType.StoredProcedure
                            );

                    result.errorCode = res.AsList()[0].ERROR;
                    result.message = res.AsList()[0].MENSAJEERROR;
                    result.retur_value = param.Get<int>("@return_value");

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


            if (result.retur_value == 0)
            {
                return new HttpGenericResponseNoData(SystemCodes.Ok, ConstantMessages.SuccessfulUpdateMessage);
            }
            else
            {
                return new HttpGenericResponseNoData(SystemCodes.RecordUpdateInternalError, ConstantMessages.ErrorUpdateMessage);
            }
        }



        public async Task<HttpGenericResponseNoData> DeleteOne(int id)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();
            System.Linq.Expressions.Expression<Func<Models.Persons.Tb_PersonasFisicas, bool>> _filter = a => true;

            _filter = _filter = a => a.IdPersonaFisica == id;

            try
            {
                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@IdPersonaFisica", id);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("sp_EliminarPersonaFisica",
                            param,
                            commandType: CommandType.StoredProcedure
                            );

                    result.errorCode = res.AsList()[0].ERROR;
                    result.message = res.AsList()[0].MENSAJEERROR;
                    result.retur_value = param.Get<int>("@return_value");

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


            if (result.retur_value == 0)
            {
                if (result.errorCode > 0)
                {
                    return new HttpGenericResponseNoData(SystemCodes.Ok, ConstantMessages.SuccessfulDeleteMessage);
                }
                else
                {
                    return new HttpGenericResponseNoData(
                        SystemCodes.RecordDeleteInternalError,
                        ConstantMessages.ErrorDeleteMessage);
                }
            }
            else
            {
                return new HttpGenericResponseNoData(
                         SystemCodes.RecordDeleteInternalError,
                         ConstantMessages.ErrorDeleteMessage);
            }

            return new HttpGenericResponseNoData(SystemCodes.InternalError, ConstantMessages.GeneralError);
        }




    }
}
