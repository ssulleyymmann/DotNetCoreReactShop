using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DotNetCoreReactShop.Models;

namespace DotNetCoreReactShop.Contexts
{
    public class DefaultDbContextInitializer : IDefaultDbContextInitializer
    {
        private readonly DefaultDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public DefaultDbContextInitializer(DefaultDbContext context,UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public async Task DefaultSeed()
        {
            var email = "user@test.com";
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    GivenName = "Süleyman AYDIN"
                };

                await _userManager.CreateAsync(user, "pass123*");
            }

            if (_context.Contacts.Any())
            {
                foreach (var u in _context.Contacts)
                {
                    _context.Remove(u);
                }
            }

            _context.Contacts.Add(new Contact() { LastName = "suleyman1", FirstName = "aydin1", Phone = "555-555-5555", Email = "suleyman@test.com" });
            _context.Contacts.Add(new Contact() { LastName = "suleyman2", FirstName = "aydin2", Phone = "555-555-5555", Email = "suleyman2@test.com" });
           _context.SaveChanges();

            if (!_context.Pizzas.Any())
            {
                _context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Cazip Pizzalar"
                    },
                    new Category
                    {
                        CategoryName = "Efsane Pizzalarr"
                    },
                    new Category
                    {
                        CategoryName = "Þefin Pizzalarý"
                    });

                _context.Pizzas.AddRange(
                    new Pizza()
                    {
                        PizzaNo = "0000",
                        PizzaName = "Sosyal Pizza",
                        Price = 37.99M,
                        Image = "/image/pizza/0000.jpg",
                        CategoryName = "Cazip Pizzalar"
                    },
                       new Pizza()
                       {
                           PizzaNo = "0001",
                           PizzaName = "Vegi",
                           Price = 37.99M,
                           Image = "/image/pizza/0001.jpg",
                           CategoryName = "Cazip Pizzalar"
                       }, new Pizza()
                       {
                           PizzaNo = "0002",
                           PizzaName = "Dev Malzemos",
                           Price = 39.99M,
                           Image = "/image/pizza/0002.jpg",
                           CategoryName = "Cazip Pizzalar"
                       },
                       new Pizza()
                       {
                           PizzaNo = "0003",
                           PizzaName = "Doyuyos Pizza",
                           Price = 39.99M,
                           Image = "/image/pizza/0003.jpg",
                           CategoryName = "Efsane Pizzalar"
                       }, new Pizza()
                       {
                           PizzaNo = "0004",
                           PizzaName = "Mangal Sucuklu Pizza",
                           Price = 43.99M,
                           Image = "/image/pizza/0004.jpg",
                           CategoryName = "Efsane Pizzalar"
                       },
                       new Pizza()
                       {
                           PizzaNo = "0005",
                           PizzaName = "Dört Peynirli Pizza",
                           Price = 43.99M,
                           Image = "/image/pizza/0005.jpg",
                           CategoryName = "Þefin Pizzalar"
                       }


                    );



                _context.SaveChanges();

            }
        }

        
    }

    public interface IDefaultDbContextInitializer
    {
        bool EnsureCreated();
        void Migrate();
        Task DefaultSeed();

    }
}
