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
    public partial class CourseRegistration : System.Web.UI.Page
    {
        BITCollege_MGContext db = new BITCollege_MGContext();
        CollegeRegistrationClient service = new CollegeRegistrationClient();

        /// <summary>
        /// Displays a Course Registration form.
        /// Populates dropdown list of courses with the student's AcademicProgramId.
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
                        Student student = (Student)Session["StudentRecord"];
                        string studentName = student.FullName;
      
                        lblStudentName.Text = studentName;

                        IQueryable<Course> courses = db.Courses.Where(x => x.AcademicProgramId == student.AcademicProgramId);

                        ddlCourses.DataSource = courses.ToList();
                        ddlCourses.DataTextField = "Title";
                        ddlCourses.DataValueField = "CourseId";

                        this.DataBind();
                    }
                    catch (Exception)
                    {
                        lblError.Visible = true;
                        lblError.Text = "An error occured while processing the registration";
                    }
                }
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
        /// Validates field requirements to process the registration
        /// If valid, checks course if qualified for registration 
        /// If student is qualified, adds course to student's registration records.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            rfvNotes.Enabled = true;
            Page.Validate();

            if (Page.IsValid)
            {
                int crsID = int.Parse(ddlCourses.SelectedValue.ToString());
                string notes = txtNotes.Text.ToString();

                Student student = (Student)Session["StudentRecord"];

                int regResult = service.RegisterCourse(student.StudentId, crsID, notes);

                if (regResult < 0)
                {
                   string error = Utility.BusinessRules.RegisterError(regResult);
                   lblError.Text = error;
                   lblError.Visible = true;
                } else
                {
                    Response.Redirect("/StudentRegistrations.aspx");
                }
                

            }
        }
    }
}