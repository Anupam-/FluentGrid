﻿using System;

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
namespace FluentGrid.Abstract
{
    public interface IFluentGridBuilder<TModel> : System.Web.IHtmlString
    {
        /// <summary>
        /// Add Columns For Grid 
        /// </summary>
        /// <param name="newColumn"></param>
        /// <returns></returns>
        IFluentGridBuilder<TModel> AddColumns(Action<IFluentColumnBuilder<TModel>> newColumn);
        IFluentGridBuilder<TModel> CreateAction(string createAction);
        IFluentGridBuilder<TModel> DeleteAction(string deleteAction);
        /// <summary>
        /// Setting Id for HTML contents
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IFluentGridBuilder<TModel> Id(string id);
        IFluentGridBuilder<TModel> ListAction(string lstAction);
        IFluentGridBuilder<TModel> PazeSize(int pageSize);

        /// <summary>
        /// Stting Grid Title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IFluentGridBuilder<TModel> Title(string title);          
        IFluentGridBuilder<TModel> UpdateAction(string updateAction);
    }
}