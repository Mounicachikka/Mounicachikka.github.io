using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SaazApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaazApplication.Controllers
{
    public class Role2Controller : Controller
    {
        static string Error = "";
        static MiddleTyre Mid = new MiddleTyre();
        static DataTable dt;
        static DateTime firstdate;

        public ActionResult Homepage()
        {
            //ViewBag.Name = Session["Employee"].ToString();
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                return View();
            }
        }

        //--------------Company Details-------------------------------------------

        public ActionResult ViewCompanyDetails()
        {
            //CmpCombine mymodel = new CmpCombine();
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.RegisterItems = Mid.GetCompanyBasicDetails();
                    //ViewBag.RegisterItems = null;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        private ActionResult UpdateCompanyView()
        {
            UpdateViewCompany();
            return View();
        }

        private void UpdateViewCompany()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetCountry();
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList Countries = new SelectList(s);
            ViewData["Countries"] = Countries;
            dt = new DataTable();
            dt = MiddleTyre.GetCompanyNames();
            List<string> s2 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.CompanyName = s2;
            dt = new DataTable();
            dt = MiddleTyre.GetBankNames();
            List<string> s3 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList BankNames = new SelectList(s3);
            ViewData["BankNames"] = BankNames;
        }

        public ActionResult EditCmpDetails(int id)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                return View(Mid.GetCompany().Find(Cmp => Cmp.CmpModels.ID == id));
            }
        }

        [HttpPost]
        public ActionResult EditCmpDetails(int id, CmpModel obj, HttpPostedFileBase file)
        {
            try
            {
                Mid.UpdateCompany(obj, file);
                return RedirectToAction("GetCompanyDetails");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteCmp(int id)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                try
                {
                    if (Mid.DeleteCompany(id))
                    {
                        ViewBag.AlertMsg = "Company details deleted successfully";

                    }
                    return RedirectToAction("GetCompanyDetails");
                }
                catch
                {
                    return View();
                }
            }
        }


        //-------------------------------Employee Details---------------------------------------------------

        public ActionResult GetEmpDetails()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ModelState.Clear();
                return View(/*Mid.GetEmployee()*/);
            }
        }

        private ActionResult Viewform()
        {
            UpdateEmployeeData();
            return View();
        }

        private void UpdateEmployeeData()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetGenderNames();
            List<string> s1 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.Gender = s1;

            dt = new DataTable();
            dt = MiddleTyre.GetMaratualStatus();
            List<string> s2 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.MaritalStatus = s2;

            dt = new DataTable();
            dt = MiddleTyre.GetDepartmentName();
            List<string> s3 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.Department = s3;

            dt = new DataTable();
            dt = MiddleTyre.GetDesignationName();
            List<string> s4 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.Designation = s4;

            dt = new DataTable();
            dt = MiddleTyre.GetEmploymentType();
            List<string> s5 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.Employment_Type = s5;

            dt = new DataTable();
            dt = MiddleTyre.GetEmploymentRole();
            List<string> s6 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.EmployeeRole = s6;

            dt = new DataTable();
            dt = MiddleTyre.GetBloodGropu();
            List<string> s7 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.BloodType = s7;

            dt = new DataTable();
            dt = MiddleTyre.GetCountry();
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList Countries = new SelectList(s);
            ViewData["Countries"] = Countries;

            var dt2 = new DataTable
            {
                Columns = { { "EmailType", typeof(string) } }
            };
            dt2.Rows.Add("Personal");
            dt2.Rows.Add("Work");
            List<string> ss = dt2.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList EmailType = new SelectList(ss);
            ViewData["EmailType"] = EmailType;

            var dt3 = new DataTable
            {
                Columns = { { "ContactType", typeof(string) } }
            };
            dt3.Rows.Add("Mobile");
            dt3.Rows.Add("Landilne");
            List<string> ss3 = dt3.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList ContactType = new SelectList(ss3);
            ViewData["ContactType"] = ContactType;

            var dt33 = new DataTable
            {
                Columns = { { "AddressType", typeof(string) } }
            };
            dt33.Rows.Add("Temporary");
            dt33.Rows.Add("permanent");
            List<string> ss33 = dt33.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList AddressType = new SelectList(ss33);
            ViewData["AddressType"] = AddressType;

            dt = new DataTable();
            dt = MiddleTyre.GetCompanyNames();
            List<string> s8 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.CompanyName = s8;


            dt = new DataTable();
            dt = MiddleTyre.GetEmployeeId();
            List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            // SelectList CompanyNames = new SelectList(s2);
            ViewBag.EmployeeID = s9;

            dt = new DataTable();
            dt = MiddleTyre.GetBankNames();
            List<string> s33 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList BankNames = new SelectList(s33);
            ViewData["BankNames"] = BankNames;
        }


        public ActionResult VEmployeeDetails()
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    ModelState.Clear();
                    //CmpCombine cmb = new CmpCombine();
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }


        //-------------------------- DC Challan Details------------------------------------------------------

        [HttpGet]
        public ActionResult Challan()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdateDCData();
                return View();
            }
        }
        [HttpPost]
        public ActionResult Challan(ChallanModel Dc)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                Error = "";
                ViewBag.Error = null;
                int count = 0;
                if ((Dc.Description8 != null) && (Dc.Quantity8 != null))
                {
                    count = 7;
                }
                else
               if ((Dc.Description7 != null) && (Dc.Quantity7 != null))
                {
                    count = 6;
                }
                else
               if ((Dc.Description6 != null) && (Dc.Quantity6 != null))
                {
                    count = 5;
                }
                else
               if ((Dc.Description5 != null) && (Dc.Quantity5 != null))
                {
                    count = 4;
                }
                else
               if ((Dc.Description4 != null) && (Dc.Quantity4 != null))
                {
                    count = 3;
                }
                else
               if ((Dc.Description3 != null) && (Dc.Quantity3 != null))
                {
                    count = 2;
                }
                else
               if ((Dc.Description2 != null) && (Dc.Quantity2 != null))
                {
                    count = 1;
                }
                string DCNumber = "";
                string EmployeeId = "";
                if (Session["UserId"] != null)
                {
                    EmployeeId = Session["UserId"].ToString();
                }
                if (Mid.AddDC(Dc, EmployeeId, ref Error, ref DCNumber))
                {
                    ViewBag.message = "";
                }
                if (Error == "Sucess")
                {
                    for (int k = 0; k <= count; k++)
                    {
                        Error = "";
                        Mid.AddDCDescreption(Dc, DCNumber, k, ref Error);
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "DC data inserted sucessfully";
                    }
                }
                else
                {
                    ViewBag.Error = "Failed to insert DC data";
                    ViewBag.Error = Error;
                }
                if (Error == "Sucess")
                {
                    ModelState.Clear();
                }
                UpdateDCData();
                return View();
            }
        }

        private void UpdateDCData()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetCompanyNames();
            List<string> s8 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.CompanyName = s8;

            var dt2 = new DataTable
            {
                Columns = { { "Returnable", typeof(string) } }
            };
            dt2.Rows.Add("Returnable");
            dt2.Rows.Add("Non-Returnable");
            List<string> ss = dt2.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList EmailType = new SelectList(ss);
            ViewData["Returnable"] = EmailType;
        }

        public byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }

        public void DownloadPDF(string htmlToConvert)
        {

            // var viewResult = ViewEngines.Engines.FindView(controllerContext, "Index", null);
            string HTMLContent = "";
            //ViewResult v = View();
            //if (string.IsNullOrEmpty(v.ViewName))
            //    v.ViewName = RouteData.GetRequiredString("action");
            //ViewEngineResult result = null;
            //StringBuilder sb = new StringBuilder();
            //StringWriter textwriter = new StringWriter(sb);
            //HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
            //if (v.View == null)
            //{
            //    result = new ViewEngineResult(new WebFormView(this.ControllerContext, "~/Views/Role1/ViewChallanDetails.cshtml"), new WebFormViewEngine());
            //    v.View = result.View;
            //}
            //ViewContext viewContext = new ViewContext(ControllerContext, v.View, ViewData, TempData, htmlwriter);
            //v.View.Render(viewContext, htmlwriter);
            string html = htmlToConvert;
            HTMLContent = html;
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(HTMLContent));
            Response.End();
        }

        public ActionResult ViewChallanDetails()
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    if (Request.Form["DCNumberSelect"] != null)
                    {
                        return RedirectToAction("SelectChallan", "Role2");
                    }
                    else
                    {
                        ModelState.Clear();
                        string DCId = TempData["DCNumber"].ToString();
                        ViewBag.RegisterItems = NewMethod(DCId);
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ViewChallanDetails(ChallanModel obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    if (Request.Form["DCNumberSelect"] != null)
                    {
                        return RedirectToAction("SelectChallan", "Role2");
                    }
                    else
                    {
                        //ModelState.Clear();
                        string DCId = TempData["DCNumber"].ToString();
                        ViewBag.RegisterItems = NewMethod(DCId);
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        public ActionResult SelectChallan()
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    ModelState.Clear();
                    string EmployeeId = Session["UserId"].ToString();
                    dt = MiddleTyre.GetDCNumber(EmployeeId);
                    List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
                    SelectList Countries = new SelectList(s);
                    ViewData["DCNumber"] = Countries;
                    return View();
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        [HttpPost]
        public ActionResult SelectChallan(ChallanModel obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    TempData["DCNumber"] = obj.DC_Number;
                    return RedirectToAction("ViewChallanDetails", "Role2");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        private IEnumerable<ChallanModel> NewMethod(string DCId)
        {
            List<ChallanModel> DescList = new List<ChallanModel>();
            DataTable sdr = new DataTable();
            DataTable sdr1 = new DataTable();
            DataTable dt = new DataTable();
            MiddleTyre.GetDCInfo(DCId, ref sdr, ref sdr1, ref dt);
            try
            {
                string address = "";
                foreach (DataRow dr in sdr.Rows)
                {
                    ViewBag.CompanyName = Convert.ToString(dr["Company"]);
                    ViewBag.Website = Convert.ToString(dr["Website"]);
                    ViewBag.Logo = Convert.ToString(dr["Logo"]);
                    ViewBag.Mail = Convert.ToString(dr["EmailId"]);
                    ViewBag.Phone = Convert.ToString(dr["PhoneNumber"]);
                    ViewBag.Fax = Convert.ToString(dr["FaxNumber"]);
                    address = Convert.ToString(dr["Plot"]);
                    address += "," + Convert.ToString(dr["Street"]);
                    address += "," + Convert.ToString(dr["City"]) + "-" + Convert.ToString(dr["PinCode"]);
                }
                string[] AddSplit = address.Replace("\r\n", "").ToString().Split(',');
                for (int k = 0; k < AddSplit.Length; k = k + 2)
                {
                    try
                    {
                        switch (k)
                        {
                            case 0:
                                if (k == AddSplit.Length - 1)
                                {
                                    ViewBag.FromAddress1 = AddSplit[k];
                                }
                                else
                                    ViewBag.FromAddress1 = AddSplit[k] + "," + AddSplit[k + 1] + ",";
                                break;
                            case 2:
                                if (k == AddSplit.Length - 1)
                                {
                                    ViewBag.FromAddress2 = AddSplit[k];
                                }
                                else
                                    ViewBag.FromAddress2 = AddSplit[k] + "," + AddSplit[k + 1] + ",";
                                break;
                            case 4:
                                if (k == AddSplit.Length - 1)
                                {
                                    ViewBag.FromAddress3 = AddSplit[k];
                                }
                                else
                                    ViewBag.FromAddress3 = AddSplit[k] + "," + AddSplit[k + 1] + ",";
                                break;
                            case 6:
                                if (k == AddSplit.Length - 1)
                                {
                                    ViewBag.FromAddress4 = AddSplit[k];
                                }
                                else
                                    ViewBag.FromAddress4 = AddSplit[k] + "," + AddSplit[k + 1];
                                break;
                            default:
                                int kk = 0;
                                break;
                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            try
            {
                string ToAddress = "";
                foreach (DataRow dr in sdr1.Rows)
                {
                    ViewBag.Dc_Number = Convert.ToString(dr["DC_Number"]);

                    try
                    {
                        firstdate = DateTime.Parse(Convert.ToString(dr["Date"]),
                                           CultureInfo.CreateSpecificCulture("fr-FR"));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        var firstDateString = firstdate.ToString("dd/MM/yyyy");
                        ViewBag.Date = firstDateString;
                    }
                    catch (Exception)
                    {
                    }

                    //DateTime firstdate = DateTime.ParseExact(Convert.ToString(dr["Date"]),
                    //                     "dd/MM/yyyy hh:mm:ss tt",
                    //                     CultureInfo.InvariantCulture);
                    //var firstDateString = firstdate.ToString("dd-MM-yyyy");
                    //ViewBag.Date = firstDateString;
                    ViewBag.Subject = Convert.ToString(dr["Subject"]);
                    ViewBag.Matter = Convert.ToString(dr["Descreption"]);
                    ToAddress = Convert.ToString(dr["ToAddress"]);
                }
                string[] AddSplit2 = ToAddress.Replace("\r\n", "").ToString().Split(',');
                for (int k = 0; k < AddSplit2.Length; k = k + 2)
                {
                    try
                    {
                        switch (k)
                        {
                            case 0:
                                if (k == AddSplit2.Length - 1)
                                {
                                    ViewBag.ToAddress1 = AddSplit2[k];
                                }
                                else
                                    ViewBag.ToAddress1 = AddSplit2[k] + "," + AddSplit2[k + 1] + ",";
                                break;
                            case 2:
                                if (k == AddSplit2.Length - 1)
                                {
                                    ViewBag.ToAddress2 = AddSplit2[k];
                                }
                                else
                                    ViewBag.ToAddress2 = AddSplit2[k] + "," + AddSplit2[k + 1] + ",";
                                break;
                            case 4:
                                if (k == AddSplit2.Length - 1)
                                {
                                    ViewBag.ToAddress3 = AddSplit2[k];
                                }
                                else
                                    ViewBag.ToAddress3 = AddSplit2[k] + "," + AddSplit2[k + 1] + ",";
                                break;
                            case 6:
                                if (k == AddSplit2.Length - 1)
                                {
                                    ViewBag.ToAddress4 = AddSplit2[k];
                                }
                                else
                                    ViewBag.ToAddress4 = AddSplit2[k] + "," + AddSplit2[k + 1];
                                break;
                            default:
                                int kk = 0;
                                break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }

            try
            {
                DescList = (from DataRow dr in dt.Rows
                            select new ChallanModel()
                            {
                                ID = Convert.ToInt32(dr["S_No"].ToString()),
                                Description = Convert.ToString(dr["Description"].ToString()),
                                Quantity = Convert.ToString(dr["Quantity"].ToString()),
                                Returnable = Convert.ToString(dr["Retunable"].ToString()),
                            }).ToList();
            }
            catch (Exception)
            {
            }
            return DescList;
        }

        public string RenderViewAsString(string viewName, object model)
        {
            // create a string writer to receive the HTML code
            StringWriter stringWriter = new StringWriter();

            // get the view to render
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
            // create a context to render a view based on a model
            ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    new ViewDataDictionary(model),
                    new TempDataDictionary(),
                    stringWriter
                    );

            // render the view to a HTML code
            viewResult.View.Render(viewContext, stringWriter);

            // return the HTML code
            return stringWriter.ToString();
        }

        //-------------------------- Salary Details------------------------------------------------------

        private void UpdateEmployeeSalaryData()
        {
            var dt2 = new DataTable
            {
                Columns = { { "Month", typeof(string) } }
            };
            dt2.Rows.Add("January");
            dt2.Rows.Add("February");
            dt2.Rows.Add("March");
            dt2.Rows.Add("April");
            dt2.Rows.Add("May");
            dt2.Rows.Add("June");
            dt2.Rows.Add("July");
            dt2.Rows.Add("August");
            dt2.Rows.Add("September");
            dt2.Rows.Add("October");
            dt2.Rows.Add("November");
            dt2.Rows.Add("December");
            List<string> ss = dt2.AsEnumerable().Select(x => x[0].ToString()).ToList();
            SelectList EmailType = new SelectList(ss);
            ViewData["Months"] = EmailType;
        }

        [HttpGet]
        public ActionResult SalaryView()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                ViewBag.RegisterItems = null;
                UpdateEmployeeSalaryData();
                return View();
            }
        }

        [HttpPost]
        public ActionResult SalaryView(SalaryModel Sal)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                string Err = "";
                DataTable dt = new DataTable();
                Sal.Employee = Session["UserId"].ToString();
                IEnumerable<SalaryModel> sal = Mid.GetEmployeeSalaryDetails(Sal.Employee, Sal.Salary_for_mnth, Sal.Salary_for_yr, ref Err, ref dt);
                if (sal.Count() > 0)
                {
                    ViewBag.RegisterItems = sal;
                    ViewBag.Company = dt.Rows[0]["CompanyName"].ToString();
                    ViewBag.Formonth = dt.Rows[0]["ForMonth"].ToString();
                    ViewBag.DaysPaid = dt.Rows[0]["DaysPaid"].ToString();
                    ViewBag.ForYear = dt.Rows[0]["ForYear"].ToString();
                    ViewBag.Name = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["MiddleName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                    ViewBag.Id = dt.Rows[0]["UId"].ToString();
                    ViewBag.Pan = dt.Rows[0]["PanNumber"].ToString();
                    ViewBag.WMailId = dt.Rows[0]["WorkMailId"].ToString();
                    ViewBag.BankName = dt.Rows[0]["BankName"].ToString();
                    ViewBag.AccountNumber = dt.Rows[0]["AccountNumber"].ToString();
                    //@ViewBag.DOJ= dt.Rows[0]["DateOfJoining"].ToString();
                    @ViewBag.Department = dt.Rows[0]["Department"].ToString();

                    try
                    {
                        firstdate = DateTime.Parse(Convert.ToString(dt.Rows[0]["DateOfJoining"]),
                                           CultureInfo.CreateSpecificCulture("fr-FR"));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        var firstDateString = firstdate.ToString("dd/MM/yyyy");
                        ViewBag.DOJ = firstDateString;
                    }
                    catch (Exception)
                    {
                    }

                    //DateTime firstdate = DateTime.ParseExact(Convert.ToString(dt.Rows[0]["DateOfJoining"]),
                    //                   "dd/MM/yyyy hh:mm:ss tt",
                    //                   CultureInfo.InvariantCulture);
                    //var firstDateString = firstdate.ToString("dd-MM-yyyy");
                    //ViewBag.DOJ = firstDateString;
                    ViewBag.BasicSalary = dt.Rows[0]["BasicSalary"].ToString();
                    ViewBag.HRA = dt.Rows[0]["HRA"].ToString();
                    ViewBag.Spl_AWL = dt.Rows[0]["SpecialAllowance"].ToString();
                    ViewBag.Cny_AWL = dt.Rows[0]["ConveyanceAllowance"].ToString();
                    ViewBag.MedicalReimbursement = dt.Rows[0]["MedicalReimbursement"].ToString();
                    ViewBag.AnualBonus = dt.Rows[0]["AnualBonus"].ToString();
                    ViewBag.Others = dt.Rows[0]["Others"].ToString();
                    ViewBag.LocationAllowance = dt.Rows[0]["LocationAllowance"].ToString();
                    ViewBag.TotalBenefit = dt.Rows[0]["TotalBenefit"].ToString();
                    ViewBag.TDS = dt.Rows[0]["TDS"].ToString();
                    ViewBag.PT = dt.Rows[0]["ProfectionalTax"].ToString();
                    ViewBag.PF = dt.Rows[0]["PF"].ToString();
                    ViewBag.Advances = dt.Rows[0]["Advances"].ToString();
                    ViewBag.Reimbursement = dt.Rows[0]["Reimbursement"].ToString();
                    ViewBag.TotalDeduction = dt.Rows[0]["Total_Deduction"].ToString();
                    ViewBag.TotalSalary = dt.Rows[0]["TotalSalary"].ToString();
                }
                else
                {
                    ViewBag.RegisterItems = null;
                    ViewBag.Error = "Salary for the month: " + Sal.Salary_for_mnth + " and year: " + Sal.Salary_for_yr + " are empty";
                }
                UpdateEmployeeSalaryData();
                return View();
            }
        }

        //-------------------------- Invoice Details------------------------------------------------------
        private void UpdateInvoiceData()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetCompanyNames();
            List<string> s8 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.CompanyName = s8;
        }

        [HttpGet]
        public ActionResult Invoice()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdateInvoiceData();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Invoice(Invoice IV)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                Error = "";
                ViewBag.Error = null;
                int count = 0;
                if (IV.Description8 != null)
                {
                    count = 7;
                }
                else
               if (IV.Description7 != null)
                {
                    count = 6;
                }
                else
               if (IV.Description6 != null)
                {
                    count = 5;
                }
                else
               if (IV.Description5 != null)
                {
                    count = 4;
                }
                else
               if (IV.Description4 != null)
                {
                    count = 3;
                }
                else
               if (IV.Description3 != null)
                {
                    count = 2;
                }
                else
               if (IV.Description2 != null)
                {
                    count = 1;
                }
                string IVNumber = "";
                string EmployeeId = "";
                if (Session["UserId"] != null)
                {
                    EmployeeId = Session["UserId"].ToString();
                }
                if (Mid.AddIV(IV, EmployeeId, ref Error, ref IVNumber))
                {
                    ViewBag.message = "";
                }
                if (Error == "Sucess")
                {
                    for (int k = 0; k <= count; k++)
                    {
                        Error = "";
                        Mid.AddIVDescreption(IV, IVNumber, k, ref Error);
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Invoice data inserted sucessfully";
                    }
                }
                else
                {
                    ViewBag.Error = "Failed to insert DC data";
                    ViewBag.Error = Error;
                }
                if (Error == "Sucess")
                {
                    ModelState.Clear();
                }
                UpdateInvoiceData();
                return View();
            }
        }
    }
}