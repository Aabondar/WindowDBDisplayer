﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "622E45B533BE5B01FE5912DFDE00C17E7358702E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TestTaskWindowsApp;


namespace TestTaskWindowsApp {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox VencodeFilter;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameFilter;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LinkedNumberFilter;
        
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
            System.Uri resourceLocater = new System.Uri("/WindowDBDisplayer;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.VencodeFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\MainWindow.xaml"
            this.VencodeFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.VencodeFilter_TextChanged);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.VencodeFilter.GotFocus += new System.Windows.RoutedEventHandler(this.VencodeFilter_GotFocus);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.VencodeFilter.LostFocus += new System.Windows.RoutedEventHandler(this.VencodeFilter_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\MainWindow.xaml"
            this.NameFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameFilter_TextChanged);
            
            #line default
            #line hidden
            
            #line 58 "..\..\MainWindow.xaml"
            this.NameFilter.GotFocus += new System.Windows.RoutedEventHandler(this.NameFilter_GotFocus);
            
            #line default
            #line hidden
            
            #line 58 "..\..\MainWindow.xaml"
            this.NameFilter.LostFocus += new System.Windows.RoutedEventHandler(this.NameFilter_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LinkedNumberFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\MainWindow.xaml"
            this.LinkedNumberFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LinkedNumberFilter_TextChanged);
            
            #line default
            #line hidden
            
            #line 59 "..\..\MainWindow.xaml"
            this.LinkedNumberFilter.GotFocus += new System.Windows.RoutedEventHandler(this.LinkedNumberFilter_GotFocus);
            
            #line default
            #line hidden
            
            #line 59 "..\..\MainWindow.xaml"
            this.LinkedNumberFilter.LostFocus += new System.Windows.RoutedEventHandler(this.LinkedNumberFilter_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

