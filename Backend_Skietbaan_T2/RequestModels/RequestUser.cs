using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Skietbaan_T2.RequestModels
{
    [Serializable]
    public class RequestUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
