﻿using FlickrNet;
using PhotoSearch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoSearch
{
    /// <summary>
    /// Interaction logic for GetPhotos.xaml
    /// </summary>
    public partial class GetPhotos : UserControl
    {
        public GetPhotos()
        {
            InitializeComponent();
            
            
            BitmapImage a = new BitmapImage();
          //  visibility = "Visible";
           
            // yo.Source = (ImageSource)"adasda";
            

        }
        public string visibility
        {
            get { return (string)GetValue(visibleStateProperty); }
            set { SetValue(visibleStateProperty, value); }
        }

        public static readonly DependencyProperty visibleStateProperty = DependencyProperty.Register("visibility", typeof(string), typeof(MainWindow), new PropertyMetadata("Visible"));
        
    }
}
