﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "146C5BBA77C50BEE9738CA0B72EC3947"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.239
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
using alchemy;


namespace alchemy {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.StackPanel mainStack;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Canvas elements;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Canvas workspace;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/alchemy;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.mainStack = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.elements = ((System.Windows.Controls.Canvas)(target));
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.elements.Drop += new System.Windows.DragEventHandler(this.elements_Drop);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.elements.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.elements_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\MainWindow.xaml"
            this.elements.DragEnter += new System.Windows.DragEventHandler(this.elements_DragEnter);
            
            #line default
            #line hidden
            return;
            case 3:
            this.workspace = ((System.Windows.Controls.Canvas)(target));
            
            #line 13 "..\..\..\MainWindow.xaml"
            this.workspace.DragEnter += new System.Windows.DragEventHandler(this.workspace_DragEnter);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\MainWindow.xaml"
            this.workspace.Drop += new System.Windows.DragEventHandler(this.workspace_Drop);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\MainWindow.xaml"
            this.workspace.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.workspace_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

