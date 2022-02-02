using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPS.DataAccess.Concrete
{
    public class SessionRepository : GenericRepository<Session>,ISessionRepository
    {
    }
}
