﻿#pragma checksum "..\..\addrecipe.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8DFA00BF318D96FFA18509EF5D5994B7F6600369"
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
    /// addrecipe
    /// </summary>
    public partial class addrecipe : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rec_name;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prigotovlenie;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox type_prod;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ingred_list;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weight_ingr;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_ingred;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock info_recipe;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button calculate;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\addrecipe.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create_recipe;
        
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
            System.Uri resourceLocater = new System.Uri("/кп;component/addrecipe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addrecipe.xaml"
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
            this.rec_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.prigotovlenie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.type_prod = ((System.Windows.Controls.ListBox)(target));
            
            #line 20 "..\..\addrecipe.xaml"
            this.type_prod.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ingred_list = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.weight_ingr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.add_ingred = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\addrecipe.xaml"
            this.add_ingred.Click += new System.Windows.RoutedEventHandler(this.add_ingred_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.info_recipe = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.calculate = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\addrecipe.xaml"
            this.calculate.Click += new System.Windows.RoutedEventHandler(this.calculate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.create_recipe = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\addrecipe.xaml"
            this.create_recipe.Click += new System.Windows.RoutedEventHandler(this.create_recipe_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

