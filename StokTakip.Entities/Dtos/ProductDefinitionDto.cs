﻿using StokTakip.Entities.Concrete;
using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Dtos
{
    public class ProductDefinitionDto : DtoGetBase
    {
        public ProductDefinition ProductDefinition { get; set; }
    }
}
