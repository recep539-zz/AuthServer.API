using CoreLayer.Configuration;
using CoreLayer.DTOs;
using CoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.GenericServices
{
    public interface ITokenService
    {
        TokenDTO CreateToken(UserApp userApp);
        ClientTokenDTO ClientTokenByClient(Client client);
    }
}
