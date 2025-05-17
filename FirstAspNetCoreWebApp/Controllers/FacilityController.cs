using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using FirstAspNetCoreWebApp.Data;
using FirstAspNetCoreWebApp.Models;
using FirstAspNetCoreWebApp.ViewModels;

namespace FirstAspNetCoreWebApp.Controllers
{
    public class FacilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Facility
        public async Task<IActionResult> Index()
        {
            var facilities = await _context.Facilities
                .Include(f => f.Location)
                .ToListAsync();
            return View(facilities);
        }

        // GET: Facility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var facility = await _context.Facilities
                .Include(f => f.Location)
                .Include(f => f.Images)
                .Include(f => f.Reviews).ThenInclude(r => r.User)
                .Include(f => f.FacilityAmenities).ThenInclude(fa => fa.Amenity)
                .FirstOrDefaultAsync(f => f.FacilityID == id);

            if (facility == null) return NotFound();

            return View(facility);
        }

        // GET: Facility/Create
        public IActionResult Create()
        {
            var viewModel = new FacilityViewModel
            {
                FacilityTypes = Enum.GetValues(typeof(FacilityType))
                    .Cast<FacilityType>()
                    .Select(t => new SelectListItem
                    {
                        Value = t.ToString(),
                        Text = t.ToString()
                    }).ToList(),
                AmenityList = _context.Amenities
                    .Select(a => new SelectListItem { Value = a.AmenityID.ToString(), Text = a.Name })
                    .ToList()
            };
            return View(viewModel);
        }

        // POST: Facility/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var facility = new Facility
                {
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type,
                    Location = new Location
                    {
                        Address = model.Address,
                        City = model.City,
                        Country = model.Country
                    }
                };

                if (model.SelectedAmenities != null)
                {
                    foreach (var amenityId in model.SelectedAmenities)
                    {
                        facility.FacilityAmenities.Add(new FacilityAmenity
                        {
                            Facility = facility,
                            AmenityID = amenityId
                        });
                    }
                }

                _context.Facilities.Add(facility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate the view model with facility types and amenities
            model.FacilityTypes = Enum.GetValues(typeof(FacilityType))
                .Cast<FacilityType>()
                .Select(t => new SelectListItem
                {
                    Value = t.ToString(),
                    Text = t.ToString()
                }).ToList();
            model.AmenityList = (await _context.Amenities.ToListAsync())
                .Select(a => new SelectListItem { Value = a.AmenityID.ToString(), Text = a.Name })
                .ToList();
            return View(model);
        }

        // GET: Facility/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var facility = await _context.Facilities
                .Include(f => f.Location)
                .Include(f => f.FacilityAmenities)
                .FirstOrDefaultAsync(f => f.FacilityID == id);

            if (facility == null) return NotFound();

            var viewModel = new FacilityViewModel
            {
                FacilityID = facility.FacilityID,
                Name = facility.Name,
                Description = facility.Description,
                Type = facility.Type,
                Address = facility.Location?.Address,
                City = facility.Location?.City,
                Country = facility.Location?.Country,
                Latitude = facility.Location.Latitude,
                Longitude = facility.Location.Longitude,
                SelectedAmenities = facility.FacilityAmenities.Select(fa => fa.AmenityID).ToList(),
                FacilityTypes = Enum.GetValues(typeof(FacilityType))
                    .Cast<FacilityType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString()
                    }).ToList(),
                AmenityList = _context.Amenities
                    .Select(a => new SelectListItem
                    {
                        Value = a.AmenityID.ToString(),
                        Text = a.Name
                    }).ToList()
            };

            return View(viewModel);
        }

        // POST: Facility/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FacilityViewModel model)
        {
            if (id != model.FacilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var facility = await _context.Facilities
                        .Include(f => f.Location)
                        .Include(f => f.FacilityAmenities)
                        .FirstOrDefaultAsync(f => f.FacilityID == id);

                    if (facility == null)
                    {
                        return NotFound();
                    }

                    facility.Name = model.Name;
                    facility.Description = model.Description;
                    facility.Type = model.Type;

                    // Update location
                    facility.Location.Address = model.Address;
                    facility.Location.City = model.City;
                    facility.Location.Country = model.Country;

                    // Update amenities
                    facility.FacilityAmenities.Clear();
                    if (model.SelectedAmenities != null)
                    {
                        foreach (var amenityId in model.SelectedAmenities)
                        {
                            facility.FacilityAmenities.Add(new FacilityAmenity
                            {
                                Facility = facility,
                                AmenityID = amenityId
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(model.FacilityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Repopulate the view model with facility types and amenities
            model.FacilityTypes = Enum.GetValues(typeof(FacilityType))
                .Cast<FacilityType>()
                .Select(t => new SelectListItem
                {
                    Value = t.ToString(),
                    Text = t.ToString()
                }).ToList();
            model.AmenityList = (await _context.Amenities.ToListAsync())
                .Select(a => new SelectListItem { Value = a.AmenityID.ToString(), Text = a.Name })
                .ToList();
            return View(model);
        }

        // GET: Facility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var facility = await _context.Facilities
                .Include(f => f.Location)
                .FirstOrDefaultAsync(f => f.FacilityID == id);

            if (facility == null) return NotFound();

            return View(facility);
        }

        // POST: Facility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null) return NotFound();

            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return _context.Facilities.Any(f => f.FacilityID == id);
        }
    }
}
