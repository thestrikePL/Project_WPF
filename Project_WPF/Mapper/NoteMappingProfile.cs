using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_WPF.Dto;
using Project_WPF.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_WPF.Mapper
{
    public class NoteMappingProfile : Profile
    {
        public NoteMappingProfile()
        {
            CreateMap<NoteEntity, NoteDto>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}