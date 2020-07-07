using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SoftwareAssignment3
{
    class Seat
    {
        private string seatNumber;
        private string customerName;
        private Button table;
        private bool isReserved;      
        //private ComboBox comboBox;

        public string SeatNumber
        {
            get => seatNumber;
            set => seatNumber = value;
        }
        public string CustomerName
        {
            get => customerName;
            set => customerName = value;
        }
        public Button Table
        {
            get => table;
            set => table = value;
        }
        
        public bool IsReserved
        {
            get => isReserved;
            set => isReserved = value;
        }

        public Seat()
        {
            this.SeatNumber = "";
            this.CustomerName = "";
            this.Table = new Button();            
           
        }
        public Seat(string tableNumber, string customerName, Button btn)
        {
            this.SeatNumber = tableNumber;
            this.CustomerName = customerName;
            this.Table = btn;
            this.IsReserved = false;            
        }
        public void Reserve(string customer)
        {            
                this.CustomerName = customer;
                this.Table.Content = customer;
                this.IsReserved = true;                
        }
        public void UnReserve()
        {
            this.CustomerName = "";
            this.Table.Content = "";
            this.IsReserved = false;
        }
    }
}
