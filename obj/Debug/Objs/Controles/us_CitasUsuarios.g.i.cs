﻿#pragma checksum "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CEB8F2791C80C477CD8E4A82463395B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SIC.Objs.Controles;
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


namespace SIC.Objs.Controles {
    
    
    /// <summary>
    /// us_CitasUsuarios
    /// </summary>
    public partial class us_CitasUsuarios : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SIC.Objs.Controles.us_CitasUsuarios us_CitasUsuarios_control;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Direccion_Solicitante;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_Copy7;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SIC.Objs.Controles.us_direcciones control_us_direccion;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SIC.Objs.Controles.us_contactos control_us_contactos;
        
        #line default
        #line hidden
        
        /// <summary>
        /// But_Siguiente Name Field
        /// </summary>
        
        #line 30 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button But_Siguiente;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/us_citasusuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.us_CitasUsuarios_control = ((SIC.Objs.Controles.us_CitasUsuarios)(target));
            return;
            case 2:
            this.Direccion_Solicitante = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.border_Copy7 = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.control_us_direccion = ((SIC.Objs.Controles.us_direcciones)(target));
            return;
            case 5:
            this.control_us_contactos = ((SIC.Objs.Controles.us_contactos)(target));
            return;
            case 6:
            this.But_Siguiente = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Objs\Controles\us_CitasUsuarios.xaml"
            this.But_Siguiente.Click += new System.Windows.RoutedEventHandler(this.But_Siguiente_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

