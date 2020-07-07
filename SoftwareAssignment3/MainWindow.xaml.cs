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
using System.Text.RegularExpressions;

namespace SoftwareAssignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Seat s1;
        Seat s2;
        Seat s3;
        Seat s4;
        Seat s5;
        Seat s6;
        Seat s7;
        Seat s8;
        Seat s9;
        Seat s10;
        Seat s11;
        Seat s12;
        Seat s13;
        Seat s14;
        Seat s15;
        Seat s16;
        Seat[] reservationSeats;       
        bool isAllSeatsReserved = false;        
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                s1 = new Seat("S1", "", S1);
                s2 = new Seat("S2", "", S2);
                s3 = new Seat("S3", "", S3);
                s4 = new Seat("S4", "", S4);
                s5 = new Seat("S5", "", S5);
                s6 = new Seat("S6", "", S6);
                s7 = new Seat("S7", "", S7);
                s8 = new Seat("S8", "", S8);
                s9 = new Seat("S9", "", S9);
                s10 = new Seat("S10", "", S10);
                s11 = new Seat("S11", "", S11);
                s12 = new Seat("S12", "", S12);
                s13 = new Seat("S13", "", S13);
                s14 = new Seat("S14", "", S14);
                s15 = new Seat("S15", "", S15);
                s16 = new Seat("S16", "", S16);

                reservationSeats = new Seat[16];
                reservationSeats[0] = s1;
                reservationSeats[1] = s2;
                reservationSeats[2] = s3;
                reservationSeats[3] = s4;
                reservationSeats[4] = s5;
                reservationSeats[5] = s6;
                reservationSeats[6] = s7;
                reservationSeats[7] = s8;
                reservationSeats[8] = s9;
                reservationSeats[9] = s10;
                reservationSeats[10] = s11;
                reservationSeats[11] = s12;
                reservationSeats[12] = s13;
                reservationSeats[13] = s14;
                reservationSeats[14] = s15;
                reservationSeats[15] = s16;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong while creating seats. Please try again");
                System.Environment.Exit(1);
            }           
        }

        private void BtnReserve_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (s1.IsReserved == true && s2.IsReserved == true && s3.IsReserved == true && s4.IsReserved == true && s5.IsReserved == true && s6.IsReserved == true && s7.IsReserved == true && s8.IsReserved == true && s9.IsReserved == true && s10.IsReserved == true && s11.IsReserved == true && s12.IsReserved == true && s13.IsReserved == true && s14.IsReserved == true && s15.IsReserved == true && s16.IsReserved == true)
                {
                    isAllSeatsReserved = true;
                    TxtCustomerName.Text = "";
                    listTable.SelectedIndex = -1;
                    MessageBox.Show("All tables are reserved. Please select any diner from the grid and click on UnReserve to provision a new reservation.");
                }

                else if (TxtCustomerName.Text.Trim() != "")
                {
                    for (int i = 0; i < reservationSeats.Length; i++)
                    {
                        try
                        {
                            if (listTable.SelectedIndex != -1)
                            {
                                if (listTable.SelectionBoxItem.ToString() == reservationSeats[i].Table.Name.ToString())
                                {
                                    if (reservationSeats[i].IsReserved == false)
                                    {
                                        reservationSeats[i].Reserve(TxtCustomerName.Text.Trim());
                                        reservationSeats[i].Table.Background = Brushes.Gray;
                                        MessageBox.Show($"Table {i + 1} has been successfully reserved for {TxtCustomerName.Text.Trim()}");
                                        TxtCustomerName.Text = "";
                                        listTable.SelectedIndex = -1;
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Table already booked.");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select a table to book from the list.");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Something went wrong. Please close the application and try again.");
                            break;
                        }                        
                    }
                }
                else
                {
                    MessageBox.Show("Please input the Diner's name.");
                    TxtCustomerName.Text = "";                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something has gone wrong. Please close the application and try again.");
            }
        }

        private void BtnUnsererve_Click(object sender, RoutedEventArgs e)
         {
            try
            {
                if (TxtCustomerName.Text.Trim() != "" && listTable.SelectionBoxItem.ToString() == "")
                {
                    int[] countArrays = new int[16];
                    int sum = 0;
                    for (int i = 0; i < reservationSeats.Length; i++)
                    {
                        if (reservationSeats[i].Table.Content.ToString().Trim().ToLower() == TxtCustomerName.Text.Trim().ToLower())
                        {
                            reservationSeats[i].UnReserve();
                            reservationSeats[i].Table.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5AD917"));
                            MessageBox.Show($"Table {i + 1} is unreserved");
                            TxtCustomerName.Text = "";
                            listTable.SelectedIndex = -1;
                            break;
                        }
                        else
                        {                            
                            countArrays[i] = 1;
                            sum += countArrays[i];
                            if (sum==16)
                            {
                                MessageBox.Show($"No one by the name {TxtCustomerName.Text.ToUpper()} has reserved a table with us.");
                                break;
                            }
                        }
                    }
                }
                else if (listTable.SelectionBoxItem.ToString() != "" && TxtCustomerName.Text.Trim() == "")
                {
                    for (int i = 0; i < reservationSeats.Length; i++)
                    {
                        if (listTable.SelectionBoxItem.ToString() == reservationSeats[i].Table.Name)
                        {
                            if (reservationSeats[i].IsReserved == true)
                            {
                                reservationSeats[i].UnReserve();
                                reservationSeats[i].Table.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5AD917"));
                                MessageBox.Show($"Table {i + 1} is unreserved");
                                TxtCustomerName.Text = "";
                                listTable.SelectedIndex = -1;
                                break;
                            }
                            else
                            {
                                MessageBox.Show($"Table {i + 1} is not reserved. Please reserve it");
                                break;
                            }
                        }
                    }
                }
                else if (listTable.SelectionBoxItem.ToString() != "" && TxtCustomerName.Text.Trim() != "")
                {
                    for (int i = 0; i < reservationSeats.Length; i++)
                    {
                        if (listTable.SelectionBoxItem.ToString() == reservationSeats[i].Table.Name)
                        {
                            if (reservationSeats[i].Table.Content.ToString().Trim() == TxtCustomerName.Text.Trim())
                            {
                                if (reservationSeats[i].IsReserved == true)
                                {
                                    reservationSeats[i].UnReserve();
                                    reservationSeats[i].Table.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF5AD917"));
                                    MessageBox.Show($"Table {i + 1} is unreserved");
                                    TxtCustomerName.Text = "";
                                    listTable.SelectedIndex = -1;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Table {i + 1} is not reserved by {TxtCustomerName.Text.Trim()}.");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the customer name or select a table to unreserve a table.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong. Please try to restart the app and give correct input.");
            }
        }              
        private void BtnChoice(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                string tableContent = button.Content.ToString().Trim();
                string tableName = button.Name;
                if (tableContent != "")
                {
                    TxtCustomerName.Text = tableContent;
                    var findTable = listTable.Items.PassesFilter(tableName);
                    if (findTable)
                    {
                        listTable.SelectedIndex = int.Parse(button.Tag.ToString());
                    }
                    else
                    {
                        MessageBox.Show($"Did not find {tableName}");
                    }
                }
                else
                {
                    MessageBox.Show($"The table is not reserved by anyone");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong while selecting the reserved table. Please retry.");
            }
        }

        private void TxtCustomerName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = new Regex(@"^[0-9$&+,:;=?@#|'<>.-^*()%!]+$").IsMatch(e.Text);
            //e.Handled = new Regex("[^0-9$&+,:;=?@#|'<>.-^*()%!]+$").IsMatch(e.Text);
            //e.Handled = new Regex("[A-Za-z\\s]+$").IsMatch(e.Text);
            Regex regex = new Regex(@"[^A-Za-z\s]+$");
            e.Handled = regex.IsMatch(e.Text);
            if (e.Handled)
            {
                MessageBox.Show("Only Alphabets allowed!!.Please Enter a Diner's Name");
            }
            
        }
    }
}