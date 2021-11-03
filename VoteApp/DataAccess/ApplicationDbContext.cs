using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VoteApp.DataAccess.Entities;

namespace VoteApp.DataAccess
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        { }

        public DbSet<VoterProfile> VoterProfiles { get; set; }
        public DbSet<PollTemplate> PollTemplates { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<IoTDevice> IoTDevices { get; set; }
        public DbSet<VoteCount> VoteCounts { get; set; }
    }
}
