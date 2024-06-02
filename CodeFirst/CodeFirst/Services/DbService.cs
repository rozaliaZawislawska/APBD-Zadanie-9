﻿using Models;
using Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{

    public class DbService : IDbService
    {
        private IConfiguration _configuration;
        private readonly MyDbContext _context = new MyDbContext();

        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int AddDoctor(Doctor doctor)
        {
            _context.Doctors.AddAsync(doctor);
            _context.SaveChangesAsync();
            return 0;
        }

        public int DeleteDoctor(int Id)
        {
            _context.Doctors.Remove(_context.Doctors.Where(x => x.IdDoctor==Id).FirstOrDefault());
            _context.SaveChangesAsync();
            return 0;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Prescription GetPrescription(int Id)
        {
            Prescription prescription = _context.Prescriptions
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Include(x => x.Prescription_Medicaments)
                .ThenInclude(x => x.Medicament)
                .Where(x => x.IdPrescription == Id).FirstOrDefault();
            return prescription;
        }

        public int UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChangesAsync();
            return 0;
        }
    }
}
