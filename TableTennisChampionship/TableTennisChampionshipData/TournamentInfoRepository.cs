using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTennisChampionshipData
{
    class TournamentInfoRepository
    {
        public TournamentInfoRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
        }

        protected DbContext Context { get; set; }
    }
}
