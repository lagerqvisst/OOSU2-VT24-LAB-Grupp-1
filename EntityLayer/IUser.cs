using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public interface IUser
    {
         string name { get; set; }
         string password { get; set; }
    }
}
