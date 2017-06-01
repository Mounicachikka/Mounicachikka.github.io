using HiQPdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SaazApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;

namespace SaazApplication.Controllers
{
    public class Role1Controller : Controller
    {
        static string Error = "";
        static MiddleTyre Mid = new MiddleTyre();
        static DataTable dt;

        public ActionResult Homepage()
        {
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

        [HttpGet]
        public ActionResult CompanyDetails()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdateViewCompany();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyDetails(CmpCombine cmb, HttpPostedFileBase file)// controller to insert data to database
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                Error = "";
                ViewBag.Error = null;
                try
                {
                    //if(ModelState.IsValid())
                    //{ }
                    if (Request.Form["CompanyCreate"] != null)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase myfile = files[i];
                            if (myfile.ContentLength > 0)
                            {
                                if (myfile.FileName != null)
                                {
                                    var binaryReader = new BinaryReader(myfile.InputStream);
                                    byte[] array = binaryReader.ReadBytes(myfile.ContentLength);
                                    string base64ImageRepresentation = Convert.ToBase64String(array);
                                    cmb.CmpModels.Logo = base64ImageRepresentation;
                                }
                            }
                        }
                        if (cmb.CmpModels.Company == null)
                        {
                            ViewBag.Error = "Company Name is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Abbrevation == null)
                        {
                            ViewBag.Error = "Abbrevation is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.City == null)
                        {
                            ViewBag.Error = "City Name is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Country == null)
                        {
                            ViewBag.Error = "Country Name is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.EmailID == null)
                        {
                            ViewBag.Error = "Email ID is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Website == null)
                        {
                            ViewBag.Error = "Website Name is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Street == null)
                        {
                            ViewBag.Error = "Street is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.State == null)
                        {
                            ViewBag.Error = "State is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.PlotNo == null)
                        {
                            ViewBag.Error = "Plot Number is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Pincode == null)
                        {
                            ViewBag.Error = "Pincode Number is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.MobileNo == null)
                        {
                            ViewBag.Error = "Contact Number is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.CmpModels.Logo == null)
                        {
                            ViewBag.Error = "Logo is required";
                            return UpdateCompanyView();
                        }
                        if (Mid.AddCompany(cmb, file, ref Error))
                        {
                            ViewBag.message = "";
                        }
                        if (Error == "Sucess")
                        {
                            ViewBag.Error = "Company Details inserted sucessfully";
                        }
                        else
                        {
                            ViewBag.Error = "Failed to insert Company Details";
                            ViewBag.Error = Error;
                        }
                    }
                    else
                    if (Request.Form["CftCreate"] != null)
                    {
                        int count = 0;
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase myfile = files[i];
                            if (myfile.ContentLength > 0)
                            {
                                if (myfile.FileName != null)
                                {
                                    var binaryReader = new BinaryReader(myfile.InputStream);
                                    byte[] array = binaryReader.ReadBytes(myfile.ContentLength);
                                    string base64ImageRepresentation = Convert.ToBase64String(array);
                                    //byte[] base64ImageRepresentationss = Convert.FromBase64String(base64ImageRepresentation);
                                    switch (count)
                                    {
                                        case 0:
                                            cmb.CmpCftModels.CIN = base64ImageRepresentation;
                                            break;
                                        case 1:
                                            cmb.CmpCftModels.AOA = base64ImageRepresentation;
                                            break;
                                        case 2:
                                            cmb.CmpCftModels.MOA = base64ImageRepresentation;
                                            break;
                                        case 3:
                                            cmb.CmpCftModels.PAN = base64ImageRepresentation;
                                            break;
                                        case 4:
                                            cmb.CmpCftModels.TAN = base64ImageRepresentation;
                                            break;
                                        case 5:
                                            cmb.CmpCftModels.PT = base64ImageRepresentation;
                                            break;
                                        case 6:
                                            cmb.CmpCftModels.ESI = base64ImageRepresentation;
                                            break;
                                        case 7:
                                            cmb.CmpCftModels.EPF = base64ImageRepresentation;
                                            break;
                                        case 8:
                                            cmb.CmpCftModels.KYC = base64ImageRepresentation;
                                            break;
                                        case 9:
                                            cmb.CmpCftModels.IEC = base64ImageRepresentation;
                                            break;
                                        case 10:
                                            cmb.CmpCftModels.UAD = base64ImageRepresentation;
                                            break;
                                        default:
                                            int k = 0;
                                            break;
                                    }
                                    count++;
                                }
                            }
                        }
                        if (Mid.AddCertificate(cmb, file, ref Error))
                        {
                            ViewBag.message = "";
                        }
                        if (Error == "Sucess")
                        {
                            ViewBag.Error = "Company certificates uploaded sucessfully";
                        }
                        else
                        {
                            ViewBag.Error = "Failed to upload Company certificates";
                            ViewBag.Error = Error;
                        }
                    }
                    else
                    if (Request.Form["BankCreate"] != null)
                    {
                        if (cmb.BnkDtls.Company == null)
                        {
                            ViewBag.Error = "Select company";
                            return UpdateCompanyView();
                        }
                        if (cmb.BnkDtls.BankName == null)
                        {
                            ViewBag.Error = "Bank Name is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.BnkDtls.IFSC == null)
                        {
                            ViewBag.Error = "IFSC code is required";
                            return UpdateCompanyView();
                        }
                        if (cmb.BnkDtls.AcHoldername != "" && cmb.BnkDtls.Acnumber != null)
                        {
                            if (Mid.Addbank(cmb, file, ref Error))
                            {
                                ViewBag.message = "";
                            }
                            if (Error == "Sucess")
                            {
                                ViewBag.Error = "Company Bank Details inserted sucessfully";
                            }
                            else
                            {
                                ViewBag.Error = "Failed to insert Company Bank Details";
                                ViewBag.Error = Error;
                            }
                        }
                        else
                        {
                            ViewBag.Error = "AcHoldername,Acnumber cannot be empty";
                        }
                    }
                    if (Error == "Sucess")
                    {
                        ModelState.Clear();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
                return UpdateCompanyView();
            }
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

        public IEnumerable<EmpCombine> GetEmployeeDetails()
        {
            try
            {
                DataTable Basic = new DataTable();
                DataTable Education = new DataTable();
                DataTable Work = new DataTable();
                MiddleTyre.GetEmployeeDetails(ref Basic);

                List<EmpCombine> EmpList = new List<EmpCombine>();
                EmpCombine obj = new EmpCombine();
                foreach (DataRow dr in Basic.Rows)
                {
                    obj = new EmpCombine();
                    string val = dr["Id"].ToString();
                    obj.EmployeeBasicDetails.Id = Convert.ToInt32(dr["Id"].ToString());
                    obj.EmployeeBasicDetails.UniqueId = dr["UId"].ToString();
                    obj.EmployeeBasicDetails.FirstName = dr["FirstName"].ToString();
                    obj.EmployeeBasicDetails.MiddleName = dr["MiddleName"].ToString();
                    obj.EmployeeBasicDetails.LastName = dr["LastName"].ToString();
                    obj.EmployeeBasicDetails.Name = dr["FirstName"].ToString() + " " + dr["MiddleName"].ToString() + " " + dr["LastName"].ToString();
                    // obj.EmployeeBasicDetails.Date_of_birth = dr["DateOfBirth"].ToString();

                    try
                    {
                        firstdate = DateTime.Parse(Convert.ToString(dr["DateOfBirth"]),
                                           CultureInfo.CreateSpecificCulture("fr-FR"));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        var firstDateString = firstdate.ToString("dd/MM/yyyy");
                        obj.EmployeeBasicDetails.Date_of_birth = firstDateString;
                    }
                    catch (Exception)
                    {
                    }

                    try
                    {
                        firstdate = DateTime.Parse(Convert.ToString(dr["DateOfJoining"]),
                                           CultureInfo.CreateSpecificCulture("fr-FR"));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        var firstDateString = firstdate.ToString("dd/MM/yyyy");
                        obj.EmployeeBasicDetails.Date_of_join = firstDateString;
                    }
                    catch (Exception)
                    {
                    }


                    //obj.EmployeeBasicDetails.Date_of_join = dr["DateOfJoining"].ToString();
                    obj.EmployeeBasicDetails.BirthPlace = dr["PlaceOfBirth"].ToString();
                    obj.EmployeeBasicDetails.PAN = dr["PanNumber"].ToString();
                    obj.EmployeeBasicDetails.Passport = dr["PassPort"].ToString();
                    obj.EmployeeBasicDetails.Nationality = dr["Nationality"].ToString();
                    obj.EmployeeBasicDetails.Driver_License = dr["DrivingLicence"].ToString();
                    obj.EmployeeBasicDetails.Unique_ID = dr["Audher"].ToString();
                    obj.EmployeeBasicDetails.Employee_profile = dr["Pic"].ToString();
                    obj.EmployeeBasicDetails.Gender = dr["Gender"].ToString();
                    obj.EmployeeBasicDetails.MaritalStatus = dr["Marital_Status"].ToString();
                    obj.EmployeeBasicDetails.Department = dr["Department"].ToString();
                    obj.EmployeeBasicDetails.BloodType = dr["Blood_Group"].ToString();
                    obj.EmployeeBasicDetails.Designation = dr["Designation"].ToString();
                    obj.EmployeeBasicDetails.Employment_Type = dr["Employment_Type"].ToString();
                    obj.EmployeeBasicDetails.EmployeeRole = dr["Employment_Role"].ToString();
                    obj.EmployeeBasicDetails.AddressType = dr["Add_Type"].ToString();
                    obj.EmployeeBasicDetails.plot = dr["Plot"].ToString();
                    obj.EmployeeBasicDetails.Street = dr["Street"].ToString();
                    obj.EmployeeBasicDetails.City = dr["City"].ToString();
                    obj.EmployeeBasicDetails.State = dr["State"].ToString();
                    obj.EmployeeBasicDetails.PinCode = dr["PinCode"].ToString();
                    obj.EmployeeBasicDetails.Country = dr["Country"].ToString();
                    obj.EmployeeBasicDetails.CNumber = dr["PhoneNumber"].ToString();
                    obj.EmployeeBasicDetails.Company = dr["CompanyName"].ToString();
                    obj.EmployeeBasicDetails.PersonalmailId = dr["PersonalMailId"].ToString();
                    obj.EmployeeBasicDetails.MailId = dr["WorkMailId"].ToString();


                    obj.EmployeeEmergencyDetails.Contactname = dr["ContactName"].ToString();
                    obj.EmployeeEmergencyDetails.Relation = dr["Reletion"].ToString();
                    obj.EmployeeEmergencyDetails.Plot = dr["Plot"].ToString();
                    obj.EmployeeEmergencyDetails.City = dr["City"].ToString();
                    obj.EmployeeEmergencyDetails.Street = dr["Street"].ToString();
                    obj.EmployeeEmergencyDetails.State = dr["State"].ToString();
                    obj.EmployeeEmergencyDetails.PinCode = dr["pincode"].ToString();
                    obj.EmployeeEmergencyDetails.Country = dr["Country"].ToString();
                    obj.EmployeeEmergencyDetails.CNumber = dr["PhoneNumber"].ToString();
                    obj.EmployeeEmergencyDetails.Email = dr["EmailId"].ToString();

                    obj.EmployeeInsuranceDetails.Insurance_company = dr["ICompany"].ToString();
                    obj.EmployeeInsuranceDetails.PolicyNumber = dr["PolicyNumber"].ToString();
                    obj.EmployeeInsuranceDetails.Policy_Name = dr["PolicyName"].ToString();


                    obj.EmployeeBankDetails.AccountHoldername = dr["AccountName"].ToString();
                    obj.EmployeeBankDetails.AccountNumber = dr["AccountNumber"].ToString();
                    obj.EmployeeBankDetails.IFSCCode = dr["IFSC_Code"].ToString();
                    obj.EmployeeBankDetails.MICR_Code = dr["MICR_Code"].ToString();
                    obj.EmployeeBankDetails.Branch = dr["Branch"].ToString();
                    obj.EmployeeBankDetails.Address = dr["Address"].ToString();
                    obj.EmployeeBankDetails.City = dr["BCity"].ToString();
                    obj.EmployeeBankDetails.District = dr["BDistrict"].ToString();
                    obj.EmployeeBankDetails.State = dr["BState"].ToString();
                    obj.EmployeeBankDetails.Country = dr["BCountry"].ToString();
                    obj.EmployeeBankDetails.BankName = dr["BBankName"].ToString();

                    EmpList.Add(obj);
                }



                return EmpList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        [HttpGet]
        public ActionResult EmployeeDetails()/*AddPersonalDtls()*/
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdateEmployeeData();
                return View();
            }
        }

        [HttpPost]
        public ActionResult EmployeeDetails(EmpCombine Ecmb, HttpPostedFileBase file)/*AddPersonalDtls()*/
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                if (Request.Form["EmpBSC"] != null)
                {

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase myfile = files[i];
                        if (myfile.ContentLength > 0)
                        {
                            if (myfile.FileName != null)
                            {
                                var binaryReader = new BinaryReader(myfile.InputStream);
                                byte[] array = binaryReader.ReadBytes(myfile.ContentLength);
                                string base64ImageRepresentation = Convert.ToBase64String(array);
                                Ecmb.EmpBasics.Employee_profile = base64ImageRepresentation;
                            }
                        }

                        if (Ecmb.EmpBasics.FirstName == null)
                        {
                            ViewBag.Error = "FirstName is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.LastName == null)
                        {
                            ViewBag.Error = "LastName is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.AddressType == null)
                        {
                            ViewBag.Error = "AddressType is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.BirthPlace == null)
                        {
                            ViewBag.Error = "BirthPlace is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.BloodType == null)
                        {
                            ViewBag.Error = "Blood Group is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.City == null)
                        {
                            ViewBag.Error = "City is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Company == null)
                        {
                            ViewBag.Error = "Company is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Date_of_birth == null)
                        {
                            ViewBag.Error = "Date of birth is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Date_of_join == null)
                        {
                            ViewBag.Error = "Date of join is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Department == null)
                        {
                            ViewBag.Error = "Department is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Designation == null)
                        {
                            ViewBag.Error = "Designation is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.EmployeeId == null)
                        {
                            ViewBag.Error = "EmployeeId is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.EmployeeRole == null)
                        {
                            ViewBag.Error = "EmployeeRole is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.MailId == null)
                        {
                            ViewBag.Error = "EmailId is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.PAN == null)
                        {
                            ViewBag.Error = "PAN is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.PinCode == null)
                        {
                            ViewBag.Error = "PinCode is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.plot == null)
                        {
                            ViewBag.Error = "plot is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Street == null)
                        {
                            ViewBag.Error = "Street is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.State == null)
                        {
                            ViewBag.Error = "State is required";
                            return Viewform();
                        }
                        if (Ecmb.EmpBasics.Employee_profile == null)
                        {
                            ViewBag.Error = "Profile Pic needed";
                            return Viewform();
                        }
                    }
                    if (Mid.AddEmployee(Ecmb, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee data inserted sucessfully";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Employee data";
                        ViewBag.Error = Error;
                    }
                }
                else if (Request.Form["EmpEgy"] != null)
                {
                    if (Ecmb.EmpEmergencys.Employee_EmgUniqueId == null)
                    {
                        ViewBag.Error = "EmployeeId is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.Contactname == null)
                    {
                        ViewBag.Error = "Contactname is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.Relation == null)
                    {
                        ViewBag.Error = "Relation is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.Email == null)
                    {
                        ViewBag.Error = "Email is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.PinCode == null)
                    {
                        ViewBag.Error = "PinCode is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.Plot == null)
                    {
                        ViewBag.Error = "plot is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.Street == null)
                    {
                        ViewBag.Error = "Street is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEmergencys.State == null)
                    {
                        ViewBag.Error = "State is required";
                        return Viewform();
                    }
                    if (Mid.AddEmpEmergencyContactDetails(Ecmb, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee Emergency Contact Details inserted sucessfully";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Emergency Contact Details";
                        ViewBag.Error = Error;
                    }
                }
                else if (Request.Form["EmpINS"] != null)
                {

                    if (Mid.AddEmpInsurenceDetails(Ecmb, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee Insurence Details inserted sucessfully";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Insurence Details";
                        ViewBag.Error = Error;
                    }
                }
                else if (Request.Form["EmpBNK"] != null)
                {
                    if (Ecmb.EmpBanks.Employee_UniqueId == null)
                    {
                        ViewBag.Error = "EmployeeId is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpBanks.AccountHoldername == null)
                    {
                        ViewBag.Error = "AccountHoldername is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpBanks.AccountNumber == null)
                    {
                        ViewBag.Error = "Account Number is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpBanks.BankName == null)
                    {
                        ViewBag.Error = "BankName is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpBanks.IFSCCode == null)
                    {
                        ViewBag.Error = "IFSCCode is required";
                        return Viewform();
                    }
                    if (Mid.AddEmpBankDetails(Ecmb, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee Bank Details inserted sucessfully";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Bank Details";
                        ViewBag.Error = Error;
                    }

                }
                else
                if (Request.Form["EmpEDU"] != null)
                {
                    int count2 = 0;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase myfile = files[i];
                        if (myfile.ContentLength > 0)
                        {
                            if (myfile.FileName != null)
                            {
                                var binaryReader = new BinaryReader(myfile.InputStream);
                                byte[] array = binaryReader.ReadBytes(myfile.ContentLength);
                                string base64ImageRepresentation = Convert.ToBase64String(array);
                                switch (count2)
                                {
                                    case 0:
                                        Ecmb.EmpEducations.Document1 = base64ImageRepresentation;
                                        break;
                                    case 1:
                                        Ecmb.EmpEducations.Document2 = base64ImageRepresentation;
                                        break;
                                    case 2:
                                        Ecmb.EmpEducations.Document3 = base64ImageRepresentation;
                                        break;
                                    case 3:
                                        Ecmb.EmpEducations.Document4 = base64ImageRepresentation;
                                        break;
                                    default:
                                        int k = 0;
                                        break;
                                }
                                count2++;
                            }
                        }
                    }
                    if (Ecmb.EmpEducations.Employee_UniqueId == null)
                    {
                        ViewBag.Error = "Employee Id is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.Document1 == null)
                    {
                        ViewBag.Error = "Atleast 1 document name is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.InstutionName1 == null)
                    {
                        ViewBag.Error = "Instution Name is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.Location1 == null)
                    {
                        ViewBag.Error = "Location Name is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.Qualification1 == null)
                    {
                        ViewBag.Error = "Qualification Name is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.ToYear1 == null)
                    {
                        ViewBag.Error = "ToYear is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpEducations.FromYear1 == null)
                    {
                        ViewBag.Error = "FromYear is required";
                        return Viewform();
                    }
                    int count = 0;
                    if ((Ecmb.EmpEducations.Qualification4 != "" || Ecmb.EmpEducations.Qualification4 != null) && (Ecmb.EmpEducations.Location4 != "" || Ecmb.EmpEducations.Location4 != null))
                    {
                        count = 3;
                    }
                    else
                    if ((Ecmb.EmpEducations.Qualification3 != "" || Ecmb.EmpEducations.Qualification3 != null) && (Ecmb.EmpEducations.Location3 != "" || Ecmb.EmpEducations.Location3 != null))
                    {
                        count = 2;
                    }
                    else
                    if ((Ecmb.EmpEducations.Qualification2 != "" || Ecmb.EmpEducations.Qualification2 != null) && (Ecmb.EmpEducations.Location2 != "" || Ecmb.EmpEducations.Location2 != null))
                    {
                        count = 1;
                    }
                    for (int k = 0; k <= count; k++)
                    {
                        Error = "";
                        if (Mid.AddEmpEducationDetails(Ecmb, k, ref Error))
                        {
                            ViewBag.message = "";
                        }
                        if (Error == "Sucess")
                        {
                            ViewBag.Error = "Employee Education Details inserted sucessfully";
                        }
                        else
                        {
                            ViewBag.Error = "Failed to insert Education Details";
                            ViewBag.Error = Error;
                        }
                    }
                }
                else if (Request.Form["EmpEXP"] != null)
                {
                    int count2 = 0;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase myfile = files[i];
                        if (myfile.ContentLength > 0)
                        {
                            if (myfile.FileName != null)
                            {
                                var binaryReader = new BinaryReader(myfile.InputStream);
                                byte[] array = binaryReader.ReadBytes(myfile.ContentLength);
                                string base64ImageRepresentation = Convert.ToBase64String(array);
                                switch (count2)
                                {
                                    case 0:
                                        Ecmb.EmpExperiences.Document1 = base64ImageRepresentation;
                                        break;
                                    case 1:
                                        Ecmb.EmpExperiences.Document2 = base64ImageRepresentation;
                                        break;
                                    case 2:
                                        Ecmb.EmpExperiences.Document3 = base64ImageRepresentation;
                                        break;
                                    case 3:
                                        Ecmb.EmpExperiences.Document4 = base64ImageRepresentation;
                                        break;
                                    default:
                                        int k = 0;
                                        break;
                                }
                                count2++;
                            }
                        }
                    }
                    int count = 0;
                    if ((Ecmb.EmpExperiences.Cmp_Nm4 != null) && (Ecmb.EmpExperiences.Cmp_Location4 != null))
                    {
                        count = 3;
                    }
                    else
                    if ((Ecmb.EmpExperiences.Cmp_Nm3 != null) && (Ecmb.EmpExperiences.Cmp_Location3 != null))
                    {
                        count = 2;
                    }
                    else
                    if ((Ecmb.EmpExperiences.Cmp_Nm2 != null) && (Ecmb.EmpExperiences.Cmp_Location2 != null))
                    {
                        count = 1;
                    }
                    for (int k = 0; k <= count; k++)
                    {
                        Error = "";
                        if (Mid.AddEmpExperenceDetails(Ecmb, k, ref Error))
                        {
                            ViewBag.message = "";
                        }
                        if (Error == "Sucess")
                        {
                            ViewBag.Error = "Employee Experence Details inserted sucessfully";
                        }
                        else
                        {
                            ViewBag.Error = "Failed to insert Experence Details";
                            ViewBag.Error = Error;
                        }
                    }
                }
                else
                if (Request.Form["EmpMail"] != null)
                {
                    Error = "";
                    if (Ecmb.EmpWorkMailId.EmployeeId == null)
                    {
                        ViewBag.Error = "Employee Id is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpWorkMailId.MailId == null)
                    {
                        ViewBag.Error = "Email Id is required";
                        return Viewform();
                    }
                    if (Ecmb.EmpWorkMailId.Password == null)
                    {
                        ViewBag.Error = "Password is required";
                        return Viewform();
                    }
                    if (Mid.AddEmpWorkMailId(Ecmb, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee Work mailId inserted sucessfully";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Work mailId Details";
                        ViewBag.Error = Error;
                    }
                }
                if (Error == "Sucess")
                {
                    ModelState.Clear();
                }
                return Viewform();
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DynamicallyRender(string name)
        {
            dt = new DataTable();
            dt = MiddleTyre.GetEmployeeId();
            List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.EmployeeID = s9;
            //ViewBag.EmployeeEducationDetails =
            IEnumerable<EmpEducation> EDUC = MiddleTyre.GetEmployeeEducationDetails(name);
            if (EDUC.Count() > 0)
            {
                ViewBag.EmployeeEducationDetails = EDUC;
            }
            else
                ViewBag.EmployeeEducationDetails = null;
            return PartialView("_EmployeeEducationDetails");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DynamicallyRender1(string name)
        {
            dt = new DataTable();
            dt = MiddleTyre.GetEmployeeId();
            List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.EmployeeID = s9;
            IEnumerable<EmpExperience> EXP = MiddleTyre.GetEmployeeExperienceDetails(name);
            if (EXP.Count() > 0)
            {
                ViewBag.EmployeeExperienceDetails = EXP;
            }
            else
                ViewBag.EmployeeExperienceDetails = null;
            return PartialView("_EmployeeExperienceDetails");
        }

        //public ActionResult VEmployeeDetails()
        //{
        //    try
        //    {
        //        if (Login.HasLogin == false)
        //        {
        //            return RedirectToAction("Signin", "Admin");
        //        }
        //        else
        //        {
        //            ModelState.Clear();
        //            CmpCombine cmb = new CmpCombine();
        //            IEnumerable<EmpCombine> Employee = GetEmployeeDetails();
        //            EmpEducation cmbemp = new EmpEducation();
        //            dt = new DataTable();
        //            dt = MiddleTyre.GetEmployeeId();
        //            List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
        //            ViewBag.EmployeeID = s9;
        //            ViewBag.EmployeeEducationDetails = null;
        //            ViewBag.RegisterItems = Employee;
        //            return View(Employee);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //    return View();
        //}

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
                    CmpCombine cmb = new CmpCombine();
                    IEnumerable<EmpCombine> Employee = GetEmployeeDetails();
                    EmpEducation cmbemp = new EmpEducation();
                    /*added this line*/
                    EmpExperience cmbexp = new EmpExperience();
                    dt = new DataTable();
                    dt = MiddleTyre.GetEmployeeId();
                    List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
                    ViewBag.EmployeeID = s9;
                    ViewBag.EmployeeEducationDetails = null;
                    /*added this line*/
                    ViewBag.EmployeeExperienceDetails = null;
                    ViewBag.RegisterItems = Employee;
                    return View(Employee);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }


        public JsonResult UpdateInsuranceDetails(EmpCombine Model)
        {
            string message = "";           
            MiddleTyre.UpdateEmpInsurenceDetails(Model,ref message);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmergencyContactDetails(EmpCombine Model)
        {
            string message = "";
            //MiddleTyre mid = new MiddleTyre();
            //Model.EmployeeEmergencyDetails.Employee_EmgUniqueId
            MiddleTyre.UpdateEmpEmergencyContactDetails(Model, ref message);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBankDetails(EmpCombine Model)
        {
            string message = "";           
            MiddleTyre.UpdateEmpBankDetails(Model, ref message);
            return Json(message, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateEmployeeDetails(EmpCombine Model)
        {
            string message = "";
          //  MiddleTyre.UpdateEmpBasicDetails(Model, ref message);
            return Json(message, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateEducationalDetails(EmpCombine Model)
        {
            string message = "";
            //MiddleTyre.UpdateEmpEducationalDetails(Model, ref message);
            return Json(message, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateExperienceDetails(EmpCombine Model)
        {
            string message = "";
            //MiddleTyre.UpdateEmpExperiencdeDetails(Model, ref message);
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        //------------------------ Common Data-------------------------------------------------------------

        public JsonResult States(string Country)
        {
            List<string> StatesList = new List<string>();
            dt = new DataTable();
            dt = MiddleTyre.GetState(Country);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            return Json(s);
        }

        public JsonResult IFSCCode(string BankName)
        {
            List<string> StatesList = new List<string>();
            dt = new DataTable();
            dt = MiddleTyre.GetIFSCCode(BankName);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            return Json(s);
        }

        public JsonResult GetMailId(string EMPWorkMail)
        {
            List<string> StatesList = new List<string>();
            dt = new DataTable();
            dt = MiddleTyre.GetMailId(EMPWorkMail);
            List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            return Json(s);
        }

        //-------------------------- DC Challan Details------------------------------------------------------
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
                string EmployeeId = "SZ017";
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

        [HttpGet]
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
                        return RedirectToAction("SelectChallan", "Role1");
                    }
                    else
                    {
                        ModelState.Clear();
                        string DCId = TempData["DCNumber"].ToString();
                        ViewBag.RegisterItems = DCData(DCId);
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
                        return RedirectToAction("SelectChallan", "Role1");
                    }
                    else
                    {
                        //ModelState.Clear();
                        string DCId = TempData["DCNumber"].ToString();
                        ViewBag.RegisterItems = DCData(DCId);
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
                    dt = MiddleTyre.GetDCNumber();
                    List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
                    SelectList DCNumber = new SelectList(s);
                    ViewData["DCNumber"] = DCNumber;
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
                    return RedirectToAction("ViewChallanDetails", "Role1");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        private IEnumerable<ChallanModel> DCData(string DCId)
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
                    ViewBag.CompanyName = Convert.ToString(dr["Company"]);// + " Systems Pvt Ltd.";
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
        [HttpGet]
        public ActionResult SalaryDetails()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdateEmployeeSalaryData();
                return View();
            }
        }

        [HttpPost]
        public ActionResult SalaryDetails(SalaryModel Sal)
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                if (Request.Form["EmpSlry"] != null)
                {
                    if (Mid.AddSalaryDetails(Sal, ref Error))
                    {
                        ViewBag.message = "";
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "Employee salary details inserted sucessfully for month of " + Sal.Salary_for_mnth;
                    }
                    else
                    {
                        ViewBag.Error = "Failed to insert Employee data";
                        ViewBag.Error = Error;
                    }
                }
                if (Error == "Sucess")
                {
                    ModelState.Clear();
                }
                UpdateEmployeeSalaryData();
                return View();
            }
        }

        private void UpdateEmployeeSalaryData()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetEmployeeId();
            List<string> s9 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.EmployeeID = s9;

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
        static DateTime firstdate;
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
                string EmployeeId = "SZ017";
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
                    ViewBag.Error = "Failed to insert Invoice data";
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

        public ActionResult SelectInvoice()
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
                    dt = MiddleTyre.GetIVNumber();
                    List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
                    SelectList DCNumber = new SelectList(s);
                    ViewData["IVNumber"] = DCNumber;
                    return View();
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        [HttpPost]
        public ActionResult SelectInvoice(Invoice obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    TempData["IVNumber"] = obj.IV_Number;
                    return RedirectToAction("ViewInvoiceDetails", "Role1");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewInvoiceDetails()
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
                        return RedirectToAction("SelectInvoice", "Role1");
                    }
                    else
                    {
                        ModelState.Clear();
                        string IVId = TempData["IVNumber"].ToString();
                        ViewBag.RegisterItems = InvoiceData(IVId);
                        string Val = @ViewBag.Currency;
                        List<WebGridColumn> columns = new List<WebGridColumn>();
                        columns.Add(new WebGridColumn() { ColumnName = "ID", Header = "S.No",  CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Description", Header = "Description Of Goods", CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Quantity", Header = "Quantity Units", CanSort = false, Style = "pass" });
                        columns.Add(new WebGridColumn() { ColumnName = "Rate", Header = "Rate " + Val, CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Per", Header = "Per", CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "TotalAmount", Header = "Amount " + Val, CanSort = false, Style = "text-align: reght;" });
                        ViewBag.Columns = columns;
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
        public ActionResult ViewInvoiceDetails(Invoice obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    if (Request.Form["IVNumberSelect"] != null)
                    {
                        return RedirectToAction("SelectInvoice", "Role1");
                    }
                    else
                    {
                        string DCId = TempData["IVNumber"].ToString();
                        ViewBag.RegisterItems = InvoiceData(DCId);
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

        private IEnumerable<Invoice> InvoiceData(string IVId)
        {
            List<Invoice> DescList = new List<Invoice>();
            DataTable sdr = new DataTable();
            DataTable sdr1 = new DataTable();
            DataTable dt = new DataTable();
            DataTable BankDetails = new DataTable();
            MiddleTyre.GetIVInfo(IVId, ref sdr, ref sdr1, ref dt, ref BankDetails);
            try
            {
                string address = "";
                foreach (DataRow dr in sdr.Rows)
                {
                    ViewBag.CompanyName = Convert.ToString(dr["Company"]);// + " Systems Pvt Ltd.";
                    ViewBag.Website = Convert.ToString(dr["Website"]);
                    ViewBag.Logo = Convert.ToString(dr["Logo"]);
                    ViewBag.Mail = Convert.ToString(dr["EmailId"]);
                    ViewBag.Phone = Convert.ToString(dr["PhoneNumber"]);
                    ViewBag.Fax = Convert.ToString(dr["FaxNumber"]);
                    address = Convert.ToString(dr["Plot"]);
                    address += "," + Convert.ToString(dr["Street"]);
                    address += "," + Convert.ToString(dr["City"]) + "-" + Convert.ToString(dr["PinCode"]);
                }
                foreach (DataRow dr in BankDetails.Rows)
                {
                    ViewBag.BankName = Convert.ToString(dr["BankName"]);// + " Systems Pvt Ltd.";
                    ViewBag.AccNo = Convert.ToString(dr["AccountNumber"]);
                    ViewBag.Branch = Convert.ToString(dr["Branch"]);
                    ViewBag.SWIFT_Code = Convert.ToString(dr["SWIFT_Code"]);
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
                    ViewBag.IV_Number = Convert.ToString(dr["Invoice_Number"]);
                    ViewBag.Currency = dr["Currency"].ToString();
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
                    ViewBag.ModeOfPayment = Convert.ToString(dr["ModeOfPayment"]);
                    ViewBag.ExportersRefNo = Convert.ToString(dr["ExportersRefNo"]);
                    ViewBag.PONumber = Convert.ToString(dr["PO_Number"]);
                    try
                    {
                        firstdate = DateTime.Parse(Convert.ToString(dr["PO_Date"]),
                                           CultureInfo.CreateSpecificCulture("fr-FR"));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        var firstDateString = firstdate.ToString("dd/MM/yyyy");
                        ViewBag.PO_Date = firstDateString;
                    }
                    catch (Exception)
                    {
                    }
                    //ViewBag.PO_Date = Convert.ToString(dr["PO_Date"]);
                    ViewBag.Dispatch_Through = Convert.ToString(dr["Dispatch_Through"]);
                    ViewBag.Destination = Convert.ToString(dr["Destination"]);
                    ViewBag.TOD = Convert.ToString(dr["Terms_OF_Delivery"]);
                    ViewBag.ShippingTerms = Convert.ToString(dr["Shipping_Terms"]);
                    ViewBag.Service_Tax_Number = Convert.ToString(dr["Service_Tax_Number"]);
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
                    catch (Exception ex)
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
                decimal TotalAmountinWords = 0;
                int TotalQuantity = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    TotalAmountinWords += Convert.ToDecimal(dr["Total_Amount"].ToString());
                    TotalQuantity += Convert.ToInt32(dr["Quantity"].ToString()); ;
                }

                ViewBag.NumbersToWords = ViewBag.Currency + " " + MiddleTyre.NumbersToWords(Convert.ToInt32(TotalAmountinWords)) + " Only";
                ViewBag.Total = TotalAmountinWords;
                ViewBag.TotalQuantity = TotalQuantity;
                Invoice obj = new Invoice();
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new Invoice();
                    obj.ID = Convert.ToInt32(dr["S_No"].ToString());
                    obj.Description = Convert.ToString(dr["Description"].ToString());
                    obj.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    string val = dr["Rate_Per_Unit"].ToString();
                    double vall = Convert.ToDouble(val);
                    val = vall.ToString("0.00");
                    obj.Rate = Convert.ToDecimal(val);
                    obj.Per = "units";
                    val = dr["Total_Amount"].ToString();
                    vall = Convert.ToDouble(val);
                    val = vall.ToString("0.00");
                    obj.TotalAmount = Convert.ToDecimal(val);
                    DescList.Add(obj);
                }
                obj = new Invoice();
                obj.ID = null;
                obj.Description = "Total";
                obj.Quantity = TotalQuantity;
                obj.Rate = null;
                obj.Per = null;
                obj.TotalAmount = Convert.ToDecimal(TotalAmountinWords.ToString("0.00"));
                DescList.Add(obj);
            }
            catch (Exception ex)
            {
            }
            return DescList;
        }

        //-------------------------- PO Details------------------------------------------------------
        private void UpdatePOData()
        {
            dt = new DataTable();
            dt = MiddleTyre.GetCompanyNames();
            List<string> s8 = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            ViewBag.CompanyName = s8;
        }

        [HttpGet]
        public ActionResult PO()
        {
            if (Login.HasLogin == false)
            {
                return RedirectToAction("Signin", "Admin");
            }
            else
            {
                ViewBag.Error = null;
                UpdatePOData();
                return View();
            }
        }

        [HttpPost]
        public ActionResult PO(PO IV)
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
                string PONumber = "";
                string EmployeeId = "SZ017";
                if (Mid.AddPO(IV, EmployeeId, ref Error, ref PONumber))
                {
                    ViewBag.message = "";
                }
                if (Error == "Sucess")
                {
                    for (int k = 0; k <= count; k++)
                    {
                        Error = "";
                        Mid.AddPODescreption(IV, PONumber, k, ref Error);
                    }
                    if (Error == "Sucess")
                    {
                        ViewBag.Error = "PO data inserted sucessfully";
                    }
                }
                else
                {
                    ViewBag.Error = "Failed to insert PO data";
                    ViewBag.Error = Error;
                }
                if (Error == "Sucess")
                {
                    ModelState.Clear();
                }
                UpdatePOData();
                return View();
            }
        }

        public ActionResult SelectPO()
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
                    dt = MiddleTyre.GetPONumber();
                    List<string> s = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
                    SelectList PONumber = new SelectList(s);
                    ViewData["PONumber"] = PONumber;
                    return View();
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        [HttpPost]
        public ActionResult SelectPO(PO obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    TempData["PONumber"] = obj.PO_Number;
                    return RedirectToAction("ViewPODetails", "Role1");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewPODetails()
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
                        return RedirectToAction("SelectInvoice", "Role1");
                    }
                    else
                    {
                        ModelState.Clear();
                        string POId = TempData["PONumber"].ToString();
                        ViewBag.RegisterItems = POData(POId);
                        string Val = @ViewBag.Currency;
                        List<WebGridColumn> columns = new List<WebGridColumn>();
                        columns.Add(new WebGridColumn() { ColumnName = "ID", Header = "S.No", CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Description", Header = "Description Of Goods", CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Quantity", Header = "Quantity Units", CanSort = false, Style = "pass" });
                        columns.Add(new WebGridColumn() { ColumnName = "Rate", Header = "Rate " + Val, CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "Per", Header = "Per", CanSort = false });
                        columns.Add(new WebGridColumn() { ColumnName = "TotalAmount", Header = "Amount " + Val, CanSort = false, Style = "text-align: reght;" });
                        ViewBag.Columns = columns;
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
        public ActionResult ViewPODetails(PO obj)
        {
            try
            {
                if (Login.HasLogin == false)
                {
                    return RedirectToAction("Signin", "Admin");
                }
                else
                {
                    if (Request.Form["PONumberSelect"] != null)
                    {
                        return RedirectToAction("SelectPO", "Role1");
                    }
                    else
                    {
                        string POId = TempData["PONumber"].ToString();
                        ViewBag.RegisterItems = POData(POId);
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

        private IEnumerable<PO> POData(string IPOId)
        {
            List<PO> DescList = new List<PO>();
            DataTable CompanyDetails = new DataTable();
            DataTable PODetails = new DataTable();
            DataTable PODESCDetails = new DataTable();
            MiddleTyre.GetPOInfo(IPOId, ref CompanyDetails, ref PODetails, ref PODESCDetails);
            try
            {
                string address = "";
                foreach (DataRow dr in CompanyDetails.Rows)
                {
                    ViewBag.CompanyName = Convert.ToString(dr["Company"]);// + " Systems Pvt Ltd.";
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
                foreach (DataRow dr in PODetails.Rows)
                {
                    ViewBag.PO_Number = Convert.ToString(dr["PO_Number"]);
                    ViewBag.Currency = dr["Currency"].ToString();
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
                        var firstDateString = firstdate.ToString("dd-MM-yyyy");
                        ViewBag.Date = firstDateString;
                    }
                    catch (Exception)
                    {
                    }
                    ViewBag.ModeOfPayment = Convert.ToString(dr["ModeOfPayment"]);
                    ViewBag.Destination = Convert.ToString(dr["Destination"]);
                    ViewBag.TOD = Convert.ToString(dr["Terms_OF_Delivery"]);
                    ViewBag.Local_Sales_Tax_Number = Convert.ToString(dr["Local_Sales_Tax_Number"]);
                    ViewBag.Inter_State_Sales_Tax_Number = Convert.ToString(dr["Inter_State_Sales_Tax_Number"]);
                    ViewBag.Companys_PAN = Convert.ToString(dr["Companys_PAN"]);
                    ToAddress = Convert.ToString(dr["Supplier"]);
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
                    catch (Exception ex)
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
                decimal TotalAmountinWords = 0;
                int TotalQuantity = 0;
                foreach (DataRow dr in PODESCDetails.Rows)
                {
                    TotalAmountinWords += Convert.ToDecimal(dr["Total_Amount"].ToString());
                    TotalQuantity += Convert.ToInt32(dr["Quantity"].ToString()); ;
                }
                ViewBag.NumbersToWords = ViewBag.Currency + " " + MiddleTyre.NumbersToWords(Convert.ToInt32(TotalAmountinWords)) + " Only";
                ViewBag.Total = TotalAmountinWords;
                ViewBag.TotalQuantity = TotalQuantity;
                PO obj = new PO();
                foreach (DataRow dr in PODESCDetails.Rows)
                {
                    obj = new PO();
                    obj.ID = Convert.ToInt32(dr["S_No"].ToString());
                    obj.Description = Convert.ToString(dr["Description"].ToString());
                    obj.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    string val = dr["Rate_Per_Unit"].ToString();
                    double vall = Convert.ToDouble(val);
                    val = vall.ToString("0.00");
                    obj.Rate = Convert.ToDecimal(val);
                    obj.Per = "unit";
                    val = dr["Total_Amount"].ToString();
                    vall = Convert.ToDouble(val);
                    val = vall.ToString("0.00");
                    obj.TotalAmount = Convert.ToDecimal(val);
                    DescList.Add(obj);
                }
                obj = new PO();
                obj.ID = null;
                obj.Description = "Total";
                obj.Quantity = TotalQuantity;
                obj.Rate = null;
                obj.Per = null;
                obj.TotalAmount = Convert.ToDecimal(TotalAmountinWords.ToString("0.00"));
                DescList.Add(obj);
            }
            catch (Exception ex)
            {
            }
            return DescList;
        }


    }
    //public byte[] GetPDF(string pHTML)
    //{
    //    byte[] bPDF = null;

    //    MemoryStream ms = new MemoryStream();
    //    TextReader txtReader = new StringReader(pHTML);

    //    // 1: create object of a itextsharp document class
    //    Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

    //    // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
    //    PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

    //    // 3: we create a worker parse the document
    //    HTMLWorker htmlWorker = new HTMLWorker(doc);

    //    // 4: we open document and start the worker on the document
    //    doc.Open();
    //    htmlWorker.StartDocument();

    //    // 5: parse the html into the document
    //    htmlWorker.Parse(txtReader);

    //    // 6: close the document and the worker
    //    htmlWorker.EndDocument();
    //    htmlWorker.Close();
    //    doc.Close();

    //    bPDF = ms.ToArray();

    //    return bPDF;
    //}

    //public void DownloadPDF(string htmlToConvert)
    //{

    //    // var viewResult = ViewEngines.Engines.FindView(controllerContext, "Index", null);
    //    string HTMLContent = "";
    //    //ViewResult v = View();
    //    //if (string.IsNullOrEmpty(v.ViewName))
    //    //    v.ViewName = RouteData.GetRequiredString("action");
    //    //ViewEngineResult result = null;
    //    //StringBuilder sb = new StringBuilder();
    //    //StringWriter textwriter = new StringWriter(sb);
    //    //HtmlTextWriter htmlwriter = new HtmlTextWriter(textwriter);
    //    //if (v.View == null)
    //    //{
    //    //    result = new ViewEngineResult(new WebFormView(this.ControllerContext, "~/Views/Role1/ViewChallanDetails.cshtml"), new WebFormViewEngine());
    //    //    v.View = result.View;
    //    //}
    //    //ViewContext viewContext = new ViewContext(ControllerContext, v.View, ViewData, TempData, htmlwriter);



    //    //v.View.Render(viewContext, htmlwriter);
    //    string html = htmlToConvert;
    //    HTMLContent = html;
    //    Response.Clear();
    //    Response.ContentType = "application/pdf";
    //    Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.BinaryWrite(GetPDF(HTMLContent));
    //    Response.End();
    //}
}