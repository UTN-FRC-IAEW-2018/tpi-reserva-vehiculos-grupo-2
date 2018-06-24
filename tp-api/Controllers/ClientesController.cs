using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace tp_api.Controllers
{
    public class ClientesController : ControllerBase
    {
        private readonly Context _context;

        public ClientesController(Context context)
        {
            _context = context;

            /*if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }*/
        }     

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetByEmail(string email)
        {
            var item = _context.Clientes.Find(email);
            return item;
        } 

    }
}