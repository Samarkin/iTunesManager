﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5448
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Ins")]
        public global::System.Windows.Forms.Keys PlayPauseHotkey {
            get {
                return ((global::System.Windows.Forms.Keys)(this["PlayPauseHotkey"]));
            }
            set {
                this["PlayPauseHotkey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Win")]
        public global::WindowsFormsApplication1.Helpers.ModifierKeys PlayPauseModifiers {
            get {
                return ((global::WindowsFormsApplication1.Helpers.ModifierKeys)(this["PlayPauseModifiers"]));
            }
            set {
                this["PlayPauseModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PgDn")]
        public global::System.Windows.Forms.Keys NextTrackHotkey {
            get {
                return ((global::System.Windows.Forms.Keys)(this["NextTrackHotkey"]));
            }
            set {
                this["NextTrackHotkey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Win")]
        public global::WindowsFormsApplication1.Helpers.ModifierKeys NextTrackModifiers {
            get {
                return ((global::WindowsFormsApplication1.Helpers.ModifierKeys)(this["NextTrackModifiers"]));
            }
            set {
                this["NextTrackModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PgUp")]
        public global::System.Windows.Forms.Keys PrevTrackHotkey {
            get {
                return ((global::System.Windows.Forms.Keys)(this["PrevTrackHotkey"]));
            }
            set {
                this["PrevTrackHotkey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Win")]
        public global::WindowsFormsApplication1.Helpers.ModifierKeys PrevTrackModifiers {
            get {
                return ((global::WindowsFormsApplication1.Helpers.ModifierKeys)(this["PrevTrackModifiers"]));
            }
            set {
                this["PrevTrackModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("End")]
        public global::System.Windows.Forms.Keys SelectSongHotkey {
            get {
                return ((global::System.Windows.Forms.Keys)(this["SelectSongHotkey"]));
            }
            set {
                this["SelectSongHotkey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Win")]
        public global::WindowsFormsApplication1.Helpers.ModifierKeys SelectSongModifiers {
            get {
                return ((global::WindowsFormsApplication1.Helpers.ModifierKeys)(this["SelectSongModifiers"]));
            }
            set {
                this["SelectSongModifiers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.85")]
        public double OSDOpacity {
            get {
                return ((double)(this["OSDOpacity"]));
            }
            set {
                this["OSDOpacity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5000")]
        public int OSDDisplayTime {
            get {
                return ((int)(this["OSDDisplayTime"]));
            }
            set {
                this["OSDDisplayTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ScreenBottom")]
        public global::WindowsFormsApplication1.Helpers.OSDPosition OSDPosition {
            get {
                return ((global::WindowsFormsApplication1.Helpers.OSDPosition)(this["OSDPosition"]));
            }
            set {
                this["OSDPosition"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool OSDDisplayOnPause {
            get {
                return ((bool)(this["OSDDisplayOnPause"]));
            }
            set {
                this["OSDDisplayOnPause"] = value;
            }
        }
    }
}
