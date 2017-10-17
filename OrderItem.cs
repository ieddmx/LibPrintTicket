using System;
using System.Globalization;

namespace LibPrintTicket
{
	public class OrderItem
	{
		private char[] delimitador = new char[] { '?' };

		public OrderItem(char delimit)
		{
			this.delimitador = new char[] { delimit };
		}

		public string GenerateItem(string cantidad, string itemName, string price)
		{
            decimal d = 0;
            object[] objArray;
            try
            {
                bool x = decimal.TryParse(price, out d);
                if(x)
                {
                    objArray = new object[] { cantidad, this.delimitador[0], itemName, this.delimitador[0], d.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX")) };
                }
                else
                {
                    objArray = new object[] { cantidad, this.delimitador[0], itemName, this.delimitador[0], price };
                }
            }
            catch
            {
                objArray = new object[] { cantidad, this.delimitador[0], itemName, this.delimitador[0], price };
            }
			return string.Concat(objArray);
		}

		public string GetItemCantidad(string orderItem)
		{
			return orderItem.Split(this.delimitador)[0];
		}

		public string GetItemName(string orderItem)
		{
			return orderItem.Split(this.delimitador)[1];
		}

		public string GetItemPrice(string orderItem)
		{
			return orderItem.Split(this.delimitador)[2];
		}
	}
}