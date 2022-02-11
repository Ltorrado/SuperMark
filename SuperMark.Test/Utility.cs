using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Test
{
  public   class Utility
    {
        public static bool CheckService(object result)
        {
            var resultobject = result as ObjectResult;
            if (resultobject.StatusCode == 500)
            {
                throw new Exception(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            }

            return resultobject.StatusCode == 200;

        }
    }
}
