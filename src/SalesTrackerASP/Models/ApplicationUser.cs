﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SalesTrackerASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        Dictionary<Item, int> Sales = new Dictionary<Item, int>();
    }
}
