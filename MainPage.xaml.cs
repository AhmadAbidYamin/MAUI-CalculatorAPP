namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private string _currentEntry = string.Empty;
        private double _firstNumber = 0;
        private string _operator = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _currentEntry += button.Text; 
            DisplayLabel.Text = _currentEntry;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

   
            if (double.TryParse(_currentEntry, out _firstNumber))
            {
                _operator = button.Text;
                _currentEntry = "";
            }
        }

     
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(_currentEntry, out double secondNumber))
            {
                double result = 0;

             
                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "x":
                        result = _firstNumber * secondNumber;
                        break;
                    case "/":
                        result = secondNumber != 0 ? _firstNumber / secondNumber : double.NaN;
                        break;
                }

                DisplayLabel.Text = result.ToString();
                _currentEntry = result.ToString();
            }
        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentEntry = "";
            _firstNumber = 0;
            _operator = "";
            DisplayLabel.Text = "0";
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentEntry))
            {
                _currentEntry = _currentEntry.Substring(0, _currentEntry.Length - 1);
                DisplayLabel.Text = string.IsNullOrEmpty(_currentEntry) ? "0" : _currentEntry;
            }
        }
    }
}