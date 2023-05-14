using Petstore.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Api
{
    public partial class Client 
    {
        public async System.Threading.Tasks.Task<HttpResponseMessage> CreateUserAsync(object body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user");

            var client_ = _httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    return response_;
                    //try
                    //{
                    //    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    //    if (response_.Content != null && response_.Content.Headers != null)
                    //    {
                    //        foreach (var item_ in response_.Content.Headers)
                    //            headers_[item_.Key] = item_.Value;
                    //    }

                    //    ProcessResponse(client_, response_);

                    //    var status_ = ((int)response_.StatusCode).ToString();
                    //}
                    //finally
                    //{
                    //    if (response_ != null)
                    //        response_.Dispose();
                    //}
                }
            }
            finally
            {
            }
        }
    }
}
