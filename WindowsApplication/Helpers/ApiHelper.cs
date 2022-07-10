using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using WindowsApplication.Utilities;

using WindowsApplication.ViewModules;
using WindowsApplication.API;
using Newtonsoft.Json;

namespace WindowsApplication.Helpers
{
    public class ApiHelper : ObservableObject
    {

        static HttpClient httpClient;
        static HttpClientHandler handler = new HttpClientHandler();

        public ApiHelper()
        {            
            handler.MaxAutomaticRedirections = 3;
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            httpClient = new HttpClient(handler);            
        }

        public static async Task postMessageAsync(string sessionId, string expertId, string input)
        {
            ChatMessage chatMessage = new ChatMessage();
            chatMessage.session_id = sessionId;
            chatMessage.expert_id = expertId;
            chatMessage.content = input;

            string json = JsonConvert.SerializeObject(chatMessage);

            string uri = "http://infra.askjusta.com/chat/message";
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            if (httpClient == null)
            {
                httpClient = new HttpClient(handler);
            }

            var response = await httpClient.PostAsync(uri, stringContent);            
        }
    }
}
