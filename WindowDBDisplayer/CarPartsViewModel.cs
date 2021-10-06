using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace TestTaskWindowsApp
{
    class CarPartsViewModel : INotifyPropertyChanged //Наш ViewModel. Здесь вся логика для получения и отображения объектов модели в Представлении
    {
        public ObservableCollection<CarParts> carPartsFullCollection { get; private set; } //Коллекция для заполнения с базы данных
        public ObservableCollection<CarParts> carPartsCollection { get; private set; } //Коллекция для вывода в ListView

        public CarPartsViewModel()
        {
            carPartsFullCollection = new ObservableCollection<CarParts>();
            DatabaseManager.InitializeConnectionString(); //Инициализируем строку соединения
            DatabaseManager.ReadFromDB(carPartsFullCollection); //Запускаем метод считывания с базы данных в коллекцию приложения
            carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
        }

        public void FilterVenCode(object sender, EventArgs e) //Обработчик события изменения текста в фильтре VenCode
        {
            TextBox textBox = sender as TextBox;
            string text;

            if (textBox != null)
            {
                text = textBox.Text;

                if (text == "фильтр по коду")
                    return;
                else
                {
                    if (text == string.Empty)
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");
                    }
                    else
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");

                        for (int i = 0; i < carPartsCollection.Count; i++)
                        {
                            string selectCode = carPartsCollection[i].venCode.Remove(carPartsCollection[i].venCode.IndexOf(" "),
                                                carPartsCollection[i].venCode.Count() - carPartsCollection[i].venCode.IndexOf(" "));
                            //Отрезаем от строки лишнее и ищем точное совпадение с введённым текстом
                            if (selectCode != text)
                            {
                                carPartsCollection.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
        }

        public void FilterPartName(object sender, EventArgs e) //Обработчик события изменения текста в фильтре PartName
        {
            TextBox textBox = sender as TextBox;
            string text;

            if (textBox != null)
            {
                text = textBox.Text;

                if (text == "фильтр по вхождению в текст имени")
                    return;
                else
                {

                    if (text == string.Empty)
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");
                    }
                    else
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");

                        for (int i = 0; i < carPartsCollection.Count; i++)
                        {
                            bool found = carPartsCollection[i].partName.IndexOf(text) != -1;
                            if (!found)
                                found = carPartsCollection[i].partName.ToLower().IndexOf(text) != -1;
                            //Ищем вхождение введённого текста независимо от регистра
                            if (!found)
                            {
                                carPartsCollection.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
        }

        public void FilterLinkedNumber(object sender, EventArgs e) //Обработчик события изменения текста в фильтре LinkedNumber
        {
            TextBox textBox = sender as TextBox;
            string text;

            if (textBox != null)
            {
                text = textBox.Text;

                if (text == "фильтр по коду")
                    return;

                else
                {
                    if (text == string.Empty)
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");
                    }
                    else
                    {
                        carPartsCollection = new ObservableCollection<CarParts>(carPartsFullCollection);
                        OnPropertyChanged("carPartsCollection");

                        for (int i = 0; i < carPartsCollection.Count; i++)
                        {
                            string selectCode = carPartsCollection[i].linkedNumber.Remove(carPartsCollection[i].linkedNumber.IndexOf(" "),
                                                carPartsCollection[i].linkedNumber.Count() - carPartsCollection[i].linkedNumber.IndexOf(" "));
                            //Отрезаем от строки лишнее и ищем точное совпадение с введённым текстом, игнорируя регистр
                            if (selectCode != text)
                            {
                                selectCode = selectCode.ToLower();
                                if (selectCode != text)
                                {
                                    carPartsCollection.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //Имплементация интерфейса INotifyPropertyChanged
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
