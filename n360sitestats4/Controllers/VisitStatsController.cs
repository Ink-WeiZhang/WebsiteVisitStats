using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using n360sitestats4.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace n360sitestats4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitStatsController : ControllerBase
    {
        private readonly VisitStatsContext _context;

        public VisitStatsController(VisitStatsContext context)
        {
            _context = context;
            if (_context.Visits.Count() == 0)
            {
                string filepath = System.IO.Path.GetFullPath("datacut.csv");
                TextReader reader = new StreamReader(filepath);
                using (var streamReader = System.IO.File.OpenText(filepath))
                {
                    int ndx = 0;
                    while (!streamReader.EndOfStream)
                    {
                        ndx++;
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        DateTime time = DateTimeOffset.FromUnixTimeSeconds(long.Parse(data[0])).UtcDateTime;
                        long UID = long.Parse(data[1], System.Globalization.NumberStyles.Float);
                        var visit = new Visit() { VisitID = ndx, VisitDateTime = time, UserID = UID, OperatingSystem = (OperatingSystemType)int.Parse(data[2]), Device = (DeviceType)int.Parse(data[3]) };

                        _context.Visits.Add(visit);
                    }
                    _context.SaveChanges();
                }
            }
        }

        [HttpGet]
        public ActionResult<List<Visit>> GetAll()
        {
            return _context.Visits.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "GetVisit")]
        public ActionResult<Visit> GetById(int id)
        {
            var item = _context.Visits.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("loyal/{device?}/{os?}", Name = "GetLoyal")]
        public ActionResult<Count> CountLoyal(string device, string os)
        {
            Count myCount = new Count();
            List<DeviceType> devSelect = new List<DeviceType>();
            List<OperatingSystemType> osSelect = new List<OperatingSystemType>();

            if (!String.IsNullOrWhiteSpace(device))
            {
                int[] devices = device.Split(',').Select(Int32.Parse).ToArray();
                for (int i = 0; i < devices.Length; i++)
                {
                    devSelect.Add((DeviceType)devices[i]);
                }
            }

            if (!String.IsNullOrWhiteSpace(os))
            {
                int[] oss = os.Split(',').Select(Int32.Parse).ToArray();
                for (int i = 0; i < oss.Length; i++)
                {
                    osSelect.Add((OperatingSystemType)oss[i]);
                }
            }

            //Todo Query by loyalty

            //Query by Device and Operating System
            var query = from v in _context.Visits
                        where (devSelect.Count() == 0 || devSelect.Contains(v.Device))
                        where (osSelect.Count() == 0 || osSelect.Contains(v.OperatingSystem))
                        select v;

            myCount.count = query.Count();
            return myCount;
        }

        [HttpGet("unique/{device?}/{os?}", Name = "GetUnique")]
        public ActionResult<Count> CountUnique(string device, string os)
        {
            Count myCount = new Count();
            List<DeviceType> devSelect = new List<DeviceType>();
            List<OperatingSystemType> osSelect = new List<OperatingSystemType>();

            if (!String.IsNullOrWhiteSpace(device))
            {
                int[] devices = device.Split(',').Select(Int32.Parse).ToArray();
                for (int i = 0; i < devices.Length; i++)
                {
                    devSelect.Add((DeviceType)devices[i]);
                }
            }
            
            if (!String.IsNullOrWhiteSpace(os))
            {
                int[] oss = os.Split(',').Select(Int32.Parse).ToArray();
                for (int i = 0; i < oss.Length; i++)
                {
                    osSelect.Add((OperatingSystemType)oss[i]);
                }
            }
            
            //Query by Device and Operating System
            var query = from v in _context.Visits
                        where (devSelect.Count() == 0 || devSelect.Contains(v.Device))
                        where (osSelect.Count() == 0 || osSelect.Contains(v.OperatingSystem))
                        select v;

            //Query by Unique UserID
            query = from v in query
                    group v by new { v.UserID }
                    into mygroup
                    select mygroup.FirstOrDefault();
            myCount.count = query.Count();
            return myCount;
        }

        public class Count
        {
            public int count = 0;
        }
    }
}

