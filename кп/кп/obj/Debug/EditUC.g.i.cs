﻿#pragma checksum "..\..\EditUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30761EF59EAA3B5129172460237986105D6F236E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using кп;


namespace кп {
    
    
    /// <summary>
    /// UsersUC
    /// </summary>
    public partial class UsersUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_edit;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagrid_recipes;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button open_recipe;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label name_of_recipe;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_recipe;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ing;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox weight;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_text;
        
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
            System.Uri resourceLocater = new System.Uri("/кп;component/edituc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditUC.xaml"
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
            this.grid_edit = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.datagrid_recipes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.open_recipe = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\EditUC.xaml"
            this.open_recipe.Click += new System.Windows.RoutedEventHandler(this.open_recipe_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.name_of_recipe = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.text_recipe = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ing = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.weight = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.save_text = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\EditUC.xaml"
            this.save_text.Click += new System.Windows.RoutedEventHandler(this.save_text_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

