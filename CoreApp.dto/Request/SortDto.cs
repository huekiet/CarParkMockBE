using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request
{
    public class SortDto
    {
        /// <summary>
        /// Field Name
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Order by ascending
        /// </summary>
        public bool Asc { get; set; }
    }
}
