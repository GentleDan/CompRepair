﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairBusinessLogic.BindingModels
{
    public class ServicesBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}