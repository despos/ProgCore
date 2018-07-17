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
using System.Text.RegularExpressions;
using Expoware.Youbiquitous.Core.Extensions;

namespace Bs4.Common
{
    public class Paginator<T>
    {
        public Paginator(IList<T> data, string filter, int pageSize = 10, int maxLinks = 5)
        {
            All = data;
            MaxPageLinks = maxLinks;
            PageSize = pageSize;
            CurrentFilter = filter;

            FilterStringBreakupInternal();
        }

        protected readonly IList<T> All;
        protected string[] FilterTokens;
        protected bool ShouldBeAdd;
        protected Func<T, string> FilterSource;

        public Paginator<T> InstallFilterSource(Func<T, string> func)
        {
            FilterSource = func;
            return this;
        }

        public SlicedList<T> Take(int pageIndex = 1)
        {
            var actualData = All.Where(country => !HasFilter || ApplyFilter(country)).ToList();
            var skip = pageIndex < 2 ? 0 : (pageIndex - 1) * PageSize;
            var items = actualData.Skip(skip).Take(PageSize).ToList();
            return new SlicedList<T>(items,
                CurrentFilter,
                pageIndex,
                PageSize,
                actualData.Count,
                MaxPageLinks);
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
        public string CurrentFilter { get; private set; }

        /// <summary>
        /// Whether there's any filter set
        /// </summary>
        public bool HasFilter { get; private set; }     

        /// <summary>
        /// Verifies that the current filter applies to the specified item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual bool ApplyFilter(T item)
        {
            var source = FilterSource(item);
            return ShouldBeAdd 
                ? source.ContainsAll(FilterTokens) 
                : source.ContainsAny(FilterTokens);
        }

        /// <summary>
        /// Breaks up the filter string into tokens 
        /// </summary>
        private void FilterStringBreakupInternal()
        {
            if (!string.IsNullOrWhiteSpace(CurrentFilter))
            {
                CurrentFilter = CurrentFilter.Trim(' ', ',');

                // A comma indicates OR and gets priority
                HasFilter = true;
                var localCurrentFilter = CurrentFilter.ToLower();
                if (CurrentFilter.Contains(","))
                    FilterTokens = localCurrentFilter.Split(',');
                else
                {
                    // Splits on spaces considering quoted strings with spaces as items
                    var regex = new Regex(@"((""((?<token>.*?)(?<!\\)"")|(?<token>[\w]+))(\s)*)", RegexOptions.None);
                    FilterTokens = (from Match m in regex.Matches(localCurrentFilter)
                        where m.Groups["token"].Success
                        select m.Groups["token"].Value).ToArray();

                    ShouldBeAdd = true;
                }

                // Trim tokens and removes any quote
                FilterTokens = FilterTokens.Where(t => !String
                        .IsNullOrEmpty(t))
                    .Select(t => t.Trim(' ', '"'))
                    .ToArray();
            }
        }
    }


    #region INTERNALS
    public class SlicedList<T>  
    {
        public SlicedList(IList<T> list, string filter, int index, int size, int total, int links)
        {
            Items = list;
            Properties = new SlicedListParams(filter, index, size, total, links, size-list.Count);
        }

        /// <summary>
        /// Data items in the current segment
        /// </summary>
        public IList<T> Items { get; }
        
        public SlicedListParams Properties { get; }
    }

    public class SlicedListParams
    {
        public SlicedListParams(string filter, int index, int size, int total, int links, int fillerRows)
        {
            CurrentFilter = filter;
            HasFilter = !string.IsNullOrWhiteSpace(CurrentFilter);

            Size = size;
            Total = total;
            PageCount = (int)Math.Ceiling(total / (double)size);
            MaxPageLinks = links;
            CurrentIndex = index;
            if (CurrentIndex > PageCount)
                CurrentIndex = 1;

            HasPreviousPage = (CurrentIndex > 1);
            IndexOfPreviousPageOfLinks = CurrentIndex - MaxPageLinks;
            if (IndexOfPreviousPageOfLinks < 1)
                IndexOfPreviousPageOfLinks = 1;

            LastIndex = (int)Math.Ceiling((double)CurrentIndex / MaxPageLinks) * MaxPageLinks;
            if (LastIndex > PageCount)
                LastIndex = PageCount;
            HasNextPage = (LastIndex < PageCount);

            IndexOfNextPageOfLinks = LastIndex + 1;
            FirstIndex = LastIndex - (MaxPageLinks - 1);
            if (FirstIndex < 1)
                FirstIndex = 1;

            FillerRows = fillerRows;
        }

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

        /// <summary>
        /// Current filter on displayted data
        /// </summary>
        public string CurrentFilter { get; }

        /// <summary>
        /// Whether there's any filter set
        /// </summary>
        public bool HasFilter { get; }
    }

    public class SlicedListHelper 
    {
        public SlicedListHelper(SlicedListParams props, string action)
        {
            Page = props;
            ActionRef = action;
        }

        public SlicedListParams Page { get; }
        public string ActionRef { get; }
     }

    #endregion
}