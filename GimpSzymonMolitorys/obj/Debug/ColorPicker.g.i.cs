﻿#pragma checksum "..\..\ColorPicker.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BD0FB565533B9DC29BF5C6BB3489EEE426198512D1190379C8C0178210264083"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using GimpSzymonMolitorys;
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


namespace GimpSzymonMolitorys {
    
    
    /// <summary>
    /// ColorPicker
    /// </summary>
    public partial class ColorPicker : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxR;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxG;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectColor;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxH;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxS;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxV;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ColorPicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dataChanger;
        
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
            System.Uri resourceLocater = new System.Uri("/GimpSzymonMolitorys;component/colorpicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ColorPicker.xaml"
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
            this.txtBoxR = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\ColorPicker.xaml"
            this.txtBoxR.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBoxR_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtBoxG = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\ColorPicker.xaml"
            this.txtBoxG.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBoxG_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBoxB = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\ColorPicker.xaml"
            this.txtBoxB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBoxB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rectColor = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.txtBoxH = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBoxS = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtBoxV = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.dataChanger = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 26 "..\..\ColorPicker.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Button_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

