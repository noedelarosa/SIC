﻿#pragma checksum "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1772D00520FCE16C712B2492DB48D122"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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


namespace SIC.Objs.Controles.Dialogos {
    
    
    /// <summary>
    /// Dial_DeseaNotificarFallecido
    /// </summary>
    public partial class Dial_DeseaNotificarFallecido : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SIC.Objs.Controles.Dialogos.Dial_DeseaNotificarFallecido us_Dial_DeseaNotificarFallecido;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Aceptar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_No;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ch_enviaremail;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Decripcion;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/dialogos/dial_deseanotificarfallecido.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
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
            this.us_Dial_DeseaNotificarFallecido = ((SIC.Objs.Controles.Dialogos.Dial_DeseaNotificarFallecido)(target));
            return;
            case 2:
            this.But_Aceptar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
            this.But_Aceptar.Click += new System.Windows.RoutedEventHandler(this.But_Aceptar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.But_No = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_DeseaNotificarFallecido.xaml"
            this.But_No.Click += new System.Windows.RoutedEventHandler(this.But_No_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ch_enviaremail = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.Txt_Decripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

