using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mostaan.Classes;
using mostaan.Model;

using Newtonsoft.Json;
using mostaan.Classes;

namespace realstate
{
    class databaseManager
    {
        Context context = new Context();
        functions FUNS = new functions();

        public void addToArchive(string hesab,string subject,string productType)
        {
            
            if (context.Archives.Any(x=> x.subject == subject))
                return;

            archive ARCHIVE = new archive()
            {
               
            };
           
            context.Archives.Add(ARCHIVE);
            context.SaveChanges();

        }
        

    }
}
