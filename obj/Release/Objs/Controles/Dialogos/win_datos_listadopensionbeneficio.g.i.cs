﻿#pragma checksum "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3909D02E8A16FCB69ACFBFF8A953B609"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
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
    /// win_datos_listadopensionbeneficio
    /// </summary>
    public partial class win_datos_listadopensionbeneficio : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SIC.Objs.Controles.Dialogos.win_datos_listadopensionbeneficio win_datos_listadopensionbeneficio_control;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Guardar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Salir;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/dialogos/win_datos_listadopensionbeneficio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
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
            this.win_datos_listadopensionbeneficio_control = ((SIC.Objs.Controles.Dialogos.win_datos_listadopensionbeneficio)(target));
            return;
            case 2:
            this.But_Guardar = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
            this.But_Guardar.Click += new System.Windows.RoutedEventHandler(this.But_Guardar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.But_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\Objs\Controles\Dialogos\win_datos_listadopensionbeneficio.xaml"
            this.But_Salir.Click += new System.Windows.RoutedEventHandler(this.But_Salir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
