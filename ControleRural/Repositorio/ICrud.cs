using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleRural.Models;

namespace ControleRural.Repositorio
{
    interface ICrud<T> where T :class 
    {
        void Save(T entidade);
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Update(T entidade);
    }
}
