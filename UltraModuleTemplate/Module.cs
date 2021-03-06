﻿using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using UltraModuleTemplate.Updaters;
using System.Drawing;

namespace UltraModuleTemplate
{
    //TODO uncomment the filter attribute depending on the platform implementation
    //[ToolboxItemFilter("Xaf.Platform.Win")]
    //[ToolboxItemFilter("Xaf.Platform.Web")]
    [DevExpress.Utils.ToolboxTabName(XafAssemblyInfo.DXTabXafModules)]
    //TODO module description
    [Description("Ultra Modules for XAF: ")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(UltraModuleTemplate), "Resources.Gear.ico")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class UltraModuleTemplate : ModuleBase
    {
        public UltraModuleTemplate()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters)
        {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new ModelLocalizationGroupGeneratorUpdater());
            updaters.Add(new ModelLocalizationNodesGeneratorUpdater());
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            //TODO return an array of types to improve performance
            //return new Type[] {
            //    typeof(BIT.XAF.DataImport.BusinessObjects.ImportMap),

            //};
            return base.GetDeclaredExportedTypes();
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            //TODO return an array of types to improve performance

            //return new Type[] {
            //    typeof(ImportControllerExcel),typeof(DisableNestedObjectActions),
            //    typeof(ShowDataDictionary), typeof(DataDictionaryController)
            //};
            return base.GetDeclaredControllerTypes();
        }
    }
}