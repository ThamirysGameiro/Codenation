﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteCodenation.Application.ViewModel
{
    public class Token
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }

    }
}
