using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DtoMapper:Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDTO, UserApp>().ReverseMap();
        }
    }
}
