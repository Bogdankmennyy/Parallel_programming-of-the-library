using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTaskExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Спосіб 1: Використовуємо метод Start класу Task
            Task task1 = new Task(DisplayCurrentTime);
            task1.Start();

            // Спосіб 2: Використовуємо метод Task.Factory.StartNew
            Task task2 = Task.Factory.StartNew(DisplayCurrentTime);

            // Спосіб 3: Використовуємо метод Task.Run
            Task task3 = Task.Run(DisplayCurrentTime);

            // Очікуємо завершення всіх завдань
            Task.WhenAll(task1, task2, task3).ContinueWith((t) =>
            {
                // Після завершення виводимо повідомлення
                MessageBox.Show("Всі завдання завершено.");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void DisplayCurrentTime()
        {
            DateTime currentTime = DateTime.Now;

            // Оновлюємо інтерфейс з потоку користувальницького інтерфейсу
            Dispatcher.Invoke(() =>
            {
                TimeLabel.Text = $"Поточний час і дата: {currentTime}";
            });
        }
    }
}
