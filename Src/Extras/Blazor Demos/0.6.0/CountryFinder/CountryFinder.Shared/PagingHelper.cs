// /////////////////////////////////////////////////////////////////
// 
// CountryFinder.Shared
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using System;

namespace CountryFinder.Shared
{
    public class PagingHelper
    {
        public PagingHelper(int itemCount, int pageSize = 10, int maxPageLinks = 10)
        {
            ItemCount = itemCount;
            PageSize = pageSize;
            MaxPageLinks = maxPageLinks;
            TotalPages = (int) Math.Ceiling(itemCount / (decimal) pageSize);
            FirstPageLinkIndex = 1;
            LastPageLinkIndex = TotalPages;
        }

        public PagingHelper ForPage(int currentPage)
        {
            var half = MaxPageLinks / 2;
            var firstPage = currentPage - half;
            var lastPage = currentPage + (half-1);
            if (firstPage <= 0)
            {
                lastPage -= (firstPage - 1);
                firstPage = 1;
            }
            if (lastPage > TotalPages)
            {
                lastPage = TotalPages;
                if (lastPage > MaxPageLinks)
                {
                    firstPage = lastPage - 9;
                }
            }

            FirstPageLinkIndex = firstPage;
            LastPageLinkIndex = lastPage;
            return this;
        }
 
        public int ItemCount { get; private set; }
        public int MaxPageLinks { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int FirstPageLinkIndex { get; private set; }
        public int LastPageLinkIndex { get; private set; }
    }
}