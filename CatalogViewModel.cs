using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Platinum_Star.Models;

namespace Platinum_Star
{
    internal class CatalogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProductModel> products { get; set; }

        private float _hue, _saturation, _luminosity;
        private Color _color;

        public float Hue
        {
            get => _hue;
            set
            {
                if (_hue != value)
                    Color = Color.FromHsla(value, _saturation, _luminosity);
            }
        }

        public float Saturation
        {
            get => _saturation;
            set
            {
                if (_saturation != value)
                    Color = Color.FromHsla(_hue, value, _luminosity);
            }
        }

        public float Luminosity
        {
            get => _luminosity;
            set
            {
                if (_luminosity != value)
                    Color = Color.FromHsla(_hue, _saturation, value);
            }
        }

        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    _hue = _color.GetHue();
                    _saturation = _color.GetSaturation();
                    _luminosity = _color.GetLuminosity();

                    OnPropertyChanged("Hue");
                    OnPropertyChanged("Saturation");
                    OnPropertyChanged("Luminosity");
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
