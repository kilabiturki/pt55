using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pt55.Data;
using pt55.Models;

namespace pt55.Controllers
{
    public class UsersaccountsController : Controller
    {
        private readonly pt55Context _context;

        public UsersaccountsController(pt55Context context)
        {
            _context = context;
        }

        // GET: Usersaccounts
        public async Task<IActionResult> Index()
        {
              return _context.Usersaccounts != null ? 
                          View(await _context.Usersaccounts.ToListAsync()) :
                          Problem("Entity set 'pt55Context.Usersaccounts'  is null.");
        }

 

        // GET: Usersaccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(string na, string pa)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=ptdb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            string sql;
            sql = "SELECT * FROM Usersaccounts where name ='" + na + "' and  pass ='" + pa + "' ";
            SqlCommand comm = new SqlCommand(sql, conn1);
            conn1.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                string role = (string)reader["role"];
                string id = Convert.ToString((int)reader["Id"]);
                HttpContext.Session.SetString("Name", na);
                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetString("userid", id);
                reader.Close();
                conn1.Close();
                if (role == "user")
                    return RedirectToAction("Index", "Home");

                else
                    return RedirectToAction("Index", "Categories");

            }
            else
            {
                ViewData["Message"] = "wrong user name password";
                return View();
            }
        }



        // POST: Usersaccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,pass,,email")] Usersaccounts usersaccounts)
        {
                 usersaccounts.role = "user";

                _context.Add(usersaccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            
        }

        // GET: Usersaccounts/Edit/5
        public async Task<IActionResult> Edit()
        {

            int id = Convert.ToInt32(HttpContext.Session.GetString("userid"));

            var usersaccounts = await _context.Usersaccounts.FindAsync(id);
    
            return View(usersaccounts);
        }

        // POST: Usersaccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,pass,role,email")] Usersaccounts usersaccounts)
        {

                    _context.Update(usersaccounts);
                    await _context.SaveChangesAsync();
               
         
                return RedirectToAction(nameof(Login));
  
        }



        private bool UsersaccountsExists(int id)
        {
          return (_context.Usersaccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
