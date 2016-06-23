using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are requuired to connect the the EF DB
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using COMP2007_S2016_MidTerm.Models;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate the ToDo grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "TodoID"; // default sort column
                Session["SortDirection"] = "ASC";
                // Get the Todo data
                this.GetTodo();
            }


        }

        /**
         * <summary>
         * This method gets the todo data from the DB
         * </summary>
         * @method GetStudents
         * @return (void)
         * */
         protected void GetTodo()
        {
            //connect to the EF
            using (TodoConnection db = new TodoConnection())
            {

                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //query the todo table using EF and LINQ
                var Todos = (from allTodos in db.Todos
                                select allTodos);

                //sends the data to a list
                TodosGridView.DataSource = Todos.AsQueryable().OrderBy(SortString).ToList();
                //binds the data to the grid
                TodosGridView.DataBind();

            }
        }

        /**
         * <summary>
         * This event handler allows pagination to occur for the Todo page
         * </summary>
         * 
         * @method TodosGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         */
        protected void TodosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            TodosGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetTodo();
        }

        /**
         * <summary>
         * This event handler allows sorting to occur for the Todo page
         * </summary>
         * 
         * @method TodosGridView_Sorting
         * @param {object} sender
         * @param {GridViewSortEventArgs} e
         * @returns {void}
         */
        protected void TodosGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetTodo();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";

        }

        /**
        * <summary>
        * This event handler deletes a todo from the db using EF
        * </summary>
        * 
        * @method TodosGridView_RowDeleting
        * @param {object} sender
        * @param {GridViewDeleteEventArgs} e
        * @returns {void}
        */
        protected void TodosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodosGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF to find the selected todo in the DB and remove it
            using (TodoConnection db = new TodoConnection())
            {
                // create object of the todo class and store the query string inside of it
                Todo deletedTodo = (from todoRecords in db.Todos
                                          where todoRecords.TodoID == TodoID
                                          select todoRecords).FirstOrDefault();

                // remove the selected todo from the db
                db.Todos.Remove(deletedTodo);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetTodo();
            }
        }

        /**
        * <summary>
        * This event handler data binding a todo to the row from the db using EF
        * </summary>
        * 
        * @method TodosGridView_RowDataBound
        * @param {object} sender
        * @param {GridViewRowEventArgs} e
        * @returns {void}
        */
        protected void TodosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < TodosGridView.Columns.Count - 1; index++)
                    {
                        if (TodosGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
            TodosGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetTodo();
        }
    }

}
