using System;
using System.Collections.Generic;

namespace Logistics_MVC.Models;

public partial class Logistic
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public string? Ownername { get; set; }

    public int? PackageId { get; set; }

    public DateTime PackedDate { get; set; }

    public DateTime ExpectedDate { get; set; }

    public decimal? Price { get; set; }

    public string? DeliveryStatus { get; set; }

    public string? FromLocation { get; set; }

    public string? ToLocation { get; set; }
}
