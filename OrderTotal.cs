using System;
using System.Globalization;

namespace LibPrintTicket
{
	public class OrderTotal
	{
		private char[] delimitador = new char[] { '?' };

		public OrderTotal(char delimit)
		{
			this.delimitador = new char[] { delimit };
		}

		public string GenerateTotal(string totalName, string price)
		{
            decimal d = 0;
            try
            {
                bool x = decimal.TryParse(price, out d);
            }
            catch
            {

            }
			return string.Concat(totalName, this.delimitador[0], d.ToString("C2", CultureInfo.CreateSpecificCulture("es-MX")));
		}

		public string GetTotalCantidad(string totalItem)
		{
            
            return totalItem.Split(this.delimitador)[1];
		}

		public string GetTotalName(string totalItem)
		{
			return totalItem.Split(this.delimitador)[0];
		}
	}
}