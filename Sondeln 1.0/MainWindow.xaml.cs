using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;






namespace Sondeln_1._0
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        int isExposed;
        private static string CONNECTION, SELECTSTRING_FINDING;
        public MainWindow()
        {

            InitializeComponent();

            isExposed = 0;

            SELECTSTRING_FINDING = "SELECT id,name,number, item_pos_x, item_pos_y, exposed, storage_box, picture, date FROM findings"; //
           
            CONNECTION = @"Data Source = C:\Sondeln\sondeln.db; Version = 3";
            
            SQLiteConnection conn = new SQLiteConnection(CONNECTION);
            Load();
            

        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            if (txt_findingName.Text != "")
            {

               String YcoordinateClear = txt_y_coordinate.Text.Replace(",",".");
               String XcoordinateClear = txt_x_coordiante.Text.Replace(",",".");

                //insertion of the finding attributes 
                SQLiteConnection conn = new SQLiteConnection(CONNECTION);

                try
                {
                    conn.Open();


                    string query = "insert into findings(name,number,item_pos_x,item_pos_y,comments_findings,exposed,storage_box,picture,date) values('" + this.txt_findingName.Text + "', '" + this.txt_number.Text + "', '" + XcoordinateClear + "', '" + YcoordinateClear + "', '" + txt_comments_finding.Text + "', '" + isExposed + "', '" + txt_stroageBox.Text + "','" + txt_pictureurl.Text + "', '" + txt_date.Text + "')";
                    SQLiteCommand createCommand = new SQLiteCommand(query, conn);
                    createCommand.ExecuteNonQuery();
                    MessageBox.Show("Saved");
                    Load();
                    clear_all_textboxes();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MessageBox.Show("Name eingeben!!");
            }
            
        }

        private void Load()
        {


            SQLiteConnection conn = new SQLiteConnection(CONNECTION);

            try
            {
                //loading the database value into grid
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(SELECTSTRING_FINDING, conn);
                cmd.ExecuteNonQuery();

                SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable("findings");
                dataadapter.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                dataadapter.Update(dt);

                conn.Close();
            }
            catch (Exception ex )
            {
                
              MessageBox.Show(ex.Message);
            }
            


        }
        
        

        private void btn_updateFinding_Click(object sender, RoutedEventArgs e)
        {

            if (txt_findingName.Text != "")
            {

               String xClearCoord= txt_x_coordiante.Text.Replace(",",".");
               String yClearCoord = txt_y_coordinate.Text.Replace(",", ".");

                try
                {
                    DataRowView drv = (DataRowView)datagrid.SelectedItem;
                    if (drv != null)
                    {
                        String result = (drv["id"]).ToString();
                        SQLiteConnection conn = new SQLiteConnection(CONNECTION);
                       
                       
                            try
                            {
                                conn.Open();
                                string query = "update findings set name= '" + txt_findingName.Text + "', number= '" + txt_number.Text + "',item_pos_x= '" + xClearCoord + "',item_pos_y= '" + yClearCoord + "',comments_findings = '" + txt_comments_finding.Text + "',exposed  = '" + isExposed + "',storage_box = '" + txt_stroageBox.Text + "',picture ='" + txt_pictureurl.Text + "', date ='" + txt_date.Text + "' where id = '" + result + "' ";
                                SQLiteCommand createCommand = new SQLiteCommand(query, conn);
                                createCommand.ExecuteNonQuery();
                                Load();



                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                       

                    
                    else
                    {
                        MessageBox.Show("Zeile im Grid anklicken du Mongo!!!!!!!!!!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Kein Leeres Feld anklicken!!");
                }
            }
            else
            {
                MessageBox.Show("Bitte Name für Fundstück eintragen");
            }
                
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(CONNECTION);




            string query = "select * from findings where name LIKE  '%" + txt_search.Text + "%' or name like '" + txt_search.Text + "%' or name like '%" + txt_search.Text + "'";
                

                try
                {
                    //loading the database value into grid
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("findings");
                    dataadapter.Fill(dt);
                    datagrid.ItemsSource = dt.DefaultView;
                    dataadapter.Update(dt);

                    conn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)datagrid.SelectedItem;
            if (drv != null)
            {
                String result = (drv["id"]).ToString();


                SQLiteConnection conn = new SQLiteConnection(CONNECTION);

                try
                {
                    conn.Open();
                    string query = "Delete From findings where id='"+ result +"'";
                    SQLiteCommand createCommand = new SQLiteCommand(query, conn);
                    createCommand.ExecuteNonQuery();
                    Load();
                    clear_all_textboxes();
                    

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }
            else
            {
                MessageBox.Show("Zeile im Grid anklicken du Mongo!!!!!!!!!!!");
            }
        }

        private void loadDatatoUpdate(string result)
        {
            SQLiteConnection conn = new SQLiteConnection(CONNECTION);
            try
            {
                conn.Open();
                string query = "Select * From findings where id='" + result + "'";
                SQLiteCommand createCommand = new SQLiteCommand(query, conn);
                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {

                    txt_findingName.Text = dr.GetString(1);            
                    txt_number.Text = dr.GetValue(2).ToString();
                    txt_x_coordiante.Text = dr.GetValue(3).ToString();
                    txt_y_coordinate.Text = dr.GetValue(4).ToString();
                    txb_comment_finding.Text = dr.GetValue(5).ToString();
                    txt_comments_finding.Text = dr.GetValue(5).ToString();
                    if(dr.GetValue(6).ToString() == "1")
                    {
                        radio_yes.IsChecked = true;

                    }
                    else
	                {
                         radio_no.IsChecked = true;   
	                }
                    txt_stroageBox.Text = dr.GetValue(7).ToString();
                    txt_pictureurl.Text = dr.GetValue(8).ToString();
                    if (txt_pictureurl.Text != "")
                        setPicture(txt_pictureurl.Text);
                    else
                        clearPicture();
                    txt_date.Text = dr.GetValue(9).ToString();

                } 





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                DataRowView drv = (DataRowView)datagrid.SelectedItem;
                if (drv != null)
                {
                    String result = (drv["id"]).ToString();
                    loadDatatoUpdate(result);
                    SQLiteConnection conn = new SQLiteConnection(CONNECTION);     
    
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Kein Leeres Feld anklicken!!");
            }
        }



        private void clear_all_textboxes()
        {
            txt_findingName.Text = "";
            txt_number.Text = "";
            txt_search.Text = "";
            txt_x_coordiante.Text = "";
            txt_y_coordinate.Text = "";
            txt_comments_finding.Text = "";
            txb_comment_finding.Text = "";
            txt_stroageBox.Text = "";
            txt_pictureurl.Text = "";
            txt_date.Text = "";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            isExposed = 0;
            //MessageBox.Show(isExposed.ToString());
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            isExposed = 1;
            
        }

        private void picture_dialog(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Pictures (.jpg)|*.jpg";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                txt_pictureurl.Text = filename;
                setPicture(filename);
                



            }

        }


        private void setPicture(string path)
        {
            img_picture.Source = new ImageSourceConverter().ConvertFromString(path) as ImageSource;
        }

        private void clearPicture()
        {
            img_picture.Source = null;
        }

       

        
        
    }
}

