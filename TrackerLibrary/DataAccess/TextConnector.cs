﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        //TODO - Wireup the CreatePrize for textfiles
        public PrizeModel CreatePrize(PrizeModel model)
        {

            model.Id = 1;

            return model;
        }
    }
}
