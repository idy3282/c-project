using System;
using System.Collections.Generic;

namespace Common.Models;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public int SchoolSymbol { get; set; }
    public virtual School? SchoolSymbolNavigation { get; set; } = null!;

}
