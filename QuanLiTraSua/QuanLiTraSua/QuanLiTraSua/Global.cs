using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiTraSua
{
    class Global
    {
        public static string GlobalUserId { get; private set; }
        public static void SetGlobalUserId(string userId)
        {
            GlobalUserId = userId;
        }
    }
}
