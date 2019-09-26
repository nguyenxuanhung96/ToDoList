using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Contexts
{
    public interface IDaoFactory
    {
        ToDoListDataContext GetDataContext();
    }

    public class DaoFactory : IDaoFactory
    {
        private ToDoListDataContext _context;
        private object _lock = new object();
        public ToDoListDataContext GetDataContext()
        {
            if(_context == null)
            {
                lock (_lock) {
                    if(_context == null)
                    {
                        _context = new ToDoListDataContext();
                    }
                }
            }
            return _context;
        }
    }
}
