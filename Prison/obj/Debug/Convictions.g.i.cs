﻿#pragma checksum "..\..\Convictions.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAB40D070CCD216FAC8B4139BAAC406A202609B8F51300AB32A5AAB47CB3CDFE"
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
    /// Convictions
    /// </summary>
    public partial class Convictions : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfConv;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PrisonTermTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PrisonerComboBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CourtComboBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CrimeComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Convictions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Prison;component/convictions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Convictions.xaml"
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
            this.DataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\Convictions.xaml"
            this.DataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DateOfConv = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.PrisonTermTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\Convictions.xaml"
            this.PrisonTermTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PrisonTermTextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PrisonerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CourtComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CrimeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Convictions.xaml"
            this.EditButton.Click += new System.Windows.RoutedEventHandler(this.EditButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Convictions.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
