using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics.Database
{

	static class ConnectionHolder
	{
		public static string NameOrConnectionString { get; set; }
	}

	class MigrationsContextFactory : IDbContextFactory<AnalyticsDb>
	{
		public AnalyticsDb Create()
		{
			return new AnalyticsDb(ConnectionHolder.NameOrConnectionString);

			////set connection string at runtime here
			//string connectionString = Properties.Settings.Default.TestDB;
			//var connectionInfo = new DbConnectionInfo(connectionString, "System.Data.SqlClient");

			//bool doInitialize = false;
			////Set initializer here
			////Database.SetInitializer<WPH_BusinessContext>(new DropCreateDatabaseAlways<WPH_BusinessContext>());
			////doInitialize = true;       

			//var contextInfo = new DbContextInfo(typeof(WPH_BusinessContext), connectionInfo);
			//var context = contextInfo.CreateInstance();
			//context.Configuration.LazyLoadingEnabled = true;
			//context.Configuration.ProxyCreationEnabled = true;

			//if (doInitialize)
			//{
			//	context.Database.Initialize(false);
			//}

			//bool doMigration = false;
			//try
			//{
			//	doMigration = !context.Database.CompatibleWithModel(true);
			//}
			//catch (NotSupportedException)
			//{
			//	//if there are no metadata for migration
			//	doMigration = true;
			//}

			//if (doMigration)
			//{
			//	var migrationConfig = new DbMigrationsConfiguration<WPH_BusinessContext>();
			//	migrationConfig.AutomaticMigrationDataLossAllowed = false;
			//	migrationConfig.AutomaticMigrationsEnabled = true;
			//	migrationConfig.TargetDatabase = connectionInfo;
			//	var migrator = new DbMigrator(migrationConfig);
			//	migrator.Update();
			//}

			//return context as WPH_BusinessContext;
		}
	}
}
