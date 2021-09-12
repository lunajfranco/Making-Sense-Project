using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_Sense_Project.Model
{
    public interface ICRUD<T>
    {
        void Create(T entity);
        void Update(T entity);
        IList<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
    }
}
