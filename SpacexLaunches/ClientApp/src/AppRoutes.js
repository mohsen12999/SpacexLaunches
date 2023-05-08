import Home  from "./components/Home";
import LaunchData from "./components/LaunchData";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/launches/:id',
        element: <LaunchData />
    }
];

export default AppRoutes;
