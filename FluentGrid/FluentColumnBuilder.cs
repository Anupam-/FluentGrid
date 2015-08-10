using FluentGrid.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;


/*
The MIT License (MIT)

Copyright (c) [2015] [Anupam Singh Bisht]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
namespace FluentGrid
{
    public class FluentColumnBuilder<TModel> : IFluentColumnBuilder<TModel>
    {
        public FluentColumnBuilder(IList<FluentColumns> columns)
        {
            _columns = columns;
        }

        public IFluentColumnBuilder<TModel> Title(string title)
        {
            _columns.LastOrDefault().Title = title;
            return this;
        }
        public IFluentColumnBuilder<TModel> Sorting()
        {
            _columns.LastOrDefault().Shorting = Status.@true;
            return this;
        } 
        public IFluentColumnBuilder<TModel> Key()
        {
            _columns.LastOrDefault().Key = Status.@true;
            return this;
        }

        public IFluentColumnBuilder<TModel> EnableCreate()
        {
            _columns.LastOrDefault().EnableCreate = Status.@true;
            return this;
        }
        public IFluentColumnBuilder<TModel> EnableEdit()
        {
            _columns.LastOrDefault().EnableEdit = Status.@true;
            return this;
        }
        public IFluentColumnBuilder<TModel> Width(int width)
        {
            _columns.LastOrDefault().Width = width;
            return this;
        }
        public IFluentColumnBuilder<TModel> DisplayFormat(string displayFormat)
        {
            _columns.LastOrDefault().DisplayFormat = displayFormat;
            return this;
        }
        public IFluentColumnBuilder<TModel> Type(string type)
        {
            _columns.LastOrDefault().Type = type;
            return this;
        }
        public IFluentColumnBuilder<TModel> List()
        {
            _columns.LastOrDefault().List = Status.@true;
            return this;
        }

        public IFluentColumnBuilder<TModel> Bind<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            string columnName = ExpressionHelper.GetExpressionText(expression);
            _columns.Add(new FluentColumns { Name = columnName });
            return this;
        }

        public IFluentColumnBuilder<TModel> Custom(string name,string format)
        {             
            _columns.Add(new FluentColumns { Name = name,CustomColumnFormat=format,IsCustomColumn=true });
            return this;
        }

        private IList<FluentColumns> _columns;
    }
}