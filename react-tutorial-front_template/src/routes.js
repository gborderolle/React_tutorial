/*!

=========================================================
* Light Bootstrap Dashboard React - v2.0.1
=========================================================

* Product Page: https://www.creative-tim.com/product/light-bootstrap-dashboard-react
* Copyright 2022 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/light-bootstrap-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import Dashboard from "views/Dashboard.tsx";
import IndexGenres from "views/genres/IndexGenres.tsx";
import UserProfile from "views/UserProfile.tsx";
import TableList from "views/TableList.tsx";
import View from "views/View.tsx";
import Typography from "views/Typography.tsx";
import Icons from "views/Icons.tsx";
import Maps from "views/Maps.tsx";
import Notifications from "views/Notifications.tsx";
import Upgrade from "views/Upgrade.tsx";

const dashboardRoutes = [
  {
    upgrade: true,
    path: "/upgrade",
    name: "Upgrade to PRO",
    icon: "nc-icon nc-alien-33",
    component: Upgrade,
    layout: "/admin",
  },
  {
    path: "/dashboard",
    name: "Cartelera",
    icon: "nc-icon nc-button-play",
    component: Dashboard,
    layout: "/admin",
  },
  {
    path: "/genre",
    name: "Géneros",
    icon: "nc-icon nc-tag-content",
    component: IndexGenres,
    layout: "/admin",
  },
  {
    path: "/view",
    name: "Películas",
    icon: "nc-icon nc-bullet-list-67",
    component: View,
    layout: "/admin",
  },
  {
    path: "/typography",
    name: "Actores",
    icon: "nc-icon nc-circle-09",
    component: Typography,
    layout: "/admin",
  },
  {
    path: "/icons",
    name: "Cines",
    icon: "nc-icon nc-atom",
    component: Icons,
    layout: "/admin",
  },
  {
    path: "/maps",
    name: "Reviews",
    icon: "nc-icon nc-notes",
    component: Maps,
    layout: "/admin",
  },
  {
    path: "/notifications",
    name: "Filtrar películas",
    icon: "nc-icon nc-zoom-split",
    component: Notifications,
    layout: "/admin",
  },
  {
    path: "/notifications",
    name: "Administración",
    icon: "nc-icon nc-settings-90",
    component: Notifications,
    layout: "/admin",
  },
];

export default dashboardRoutes;
