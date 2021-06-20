using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Work.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string sth { get ;  set;}
    }

    
    public class Pager
    {
        public int TotalItems { get;private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager() { }
        public Pager(int totalItems, int page, int pageSize = 10) 
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;
            int starPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (starPage <= 0) 
            {
                endPage = endPage - (starPage - 1);
                starPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;

                if (endPage > 10) 
                {
                    starPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = starPage;
            EndPage = endPage;

        }

    }

}

