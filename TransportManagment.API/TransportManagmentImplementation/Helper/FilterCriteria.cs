﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.Helper
{

    public class FilterDetail
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
        public List<FilterCriteria>? Criteria { get; set; } = null!;
    }

    public class FilterCriteria
    {
        public string ColumnName { get; set; } = null!;
        public string FilterValue { get; set; } = null!;
    }
}
