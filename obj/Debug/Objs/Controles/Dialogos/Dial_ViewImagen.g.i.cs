﻿#pragma checksum "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45FF192C45A3F9231154242804EACACC"
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
    /// Dial_ViewImagen
    /// </summary>
    public partial class Dial_ViewImagen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Salir;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_contenido;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox vb_contenido;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img_documento;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Imprimir;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/dialogos/dial_viewimagen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
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
            this.But_Salir = ((System.Windows.Controls.Button)(target));
            
            #line 8 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
            this.But_Salir.Click += new System.Windows.RoutedEventHandler(this.But_Salir_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid_contenido = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.vb_contenido = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 4:
            this.img_documento = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            
            #line 35 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
            ((System.Windows.Controls.Slider)(target)).ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.But_Imprimir = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\Objs\Controles\Dialogos\Dial_ViewImagen.xaml"
            this.But_Imprimir.Click += new System.Windows.RoutedEventHandler(this.But_Imprimir_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
