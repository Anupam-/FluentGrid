using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkingDemo.Models;

namespace WorkingDemo.Controllers
{
    [AllowAnonymous]
     public class HomeController : Controller
    {
        #region Data
        List<People> _peoples = new List<People> {
                    new People { ID=1, Name="Anupam" ,DOB= new DateTime(1989,09,13) },
                    new People { ID=2, Name="Aadarsh"  },
                    new People { ID=3, Name="Aadavan"  },
                    new People { ID=4, Name="Aadhar"  },
                    new People { ID=5, Name="Aachman"  },
                    new People { ID=6, Name="Aaditeya"  },
                    new People { ID=7, Name="Aadithya"  },
                    new People { ID=8, Name="Hamrish"  },
                    new People { ID=9, Name="Hans"  },
                    new People { ID=10, Name="Hansaraj"  },
                    new People { ID=11, Name="Harendra"  },
                    new People { ID=12, Name="Maanya"  },
                    new People { ID=13, Name="Madhavi"  },
                    new People { ID=14, Name="Madhu Bindu"  },
                    new People { ID=15, Name="Madhubala"  },
                    new People { ID=16, Name="Madhumanti"  },
                    new People { ID=17, Name="Madhuparna"  },
                    new People { ID=18, Name="Tamayanthy"  },
                    new People { ID=19, Name="Tammana"  },
                    new People { ID=20, Name="Tanaya"  },
                    new People { ID=21, Name="Tanishia"  },
                    new People { ID=22, Name="Tanmaya"  }

                };

        #endregion
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetData(int jtStartIndex = 0, int jtPageSize = 0, string name=null, string jtSorting = null)
        {
            try
            {        

                IEnumerable<People> data = _peoples;

                if (!string.IsNullOrEmpty(name))
                {
                    data = data.Where(x => x.Name.Contains(name));
                }

                if (jtSorting != null)
                {
                    if (jtSorting.Equals("Name DESC"))
                    {
                        data = data.Skip(jtStartIndex).Take(jtPageSize).OrderByDescending(x => x.Name);
                    }
                    else if (jtSorting.Equals("Name ASC"))
                    {
                        data = data.Skip(jtStartIndex).Take(jtPageSize).OrderBy(x => x.Name);
                    }


                }
                else
                {
                    data = _peoples.Skip(jtStartIndex).Take(jtPageSize);
                }
               


                    return Json(new { Result = "OK", Records = data, TotalRecordCount = data.Count() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AddInfo(People person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                _peoples.Add(person);
                return Json(new { Result = "OK", Record = _peoples.LastOrDefault() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult UpdateInfo(People person)
        {
            try
            {
                person.DOB = Convert.ToDateTime(person.DOB);

                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                var info = _peoples.Find(x=>x.ID==person.ID);
                info.Name = person.Name;
                info.DOB = person.DOB;

                return Json(new { Result = "OK", Record = _peoples.LastOrDefault() });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}