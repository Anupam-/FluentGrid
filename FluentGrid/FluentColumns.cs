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
    public class FluentColumns
    {
        public Status List { get; set; }
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Title { get; set; }
        public object Value { get; set; }
        public int Width { get; set; } 
        public string Type { get; set; }
        public string DisplayFormat { get; set; }
        public Status Shorting { get; set; } = Status.@false;
        public Status EnableCreate { get; set; } = Status.@false;
        public Status EnableEdit { get; set; } = Status.@false;
        public Status Key { get; set; } = Status.@false;
        public string CustomColumnFormat { get; set; } 
        public bool IsCustomColumn { get; set; }
    }

    public enum Status
    {
      @true,
      @false
    }
}