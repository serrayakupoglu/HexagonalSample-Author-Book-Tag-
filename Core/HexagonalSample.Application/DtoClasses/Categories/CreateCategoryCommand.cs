using MediatR;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DtoClasses.Categories
{
    //Todo : DTO (Command ve Query sistemi)
    public class CreateCategoryCommand : IRequest {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
