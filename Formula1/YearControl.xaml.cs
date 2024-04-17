using Formula1.Models;
namespace Formula1
{
    public partial class YearControl : ContentView
    {

        public int Value { get; set; }   
        public YearControl()
        {
            InitializeComponent();
            ValueEntry.Text = "2001";
        }

        private void MinusButton_Clicked(object sender, EventArgs e)
        {

            if (Value > 0)
            {
                Value--;
                ValueEntry.Text = Value.ToString();
            }

        }

        private void PlusButton_Clicked(object sender, EventArgs e)
        {
            Value++;
            ValueEntry.Text = Value.ToString();
        }

        private void Value_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(e.NewTextValue, out var value))
            {
                Value = value;
            }

            if (e.NewTextValue.StartsWith("-"))
            {
                ValueEntry.Text = value.ToString();
                return;
            }

        }

    


    }
}