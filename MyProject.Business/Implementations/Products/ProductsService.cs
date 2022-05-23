using Dapper;
using MyProject.Business.Interfaces.Products;
using MyProject.Common;
using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using MyProject.Models.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.Products
{
    public class ProductsService : IProductsService
    {
        public ProductsService()
        {

        }

        public async Task<HttpGenericResponse<List<ADM_PRODUCTS>>> GetList(int idCategory)
        {
            var result = new GenericResponse<List<ADM_PRODUCTS>>();

            List<ADM_PRODUCTS> productos = new List<ADM_PRODUCTS>();


            try
            {
                string query = string.Empty;
                if (idCategory != 0)
                    query = string.Format("SELECT * FROM ADM_PRODUCTS WITH(NOLOCK) WHERE IdCategory = {0} AND Status = 1 ", idCategory);
                else
                    query = "SELECT * FROM ADM_PRODUCTS WITH(NOLOCK) WHERE Status = 1 ";

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {

                    con.Open();
                    var sqlQuery = await con.QueryAsync<ADM_PRODUCTS>(query);
                    productos = sqlQuery.ToList();
                    con.Close();
                    con.Dispose();
                }

                productos.ForEach(car => Console.WriteLine(car));

            }
            catch (Exception ex)
            {

            }




            result.Data = productos;

            result.TotalRows = productos.Count();

            if (result.Data != null)
            {
                result.Code = SystemCodes.Ok;
                result.Message = SystemCodes.Ok.ToString();
            }
            else
            {
                result.Code = SystemCodes.NoContent;
                result.Data = new List<ADM_PRODUCTS>();
                result.Message = ConstantMessages.NoContentList;
            }

            return new HttpGenericResponse<List<ADM_PRODUCTS>>(result.Code,
                    result.Data,
                    result.Message,
                    result.TotalRows);
        }


        /// <summary>
        /// Servicio para crear una persona física
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HttpGenericResponseNoData> InsertOne(ADM_PRODUCTS obj)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();
            // Limpiamos espacios en blanco
            obj.Product = obj.Product == null ? string.Empty : obj.Product.Trim();
            obj.Ingredients = obj.Ingredients == null ? string.Empty : obj.Ingredients.Trim();

            try
            {

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();
                    obj.ImgSrc = string.Empty;
                    var param = new DynamicParameters();
                    param.Add("@product", obj.Product);
                    param.Add("@ingredients", obj.Ingredients);
                    param.Add("@weight", obj.Weight);
                    param.Add("@calories", obj.Calories);
                    param.Add("@price", obj.Price);
                    param.Add("@imgSrc", obj.ImgSrc);
                    param.Add("@idCategory", obj.IdCategory);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("agregarProducto",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    var resp = res.AsList().FirstOrDefault();
                    result.errorCode_s = resp.ERROR.ToString();
                    result.message = resp.MENSAJEERROR;
                    result.retur_value_s = param.Get<string>("@return_value");

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
                // Se puede implementer ErrorHandler para guardar los logs
            }

            if (result.retur_value_s != null && result.retur_value_s.Length >= 0)
            {
                return new HttpGenericResponseNoData(SystemCodes.Ok, ConstantMessages.SuccessfulInsertMessage);

            }
            else
            {
                return new HttpGenericResponseNoData(SystemCodes.RecordCreateInternalError, result.message);

            }

        }



        public async Task<HttpGenericResponse<ADM_PRODUCTS>> GetObjectWithRefs(string id)
        {
            ResultStoredProcedure resp = new ResultStoredProcedure();
            var result = new GenericResponse<ADM_PRODUCTS>();
            ADM_PRODUCTS obj = new ADM_PRODUCTS();
            try
            {

                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@idProduct", id);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var query = await con.QueryAsync<ADM_PRODUCTS>("obtenerProductoId",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    obj = query.AsList().FirstOrDefault();

                    resp.retur_value = param.Get<int>("@return_value");
                    if (resp.retur_value == 0 && obj.Id.ToString().Length > 0)
                    {
                        result.Data = obj;
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

            if (result.Data != null && result.Data.Id != null | result.Data.Id.ToString().Length > 0)
            {
                result.Code = SystemCodes.Ok;
            }
            else
            {
                result.Code = SystemCodes.NoContent;
                result.Data = new ADM_PRODUCTS();
            }

            return new HttpGenericResponse<ADM_PRODUCTS>(result.Code,
                                                              result.Data,
                                                              result.Code.ToString(),
                                                              result.TotalRows);
        }


        /// <summary>
        /// Servicio para actualizar persona física
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<HttpGenericResponseNoData> UpdateOne(ADM_PRODUCTS person)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();

            try
            {
                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@idProduct", person.Id.ToString());
                    param.Add("@product", person.Product);
                    param.Add("@ingredients", person.Ingredients);
                    param.Add("@weight", person.Weight);
                    param.Add("@calories", person.Calories);
                    param.Add("@price", person.Price);
                    param.Add("@imgSrc", person.ImgSrc);
                    param.Add("@idCategory", person.IdCategory);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("actualizarProducto",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    result.errorCode_s = res.AsList()[0].ERROR.ToString();
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


        public async Task<HttpGenericResponseNoData> DeleteOne(string id)
        {
            ResultStoredProcedure result = new ResultStoredProcedure();
            System.Linq.Expressions.Expression<Func<ADM_PRODUCTS, bool>> _filter = a => true;

            //_filter = _filter = a => a.IdPersonaFisica == id;

            try
            {
                using (SqlConnection con = new SqlConnection(StaticConfig.SQLConnectionString))
                {
                    con.Open();

                    var param = new DynamicParameters();
                    param.Add("@idProduct", id);
                    param.Add("@status", (int)StatusRecord.delete);
                    param.Add("@return_value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                    var res = await con.QueryAsync("cambiarStatus",
                            param,
                            commandType: CommandType.StoredProcedure
                            );
                    var resp = res.AsList().FirstOrDefault();
                    result.errorCode_s = resp.ERROR.ToString();
                    result.message = resp.MENSAJEERROR;
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
                if (result.errorCode_s.Length > 0)
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
