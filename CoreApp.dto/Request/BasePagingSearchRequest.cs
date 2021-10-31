using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.dto.Request
{
    public class BasePagingSearchRequest: BaseRequest
    {
        public IList<SearchDto> Filter { get; set; }
        //public SortDto Sort { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

    }
}
