using FinalHerhalingApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalHerhalingApi.repositories
{
    public class SchoolRepository
    {
        private SchoolContext Db;

        public SchoolRepository(SchoolContext context)
        {
            Db = context;
        }

    }
}
