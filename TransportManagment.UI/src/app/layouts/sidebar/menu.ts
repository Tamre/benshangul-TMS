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
        id: 4,
        label: "MENUITEMS.CONFIGURATION.LIST.LOCATION",
        link: "/config/location",
        parentId: 3,
      },

      {
        id: 5,
        label: "MENUITEMS.CONFIGURATION.LIST.COMPANY",
        link: "/config/company",
        parentId: 3,
      },
      {
        id: 6,
        label: "MENUITEMS.CONFIGURATION.LIST.USER",
        link: "/config/users",
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
    icon: "ri-apps-2-line",
    isCollapsed: true,
    subItems: [
      {
        id: 9,
        label: "MENUITEMS.VEHICLE-CONFIGURATION.LIST.VEHICLE",
        link: "/v-config/vehicle-config",
        parentId: 8,
      },

      {
        id: 10,
        label: "MENUITEMS.VEHICLE-CONFIGURATION.LIST.STOCKTYPE",
        link: "/v-config/stock-type",
        parentId: 8,
      },
      {
        id: 11,
        label: "MENUITEMS.VEHICLE-CONFIGURATION.LIST.USER",
        link: "/config/users",
        parentId: 8,
      },
      {
        id: 12,
        label: "MENUITEMS.VEHICLE-CONFIGURATION.LIST.ADDRESS",
        link: "/v-config/address",
        parentId: 8,
      },
    ],
  },
];
