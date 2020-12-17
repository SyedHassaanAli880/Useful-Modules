using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using MainClass;

namespace DATA_BASE_OPERATIONS
{
    public class SQL_TASKS
    {
        public static void load_data(string proc, DataGridView dv, ListBox lb)
        {
            try
            {
                SqlConnection sql_con = new SqlConnection(CodingSourceClass.connection());

                SqlCommand command = new SqlCommand(proc, sql_con);

                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dat = new DataTable();

                adapter.Fill(dat);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName1 = ((DataGridViewColumn)lb.Items[i]).Name;

                    dv.Columns[colName1].DataPropertyName = dat.Columns[i].ToString();
                }

                dv.DataSource = dat;
            }
            catch (Exception ex)
            {
                CodingSourceClass.ShowMsg(ex.Message, "Error");
            }
        }

        public static void LoadList(string proc, ComboBox cb, string valueMember, string displayMember)
        {
            try
            {
                cb.Items.Clear();

                SqlConnection sql = new SqlConnection(CodingSourceClass.connection());

                SqlCommand cmd = new SqlCommand(proc, sql);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable(); da.Fill(dt);

                cb.DisplayMember = displayMember; cb.ValueMember = valueMember;

                cb.DataSource = dt; cb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                CodingSourceClass.ShowMsg(ex.Message, "Error");
            }
        }
        //to be fixed
        //overloaded version:
        public static void load_roles_like(DataGridView dv, DataGridViewColumn RoleGV, string data)
        {
            SqlConnection sql_con = new SqlConnection(CodingSourceClass.connection());
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "st_getROLESlike";

                cmd.Parameters.AddWithValue("@data", data);

                cmd.Connection = sql_con;

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqladp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                sqladp.Fill(dt);

                RoleGV.DataPropertyName = dt.Columns["Role"].ToString();

                dv.DataSource = dt;
            }
            catch (Exception ex)
            {
                CodingSourceClass.ShowMsg(ex.Message, "Error");
            }
        }

        public static int insert_update_delete(string proc, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlConnection sql_con = new SqlConnection(CodingSourceClass.connection());

                SqlCommand cmd = new SqlCommand(proc, sql_con);

                cmd.CommandType = CommandType.StoredProcedure;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                sql_con.Open();

                //returns an integer which indicates how many rows have been affected
                res = cmd.ExecuteNonQuery();

                sql_con.Close();

            }
            catch (Exception ex)
            {
                CodingSourceClass.ShowMsg(ex.Message, "Error");
            }

            return res;
        }
    }
}
