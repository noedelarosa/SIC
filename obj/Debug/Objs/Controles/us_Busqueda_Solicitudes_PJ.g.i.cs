﻿#pragma checksum "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A40F0426C891FD2AEF46FB1D66223138"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Empresa.Comun;
using Empresa.Docente;
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
using Xceed.Wpf.Controls;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.Automation;
using Xceed.Wpf.DataGrid.Converters;
using Xceed.Wpf.DataGrid.FilterCriteria;
using Xceed.Wpf.DataGrid.Markup;
using Xceed.Wpf.DataGrid.Print;
using Xceed.Wpf.DataGrid.Stats;
using Xceed.Wpf.DataGrid.ValidationRules;
using Xceed.Wpf.DataGrid.Views;
using Xceed.Wpf.DataGrid.Views.Surfaces;


namespace SIC.Objs.Controles {
    
    
    /// <summary>
    /// us_Busqueda_Solicitudes_PJ
    /// </summary>
    public partial class us_Busqueda_Solicitudes_PJ : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_finicio;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_ffinal;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Com_estado;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Buscar;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.DataGrid.DataGridControl datagrid12;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/us_busqueda_solicitudes_pj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
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
            this.dp_finicio = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.dp_ffinal = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.Com_estado = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.But_Buscar = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Objs\Controles\us_Busqueda_Solicitudes_PJ.xaml"
            this.But_Buscar.Click += new System.Windows.RoutedEventHandler(this.But_Buscar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.datagrid12 = ((Xceed.Wpf.DataGrid.DataGridControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

