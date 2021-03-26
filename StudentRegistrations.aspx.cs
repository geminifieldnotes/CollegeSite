using BITCollege_MG.Data;
using BITCollege_MG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITCollegeSite
{
    public partial class StudentRegistrations : System.Web.UI.Page
    {
        BITCollege_MGContext db = new BITCollege_MGContext();

        /// <summary>
        /// Populates the GridView with registration records based on student number.
        /// Stores course list based on registration records to a Session variable.
        /// Stores student record to a Session variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        string username = Page.User.Identity.Name;
                        long studentNum = long.Parse(username.Substring(0, username.IndexOf("@")));

                        Student student = db.Students
                            .Where(x => x.StudentNumber == studentNum)
                            .SingleOrDefault();

                        lblStudentName.Text = student.FullName;

                        Session["StudentRecord"] = student;

                        int studentId = db.Students
                            .Where(x => x.StudentNumber == studentNum)
                            .Select(x => x.StudentId).SingleOrDefault();
                        //Queries and inserts Registration collection to List for looping
                        IQueryable<Registration> registrations = db.Registrations
                            .Where(x => x.StudentId == studentId);


                        List<Registration> registrationList = new List<Registration>();
                        registrationList = registrations.ToList();

                        //Store each CourseNumber of every Registration
                        List<string> courses = new List<string>();

                        foreach (Registration regItem in registrationList)
                        {
                            int courseId = regItem.CourseId;
                            string course = db.Courses
                                .Where(x => x.CourseId == courseId)
                                .Select(x => x.CourseNumber)
                                .SingleOrDefault();
                            courses.Add(course);
                        }

                        gvRegistrations.DataSource = registrationList;
                        Session["Registration"] = gvRegistrations.DataSource;
                        this.DataBind();
                    }
                    catch (Exception)
                    {
                        lblError.Visible = true;
                        lblError.Text = "an error has occurred upon processing registrations";
                    }

                }

            }
        }

        /// <summary>
        /// Redirects to ViewDrop page of selected registration
        /// Stores CourseNumber of selected registration to a Session variable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvRegistrations_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedCrsNum"] = gvRegistrations
                .Rows[gvRegistrations
                .SelectedIndex]
                .Cells[1].Text;

            Response.Redirect("/ViewDrop.aspx");
        }


        /// <summary>
        /// Redirect to CourseRegistration page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/CourseRegistration.aspx");
        }
    }
}