﻿#pragma checksum "..\..\Authorized1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9F4E1E114C2A19FD674F3CD7797437CD3A10836E9FB53C229F49F84764B33A0"
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
    /// Authorized1
    /// </summary>
    public partial class Authorized1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\Authorized1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LoginHint;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Authorized1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Authorized1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PasswordHint;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Authorized1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Authorized1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignInButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Prison;component/authorized1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Authorized1.xaml"
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
            this.LoginHint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.LoginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordHint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.SignInButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Authorized1.xaml"
            this.SignInButton.Click += new System.Windows.RoutedEventHandler(this.SignInButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

