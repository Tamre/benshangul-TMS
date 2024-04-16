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
        link: "/location",
        parentId: 3,
      },

      {
        id: 5,
        label: "MENUITEMS.CONFIGURATION.LIST.COMPANY",
        link: "/company",
        parentId: 3,
      },
    ],
  },
];
