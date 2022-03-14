using CampsitesApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampsitesApi.Sites;

public class SitesController : ControllerBase
{
    private readonly CampsiteDataContext _context;

    public SitesController(CampsiteDataContext context)
    {
        _context = context;
    }

    [HttpGet("sites")]
    public async Task<ActionResult<GetSitesResponseModel>> GetAllSitesAsync()
    {
        var data = await _context.Sites!.Select(s => new GetSitesResponseItemModel
        {
            SiteId = s.SiteId,
            SiteName = s.SiteName,
            HasElectricalHookup = s.HasElectricalHookup,
            HasWater = s.HasWater,
            IsLakeFront = s.IsLakeFront,
        }).AsNoTracking()
          .ToListAsync();
        var response = new GetSitesResponseModel()
        {
            Data = data
        };
        
        

        return Ok(response);
    }

    [HttpGet("/sites/{siteId:maxlength(10)}/bookings")]
    public async Task<ActionResult<GetSiteBookingsResponseModel>> GetSiteAvailabilityAsync(string siteId)
    {
        var site =await  _context.Sites!.Include(s => s.Bookings).Where(s => s.SiteId == siteId).SingleOrDefaultAsync();
        if(site == null)
        {
            return NotFound("That site does not exist");
        }

        var bookings = new List<GetSiteBookingItemModel>();
        foreach(var booking in site.Bookings.Where(b => b.ReservationDate >= DateTime.Now.Date))
        {
            for(var t = 0; t <booking.NumberOfDays; t++)
            {
                bookings.Add(new GetSiteBookingItemModel
                {
                    Date = booking.ReservationDate.AddDays(t)
                });
            }
        }
        var response = new GetSiteBookingsResponseModel
        {
            Site = new GetSitesResponseItemModel
            {
                SiteId = site.SiteId,
                SiteName = site.SiteName,
                HasElectricalHookup = site.HasElectricalHookup,
                HasWater = site.HasWater,
                IsLakeFront = site.IsLakeFront
            },
            Bookings = bookings
        };
        return Ok(response);
    }
}
