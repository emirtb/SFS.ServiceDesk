using SFSdotNet.Framework.Graph;
using SFSdotNet.Framework.Web.Mvc.Models;
using SFSdotNet.Framework.Web.Mvc.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFSdotNet.Framework.Geo;
using SFS.ServiceDesk.BusinessObjects;  
//using SFSdotNet.Framework.Web.Mvc.Graph;

namespace SFS.ServiceDesk.Web.Mvc.Controllers
{


    public class DashboardController : SFSdotNet.Framework.Web.Mvc.ControllerBase
    {

        //
        // GET: /Dasboard/
        #region Totals Top
        public DataGraph TotalCountApproved()
        {
            if (SFSdotNet.Framework.Cache.Caching.ExistInCompany("dashboard-tota-approved", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany))
            {
                return (DataGraph)SFSdotNet.Framework.Cache.Caching.GetFromCompany("dashboard-tota-approved", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany);
            }
            else
            {
                var dataGraph = new DataGraph();
                dataGraph.Title = "Aprobadas";
               // dataGraph.Total = SFS.ServiceDesk.BR.accIncomeExpensesBR.Instance.GetCount(p => p.accReusableCatalogValue.ValueString == "money-out-request" && p.Authorized == true);

                SFSdotNet.Framework.Cache.Caching.SetToCompany(dataGraph, "dashboard-tota-approved", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany, TimeSpan.FromMinutes(60));
                return dataGraph;

            }

        }

        public DataGraph<int> TotalCountInProcess()
        {
            if (SFSdotNet.Framework.Cache.Caching.ExistInCompany("dashboard-tota-inprocess", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany))
            {
                return (DataGraph<int>)SFSdotNet.Framework.Cache.Caching.GetFromCompany("dashboard-tota-inprocess", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany);
            }
            else
            {
                var dataGraph = new DataGraph<int>();
                dataGraph.Title = "En proceso";
                //dataGraph.Total = SFS.ServiceDesk.BR.accIncomeExpensesBR.Instance.GetCount(p => p.accReusableCatalogValue.ValueString == "money-out-request" && p.Authorized == null);

                SFSdotNet.Framework.Cache.Caching.SetToCompany(dataGraph, "dashboard-tota-inprocess", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany, TimeSpan.FromMinutes(60));
                return dataGraph;

            }

        }

        public DataGraph TotalCountrejected()
        {
            if (SFSdotNet.Framework.Cache.Caching.ExistInCompany("dashboard-total-rejected", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany))
            {
                return (DataGraph)SFSdotNet.Framework.Cache.Caching.GetFromCompany("dashboard-total-rejected", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany);
            }
            else
            {
                var dataGraph = new DataGraph();
                dataGraph.Title = "Rechazadas";
              //  dataGraph.Total = SFS.ServiceDesk.BR.accIncomeExpensesBR.Instance.GetCount(p => p.accReusableCatalogValue.ValueString == "money-out-request" && p.Authorized == false);

                SFSdotNet.Framework.Cache.Caching.SetToCompany(dataGraph, "dashboard-total-rejected", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany, TimeSpan.FromMinutes(60));
                return dataGraph;

            }

        }

        public DataGraph TotalCountPayment()
        {
            if (SFSdotNet.Framework.Cache.Caching.ExistInCompany("dashboard-total-payment", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany))
            {
                return (DataGraph)SFSdotNet.Framework.Cache.Caching.GetFromCompany("dashboard-total-payment", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany);
            }
            else
            {
                var dataGraph = new DataGraph<int>();
                dataGraph.Title = "Pagadas";
               // dataGraph.Total = SFS.ServiceDesk.BR.accIncomeExpensesBR.Instance.GetCount(p => p.accReusableCatalogValue.ValueString == "money-out-request"  && p.TotalPayment >= p.TotalChilds);

                SFSdotNet.Framework.Cache.Caching.SetToCompany(dataGraph, "dashboard-total-payment", "SFSServiceDesk", SFSdotNet.Framework.My.Context.CurrentContext.Company.GuidCompany, TimeSpan.FromMinutes(60));
                return dataGraph;

            }

        }




        public ActionResult TotalApps()
        {
            // total de apps que esta usando la empresa

            return View("");
        }

        public ActionResult TotalErrors()
        {
            // total de apps que esta usando la empresa

            return View("");
        }
      
        [MyAuthorize("r")]
        public ActionResult Index() {

            

            if (ViewData["uiv"] == null)
            {
                ViewBag.TotalCountApproved = TotalCountApproved();
                ViewBag.TotalInProcess = TotalCountInProcess();
                ViewBag.TotalRejected = TotalCountrejected();
                ViewBag.TotalPayment = TotalCountPayment();
                ViewBag.HistoryChart = GetHistoryDataDefitition();

                ViewBag.SpaceUsed = GetTotalSpaceUsed();
                ViewBag.DemoDonut = GetDonutDataDemo();
                //DashboardItem pendings =  new DashboardItem();
                ViewBag.GeoMapData = GetGeoDataDemo();



                #region lists
                List<DashboardItemList> lists = new List<DashboardItemList>();

                //DashboardItemList listMovements = new DashboardItemList();
                //listMovements.UrlView = VirtualPathUtility.ToAbsolute("~/") + "SFSdotNetFrameworkSecurity/secMoneyMovements/ListViewGen?usemode=myaccount";
                //listMovements.Title = "Mis movimientos";
                //listMovements.UrlCatalog = VirtualPathUtility.ToAbsolute("~/") + "SFSdotNetFrameworkSecurity/secMoneyMovements";

                //lists.Add(listMovements);
                DashboardItemList list = new DashboardItemList();


                //if ((new SFSdotNet.Framework.Security.Permissions()).IsAllowed(SFSdotNet.Framework.My.Context.CurrentContext.User, "SFSServiceDesk", accIncomeExpens.EntityName + "_money-in", "r"))
                //{
                //    list = new DashboardItemList();
                //    list.UrlView = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/accIncomeExpenses/ListViewGen?usemode=money-in";
                //    list.Title = "Ingresos";
                //    list.UrlCatalog = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/accIncomeExpenses?usemode=money-in";

                //    lists.Add(list);
                //}
                //if ((new SFSdotNet.Framework.Security.Permissions()).IsAllowed(SFSdotNet.Framework.My.Context.CurrentContext.User, "SFSServiceDesk", accIncomeExpens.EntityName + "_money-out-request", "r"))
                //{
                //    list = new DashboardItemList();
                //    list.UrlView = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/accIncomeExpenses/ListViewGen?usemode=money-out-request";
                //    list.Title = "Solicitudes de egreso";
                //    list.UrlCatalog = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/accIncomeExpenses?usemode=money-out-request";

                //    lists.Add(list);
                //}
                DashboardItem item = new DashboardItem();
                item.ItemType = DashboardItemTypes.ListView;
                item.Lists = lists;

                #endregion
                ViewBag.MyPendings = item;
            }
            DashboardModel model = new DashboardModel();
            UIModel uiModel = new UIModel();
            return ResolveView("Dashboard", uiModel, model);
        }
        
        #endregion

        #region Historic charts
        public DataGraph GetTotalSpaceUsed() {
           
            var dataGraph = new DataGraph();
            List<int> serie = new List<int>();
            serie.Add(12);
            dataGraph.Title = "Espacio usado";
            serie.Add(100 - 12);
            serie.Add(100 - (12 + 20));
            dataGraph.Data.Add(serie);
            dataGraph.Series.Add(new Serie() { FillColor = "#46BFBD" });
            dataGraph.Series.Add(new Serie() { FillColor = "#FDB45C" });
            dataGraph.Series.Add(new Serie() { FillColor = "#F7464A" });
            dataGraph.DataLabels.Add("Usado");
            dataGraph.DataLabels.Add("Libre");
            dataGraph.DataLabels.Add("Reciclaje");
            dataGraph.ChartType = ChartTypes.Pie;
            
            return dataGraph;
        }

        public DataGraph GetDonutDataDemo()
        {

            var dataGraph = new DataGraph();
            List<int> serie = new List<int>();
            serie.Add(20);
            dataGraph.Title = "Demo de gráfica";
            serie.Add(30);

            dataGraph.Data.Add(serie);
            //dataGraph.DataLabels.Add("Usado");
            //dataGraph.DataLabels.Add("Libre");
            dataGraph.ChartType = ChartTypes.Donut;
            return dataGraph;
        }
        public GeoData GetGeoDataDemo()
        {
            GeoData data = new GeoData();
            data.Locations.Add(new Location() { Lat = "34.452218", Lon = "-111.408234" });
            data.Locations.Add(new Location() { Lat = "28.88316", Lon = "-106.222687" });
            return data;
        }

        [HttpGet]
        public ActionResult GetDataGraphJson(string id, DateTime? from , DateTime? to)
        {

            DataGraph<decimal> result = new DataGraph<decimal>();

            if (id == "HistoricalData")
                return Json(GetHistoryData(from, to), JsonRequestBehavior.AllowGet);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public DataGraph<int> GetHistoryDataDefitition()
        {
            var dataGraph = new DataGraph<int>();
            dataGraph.ChartType = ChartTypes.Historical;
            //var usersAddedYear = (new BR.DataGraphBR()).GetHistoricalAdded("m", 12, "secUser");
            dataGraph.Title = "Egresos";
            dataGraph.UrlData = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/Dashboard/GetDataGraphJson/HistoricalData";
            return dataGraph;
        }
        public DataGraph<int> GetHistoryData(DateTime? start, DateTime? end)
        {

            var dataGraph = new DataGraph<int>();
            ////List<int> serieAmountApproved = new List<int>();
            //List<int> serieInprogress = new List<int>();
            //List<int> serieApproved = new List<int>();
            //List<int> serieRejected = new List<int>();
            
            ////List<int> serieCompaniesAdded = new List<int>();
            //dataGraph.DataLabels.Add(DateTime.UtcNow.ToString("dd/MM/yyyy"));
            //for (int i = 1; i < 30; i++)
            //{
            //    dataGraph.DataLabels.Add(DateTime.UtcNow.AddDays(-i).ToString("dd/MM/yyyy"));

            //    //dataGraph.DataLabels.Add("");

            //}
            //string rangeType = "d";
            //if (start != null && end != null) {
            //    rangeType = "specific";
            //}
            ////var amountApproved = (new BR.DataGraphBR()).GetHistoricalMovs(rangeType, 30, start, end, "accIncomeExpens", "amount-approved");
            //var inprogress = (new BR.DataGraphBR()).GetHistoricalMovs(rangeType, 30, start, end, "accIncomeExpens", "in-progress");
            //var approved = (new BR.DataGraphBR()).GetHistoricalMovs(rangeType, 30, start, end, "accIncomeExpens", "approved");
            //var rejected = (new BR.DataGraphBR()).GetHistoricalMovs(rangeType, 30, start, end, "accIncomeExpens", "rejected");

            ////var companiesAddedYear = (new BR.DataGraphBR()).GetHistoricalAdded("m", 12, "secCompany");

            //foreach (var expected in dataGraph.DataLabels)
            //{
            //    int value = 0;
            //    //if (amountApproved.TryGetValue(expected, out value))
            //    //{
            //    //    serieAmountApproved.Add(value);
            //    //}
            //    //else
            //    //{
            //    //    serieAmountApproved.Add(0);
            //    //}

            //     value = 0;
            //    if (inprogress.TryGetValue(expected, out value))
            //    {
            //        serieInprogress.Add(value);
            //    }
            //    else
            //    {
            //        serieInprogress.Add(0);
            //    }
            //    value = 0;
            //    if (approved.TryGetValue(expected, out value))
            //    {
            //        serieApproved.Add(value);
            //    }
            //    else
            //    {
            //        serieApproved.Add(0);
            //    }

            //    value = 0;
            //    if (rejected.TryGetValue(expected, out value))
            //    {
            //        serieRejected.Add(value);
            //    }
            //    else
            //    {
            //        serieRejected.Add(0);
            //    }

               

            //}
            //dataGraph.Title = "Historico";
            ////serieAmountApproved.Reverse();
            //serieInprogress.Reverse();
            //serieApproved.Reverse();

            //serieRejected.Reverse();

            //dataGraph.DataLabels.Reverse();

            ////dataGraph.Data.Add(serieAmountApproved);
            //dataGraph.Data.Add(serieInprogress);
            //dataGraph.Data.Add(serieApproved);
            //dataGraph.Data.Add(serieRejected);
          

            //dataGraph.ChartType = ChartTypes.Historical;
            ////dataGraph.Series.Add(new Serie() { Title = "Monto aprobado", FillColor = "#949FB1" });
            //dataGraph.Series.Add(new Serie() { Title = "En proceso", FillColor = "#FDB45C" });
            //dataGraph.Series.Add(new Serie() { Title = "Aprobadas", FillColor = "#46BFBD" });
            //dataGraph.Series.Add(new Serie() { Title = "Rechazadas", FillColor = "#F7464A" });

            //dataGraph.HideLabels = true;
            //dataGraph.Ser

            return dataGraph;
        }

        #endregion
    }
}

        