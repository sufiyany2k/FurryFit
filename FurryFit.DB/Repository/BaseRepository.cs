using System;
using System.Collections.Generic;
using System.Text;
using FurryFit.Repository.Interface;

namespace FurryFit.DB.Repository
{
    public class BaseRepository: IBaseRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BaseRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

    }
}
