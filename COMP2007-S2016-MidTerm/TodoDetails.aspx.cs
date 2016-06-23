using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements required for EF DB access
using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }

    /**
     * <summary>
     * This method gets the todo data from the DB
     * </summary>
     * @method GetTodo
     * @return (void)
     * */
        protected void GetTodo()
        {
            //populate the form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a todo object instance with the todoID from the URL Parameter
                Todo updatedTodo = (from todos in db.Todos
                                          where todos.TodoID == TodoID
                                          select todos).FirstOrDefault();

                //map the todo properties to the form
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    //Not too sure about this one...
                   // Completed.AutoPostBack = updatedTodo.Completed.(Completed.Checked);

                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                //use the Todo model to create a new todo object and 
                //save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) //our URL has a todo ID in it
                {
                    //get the id from the url
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    //get the current student from the EF DB
                    newTodo = (from todo in db.Todos
                                  where todo.TodoID == TodoID
                                  select todo).FirstOrDefault();
                }
                //add form data to the new todo 
                TodoNameTextBox.Text = newTodo.TodoName;
                TodoNotesTextBox.Text = newTodo.TodoNotes;
                //Not too sure about this one...
                // Completed.AutoPostBack = updatedTodo.Completed.(Completed.Checked);

                //use LINQ to ADO.NET to add / insert new todo
                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                //save our changes
                db.SaveChanges();

                //redirect back to the updated Todo List page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
 }