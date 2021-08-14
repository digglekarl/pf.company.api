﻿using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IDividendRepository
    {
        List<Dividend> Get();
        Dividend Get(long id);
        bool Create(Dividend dividend);
        bool Update(Dividend dividend);
        bool Delete(long id);
    }
}