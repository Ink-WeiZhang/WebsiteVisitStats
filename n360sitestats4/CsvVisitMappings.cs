using n360sitestats4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace n360sitestats4
{
    public class CsvVisitMapping : CsvMapping<Visit>
    {
        public CsvVisitMapping()
            : base() 
        {

        }
    }
}
