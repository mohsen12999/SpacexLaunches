import React from 'react';
import { Link } from "react-router-dom";

import x_svg from '../statics/x.svg'
import check_svg from '../statics/check.svg'

const Home = () => {
    const [loading, setLoading] = React.useState(true);
    const [loadingError, setLoadingError] = React.useState(false);
    const [allLaunchesData, setAllLaunchesData] = React.useState({});

    React.useEffect(() => {
        getAllLaunchesData();
    }, []);

    const getAllLaunchesData = async () => {
        setLoading(true)
        const launches_url = "https://api.spacexdata.com/v3/launches";
        try {
            const response = await fetch(launches_url);
            const data = await response.json();
            setAllLaunchesData(data);
            setLoadingError(false);
        } catch (error) {
            setLoadingError(true);
        }
        setLoading(false);
    }

    const renderLaunchesTable = (launches) => (
        <table className="table table-striped table-hover" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Mission Name</th>
                    <th>Rocket Name</th>
                    <th>Site Name</th>
                    <th>Launch Year</th>
                    <th>Launch Success</th>
                </tr>
            </thead>
            <tbody>
                {launches.map(launch =>
                    <tr key={launch.flight_number}>
                        <td>
                            <Link to={"/launches/" + launch.flight_number}>{launch.mission_name}</Link></td>
                        <td>{launch.rocket.rocket_name}</td>
                        <td>{launch.launch_site.site_name}</td>
                        <td>{launch.launch_year}</td>
                        <td>{launch.launch_success ? <img src={check_svg} alt='check sign' /> : <img src={x_svg} alt='x sign' />}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    const content = loading ?
        <p><em>Loading...</em></p>
        : loadingError ?
            <p>
                <em>Something Bad happened.</em>
                <button type="button" className="btn btn-outline-primary" onClick={() => getAllLaunchesData()}>Reload</button>
            </p>
            :
            renderLaunchesTable(allLaunchesData)

    return <div>
        <h1 id="tableLabel">launches List</h1>
        {content}
    </div>;

}

export default Home;