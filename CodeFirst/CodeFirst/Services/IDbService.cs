using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public int AddDoctor(Doctor doctor);
        public int DeleteDoctor(int Id);
        public int UpdateDoctor(Doctor doctor);
        public Prescription GetPrescription(int Id);
    }
}
