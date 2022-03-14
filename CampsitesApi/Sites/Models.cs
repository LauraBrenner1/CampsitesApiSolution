namespace CampsitesApi.Sites;


public class GetSitesResponseModel
{
    public IList<GetSitesResponseItemModel> Data { get; init; } = new List<GetSitesResponseItemModel>();
}

public class GetSitesResponseItemModel
{
    public string SiteId { get; init;} = string.Empty;
    public string SiteName { get; init;}=string.Empty;
    public bool HasWater { get;init;} = false;
    public bool HasElectricalHookup { get; init;} = false;
    public bool IsLakeFront { get; init;} = false;
}

/*
 * {
    "site": {

    },

    "bookings": [
        { "date": "03/18/2022"},
        { "date": "03/19/2022"},
        { "date": "08/12/2022"}
    ]
}*/

public class GetSiteBookingsResponseModel
{
    public GetSitesResponseItemModel? Site { get; init; }
    public List<GetSiteBookingItemModel>? Bookings { get; init; }
}

public class GetSiteBookingItemModel
{
    public DateTime Date { get; init; }
}
