// See https://aka.ms/new-console-template for more information

using Azure.Identity;
using Microsoft.Graph;

var scopes = new[] {"https://graph.microsoft.com/.default"};
string clientId = "";
string tennantId = "";
string clientSecret = "";


var options = new TokenCredentialOptions
{
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
};

var clientSecretCredentials = new ClientSecretCredential(tennantId, clientId, clientSecret, options);

var graphClient = new GraphServiceClient(clientSecretCredentials, scopes);

var collectionResponse = await graphClient.Users.GetAsync();

var users = collectionResponse.Value;

foreach (var user in users)
{
    Console.WriteLine(user.DisplayName);
}

Console.WriteLine("Hello, World!");
