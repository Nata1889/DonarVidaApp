using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaDonarVidaApp.Models;

namespace BibliotecaDonarVidaApp.Services.Interfaces
{
    public interface IDonanteSercice
    {
        Task<List<Donante>> GetAllAsync();
        Task<Donante> GetByIdAsync(int id);
        Task<bool> CreateAsync(Donante donante);
        Task<bool> UpdateAsync(Donante donante);
        Task<bool> DeleteAsync(int id);
    }
}
