using System;
using System.Collections.Generic;

namespace BuiThiQuynhNga_2310900075.Models;

public partial class BtqnEmployee
{
    public int BtqnEmpld { get; set; }

    public string? BtqnEmpName { get; set; }

    public string? BtqnEmpLevel { get; set; }

    public DateOnly? BtqnEmpStartDate { get; set; }

    public bool? BtqnEmpStatus { get; set; }
}
