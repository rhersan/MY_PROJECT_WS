using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.Common
{
    public class RequestService<T> where T : class
    {
        public void UnAuthorizedCredentials(SystemCodes status)
        {
            if (status == SystemCodes.UnauthorizedCredentials)
            {
                throw new Exception(nameof(SystemCodes.UnauthorizedCredentials));
            }
        }

        public async Task<HttpGenericResponseNoDataMS> SendNoDataMS(string url, object content, HttpMethod metodoHttp, string idUser = "", string token = "")
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpGenericResponseNoDataMS resp = new HttpGenericResponseNoDataMS();
            string json = JsonSerializer.Serialize(content);
            using (var client = new HttpClient(clientHandler))
            {
                var request = new HttpRequestMessage
                {
                    Method = metodoHttp,
                    RequestUri = new Uri(StaticConfig.UrlMS + url),
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                };

                if (!string.IsNullOrEmpty(idUser))
                    request.Headers.Add(nameof(idUser), idUser);

                if (!string.IsNullOrEmpty(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.SendAsync(request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    resp = await JsonSerializer.DeserializeAsync<HttpGenericResponseNoDataMS>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        IgnoreNullValues = true,
                        WriteIndented = false
                    });
                }
                else
                {
                    resp = new HttpGenericResponseNoDataMS(MyProject.Common.Utilities.ParseRequest.ConvertHttpStatusToSystemsCode(response.StatusCode), response.ReasonPhrase);
                    UnAuthorizedCredentials(resp.SystemCode);
                }
            }
            return resp;
        }

        public async Task<HttpGenericResponseMS<T>> SendMs(string url, object content, HttpMethod metodoHttp)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpGenericResponseMS<T> resp = new HttpGenericResponseMS<T>();
            using (var client = new HttpClient(clientHandler))
            {
                var request = new HttpRequestMessage
                {
                    Method = metodoHttp,
                    RequestUri = new Uri(StaticConfig.UrlMS + url),
                    Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        resp = await JsonSerializer.DeserializeAsync<HttpGenericResponseMS<T>>(await response.Content.ReadAsStreamAsync(),
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            IgnoreNullValues = true,
                            WriteIndented = false
                        });
                    }
                    else
                    {
                        resp = new HttpGenericResponseMS<T>
                        {
                            SystemCode = SystemCodes.NoContent,
                            Message = SystemCodes.NoContent.ToString(),
                        };
                    }
                }
                else
                {
                    resp = new HttpGenericResponseMS<T>
                    {
                        Message = response.ReasonPhrase,
                        SystemCode = MyProject.Common.Utilities.ParseRequest.ConvertHttpStatusToSystemsCode(response.StatusCode)
                    };

                    UnAuthorizedCredentials(resp.SystemCode);
                }
            }
            return resp;
        }

    }
}
