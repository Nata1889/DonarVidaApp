﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDonarVidaApp.Models;

namespace BibliotecaDonarVidaApp.Services.Interfaces
{
    public interface IProgramaDonacion
    {
        Task<List<ProgramaDonacion>> GetAllAsync();
        Task<ProgramaDonacion> GetByIdAsync(int id);
        Task<bool> CreateAsync(ProgramaDonacion programa);
        Task<bool> UpdateAsync(ProgramaDonacion programa);
        Task<bool> DeleteAsync(int id);
    }
}
