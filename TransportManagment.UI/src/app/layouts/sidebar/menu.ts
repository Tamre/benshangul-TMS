import { MenuItem } from "./menu.model";

export const MENU: MenuItem[] = [
  {
    id: 1,
    label: "MENUITEMS.MENU.TEXT",
    isTitle: true,
  },
  {
    id: 2,
    label: "MENUITEMS.DASHBOARD.TEXT",
    icon: "ri-dashboard-2-line",
    isCollapsed: true,
    subItems: [
      {
        id: 3,
        label: "MENUITEMS.DASHBOARD.LIST.REPORT",
        link: "/report",
        parentId: 2,
      },
    ],
  },
  {
    id: 3,
    label: "MENUITEMS.CONFIGURATION.TEXT",
    icon: "ri-apps-2-line",
    isCollapsed: true,
    subItems: [
    

      {
        id: 5,
        label: "MENUITEMS.CONFIGURATION.LIST.COMPANY",
        link: "/config/company",
        parentId: 3,
      },
      {
        id: 6,
        label: "Devices",
        link: "/config/devices",
        parentId: 3,
      },
      {
        id: 6,
        label: "MENUITEMS.CONFIGURATION.LIST.ADDRESS",
        link: "/config/address",
        parentId: 3,
      },
    ],
  },
  {
    id: 7,
    label: "MENUITEMS.VRMS.TEXT",
    isTitle: true,
    
  },


  {
    id: 8,
    label: "MENUITEMS.VEHICLE-CONFIGURATION.TEXT",
    icon: "ri-settings-4-line",
    link: "/v-management/vehicle-config",
    isCollapsed: true,
  },
  {
    id: 9,
    label: "MENUITEMS.STOCK-MANAGEMENT.TEXT",
    icon: "ri-stack-line",
    link: "/v-management/stock-management",
    isCollapsed: true,
  },
  {
    id: 9,
    label: "MENUITEMS.VEHICLE.TEXT",
    icon: "ri-apps-2-line",
    isCollapsed: true,
    subItems: [
      {
        id: 10,
        label: "MENUITEMS.VEHICLE.LIST.REGISTER",
        link: "/vehicle/add",
        parentId: 3,
      },
      {
        id: 10,
        label: "MENUITEMS.VEHICLE.LIST.FIND",
        link: "/vehicle/list",
        parentId: 3,
      }
    ],
  },
];
