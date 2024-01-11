namespace UD5T1
{
    public partial class MainPage : ContentPage
    {
        private decimal cuenta;
        private int propina;
        private int personas = 1;
        public MainPage()
        {
            InitializeComponent();
        }

        //Método encargado de calcular los valores paar cada labes, es decir el total a pagar por persona, el subtotal y la propina por persona.
        private void CalcularTotal()
        {
            //Propina Total
            var propinaTotal = cuenta * propina / 100;

            //Propina por persona
            var propinaPorPersona = propinaTotal / personas;
            lblPropinaPorPersona.Text = $"{propinaPorPersona:C}";

            //Subtotal
            var subtotal = cuenta / personas;
            lblSubtotal.Text = $"{subtotal:C}";

            //Total
            var totalPorPersona = (cuenta + propinaTotal) / personas;
            lblTotal.Text = $"{totalPorPersona:C}";
        }
        //Método que recoge el importe de la cuenta y calcula el total
        private void TxtCuenta_Completed(object sender, EventArgs e)
        {
            cuenta=decimal.Parse(txtCuenta.Text);
            CalcularTotal();
        }
        //Método que recoge el valor del slider, actualiza el lbl de la propina y calcula el total.
        private void SldPropina_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            propina=Convert.ToInt32(sldPropina.Value);
            lblPropina.Text = propina.ToString();
            CalcularTotal();
        }
        // Este método se activa cuando se hace clic en un botón específico relacionado con el porcentaje de propina.
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                // Convierte el objeto 'sender' a un tipo Button para acceder a sus propiedades y métodos.
                var btn = (Button)sender;

                // Extrae el porcentaje del texto del botón (elimina el símbolo '%' y convierte a entero).
                var porcentaje = int.Parse(btn.Text.Replace("%", string.Empty));

                // Asigna el valor del porcentaje al control deslizante de propina (slider).
                sldPropina.Value = porcentaje;
            }
        }
        //Método que se encarga de cuando se pulsa el botón menos disminuyen las personas y calcula el total, siempre y cuando haya al menos una persona.
        private void BtnMenos_Clicked(object sender, EventArgs e)
        {
            if (personas > 1)
            {
                personas--;
                lblPersonas.Text=personas.ToString();
                CalcularTotal();
            }
        }
        //Método encargado de incrementar el número de personas, cada vez que se pulse e botón más, posteriorment calcula el total
        private void BtnMas_Clicked(object sender, EventArgs e)
        {
            personas++;
            lblPersonas.Text = personas.ToString();
            CalcularTotal();
        }
    }
}