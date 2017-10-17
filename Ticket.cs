using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LibPrintTicket
{
    public class Ticket
    {
        private ArrayList headerLines = new ArrayList();

        private ArrayList subHeaderLines = new ArrayList();

        private ArrayList items = new ArrayList();
        private ArrayList itemsVentas = new ArrayList();
        private ArrayList itemsAbonos = new ArrayList();
        private ArrayList ProductosVendidos = new ArrayList();
        private ArrayList itemsPagosEfectivo = new ArrayList();
        private ArrayList itemsPagosCredito = new ArrayList();
        private ArrayList itemsPagosCheques = new ArrayList();
        private ArrayList itemsPagosPorCobrar = new ArrayList();
        private ArrayList itemsPagosTarjeta = new ArrayList();
        private ArrayList itemsMovimientosMonederos = new ArrayList();
        private ArrayList itemsProductosDevueltos = new ArrayList();
        private ArrayList itemsVentasCanceladas = new ArrayList();
        private ArrayList itemsProductosCancelados = new ArrayList();
        private ArrayList itemsValesUsados = new ArrayList();
        private ArrayList itemsValesEmitidos = new ArrayList();
        private ArrayList itemsGastos = new ArrayList();
        private ArrayList itemsDepositos = new ArrayList();
        private ArrayList itemsComprasExpress = new ArrayList();
        private ArrayList totales = new ArrayList();

        private ArrayList footerLines = new ArrayList();

        private Image headerImage;

        private Image qr_Image;

        private int count;

        private int maxChar = 40;

        private int maxCharDescription = 20;

        private int imageHeight;

        private float leftMargin;

        private float topMargin = 3f;

        private string fontName = "Segoe UI";

        private int fontSize = 9;

        private Font printFont;

        private SolidBrush myBrush = new SolidBrush(Color.Black);

        private Graphics gfx;

        private string line;

        public string FontName
        {
            get
            {
                return this.fontName;
            }
            set
            {
                if (value != this.fontName)
                {
                    this.fontName = value;
                }
            }
        }

        public int FontSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                if (value != this.fontSize)
                {
                    this.fontSize = value;
                }
            }
        }

        public Image HeaderImage
        {
            get
            {
                return this.headerImage;
            }
            set
            {
                if (this.headerImage != value)
                {
                    this.headerImage = value;
                }
            }
        }
        public Image QRImage
        {
            get
            {
                return this.qr_Image;
            }
            set
            {
                if (this.qr_Image != value)
                {
                    this.qr_Image = value;
                }
            }
        }
        public int MaxChar
        {
            get
            {
                return this.maxChar;
            }
            set
            {
                if (value != this.maxChar)
                {
                    this.maxChar = value;
                }
            }
        }
        public int MaxCharDescription
        {
            get
            {
                return this.maxCharDescription;
            }
            set
            {
                if (value != this.maxCharDescription)
                {
                    this.maxCharDescription = value;
                }
            }
        }
        public Ticket()
        {
        }
        public void AddFooterLine(string line)
        {
            this.footerLines.Add(line);
        }
        public void AddHeaderLine(string line)
        {
            this.headerLines.Add(line);
        }
        public void AddGasto(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsGastos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddDeposito(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsDepositos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddCompraExpress(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsComprasExpress.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddItem(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.items.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddVenta(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsVentas.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddProductoVendido(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.ProductosVendidos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddPagoCredito(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsPagosCredito.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddVentaCancelada(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsVentasCanceladas.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddProductoCancelado(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsProductosCancelados.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddValeCanjeado(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsValesUsados.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddValeEmitido(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsValesEmitidos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddPagoEfectivo(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsPagosEfectivo.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddAbono(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsAbonos.Add(orderItem.GenerateItem(cantidad, item, price));
        }

        public void AddPagoTarjeta(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsPagosTarjeta.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddSubHeaderLine(string line)
        {
            this.subHeaderLines.Add(line);
        }
        public void AddPagoCheque(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsPagosCheques.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddPagoPorCobrar(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsPagosPorCobrar.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddMovimientoMonedero(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsMovimientosMonederos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddDevolucioProduto(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            this.itemsProductosDevueltos.Add(orderItem.GenerateItem(cantidad, item, price));
        }
        public void AddTotal(string name, string price)
        {
            OrderTotal orderTotal = new OrderTotal('?');
            this.totales.Add(orderTotal.GenerateTotal(name, price));
        }
        private string AlignRightText(int lenght)
        {
            string str = "";
            int num = this.maxChar - lenght;
            for (int i = 0; i < num; i++)
            {
                str = string.Concat(str, " ");
            }
            return str;
        }
        private string DottedLine()
        {
            string str = "";
            for (int i = 0; i < this.maxChar; i++)
            {
                str = string.Concat(str, "=");
            }
            return str;
        }
        private void DrawEspacio()
        {
            this.line = "";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
        }
        private void DrawFooter()
        {
            foreach (string footerLine in this.footerLines)
            {
                if (footerLine.Length <= this.maxChar)
                {
                    bool Underline = false;
                    if(footerLine.Contains("~"))
                    {
                        footerLine.Replace("~", "");
                        Underline = true;
                    }
					this.line = footerLine;
                    if(Underline)
                    {
                        this.gfx.DrawString(this.line.Replace("~", ""), new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Underline), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    }
                    else
                    {
                        this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    }
					Ticket ticket = this;
					ticket.count = ticket.count + 1;
				}
				else
				{
                    bool Underline = false;
                    if (footerLine.Contains("~"))
                    {
                        footerLine.Replace("~", "");
                        Underline = true;
                    }
                        int num = 0;
					for (int i = footerLine.Length; i > this.maxChar; i = i - this.maxChar)
					{
						this.line = footerLine;
                        if (Underline)
                        {
                            this.gfx.DrawString(this.line.Replace("~", "").Substring(num, this.maxChar), new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Underline), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        }
                        else
                        {
                            this.gfx.DrawString(this.line.Substring(num, this.maxChar), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        }
						Ticket ticket1 = this;
						ticket1.count = ticket1.count + 1;
						num = num + this.maxChar;
					}
					this.line = footerLine;
                    if (Underline)
                    {
                        this.gfx.DrawString(this.line.Replace("~", "").Substring(num, this.line.Length - num), new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Underline), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    }
                    else
                    {
                        this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    }
					Ticket ticket2 = this;
					ticket2.count = ticket2.count + 1;
				}
			}
			this.leftMargin = 0f;
			this.DrawEspacio();
		}

		private void DrawHeader()
		{
			foreach (string headerLine in this.headerLines)
			{
				if (headerLine.Length <= this.maxChar)
				{
					this.line = headerLine;
					this.gfx.DrawString(this.line, new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket = this;
					ticket.count = ticket.count + 1;
				}
				else
				{
					int num = 0;
					for (int i = headerLine.Length; i > this.maxChar; i = i - this.maxChar)
					{
						this.line = headerLine.Substring(num, this.maxChar);
						this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
						Ticket ticket1 = this;
						ticket1.count = ticket1.count + 1;
						num = num + this.maxChar;
					}
					this.line = headerLine;
					this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket2 = this;
					ticket2.count = ticket2.count + 1;
				}
			}
			this.DrawEspacio();
		}
        public uint ImprimeCorte = 0;
		private void DrawImage()
		{
			if (this.headerImage != null)
			{
				try
				{
                    this.gfx.DrawImage(this.headerImage, new Point((int)this.leftMargin, (int)this.YPosition()));
                    double height = (double)this.headerImage.Height / 58 * 15;
                    this.imageHeight = (int)Math.Round(height) + 3;
                }
				catch (Exception exception)
				{
				}
			}
		}

        private void DrawQR()
        {
            if (this.qr_Image != null)
            {
                try
                {
                    this.gfx.DrawImage(this.qr_Image, new Point((int)this.leftMargin+1, (int)this.YPosition()));
                    double height = (double)this.qr_Image.Height / 20 * 17;
                    this.imageHeight = (int)Math.Round(height) + 4;
                    this.DrawEspacio();
                    this.DrawEspacio();
                }
                catch (Exception exception)
                {
                }
            }
        }

		private void DrawItems()
		{
			OrderItem orderItem = new OrderItem('?');
			this.gfx.DrawString("CANT    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name,FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
			Ticket ticket = this;
			ticket.count = ticket.count + 1;
			//this.DrawEspacio();
			foreach (string item in this.items)
			{
				this.line = orderItem.GetItemCantidad(item);
				this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
				this.line = orderItem.GetItemPrice(item);
				this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
				this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
				string itemName = orderItem.GetItemName(item);
				this.leftMargin = 0f;
				if (itemName.Length <= this.maxCharDescription)
				{
					this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket1 = this;
					ticket1.count = ticket1.count + 1;
				}
				else
				{
					int num = 0;
					for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
					{
						this.line = orderItem.GetItemName(item);
						this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
						Ticket ticket2 = this;
						ticket2.count = ticket2.count + 1;
						num = num + this.maxCharDescription;
					}
					this.line = orderItem.GetItemName(item);
					this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket3 = this;
					ticket3.count = ticket3.count + 1;
				}
			}
			this.leftMargin = 0f;
			this.DrawEspacio();
			this.line = this.DottedLine();
			this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
			Ticket ticket4 = this;
			ticket4.count = ticket4.count + 1;
			this.DrawEspacio();
		}
        private void DrawPagosCheques()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* PAGOS CON CHEQUE ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("----    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO DETALLE        IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsPagosCheques)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }

        private void DrawPagosPorCobrar()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* PAGOS POR COBRAR ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("----    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO DETALLE        IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsPagosPorCobrar)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawMovimientosMonederos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* MOVIMIENTOS CON MONEDERO ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("----    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO DETALLE        IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsMovimientosMonederos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }

        private void DrawProductosDevueltos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* PRODUCTOS DEVUELTOS ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("----    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            foreach (string item in this.itemsProductosDevueltos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteProductos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* PRODUCTOS VENDIDOS ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("CANT    PRODUCTO                 IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.ProductosVendidos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }

        private void DrawCorteVentas()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "********** VENTAS DEL DIA *********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   CLIENTE                      IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO DETALLE        IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsVentas)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCortePagosEfectivo()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******** PAGOS EN EFECTIVO ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   FECHA                      IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsPagosEfectivo)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCortePagosCredito()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******** PAGOS CON CREDITO ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   CLIENTE                    CREDITO", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("FOLIO  CLIENTE             CREDITO", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsPagosCredito)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCortePagosTarjeta()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******** PAGOS CON TARJETA ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   CLIENTE                    IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("FOLIO CLIENTE               IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsPagosTarjeta)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteValesEmitidos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "********* VALES EMITIDOS **********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   VALE                       IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsValesEmitidos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
            gfx.Save();
        }
        private void DrawCorteValesCanjeados()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "********* VALES CANJEADOS *********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--

            this.gfx.DrawString("VENTA FOLIO VALE           IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsValesUsados)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("      ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("      ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("      ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCortePagosAbonos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******** ABONO A CUENTAS DE CRÉDITO *********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   MONTO                      TIPO   ", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("Folio  MONTO           TIPO DE ABONO", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsAbonos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteGastos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* RETIROS REGISTRADOS ********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("----    DESCRIPCION                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO DETALLE        IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsGastos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                      ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteProductosCancelados()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "****** PRODUCTOS CANCELADOS *******";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            //this.gfx.DrawString("FOLIO PRODUCTO             IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            this.gfx.DrawString("FOLIO   PRODUCTO                   IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsProductosCancelados)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteVentasCanceladas()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "******* VENTAS CANCELADAS *********";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("FOLIO   CLIENTE                    IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("FOLIO CLIENTE               IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsVentasCanceladas)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawCorteDepositos()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "***** DEPOSITOS REGISTRADOS *******";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("        DETALLE                    IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO   DETALLE             IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsDepositos)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawComprasExpress()
        {
            OrderItem orderItem = new OrderItem('?');
            //--
            this.line = "***** COMPRAS EXPRESS *******";
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket = this;
            ticket.count = ticket.count + 1;
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket1 = this;
            ticket1.count = ticket1.count + 1;
            //--
            this.gfx.DrawString("        DETALLE                    IMPORTE", new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            //this.gfx.DrawString("USUARIO   DETALLE             IMPORTE", this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            ticket = this;
            ticket.count = ticket.count + 1;
            //this.DrawEspacio();
            foreach (string item in this.itemsComprasExpress)
            {
                this.line = orderItem.GetItemCantidad(item);
                this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                this.line = orderItem.GetItemPrice(item);
                this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
                this.gfx.DrawString(string.Concat("                   ", this.line), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                this.leftMargin = 0f;
                if (itemName.Length <= this.maxCharDescription)
                {
                    this.gfx.DrawString(string.Concat("            ", orderItem.GetItemName(item)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    ticket1 = this;
                    ticket1.count = ticket1.count + 1;
                }
                else
                {
                    int num = 0;
                    for (int i = itemName.Length; i > this.maxCharDescription; i = i - this.maxCharDescription)
                    {
                        this.line = orderItem.GetItemName(item);
                        this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.maxCharDescription)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                        Ticket ticket2 = this;
                        ticket2.count = ticket2.count + 1;
                        num = num + this.maxCharDescription;
                    }
                    this.line = orderItem.GetItemName(item);
                    this.gfx.DrawString(string.Concat("            ", this.line.Substring(num, this.line.Length - num)), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
                    Ticket ticket3 = this;
                    ticket3.count = ticket3.count + 1;
                }
            }
            this.leftMargin = 0f;
            this.DrawEspacio();
            this.line = this.DottedLine();
            this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
            Ticket ticket4 = this;
            ticket4.count = ticket4.count + 1;
            this.DrawEspacio();
        }
        private void DrawSubHeader()
		{
			foreach (string subHeaderLine in this.subHeaderLines)
			{
				if (subHeaderLine.Length <= this.maxChar)
				{
					this.line = subHeaderLine;
					this.gfx.DrawString(this.line, new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket = this;
					ticket.count = ticket.count + 1;
					this.line = this.DottedLine();
					this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket1 = this;
					ticket1.count = ticket1.count + 1;
				}
				else
				{
					int num = 0;
					for (int i = subHeaderLine.Length; i > this.maxChar; i = i - this.maxChar)
					{
						this.line = subHeaderLine;
						this.gfx.DrawString(this.line.Substring(num, this.maxChar), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
						Ticket ticket2 = this;
						ticket2.count = ticket2.count + 1;
						num = num + this.maxChar;
					}
					this.line = subHeaderLine;
					this.gfx.DrawString(this.line.Substring(num, this.line.Length - num), this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
					Ticket ticket3 = this;
					ticket3.count = ticket3.count + 1;
				}
			}
			this.DrawEspacio();
		}
		private void DrawTotales()
		{
			OrderTotal orderTotal = new OrderTotal('?');
			foreach (string totale in this.totales)
			{
				this.line = orderTotal.GetTotalCantidad(totale);
				this.line = string.Concat(this.AlignRightText(this.line.Length), this.line);
				this.gfx.DrawString(this.line, this.printFont, this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
				this.leftMargin = 0f;
				this.line = string.Concat("      ", orderTotal.GetTotalName(totale));
				this.gfx.DrawString(this.line, new Font(this.printFont.FontFamily.Name, FontSize, FontStyle.Bold), this.myBrush, this.leftMargin, this.YPosition(), new StringFormat());
				Ticket ticket = this;
				ticket.count = ticket.count + 1;
			}
			this.leftMargin = 0f;
			this.DrawEspacio();
			this.DrawEspacio();
		}
        private void pr_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            this.gfx = e.Graphics;
            this.DrawImage();
            this.DrawHeader();
            this.DrawSubHeader();
            if (ImprimeCorte == 1)
            {


            }
            else
            {
                this.DrawItems();
            }

            this.DrawTotales();

            if (ImprimeCorte == 1)
            {
                DrawCorteVentas();
                DrawCortePagosCredito();
                DrawCortePagosEfectivo();
                DrawCortePagosTarjeta();
                DrawCorteDepositos();
                DrawCortePagosAbonos();
                DrawCorteGastos();
                DrawComprasExpress();
                //DrawCorteProductos();
                DrawCorteProductosCancelados();
                DrawCorteVentasCanceladas();
                DrawPagosCheques();
                DrawProductosDevueltos();
                DrawMovimientosMonederos();
                DrawPagosPorCobrar();
                gfx.Save();
            }
          
            this.DrawFooter();
            this.DrawQR();
			if (this.headerImage != null)
			{
				this.HeaderImage.Dispose();
				this.headerImage.Dispose();
			}
            if (this.qr_Image != null)
            {
                this.qr_Image.Dispose();
                this.qr_Image.Dispose();
            }
		}
        public volatile int sizeH=0;
        public volatile int sizeW=300;
        public bool PrinterExists(string impresora)
		{
			bool flag;
			IEnumerator enumerator = PrinterSettings.InstalledPrinters.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					if (impresora != (string)enumerator.Current)
					{
						continue;
					}
					flag = true;
					return flag;
				}
				return false;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return flag;
		}
        public void loop()
        {
           
            int vHe = 52;
            int vLn = 23;
            int vLn3 = 23;
            int vLn2 = 56;
            int sbL = 23;
            int vCn = 23;
            sizeH += 50;
            if (ImprimeCorte == 0)
            {
                sizeH += 20;
                foreach (string x in items)
                {
                      sizeH += vLn;
                }
            }
               
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe*11;
                sizeH += vHe * 11;
                sizeH += vHe * 11;
                sizeH += vHe * 11;
                sizeH += vHe * 11;
                foreach (string x in itemsAbonos)
                {
                      sizeH += vLn;
                }
                if (itemsAbonos.Count == 0)
                {
                    sizeH += vCn;
                }
                foreach (string x in itemsMovimientosMonederos)
                {
                    sizeH += vLn + 10;
                }
                if (itemsMovimientosMonederos.Count == 0)
                {
                    sizeH += vCn;
                }
                foreach (string x in itemsPagosCheques)
                {
                    sizeH += vLn + 10;
                }
                if (itemsPagosCheques.Count == 0)
                {
                    sizeH += vCn;
                }
                foreach (string x in itemsProductosDevueltos)
                {
                    sizeH += vLn + 10;
                }
                if (itemsProductosDevueltos.Count == 0)
                {
                    sizeH += vCn;
                }
                foreach (string x in itemsPagosPorCobrar)
                {
                    sizeH += vLn + 10;
                }
                if (itemsPagosPorCobrar.Count == 0)
                {
                    sizeH += vCn;
                }
            }
              
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe;
                foreach (string x in itemsDepositos)
                {
                      sizeH += vLn+10;
                }
                if (itemsDepositos.Count == 0)
                {
                    sizeH += vCn;
                }
            }
                
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe;
                foreach (string x in itemsGastos)
                {
                      sizeH += vLn+10;
                }
                if (itemsGastos.Count == 0)
                {
                    sizeH += vCn;
                }
            }
                
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe;
                foreach (string x in itemsPagosCredito)
                {
                      sizeH += vLn;
                }
                if (itemsPagosCredito.Count == 0)
                {
                    sizeH += vCn;
                }
            }
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe;
                foreach (string x in itemsPagosEfectivo)
                {
                      sizeH += vLn;
                }
                if(itemsPagosEfectivo.Count==0)
                {
                    sizeH += vCn;
                }
            }
               
            if (ImprimeCorte == 1)
            {
                 sizeH += vHe;
                foreach (string x in itemsProductosCancelados)
                {
                      sizeH += vLn;
                }
                if (itemsProductosCancelados.Count == 0)
                {
                    sizeH += vCn;
                }
            }
                
               
            if(ImprimeCorte==1)
            {
                 sizeH += vHe;
                foreach (string x in itemsVentas)
                {
                      sizeH += vLn;
                }
                if (itemsVentas.Count == 0)
                {
                    sizeH += vCn;
                }
                if(itemsVentas.Count<4)
                {
                    sizeH += vLn2 + 50;
                }
            }
            
            if(ImprimeCorte==1)
            {
                 sizeH += vHe;
                foreach (string x in itemsVentasCanceladas)
                {
                      sizeH += vLn;
                }
                if (itemsVentasCanceladas.Count == 0)
                {
                    sizeH += vCn;
                }
            }
           
            if(ImprimeCorte==1)
            {
                 sizeH += vHe;
                foreach (string x in ProductosVendidos)
                {
                      sizeH += vLn;
                   
                }
                if (ProductosVendidos.Count == 0)
                {
                    sizeH += vCn;
                }
                if (ProductosVendidos.Count < 4)
                {
                    sizeH += vLn2;
                }
            }
            foreach(string x in subHeaderLines)
            {
                sizeH += sbL;
               
            }
            foreach(string x in headerLines)
            {
                sizeH += sbL;
                
            }
            foreach(string x in footerLines)
            {
                sizeH += sbL;
               
            }
            foreach (string x in totales)
            {
                sizeH += vLn3;
            }
          
            if (this.headerImage != null)
            {
                sizeH += 285;
            }
            if (this.qr_Image != null)
            {
                sizeH += 280;
            }
            
        }
        public void PrintTicket(string impresora)
        {
           
            loop();
            this.printFont = new Font(this.fontName, (float)this.fontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;
            printDocument.PrintPage += new PrintPageEventHandler(this.pr_PrintPage);
            printDocument.DefaultPageSettings.PaperSize = new PaperSize() { Height = sizeH, Width = sizeW, PaperName = "Custom" };
            //PrinterSettings ps = new PrinterSettings();
            //PrintPreviewDialog ppvw = new PrintPreviewDialog();
            //ppvw.Document = printDocument;
            //ppvw.Document.DefaultPageSettings.PaperSize = new PaperSize() { Height= sizeH, Width= sizeW, PaperName="Custom"};
            //ppvw.ShowDialog();
            printDocument.Print();
        }
		private float YPosition()
		{
			return this.topMargin + ((float)this.count * this.printFont.GetHeight(this.gfx) + (float)this.imageHeight);
		}
	}
}