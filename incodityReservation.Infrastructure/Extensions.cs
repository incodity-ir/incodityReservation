using System.Reflection;
using System.Runtime.Loader;
using incodityReservation.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace incodityReservation.Infrastructure
{
    public static class Extensions
    {

        public static void OnCreatedAt(this ModelBuilder modelBuilder)
        {
            var ListDateEntities = typeof(IDateEntity).GetAllClassName();
            var ListEntitiesMap = modelBuilder.Model.GetEntityTypes()
                .Where(w => ListDateEntities.Contains(w.ClrType.FullName));
            foreach (var map in ListEntitiesMap )
            {
                var props = map.FindProperty("CreateAt");
                if (props != null)
                {
                    props.ValueGenerated = ValueGenerated.OnAdd;
                    props.SetDefaultValueSql("GETDATE()");
                }
            }
        }

        public static string GetUserBrowserName(HttpContext context) => context.Request.Headers["User-Agent"].ToString();
        public static string GetUserIPAddress(HttpContext context) => context.Connection.RemoteIpAddress.ToString();

        public static List<string> GetAllClassName(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(System.AppContext.BaseDirectory, "incodityReservation.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).Select(x => x.FullName).ToList();
        }

        public static List<Type> GetAllClassTypes(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(System.AppContext.BaseDirectory, "incodityReservation.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList();
        }
    }


}
