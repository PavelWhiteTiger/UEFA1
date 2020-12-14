using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UEFA
{
    using Model;
    class Connection
    {
        private static CupUEFAEntities DataBase { get; set; }
        private Connection()
        {

        }

        public static CupUEFAEntities NewInstance()
        {
            if (DataBase == null)
            {
                DataBase = new CupUEFAEntities();
            }
            return DataBase;
        }
        public static void refresh()
        {
                DataBase = new CupUEFAEntities();
        }

    }
}
