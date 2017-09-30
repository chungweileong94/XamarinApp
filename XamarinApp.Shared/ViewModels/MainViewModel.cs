using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinApp.Helpers;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ViewImage> ImageCollection { get; set; }

        private bool _IsLoading;

        public bool IsLoading
        {
            get { return _IsLoading; }
            set { Set(ref _IsLoading, value); }
        }

        private ICommand _RefreshCommand;

        public ICommand RefreshCommand
        {
            get
            {
                _RefreshCommand = new RelayCommand<EventArgs>(async (e) =>
                {
                    await LoadImagesAsync();
                });
                return _RefreshCommand;
            }
            set { _RefreshCommand = value; }
        }


        public MainViewModel()
        {
            ImageCollection = new ObservableRangeCollection<ViewImage>();
        }

        public async Task LoadImagesAsync()
        {
            ImageCollection.Clear();

            using (HttpClient http = new HttpClient())
            {
                IsLoading = true;
                string json = await http.GetStringAsync("https://www.bing.com/HPImageArchive.aspx?format=js&n=8");

                var bingImages = JsonConvert.DeserializeObject<BingImages>(json);

                List<ViewImage> temp = new List<ViewImage>();

                foreach (var item in bingImages.Images)
                {
                    temp.Add(
                        new ViewImage
                        {
                            Title = item.Copyright,
                            Url = $"http://www.bing.com{item.Url}"
                        });
                }

                ImageCollection.AddRange(temp);
                IsLoading = false;
            }
        }
    }
}
