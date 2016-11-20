using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;
using Newtonsoft.Json;

namespace Food.Server.WebApi.Authorization
{
    public class AuthorizeTicketMiddleware : OwinMiddleware
    {
        public AuthorizeTicketMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(authorizationHeader))
            {
                try
                {
                    var token = ExtractTokenFromHeader(authorizationHeader);

                    var utf8EncodedByteArray = Convert.FromBase64String(token);

                    var utf8string = Encoding.UTF8.GetString(utf8EncodedByteArray);

                    var incomingClaims = JsonConvert.DeserializeObject<Dictionary<string, string>>(utf8string);
                    CheckClaims(incomingClaims);
                    Claim[] claims = incomingClaims.Select(kvp => new Claim(kvp.Key, kvp.Value)).ToArray();

                    var identity = new ClaimsIdentity(claims, "Basic");

                    context.Request.User = new ClaimsPrincipal(identity);
                    Thread.CurrentPrincipal = context.Request.User;
                }
                catch (Exception)
                {
                    //YOLO
                }
            }

            await Next.Invoke(context);
        }

        private static void CheckClaims(Dictionary<string,string> incomingClaims)
        {
            var goodClaims = new Dictionary<string, string>
            {
                {"All","Good"},
                {"In","The"},
                { "Fucking","Hood"}
            };
            var dictionariesEqual = incomingClaims.Keys.Count == goodClaims.Keys.Count && 
                incomingClaims.Keys.All(k => goodClaims.ContainsKey(k)) && 
                incomingClaims.Values.All(k => goodClaims.ContainsValue(k));
            if (!dictionariesEqual)
            {
                throw new Exception("No Authorization");
            }
        }
        private static string ExtractTokenFromHeader(string authorizationHeader)
        {
            var match = Regex.Match(authorizationHeader, @"Bearer\s+(.+)");
            return match.Groups[1].Value;
        }
    }
}