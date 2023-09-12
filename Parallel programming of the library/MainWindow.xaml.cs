using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            int lowerBound = 2;
            int upperBound = 1000;

            int primeCount = await Task.Run(() => CountPrimes(lowerBound, upperBound));

            ResultTextBlock.Text = $"Кількість простих чисел в діапазоні від {lowerBound} до {upperBound}: {primeCount}";
        }

        private int CountPrimes(int lowerBound, int upperBound)
        {
            int count = 0;

            for (int number = lowerBound; number <= upperBound; number++)
            {
                if (IsPrime(number))
                {
                    count++;
                }
            }

            return count;
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

