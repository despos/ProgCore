// /////////////////////////////////////////////////////////////////
// 
// Mvc.Ux.Demos
// Copyright (c) Youbiquitous srls 2017
// 
// Author: Dino Esposito (http://youbiquitous.net)
//  

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bs4.Common
{
    public class Paginator<T>
    {
        public Paginator(IList<T> data, int pageSize = 10, int maxLinks = 5)
        {
            _all = data;
            MaxPageLinks = maxLinks;
            PageSize = pageSize;
        }

        private readonly IList<T> _all;

        public SegmentedList<T> Take(int pageIndex = 1)
        {
            var skip = pageIndex < 2 ? 0 : (pageIndex - 1) * PageSize;
            var items = _all.Skip(skip).Take(PageSize).ToList();
            return new SegmentedList<T>(items,
                pageIndex,
                PageSize,
                _all.Count);
        }

        /// <summary>
        /// Maximum number of page links to show
        /// </summary>
        public int MaxPageLinks { get; }

        /// <summary>
        /// Number of items in the current segmented view
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Filter string applied to the data set (if any)
        /// </summary>
        public string Filter { get; set; }
    }

    public class SegmentedList<T>  
    {
        public SegmentedList(IList<T> list, int index, int size, int total, int links = 5)
        {
            Items = list;
            CurrentIndex = index;
            Size = size;
            Total = total;
            PageCount = (int) Math.Ceiling(total / (double)size);
            MaxPageLinks = links;

            HasPreviousPage = (CurrentIndex > 1);
            IndexOfPreviousPageOfLinks = CurrentIndex - MaxPageLinks;
            if (IndexOfPreviousPageOfLinks < 1)
            {
                IndexOfPreviousPageOfLinks = 1;
            }

            LastIndex = (int)Math.Ceiling((double)CurrentIndex / MaxPageLinks) * MaxPageLinks;
            if (LastIndex > PageCount)
            {
                LastIndex = PageCount;
            }
            HasNextPage = (LastIndex < PageCount);

            IndexOfNextPageOfLinks = LastIndex + 1;
            FirstIndex = LastIndex - (MaxPageLinks - 1);

            FillerRows = Size - list.Count;
        }

        /// <summary>
        /// Data items in the current segment
        /// </summary>
        public IList<T> Items { get; }
        
        /// <summary>
        /// Index of the current segment displayed
        /// </summary>
        public int CurrentIndex { get; }

        /// <summary>
        /// Number of items in the current segmented view
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Total number of items to be rendered
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Total number of pages to link
        /// </summary>
        public int PageCount { get; }

        /// <summary>
        /// Maximum number of page links to show
        /// </summary>
        public int MaxPageLinks { get; }

        /// <summary>
        /// Whether there previous pages to show
        /// </summary>
        public bool HasPreviousPage { get; }

        /// <summary>
        /// Whether there are more pages to show
        /// </summary>
        public bool HasNextPage { get; }

        /// <summary>
        /// First page index in the pager
        /// </summary>
        public int FirstIndex { get; }

        /// <summary>
        /// Last page index in the pager
        /// </summary>
        public int LastIndex { get; }

        /// <summary>
        /// Index the starting page in the previous page of links
        /// </summary>
        public int IndexOfPreviousPageOfLinks { get; }

        /// <summary>
        /// Index of the starting page in the next page of links
        /// </summary>
        public int IndexOfNextPageOfLinks { get; }

        /// <summary>
        /// Number of blank rows
        /// </summary>
        public int FillerRows { get; }
    }

    public class SegmentedListPager<T>
    {
        public SegmentedListPager(SegmentedList<T> items, string action)
        {
            Page = items;
            ActionRef = action;
        }

        public SegmentedList<T> Page { get; }
        public string ActionRef { get; }
     }
}