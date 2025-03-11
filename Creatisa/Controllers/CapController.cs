using Creatisa.Data;
using Creatisa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Creatisa.Identity;
namespace Creatisa.Controllers;

 public class CapController : Controller
    {
        private readonly ILogger<CapController> _logger;
        private readonly ApplicationDbContext _context;

        public CapController(ILogger<CapController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult CapsList()
        {
            List<CapModel> list = _context.Caps.Select(c => new CapModel()
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color,
                CapSize = c.CapSize,
                Price = c.Price,
                Type = c.Type,
                Material = c.Material,
                Quantity = c.Quantity
            }).ToList();
            return View(list);
        }

        public IActionResult CapsAdd(CapModel cap)
        {
            if (ModelState.IsValid)
            {
                Cap capInfo = new Cap()
                {
                    Id = Guid.NewGuid(),
                    Name = cap.Name,
                    Color = cap.Color,
                    CapSize = cap.CapSize,
                    Price = cap.Price,
                    Type = cap.Type,
                    Material = cap.Material,
                    Quantity = cap.Quantity
                };
                _context.Caps.Add(capInfo);
                _context.SaveChanges();
                return RedirectToAction("CapsList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CapsEdit(Guid Id)
        {
            Cap capToUpdate = _context.Caps.FirstOrDefault(c => c.Id == Id);
            if (capToUpdate == null)
            {
                return RedirectToAction("CapsList");
            }
            
            CapModel model = new CapModel()
            {
                Id = capToUpdate.Id,
                Name = capToUpdate.Name,
                Color = capToUpdate.Color,
                CapSize = capToUpdate.CapSize,
                Price = capToUpdate.Price,
                Type = capToUpdate.Type,
                Material = capToUpdate.Material,
                Quantity = capToUpdate.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CapsEdit(CapModel model)
        {
            if (ModelState.IsValid)
            {
                Cap capToUpdate = _context.Caps.FirstOrDefault(c => c.Id == model.Id);
                if (capToUpdate == null)
                {
                    return RedirectToAction("CapsList");
                }

                capToUpdate.Name = model.Name;
                capToUpdate.Color = model.Color;
                capToUpdate.CapSize = model.CapSize;
                capToUpdate.Price = model.Price;
                capToUpdate.Type = model.Type;
                capToUpdate.Material = model.Material;
                capToUpdate.Quantity = model.Quantity;

                _context.Caps.Update(capToUpdate);
                _context.SaveChanges();

                return RedirectToAction("CapsList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CapsDelete(Guid Id)
        {
            Cap capToDelete = _context.Caps.FirstOrDefault(c => c.Id == Id);
            if (capToDelete == null)
            {
                return RedirectToAction("CapsList");
            }

            CapModel model = new CapModel()
            {
                Id = capToDelete.Id,
                Name = capToDelete.Name,
                Color = capToDelete.Color,
                CapSize = capToDelete.CapSize,
                Price = capToDelete.Price,
                Type = capToDelete.Type,
                Material = capToDelete.Material,
                Quantity = capToDelete.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CapsDelete(CapModel model)
        {
            Cap capToDelete = _context.Caps.FirstOrDefault(c => c.Id == model.Id);
            if (capToDelete == null)
            {
                return RedirectToAction("CapsList");
            }

            _context.Caps.Remove(capToDelete);
            _context.SaveChanges();

            return RedirectToAction("CapsList");
        }
    }
}
