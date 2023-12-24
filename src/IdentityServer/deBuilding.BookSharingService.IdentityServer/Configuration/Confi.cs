using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace deBuilding.BookSharingService.IdentityServer.Configuration
{
	/// <summary>
	/// Файл конфигураций дла IdentityServer.
	/// </summary>
	public static class Confi
	{
		/// <summary>
		/// Список API, к которым у клиентов будет доступ.
		/// </summary>
		public static IEnumerable<ApiResource> GetApis =>
			new List<ApiResource>
			{
				new ApiResource("BSSWebAPI", "BookSharingService WebAPI")
				{
					Scopes = new List<string>()
					{
						"WebApiScope"
					}
				}
			};

		/// <summary>
		/// Scope 
		/// </summary>
		public static IEnumerable<ApiScope> GetScopes =>
			new List<ApiScope>
			{
				new ApiScope(name: "WebApiScope", displayName: "Web Application Scope")
			};

		/// <summary>
		/// Ресурсы, по которым может проходить вутентификация, т.е. почта, персональные данные пользователя и т.д.
		/// </summary>
		public static IEnumerable<IdentityResource> GetResourses =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
			};

		/// <summary>
		/// Регистрация клиентов.
		/// </summary>
		public static IEnumerable<Client> GetClients(IConfiguration configuration)
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "MvcClient",
					ClientName = "Mvc Web Client",
					AllowedGrantTypes = GrantTypes.Code,
					AllowAccessTokensViaBrowser = false,
					ClientSecrets = new List<Secret>
					{
						new Secret("4F741440-7F2A-4AD7-8A56-E57B7291EB24".Sha256())
					},
					ClientUri = $"{configuration["MvcClient"]}",
					RequireConsent = false,
					AllowOfflineAccess = false,
					AlwaysIncludeUserClaimsInIdToken = true,
					RedirectUris = new List<string>
					{
						$"{configuration["MvcClient"]}/signin-oidc",
						"http://localhost:5102/signin-oidc"
					},
					PostLogoutRedirectUris = new List<string>
					{
						$"{configuration["MvcClient"]}/signout-callback-oidc",
						"http://localhost:5102/signout-callback-oidc"
					},
					AllowedScopes = new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"WebApiScope"
					},
					AccessTokenLifetime = 60*60*2,
					IdentityTokenLifetime= 60*60*2
				}
			};
		}
	}
}
