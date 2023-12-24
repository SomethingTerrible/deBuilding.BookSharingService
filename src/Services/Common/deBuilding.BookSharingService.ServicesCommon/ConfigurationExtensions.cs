using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.ServicesCommon
{
	public static class ConfigurationExtensions
	{
		public static string GetRequiredValue(this IConfiguration configuration, string name) =>
			configuration[name] ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");

		public static string GetRequiredConnectionString(this IConfiguration configuration, string name) =>
			configuration.GetConnectionString(name) ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":ConnectionStrings:" + name : "ConnectionStrings:" + name)}");
	}
}
