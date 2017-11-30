using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace ISMeetup.AppStart
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "api1" }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "ffonseca",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "ffonseca2",
                    Password = "password"
                }
            };
        }
    }
}
