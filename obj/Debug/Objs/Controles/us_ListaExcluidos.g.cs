﻿#pragma checksum "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "986329D613B7BB5FF167F140684A969F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Empresa.Comun;
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
    /// us_ListaExcluidos
    /// </summary>
    public partial class us_ListaExcluidos : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Refresh;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.DataGrid.DataGridControl datagrid1;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Inclusion;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button But_Editar;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Txt_Familiares;
        
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
            System.Uri resourceLocater = new System.Uri("/SIC;component/objs/controles/us_listaexcluidos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
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
            
            #line 8 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
            ((SIC.Objs.Controles.us_ListaExcluidos)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.UserControl_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.But_Refresh = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
            this.But_Refresh.Click += new System.Windows.RoutedEventHandler(this.But_Refresh_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.datagrid1 = ((Xceed.Wpf.DataGrid.DataGridControl)(target));
            return;
            case 4:
            this.But_Inclusion = ((System.Windows.Controls.Button)(target));
            
            #line 139 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
            this.But_Inclusion.Click += new System.Windows.RoutedEventHandler(this.But_Inclusion_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.But_Editar = ((System.Windows.Controls.Button)(target));
            
            #line 147 "..\..\..\..\Objs\Controles\us_ListaExcluidos.xaml"
            this.But_Editar.Click += new System.Windows.RoutedEventHandler(this.But_Editar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Txt_Familiares = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

