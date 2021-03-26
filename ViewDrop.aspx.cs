using BITCollege_MG.Data;
using BITCollege_MG.Models;
using BITCollegeSite.RegistrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITCollegeSite
{
    public partial class ViewDrop : System.Web.UI.Page
    {
        BITCollege_MGContext db = new BITCollege_MGContext();
        CollegeRegistrationClient service = new CollegeRegistrationClient();

        /// <summary>
        /// Populates the DetailsView
        /// Sets the Enabled property of Drop link button based on Grade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        string selectedCrsNum = Session["SelectedCrsNum"].ToString();

                        int courseId = db.Courses
                            .Where(x => x.CourseNumber == selectedCrsNum)
                            .Select(x => x.CourseId)
                            .SingleOrDefault();

                        List<Registration> registrations = (List<Registration>)Session["Registration"];

                        List<Registration> filteredRegs = new List<Registration>();
                        foreach (Registration reg in registrations)
                        {
                            // Get all registrations with CourseId of courseId
                            if (reg.CourseId == courseId)
                            { 
                                
                                filteredRegs.Add(reg);
                            }
                        }

                        Session["FilteredRegs"] = filteredRegs;

                        dvRegister.DataSource = filteredRegs;
                        this.DataBind();

                        // Modiefies Enable property of lnkDrop
                        DropEnable(lnkDrop, dvRegister);
                    }
                    catch (Exception)
                    {
                        lblError.Visible = true;
                        lblError.Text = "An error occurred while processing course information";
                    }

                }

            }
        }

        /// <summary>
        /// Updates the displayed registration records based on the page index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dvRegister_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dvRegister.PageIndex = e.NewPageIndex;

            List<Registration> filteredRegs = (List<Registration>)Session["FilteredRegs"];
            dvRegister.DataSource = filteredRegs;
            dvRegister.DataBind();

            DropEnable(lnkDrop, dvRegister);

        }

        /// <summary>
        /// Drops the selected course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkDrop_Click(object sender, EventArgs e)
        {
            try
            {
                long registrationNum = long.Parse(dvRegister.Rows[0].Cells[1].Text.ToString());
                int registrationId = db.Registrations
                    .Where(x => x.RegistrationNumber == registrationNum)
                    .Select(x => x.RegistrationId)
                    .SingleOrDefault();

                service.DropCourse(registrationId);
                Response.Redirect("/StudentRegistrations.aspx");
            } 
            catch (Exception)
            {
                lblError.Visible = true;
                lblError.Text = "Unsuccessfully dropped course";
            }
           
        }

        /// <summary>
        /// Redirects to the StudentRegistrations page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/StudentRegistrations.aspx");
        }

        /// <summary>
        /// Checks if a link button must be enabled
        /// </summary>
        /// <param name="button">The link button to be modified</param>
        /// <param name="view">DetailsView where grade data is checked</param>
        /// <returns>true, if grade value is null; false, if grade valude is not null</returns>
        private bool DropEnable(LinkButton button, DetailsView view)
        {
            string grade = view.Rows[4].Cells[1].Text;
            button.Enabled = grade.Equals("&nbsp;") ? true : false;

            return button.Enabled;
        }
    }
}
    
