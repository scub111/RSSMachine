﻿#pragma checksum "..\..\HMIButton.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "017293474EA875722CE4273D1D46DC83"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RSSMachine;
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


namespace RSSMachine {
    
    
    /// <summary>
    /// HMIButton
    /// </summary>
    public partial class HMIButton : RSSMachine.HMIBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualStateGroup MouseStateGroup;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState ControlMouseEnter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState ControlMouseLeave;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualStateGroup ValueStateGroup;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualStateGroup ActualStateGroup;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState ControlActualTrue;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState ControlActualFalse;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recMouse;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtCaption;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox vwWarning;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\HMIButton.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle recFill;
        
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
            System.Uri resourceLocater = new System.Uri("/RSSMachine;component/hmibutton.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HMIButton.xaml"
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
            this.MouseStateGroup = ((System.Windows.VisualStateGroup)(target));
            return;
            case 2:
            this.ControlMouseEnter = ((System.Windows.VisualState)(target));
            return;
            case 3:
            this.ControlMouseLeave = ((System.Windows.VisualState)(target));
            return;
            case 4:
            this.ValueStateGroup = ((System.Windows.VisualStateGroup)(target));
            return;
            case 5:
            this.ActualStateGroup = ((System.Windows.VisualStateGroup)(target));
            return;
            case 6:
            this.ControlActualTrue = ((System.Windows.VisualState)(target));
            return;
            case 7:
            this.ControlActualFalse = ((System.Windows.VisualState)(target));
            return;
            case 8:
            this.recMouse = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 9:
            this.txtCaption = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.vwWarning = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 11:
            this.recFill = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

