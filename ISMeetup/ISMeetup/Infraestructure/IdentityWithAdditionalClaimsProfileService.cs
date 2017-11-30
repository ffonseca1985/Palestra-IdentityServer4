using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Extensions;
using ISMeetup.Infraestructure.MySqlEntityFramework.Repositories;
using ISMeetup.DomainModel;
using System.Security.Claims;
using IdentityModel;

namespace ISMeetup.Infraestructure
{
    public class IdentityWithAdditionalClaimsProfileService : IProfileService
    {
        RepositoryBase<User> _userRepository;

        public IdentityWithAdditionalClaimsProfileService(RepositoryBase<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = _userRepository.Find(sub);

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
            claims.Add(new Claim(JwtClaimTypes.Name, "ffonseca"));

            context.IssuedClaims = claims;

            return Task.FromResult(0);

        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = _userRepository.Find(sub);
            context.IsActive = user != null;

            return Task.FromResult(0);
        }
    }
}
