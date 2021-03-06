using GraphQL;
using Identity.Data.Models;

namespace Identity.Api.GraphQl.Identity
{
    [GraphQLMetadata("User", IsTypeOf = typeof(AppUser))]
    public class UserType
    {
        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Id(AppUser identity) => identity.Id;

        /// <summary>
        /// Name field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Name(AppUser identity) => identity.Name;

        /// <summary>
        /// Username field resolver
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string Username(AppUser identity) => identity.UserName;
    }
}