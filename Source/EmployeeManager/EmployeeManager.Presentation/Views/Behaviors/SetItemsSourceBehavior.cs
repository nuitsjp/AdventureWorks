using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using GrapeCity.Windows.SpreadGrid;

namespace AdventureWorks.EmployeeManager.Presentation.Views.Behaviors
{
    public class SetItemsSourceBehavior : Behavior<UIElement>
    {
        public static readonly DependencyProperty ComboBoxCellProperty = DependencyProperty.Register(
            "ComboBoxCell", typeof(ComboBoxCellType), typeof(SetItemsSourceBehavior), new PropertyMetadata(default(ComboBoxCellType)));

        public ComboBoxCellType ComboBoxCell
        {
            get => (ComboBoxCellType) GetValue(ComboBoxCellProperty);
            set => SetValue(ComboBoxCellProperty, value);
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(SetItemsSourceBehavior), new PropertyMetadata(default(IEnumerable), OnItemsSourceChanged));

        public IEnumerable ItemsSource
        {
            get => (IEnumerable) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (SetItemsSourceBehavior)d;
            behavior.ComboBoxCell.ItemsSource = behavior.ItemsSource;
        }
    }
}
