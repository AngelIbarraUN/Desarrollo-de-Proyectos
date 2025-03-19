using Creatisa.Data;
using Creatisa.Models;
using Microsoft.AspNetCore.Mvc;
using Creatisa.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Creatisa.Controllers
{
    public class SweaterController : Controller
    {
        private readonly ILogger<SweaterController> _logger;
        private readonly ApplicationDbContext _context;

        public SweaterController(ILogger<SweaterController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult SweatersList()
        {
            List<SweaterModel> list = _context.Sweaters.Select(s => new SweaterModel()
            {
                Id = s.Id,
                Name = s.Name,
                Color = s.Color,
                SweaterSize = s.SweaterSize,
                Price = s.Price,
                Type = s.Type,
                Material = s.Material,
                Quantity = s.Quantity
            }).ToList();
            return View(list);
        }

        public IActionResult SweatersAdd(SweaterModel sweater)
        {
            if (ModelState.IsValid)
            {
                Sweater sweaterInfo = new Sweater()
                {
                    Id = Guid.NewGuid(),
                    Name = sweater.Name,
                    Color = sweater.Color,
                    SweaterSize = sweater.SweaterSize,
                    Price = sweater.Price,
                    Type = sweater.Type,
                    Material = sweater.Material,
                    Quantity = sweater.Quantity
                };
                _context.Sweaters.Add(sweaterInfo);
                _context.SaveChanges();
                return RedirectToAction("SweatersList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult SweatersEdit(Guid Id)
        {
            Sweater sweaterToUpdate = _context.Sweaters.FirstOrDefault(s => s.Id == Id);
            if (sweaterToUpdate == null)
            {
                return RedirectToAction("SweatersList");
            }
            
            SweaterModel model = new SweaterModel()
            {
                Id = sweaterToUpdate.Id,
                Name = sweaterToUpdate.Name,
                Color = sweaterToUpdate.Color,
                SweaterSize = sweaterToUpdate.SweaterSize,
                Price = sweaterToUpdate.Price,
                Type = sweaterToUpdate.Type,
                Material = sweaterToUpdate.Material,
                Quantity = sweaterToUpdate.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SweatersEdit(SweaterModel model)
        {
            if (ModelState.IsValid)
            {
                Sweater sweaterToUpdate = _context.Sweaters.FirstOrDefault(s => s.Id == model.Id);
                if (sweaterToUpdate == null)
                {
                    return RedirectToAction("SweatersList");
                }

                sweaterToUpdate.Name = model.Name;
                sweaterToUpdate.Color = model.Color;
                sweaterToUpdate.SweaterSize = model.SweaterSize;
                sweaterToUpdate.Price = model.Price;
                sweaterToUpdate.Type = model.Type;
                sweaterToUpdate.Material = model.Material;
                sweaterToUpdate.Quantity = model.Quantity;

                _context.Sweaters.Update(sweaterToUpdate);
                _context.SaveChanges();

                return RedirectToAction("SweatersList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SweatersDelete(Guid Id)
        {
            Sweater sweaterToDelete = _context.Sweaters.FirstOrDefault(s => s.Id == Id);
            if (sweaterToDelete == null)
            {
                return RedirectToAction("SweatersList");
            }

            SweaterModel model = new SweaterModel()
            {
                Id = sweaterToDelete.Id,
                Name = sweaterToDelete.Name,
                Color = sweaterToDelete.Color,
                SweaterSize = sweaterToDelete.SweaterSize,
                Price = sweaterToDelete.Price,
                Type = sweaterToDelete.Type,
                Material = sweaterToDelete.Material,
                Quantity = sweaterToDelete.Quantity
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SweatersDelete(SweaterModel model)
        {
            Sweater sweaterToDelete = _context.Sweaters.FirstOrDefault(s => s.Id == model.Id);
            if (sweaterToDelete == null)
            {
                return RedirectToAction("SweatersList");
            }

            _context.Sweaters.Remove(sweaterToDelete);
            _context.SaveChanges();

            return RedirectToAction("SweatersList");
        }
    }
}
