using FluentGrid.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
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
    public class FluentGridBuilder<TModel> : IFluentGridBuilder<TModel>
    {
        // Cror
        public FluentGridBuilder(HtmlHelper helper, IEnumerable<TModel> model)
        {
            _helper = helper;
            _dataSource = model;
        }
        public IFluentGridBuilder<TModel> Title(string title)
        {
            _gridTitle = title;
            return this;
        }

        public IFluentGridBuilder<TModel> ListAction(string lstAction)
        {
            _gridListAction = lstAction;
            return this;
        }

        public IFluentGridBuilder<TModel> CreateAction(string createAction)
        {
            _gridCreateAction = createAction;
            return this;
        }

        public IFluentGridBuilder<TModel> DeleteAction(string deleteAction)
        {
            _gridDeleteAction = deleteAction;
            return this;
        }
        public IFluentGridBuilder<TModel> UpdateAction(string updateAction)
        {
            _gridUpdateAction = updateAction;
            return this;
        }

        public IFluentGridBuilder<TModel> Id(string id)
        {
            _id = id;
            return this;
        }

        public IFluentGridBuilder<TModel> PazeSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public IFluentGridBuilder<TModel> AddColumns(Action<IFluentColumnBuilder<TModel>> newColumn)
        {
            newColumn(new FluentColumnBuilder<TModel>(_columns));
            return this;
        }

        private string RenderHtmlString()
        {
            var div = new StringBuilder();
            div.AppendFormat("<div id=\"{0}\"></div>", _id);

            return div.ToString();
        }

        private string RenderJavaScriptString()
        {
            var script = new StringBuilder();

            script.AppendLine("$(document).ready(function () {");

            script.AppendLine("$('#" + _id + "').jtable({");

            if (!string.IsNullOrEmpty(_gridTitle))
            {
                script.AppendFormat("title :'{0}',", _gridTitle).AppendLine();
            }
            script.AppendFormat("paging: {0},", _paging).AppendLine();
            script.AppendFormat("pageSize: {0},", _pageSize).AppendLine();
            script.AppendFormat("sorting:{0},", _sorting).AppendLine();
            script.AppendFormat("selecting: {0},", _selecting).AppendLine();

            if (!string.IsNullOrEmpty(_defaultSorting))
            {
                script.AppendFormat("defaultSorting:{0},", _defaultSorting).AppendLine();
            }

            // actions

            string actions = string.Format("\r\nlistAction :'{0}', \r\n deleteAction: '{1}', \r\n updateAction: '{2}',\r\n createAction: '{3}'", _gridListAction, _gridDeleteAction, _gridUpdateAction, _gridCreateAction);

            // string actions = "\r\nlistAction :'"+ _gridListAction +"'";
            script.AppendLine("actions:{" + actions + "\r\n},");

            // columns
            if (_columns.Count > 0)
            {
                var appendColumns = new StringBuilder();

                for (int i = 0; i < _columns.Count; i++)
                {

                    appendColumns.AppendFormat("{0}:", _columns[i].Name);
                    appendColumns.AppendLine("{");
                    appendColumns.AppendFormat("list:{0},", _columns[i].List.ToString()).AppendLine();
                    appendColumns.AppendFormat("sorting:{0},", _columns[i].Shorting.ToString()).AppendLine();
                    appendColumns.AppendFormat("title:'{0}',", _columns[i].Title ?? _columns[i].Name).AppendLine();
                    appendColumns.AppendFormat("key:{0},", _columns[i].Key).AppendLine();
                    appendColumns.AppendFormat("create:{0},", _columns[i].EnableCreate).AppendLine();
                    appendColumns.AppendFormat("edit: {0},", _columns[i].EnableEdit).AppendLine();

                    if (!string.IsNullOrEmpty(_columns[i].DisplayFormat))
                    {
                        appendColumns.AppendFormat("displayFormat: '{0}',", _columns[i].DisplayFormat).AppendLine();
                    }
                    if (_columns[i].Width != 0)
                    {
                        appendColumns.AppendFormat("width: '{0}%',", _columns[i].Width).AppendLine();
                    }
                    if (!string.IsNullOrEmpty(_columns[i].Type))
                    {
                        appendColumns.AppendFormat("type: '{0}',", _columns[i].Type).AppendLine();
                    }



                    if (_columns[i].IsCustomColumn)
                    {
                        appendColumns.AppendLine("display: function(data){");
                        appendColumns.AppendFormat("return {0}", string.Format(_columns[i].CustomColumnFormat));
                        appendColumns.AppendLine("}");
                    }


                    //  ,\r\n
                    appendColumns.Replace(",\r\n", "\r\n", appendColumns.Length - 5, 5);
                    appendColumns.AppendLine();
                    appendColumns.Append("\r\n},");

                }
                string fields = appendColumns.ToString().TrimEnd(',');
                script.AppendLine("fields:{" + fields + "}});");
            }

            script.AppendLine("$('#" + _id + "').jtable('load');");
            script.AppendLine("});");
            return script.ToString();
        }


        public string ToHtmlString()
        {
            var script = new StringBuilder();

            script.AppendLine(RenderHtmlString());

            script.AppendLine("<script type=\"text/javascript\">");
            script.Append(RenderJavaScriptString());
            script.AppendLine("</script>");

            return script.ToString();
        }


        /* grid properties  */

        private string _gridTitle;

        private IList<FluentColumns> _columns = new List<FluentColumns>();

        private IEnumerable<TModel> _dataSource;

        private HtmlHelper _helper;

        private string _id;

        private string _gridListAction;
        private string _gridCreateAction;
        private string _gridDeleteAction;
        private string _gridUpdateAction;

        // paging and sorting
        private string _paging = "true";
        private string _sorting = "true";
        private string _defaultSorting = string.Empty;
        private string _selecting = "false";
        private int _pageSize = 10;

    }
}