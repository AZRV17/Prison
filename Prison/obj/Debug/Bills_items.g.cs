﻿#pragma checksum "..\..\Bills_items.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E91F6D9295AE66D899BE8C6E98A66345992E00C82C2DFC9C4153E47A35563A76"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Prison;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Prison {
    
    
    /// <summary>
    /// Bills_items
    /// </summary>
    public partial class Bills_items : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BillsComboBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Bills_ItemsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EmployeeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateTextBlock;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SumTextBlock;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock InputTextBlock;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SurrenderTextBlock;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Bills_items.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBillButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Prison;component/bills_items.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Bills_items.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BillsComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\Bills_items.xaml"
            this.BillsComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BillsComboBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Bills_ItemsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.EmployeeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.DateTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SumTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.InputTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.SurrenderTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.SaveBillButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Bills_items.xaml"
            this.SaveBillButton.Click += new System.Windows.RoutedEventHandler(this.SaveBillButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

