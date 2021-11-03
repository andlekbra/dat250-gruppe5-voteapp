using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Server.Service
{
    public interface IDbInitializer
    {
        public void Initialize();
    }
}
