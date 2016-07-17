using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MysticChronicles.WebAPI.Helpers {
    public class TokenParserHandler : DelegatingHandler {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var token = request.Headers.GetValues("Token").First();

            var result = new MysticChronicles.WebAPI.BusinessLayer.Managers.AuthenticationManager().GetBaseManagerConstructorItemFromToken(token);

            if (result.ReturnValue == null) {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);

                return await tsc.Task;
            }
            
            request.Properties.Add("BASE_MANAGER", result.ReturnValue);
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}