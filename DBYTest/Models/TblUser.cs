using System;
using System.Collections.Generic;

namespace DBYTest.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
