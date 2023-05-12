import AllLaunches  from "./components/AllLaunches";
import LaunchData from "./components/LaunchData";

const AppRoutes = [
    {
        index: true,
        element: <AllLaunches />
    },
    {
        path: '/launches/:id',
        element: <LaunchData />
    }
];

export default AppRoutes;
