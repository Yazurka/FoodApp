using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Services
{
    public interface IIdGenerator
    {
        int GenerateId();
    }
}
