//using n360sitestats4.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TinyCsvParser.Mapping;
//using TinyCsvParser.TypeConverter;

//namespace n360sitestats4
//{
//    public class CsvVisitMapping : CsvMapping<Visit>
//    {
//        public CsvVisitMapping()
//            : base() 
//        {
//            MapProperty(0, x => x.VisitDateTime);
//            MapProperty(1, x => x.UserID);
//            MapProperty(2, D)
//        }

        
//    }

//    public class VisitDateTimeConverter : ITypeConverter<int>
//    {
//        public Type TargetType => typeof(int);

//        public bool TryConvert(string value, out DateTime result)
//        {
//            result = DateTimeOffset.FromUnixTimeSeconds(long.Parse(value)).UtcDateTime;
//            return true;
//        }

//        public bool TryConvert(string value, out int result)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
