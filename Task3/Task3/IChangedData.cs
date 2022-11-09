using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IChangedData
    {
        public void ChangedData(string changedType, string clientId);
    }
}
