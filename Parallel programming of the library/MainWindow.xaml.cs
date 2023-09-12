using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTaskPrimeNumbers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void FindPrimes_Click(object sender, RoutedEventArgs e)
        {
            PrimeNumbersListBox.Items.Clear();

            List<int> primeNumbers = await Task.Run(() => FindPrimes());

            foreach (int prime in primeNumbers)
            {
                PrimeNumbersListBox.Items.Add(prime);
            }
        }

        private List<int> FindPrimes()
        {
            List<int> primes = new List<int>();

            for (int number = 2; number <= 1000; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
