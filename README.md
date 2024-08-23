# FluentGrid
FluentGrid is an Mvc grid helper with paging,searching ,sorting ,filtering and many more. This mvc helper is built upon JTable and uses Jquery to work with asynchronus requests.  

# Usase

```
   @(Html.FluentGrid(Model)
            .Title("My Grid")
            .Id("FluentGrid")
            .PazeSize(15)
            .ListAction(Url.Action("GetData"))
            .CreateAction(Url.Action("AddInfo"))
            .UpdateAction(Url.Action("UpdateInfo"))
            .AddColumns(x =>
                 {
                     x.Bind(m => m.ID).Key().Title("Person ID").Width(1)
                      .Bind(m => m.Name).Title("Person Name").EnableEdit().EnableCreate().Width(5).Sorting()
                      .Bind(m => m.DOB).Title("Date Of Birth").Type("date").DisplayFormat("dd-mm-yy").EnableEdit().EnableCreate()
                      .Custom("TestColumn","'<a href=#>'+data.record.Name+'</a>'").Title("Custom Column");
                  })
                )
```
