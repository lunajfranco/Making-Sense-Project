using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Model.Interfaces
{
    public interface ICRUD<T>
    {
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        ICollection<T> GetAll();
        T GetById(int id);
        
        bool Save();
    }
}
