﻿#pragma checksum "..\..\..\..\Views\InvoicesView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1000DD736026B29DF7902C0788976EC9839CCBEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Telesi.Views;


namespace Telesi.Views {
    
    
    /// <summary>
    /// InvoicesView
    /// </summary>
    public partial class InvoicesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 122 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Buscar;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image NewLogButton;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image OpenLogButton;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SaveLogButton;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrViwer;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\..\Views\InvoicesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Pp;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Telesi;V1.0.0.0;component/views/invoicesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\InvoicesView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Buscar = ((System.Windows.Controls.TextBox)(target));
            
            #line 131 "..\..\..\..\Views\InvoicesView.xaml"
            this.Buscar.GotFocus += new System.Windows.RoutedEventHandler(this.TBoxF);
            
            #line default
            #line hidden
            
            #line 132 "..\..\..\..\Views\InvoicesView.xaml"
            this.Buscar.LostFocus += new System.Windows.RoutedEventHandler(this.TBoxLF);
            
            #line default
            #line hidden
            
            #line 133 "..\..\..\..\Views\InvoicesView.xaml"
            this.Buscar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.K);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NewLogButton = ((System.Windows.Controls.Image)(target));
            
            #line 141 "..\..\..\..\Views\InvoicesView.xaml"
            this.NewLogButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonNew);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 147 "..\..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonNew);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OpenLogButton = ((System.Windows.Controls.Image)(target));
            
            #line 154 "..\..\..\..\Views\InvoicesView.xaml"
            this.OpenLogButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonOpen);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 160 "..\..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonOpen);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveLogButton = ((System.Windows.Controls.Image)(target));
            
            #line 167 "..\..\..\..\Views\InvoicesView.xaml"
            this.SaveLogButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonSave);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 173 "..\..\..\..\Views\InvoicesView.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClickButtonSave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ScrViwer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 9:
            this.Pp = ((System.Windows.Controls.Border)(target));
            
            #line 208 "..\..\..\..\Views\InvoicesView.xaml"
            this.Pp.SizeChanged += new System.Windows.SizeChangedEventHandler(this.UpdateList);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

