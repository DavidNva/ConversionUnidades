using System;
using System.Windows.Forms;

namespace ConversionUnidades_V01
{
    public partial class FormConversionUnidades : Form
    {
        public FormConversionUnidades()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Agredando items a los combos

            //ConversionMoneda                //Items
            cmbInicioMoneda.Items.Add("Pesos");//0
            cmbInicioMoneda.Items.Add("Dolares");//1

            cmbFinalMoneda.Items.Add("Pesos");//0
            cmbFinalMoneda.Items.Add("Dolares");//1

            //ConversionMasa                   //Items
            cmbInicioMasa.Items.Add("Gramos");//0
            cmbInicioMasa.Items.Add("Kilogramos");//1
            cmbInicioMasa.Items.Add("Onzas");//2
            cmbInicioMasa.Items.Add("Libras");//3

            cmbFinalMasa.Items.Add("Gramos");//0
            cmbFinalMasa.Items.Add("Kilogramos");//1
            cmbFinalMasa.Items.Add("Onzas");//2
            cmbFinalMasa.Items.Add("Libras");//3

            //ConversionLongitud          //Items
            cmbInicioLongitud.Items.Add("Milimetros");//0
            cmbInicioLongitud.Items.Add("Centimetros");//1
            cmbInicioLongitud.Items.Add("Metros");//2
            cmbInicioLongitud.Items.Add("Kilometros");//3

            cmbFinalLongitud.Items.Add("Milimetros");//0
            cmbFinalLongitud.Items.Add("Centimetros");//1
            cmbFinalLongitud.Items.Add("Metros");//2
            cmbFinalLongitud.Items.Add("Kilometros");//3

            //ConversionTemperatura   
            cmbInicioTemp.Items.Add("Celsius");//0
            cmbInicioTemp.Items.Add("Fahrenheit");//1
            cmbInicioTemp.Items.Add("Kelvin");//2

            cmbFinalTemp.Items.Add("Celsius");//0
            cmbFinalTemp.Items.Add("Fahrenheit");//1
            cmbFinalTemp.Items.Add("Kelvin");//2
        }
        ConversionModeda moneda = new ConversionModeda();
        private void btnConvertirMoneda_Click(object sender, EventArgs e)
        {
            //Validacion de campos vacios
            if (cmbInicioMoneda.Items == null || cmbFinalMoneda.Items == null || txtValorInicioMoneda.Text == "")
            {
                errorIndice.SetError(cmbInicioMoneda, "Debes seleccionar un valor a convertir");
                errorIndice.SetError(cmbFinalMoneda, "Debes selecionar una conversion");
                errorIndice.SetError(txtValorInicioMoneda, "Debes ingresar un valor");
            }
            else
            {//Si los campos esta llenos, continua con los metodos a a realizar de acuerdo al item seleccionado

                double valorMoneda;
                if (!double.TryParse(txtValorInicioMoneda.Text, out valorMoneda))
                {
                    errorIndice.SetError(txtValorInicioMoneda, "Debes ingresar un numero");
                    return;
                }
                else
                {
                    if (cmbInicioMoneda.SelectedIndex.Equals(0) == true && cmbFinalMoneda.SelectedIndex.Equals(1) == true)
                    {
                        txtResultadoMoneda.Text = moneda.CalculaPesosADolares(Convert.ToDouble(txtValorInicioMoneda.Text)).ToString() + " " + cmbFinalMoneda.SelectedItem;
                    }
                    if (cmbInicioMoneda.SelectedIndex.Equals(1) == true && cmbFinalMoneda.SelectedIndex.Equals(0) == true)
                    {
                        txtResultadoMoneda.Text = moneda.CalculaDolaresAPesos(Convert.ToDouble(txtValorInicioMoneda.Text)).ToString() + " " + cmbFinalMoneda.SelectedItem;
                    }
                }
                //Ingreso de misma conversion
                if (cmbInicioMoneda.SelectedItem == cmbFinalMoneda.SelectedItem)
                {
                    if (cmbInicioMoneda.SelectedItem != null || cmbFinalMoneda.SelectedItem != null)
                    {
                        txtResultadoMoneda.Text = txtValorInicioMoneda.Text + " " + cmbFinalMoneda.SelectedItem;
                    }
                    else
                    {
                        errorIndice.SetError(cmbInicioMoneda, "Debes seleccionar un valor a convertir");
                        cmbInicioMoneda.Focus();
                        errorIndice.SetError(cmbFinalMoneda, "Debes selecionar una conversion");
                        //errorIndice.SetError(txtValorInicioMoneda, "Debes selecionar una conversion de arriba");
                    }
                }
                else
                {
                    btnLimpiarMoneda.Visible = false;
                    lblResultadoMoneda.Visible = false;
                    txtResultadoMoneda.Visible = false;
                }
            }
            //Si no, si no estan vacios
            //Se quitan los errores si se cumple que:
            if (cmbInicioMoneda.Text != "") { errorIndice.SetError(cmbInicioMoneda, null); }
            if (cmbFinalMoneda.Text != "") { errorIndice.SetError(cmbFinalMoneda, null); }
            if (txtValorInicioMoneda.Text != "") { errorIndice.SetError(txtValorInicioMoneda, null); }
            //Si se cumplen las condiciones entonces ya se muestra el resultado y el boton limpiar
            if (txtValorInicioMoneda.Text != "" && cmbInicioMoneda.SelectedItem != null && cmbFinalMoneda.SelectedItem != null)
            {
                btnLimpiarMoneda.Visible = true;
                lblResultadoMoneda.Visible = true;
                txtResultadoMoneda.Visible = true;
            }
        }
        private void btnLimpiarMoneda_Click(object sender, EventArgs e)
        {
            cmbInicioMoneda.Text = null;//El null seria como eliminar en un combo, ya que si usamos las dos comillas
            //no serviria y solo estaria indicando que se borrara el texto
            cmbFinalMoneda.Text = null;
            txtValorInicioMoneda.Clear();
            txtResultadoMoneda.Clear();
            btnLimpiarMoneda.Visible = false;
            lblResultadoMoneda.Visible = false;
            txtResultadoMoneda.Visible = false;
        }
        private void btnSalirMoneda_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Salir de la Appliacion", "Confirme Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //-----------------------------------------------------------------------------------------------------
        private void btnConvertirMasa_Click(object sender, EventArgs e)
        {
            ConversionMasa masa = new ConversionMasa();
            if (cmbInicioMasa.Items == null || cmbFinalMasa.Items == null || txtValorInicioMasa.Text == "")
            {
                errorIndice.SetError(cmbInicioMasa, "Debes seleccionar un valor a convertir");
                errorIndice.SetError(cmbFinalMasa, "Debes selecionar una conversion");
                errorIndice.SetError(txtValorInicioMasa, "Debes ingresar un valor");
            }
            else
            {
                if (!double.TryParse(txtValorInicioMasa.Text, out double valorMasa))
                {
                    errorIndice.SetError(txtValorInicioMasa, "Debes ingresar un numero");
                    return;
                }
                else
                {
                    //Conversion gramos a kg y viceversa
                    if (cmbInicioMasa.SelectedIndex.Equals(0) && cmbFinalMasa.SelectedIndex.Equals(1))
                    {
                        txtResultadoMasa.Text = masa.CalculaGramosAKilogramos(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(1) && cmbFinalMasa.SelectedIndex.Equals(0))
                    {
                        txtResultadoMasa.Text = masa.CalculaKilogramosAGramos(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }
                    //Conversion gramos a onzas y viceversa
                    if (cmbInicioMasa.SelectedIndex.Equals(0) && cmbFinalMasa.SelectedIndex.Equals(2))
                    {
                        txtResultadoMasa.Text = masa.CalculaGramosAOnzas(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(2) && cmbFinalMasa.SelectedIndex.Equals(0))
                    {
                        txtResultadoMasa.Text = masa.CalculaOnzasAGramos(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }
                    //Conversion gramos a libras y viceversa
                    if (cmbInicioMasa.SelectedIndex.Equals(0) && cmbFinalMasa.SelectedIndex.Equals(3))
                    {
                        txtResultadoMasa.Text = masa.CalculaGramosALibras(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(3) && cmbFinalMasa.SelectedIndex.Equals(0))
                    {
                        txtResultadoMasa.Text = masa.CalcularLibrasAGramos(Convert.ToDouble(txtValorInicioMasa.Text)).ToString() + " " + cmbFinalMasa.SelectedItem;
                    }

                    //Capturando las funciones que aun no se tienen en la aplicacion 
                    if (cmbInicioMasa.SelectedIndex.Equals(1) && cmbFinalMasa.SelectedIndex.Equals(3))//De Kg a lb
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(1) && cmbFinalMasa.SelectedIndex.Equals(2))//De kg a onzas
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(2) && cmbFinalMasa.SelectedIndex.Equals(1))//De onzas a kg
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(2) && cmbFinalMasa.SelectedIndex.Equals(3))//De onzas a lb
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(3) && cmbFinalMasa.SelectedIndex.Equals(2))//De lb a onzas
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (cmbInicioMasa.SelectedIndex.Equals(3) && cmbFinalMasa.SelectedIndex.Equals(1))//De lb a kg
                    {
                        MessageBox.Show("Lo sentimos La aplicacion no cuenta con una conversion de " + cmbInicioMasa.SelectedItem + " a " + cmbFinalMasa.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Ingreso de misma conversion

                if (cmbInicioMasa.SelectedItem == cmbFinalMasa.SelectedItem)
                {
                    if (cmbInicioMasa.SelectedItem != null || cmbFinalMasa.SelectedItem != null)
                    {
                        txtResultadoMasa.Text = txtValorInicioMasa.Text + " " + cmbFinalMasa.SelectedItem;

                    }
                    else
                    {
                        errorIndice.SetError(cmbInicioMasa, "Debes seleccionar un valor a convertir");
                        cmbInicioMasa.Focus();
                        errorIndice.SetError(cmbFinalMasa, "Debes selecionar una conversion");
                    }
                }
                else
                {
                    btnLimpiarMasa.Visible = false;
                    lblResultadoMasa.Visible = false;
                    txtResultadoMasa.Visible = false;
                }
            }
            //Se quitan los errores si se cumple que:
            if (cmbInicioMasa.Text != "") { errorIndice.SetError(cmbInicioMasa, null); }
            if (cmbFinalMasa.Text != "") { errorIndice.SetError(cmbFinalMasa, null); }
            if (txtValorInicioMasa.Text != "") { errorIndice.SetError(txtValorInicioMasa, null); }
            //Si se cumplen las condiciones entonces ya se muestra el resultado y el boton limpiar
            if (txtValorInicioMasa.Text != "" && cmbInicioMasa.SelectedItem != null && cmbFinalMasa.SelectedItem != null)
            {
                btnLimpiarMasa.Visible = true;
                lblResultadoMasa.Visible = true;
                txtResultadoMasa.Visible = true;
            }
        }
        private void btnLimpiarMasa_Click(object sender, EventArgs e)
        {
            cmbInicioMasa.Text = null;
            cmbFinalMasa.Text = null;
            txtValorInicioMasa.Clear();
            txtResultadoMasa.Clear();
            lblResultadoMasa.Visible = false;
            txtResultadoMasa.Visible = false;
            btnLimpiarMasa.Visible = false;
        }

        private void btnSalirMasa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Salir de la Appliacion", "Confirme Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //-------------------------------------------------------------------------------------------------------
        
        ConversionLongitud longitud = new ConversionLongitud();
        private void btnConvertirLongitud_Click(object sender, EventArgs e)
        {
            if (cmbInicioLongitud.Items == null || cmbFinalLongitud.Items == null || txtValorInicioLongitud.Text == "")
            {
                errorIndice.SetError(cmbInicioLongitud, "Debes seleccionar un valor a convertir");
                errorIndice.SetError(cmbFinalLongitud, "Debes selecionar una conversion");
                errorIndice.SetError(txtValorInicioLongitud, "Debes ingresar un valor");
            }
            else
            {
                if (!double.TryParse(txtValorInicioLongitud.Text, out double valorLongitud))
                {
                    errorIndice.SetError(txtValorInicioLongitud, "Debes ingresar un numero");
                    return;
                }
                else
                {   //Milimetros a Centimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(0) == true && cmbFinalLongitud.SelectedIndex.Equals(1) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaMiliACentimetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Centimetros a Milimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(1) == true && cmbFinalLongitud.SelectedIndex.Equals(0) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaCmAMilimetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Centimetros a Metros
                    if (cmbInicioLongitud.SelectedIndex.Equals(1) == true && cmbFinalLongitud.SelectedIndex.Equals(2) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaCmAMetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Metros a Centimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(2) == true && cmbFinalLongitud.SelectedIndex.Equals(1) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaMetrosACentimetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Centimetros a Kilometros
                    if (cmbInicioLongitud.SelectedIndex.Equals(1) == true && cmbFinalLongitud.SelectedIndex.Equals(3) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaCmAKilometros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Kilometros a Centimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(3) == true && cmbFinalLongitud.SelectedIndex.Equals(1) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaKmACentimetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Metros a Kilometros
                    if (cmbInicioLongitud.SelectedIndex.Equals(2) == true && cmbFinalLongitud.SelectedIndex.Equals(3) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaMetrosAKilometros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }
                    //Kilometros a Metros
                    if (cmbInicioLongitud.SelectedIndex.Equals(3) == true && cmbFinalLongitud.SelectedIndex.Equals(2) == true)
                    {
                        txtResultadoLongitud.Text = longitud.CalculaKmAMetros(Convert.ToDecimal(txtValorInicioLongitud.Text)).ToString() + " " + cmbFinalLongitud.SelectedItem;
                    }

                    //Capturando las funciones que aun no se tienen en la aplicacion 

                    //De metros a milimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(2) && cmbFinalLongitud.SelectedIndex.Equals(0))
                    {
                        MessageBox.Show("Lo sentimos!... La aplicacion no cuenta con una conversion de " + cmbInicioLongitud.SelectedItem + " a " + cmbFinalLongitud.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //De milimetros a metros
                    if (cmbInicioLongitud.SelectedIndex.Equals(0) && cmbFinalLongitud.SelectedIndex.Equals(2))
                    {
                        MessageBox.Show("Lo sentimos!... La aplicacion no cuenta con una conversion de " + cmbInicioLongitud.SelectedItem + " a " + cmbFinalLongitud.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //De kilometros a milimetros
                    if (cmbInicioLongitud.SelectedIndex.Equals(3) && cmbFinalLongitud.SelectedIndex.Equals(0))
                    {
                        MessageBox.Show("Lo sentimos!... La aplicacion no cuenta con una conversion de " + cmbInicioLongitud.SelectedItem + " a " + cmbFinalLongitud.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //De milietros a kilometros
                    if (cmbInicioLongitud.SelectedIndex.Equals(0) && cmbFinalLongitud.SelectedIndex.Equals(3))
                    {
                        MessageBox.Show("Lo sentimos!... La aplicacion no cuenta con una conversion de " + cmbInicioLongitud.SelectedItem + " a " + cmbFinalLongitud.SelectedItem, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Ingreso de misma conversion

                if (cmbInicioLongitud.SelectedItem == cmbFinalLongitud.SelectedItem)
                {
                    if (cmbInicioLongitud.SelectedItem != null || cmbFinalLongitud.SelectedItem != null)
                    {
                        txtResultadoLongitud.Text = txtValorInicioLongitud.Text + " " + cmbFinalLongitud.SelectedItem;
                    }
                    else
                    {
                        errorIndice.SetError(cmbInicioLongitud, "Debes seleccionar un valor a convertir");
                        cmbInicioLongitud.Focus();
                        errorIndice.SetError(cmbFinalLongitud, "Debes selecionar una conversion");
                    }
                }
                else
                {
                    btnLimpiarLongitud.Visible = false;
                    lblResultadoLongitud.Visible = false;
                    txtResultadoLongitud.Visible = false;
                }

            }
            //Se quitan los errores si se cumple que:
            if (cmbInicioLongitud.Text != "") { errorIndice.SetError(cmbInicioLongitud, null); }
            if (cmbFinalLongitud.Text != "") { errorIndice.SetError(cmbFinalLongitud, null); }
            if (txtValorInicioLongitud.Text != "") { errorIndice.SetError(txtValorInicioLongitud, null); }
            //Si se cumplen las condiciones entonces ya se muestra el resultado y el boton limpiar
            if (txtValorInicioLongitud.Text != "" && cmbInicioLongitud.SelectedItem != null && cmbFinalLongitud.SelectedItem != null)
            {
                btnLimpiarLongitud.Visible = true;
                lblResultadoLongitud.Visible = true;
                txtResultadoLongitud.Visible = true;
            }
        }

        private void btnLimpiarLongitud_Click(object sender, EventArgs e)
        {
            cmbInicioLongitud.Text = null;
            cmbFinalLongitud.Text = null;
            txtValorInicioLongitud.Clear();
            txtResultadoLongitud.Clear();
            lblResultadoLongitud.Visible = false;
            txtResultadoLongitud.Visible = false;
            btnLimpiarLongitud.Visible = false;
        }

        private void btnSalirLongitud_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Salir de la Appliacion", "Confirme Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //------------------------------------------------------------------------------------------------------------
        ConversionTemperatura temperatura = new ConversionTemperatura();
        private void btnConvertirTemp_Click(object sender, EventArgs e)
        {
            //Validacion de campos vacios
            if (cmbInicioTemp.Items == null || cmbFinalTemp.Items == null || txtValorInicioTemp.Text == "")
            {
                errorIndice.SetError(cmbInicioTemp, "Debes seleccionar un valor a convertir");
                errorIndice.SetError(cmbFinalTemp, "Debes selecionar una conversion");
                errorIndice.SetError(txtValorInicioTemp, "Debes ingresar un valor");
            }
            else
            {//Si los campos esta llenos, continua con los metodos a a realizar de acuerdo al item seleccionado

                double valorMoneda;
                if (!double.TryParse(txtValorInicioTemp.Text, out valorMoneda))
                {
                    errorIndice.SetError(txtValorInicioTemp, "Debes ingresar un numero");
                    return;
                }
                else
                {
                    if (cmbInicioTemp.SelectedIndex.Equals(0) == true && cmbFinalTemp.SelectedIndex.Equals(1) == true)
                    {
                        txtResultadoTemp.Text = temperatura.CalculaCelsiusAFahre(Convert.ToDouble(txtValorInicioTemp.Text)).ToString() + "º F ";
                    }
                    if (cmbInicioTemp.SelectedIndex.Equals(1) == true && cmbFinalTemp.SelectedIndex.Equals(0) == true)
                    {
                        txtResultadoTemp.Text = temperatura.CalculaFahrenheitACelsius(Convert.ToDouble(txtValorInicioTemp.Text)).ToString() + "º C ";
                    }


                }
                //Ingreso de misma conversion
                if (cmbInicioTemp.SelectedItem == cmbFinalTemp.SelectedItem)
                {
                    if (cmbInicioTemp.SelectedItem != null || cmbFinalTemp.SelectedItem != null)
                    {
                        txtResultadoTemp.Text = txtValorInicioTemp.Text + "º " + cmbFinalTemp.SelectedItem;
                    }
                    else
                    {
                        errorIndice.SetError(cmbInicioTemp, "Debes seleccionar un valor a convertir");
                        cmbInicioMoneda.Focus();
                        errorIndice.SetError(cmbFinalTemp, "Debes selecionar una conversion");
                        //errorIndice.SetError(txtValorInicioMoneda, "Debes selecionar una conversion de arriba");
                    }
                }
                else
                {
                    btnLimpiarTemp.Visible = false;
                    lblResultadoTemp.Visible = false;
                    txtResultadoTemp.Visible = false;
                }
            }
            //Si no, si no estan vacios
            //Se quitan los errores si se cumple que:
            if (cmbInicioTemp.Text != "") { errorIndice.SetError(cmbInicioTemp, null); }
            if (cmbFinalTemp.Text != "") { errorIndice.SetError(cmbFinalTemp, null); }
            if (txtValorInicioTemp.Text != "") { errorIndice.SetError(txtValorInicioTemp, null); }
            //Si se cumplen las condiciones entonces ya se muestra el resultado y el boton limpiar
            if (txtValorInicioTemp.Text != "" && cmbInicioTemp.SelectedItem != null && cmbFinalTemp.SelectedItem != null)
            {
                btnLimpiarTemp.Visible = true;
                lblResultadoTemp.Visible = true;
                txtResultadoTemp.Visible = true;
            }

        }

        private void btnLimpiarTemp_Click(object sender, EventArgs e)
        {
            cmbInicioTemp.Text = null;
            cmbFinalTemp.Text = null;
            txtValorInicioTemp.Clear();
            txtResultadoTemp.Clear();
            lblResultadoTemp.Visible = false;
            txtResultadoTemp.Visible = false;
            btnLimpiarTemp.Visible = false;
        }

        private void btnSalirTemp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Salir de la Appliacion", "Confirme Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
