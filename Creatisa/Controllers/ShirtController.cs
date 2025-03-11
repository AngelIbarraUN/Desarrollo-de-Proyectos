using Creatisa.Data;
using Creatisa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Creatisa.Identity;

namespace Creatisa.Controllers;

public class ShirtController : Controller
{
    private readonly ILogger<ShirtController> _logger;
    private readonly ApplicationDbContext _context;

    public ShirtController(ILogger<ShirtController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult ShirtsList()
    {
        List<ShirtModel> list = _context.Shirts.Select(s => new ShirtModel()
        {
            Id = s.Id,
            Name = s.Name,
            Color = s.Color,
            ShirtSize = s.ShirtSize,
            Price = s.Price,
            Type = s.Type,
            Material = s.Material,
            Quantity = s.Quantity
        }).ToList();
        return View(list);
    }

    public IActionResult ShirtsAdd(ShirtModel shirt)
    {
        if (ModelState.IsValid)
        {
            Shirt shirtInfo = new Shirt()
            {
                Id = Guid.NewGuid(),
                Name = shirt.Name,
                Color = shirt.Color,
                ShirtSize = shirt.ShirtSize,
                Price = shirt.Price,
                Type = shirt.Type,
                Material = shirt.Material,
                Quantity = shirt.Quantity
            };
            _context.Shirts.Add(shirtInfo);
            _context.SaveChanges();
            return RedirectToAction("ShirtsList");
        }
        return View();
    }

    [HttpGet]
    public IActionResult ShirtsEdit(Guid Id)
    {
        Shirt shirtToUpdate = _context.Shirts.FirstOrDefault(s => s.Id == Id);
        if (shirtToUpdate == null)
        {
            return RedirectToAction("ShirtsList");
        }

        ShirtModel model = new ShirtModel()
        {
            Id = shirtToUpdate.Id,
            Name = shirtToUpdate.Name,
            Color = shirtToUpdate.Color,
            ShirtSize = shirtToUpdate.ShirtSize,
            Price = shirtToUpdate.Price,
            Type = shirtToUpdate.Type,
            Material = shirtToUpdate.Material,
            Quantity = shirtToUpdate.Quantity
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult ShirtsEdit(ShirtModel model)
    {
        if (ModelState.IsValid)
        {
            Shirt shirtToUpdate = _context.Shirts.FirstOrDefault(s => s.Id == model.Id);
            if (shirtToUpdate == null)
            {
                return RedirectToAction("ShirtsList");
            }

            shirtToUpdate.Name = model.Name;
            shirtToUpdate.Color = model.Color;
            shirtToUpdate.ShirtSize = model.ShirtSize;
            shirtToUpdate.Price = model.Price;
            shirtToUpdate.Type = model.Type;
            shirtToUpdate.Material = model.Material;
            shirtToUpdate.Quantity = model.Quantity;

            _context.Shirts.Update(shirtToUpdate);
            _context.SaveChanges();

            return RedirectToAction("ShirtsList");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult ShirtsDelete(Guid Id)
    {
        Shirt shirtToDelete = _context.Shirts.FirstOrDefault(s => s.Id == Id);
        if (shirtToDelete == null)
        {
            return RedirectToAction("ShirtsList");
        }

        ShirtModel model = new ShirtModel()
        {
            Id = shirtToDelete.Id,
            Name = shirtToDelete.Name,
            Color = shirtToDelete.Color,
            ShirtSize = shirtToDelete.ShirtSize,
            Price = shirtToDelete.Price,
            Type = shirtToDelete.Type,
            Material = shirtToDelete.Material,
            Quantity = shirtToDelete.Quantity
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult ShirtsDelete(ShirtModel model)
    {
        Shirt shirtToDelete = _context.Shirts.FirstOrDefault(s => s.Id == model.Id);
        if (shirtToDelete == null)
        {
            return RedirectToAction("ShirtsList");
        }

        _context.Shirts.Remove(shirtToDelete);
        _context.SaveChanges();

        return RedirectToAction("ShirtsList");
    }
}