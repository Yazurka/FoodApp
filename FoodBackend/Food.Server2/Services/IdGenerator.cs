using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Server.Services
{
    public class IdGenerator : IIdGenerator
    {
        private Random m_random;
        public IdGenerator()
        {
            m_random = new Random();
        }
        public int GenerateId()
        {
            return m_random.Next(1, int.MaxValue);
        }
    }
}
