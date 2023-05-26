import React from 'react';
import { Link } from "react-router-dom";

import x_svg from '../statics/x.svg'
import check_svg from '../statics/check.svg'

const AllLaunches = () => {
    const [totalState, setTotalState] = React.useState({ loading: true, error: false, allLaunchesData :[] })

    React.useEffect(() => {
        getAllLaunchesData();
    }, []);

    const getAllLaunchesData = async () => {
        setTotalState({ loading: true });

        // const launches_url = "https://api.spacexdata.com/v5/launches";
        const launches_url = "spacex";
        
        try {
            const response = await fetch(launches_url);
            if(response.ok){
                const data = await response.json();
                setTotalState({ loading: false, error:false, allLaunchesData:data });
            } else {
                setTotalState({ loading: false, error: true });
            }
            
        } catch (error) {
            setTotalState({ loading: false, error: true });
        }
    }

    const renderLaunchesTable = (launches) => (
        <table className="table table-striped table-hover" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Mission Name</th>
                    <th>Rocket</th>
                    <th>Launchpad</th>
                    <th>Flight Number</th>
                    <th>Launch Date</th>
                    <th>Launch Success</th>
                </tr>
            </thead>
            <tbody>
                {launches.map(launch =>
                    <tr key={launch.id}>
                        <td>
                            <Link to={"/launches/" + launch.id}>{launch.name}</Link></td>
                        <td>{launch.rocket}</td>
                        <td>{launch.launchpad}</td>
                        <td>{launch.flight_number}</td>
                        <td>{launch.date_utc}</td>
                        <td>{launch.success ? <img src={check_svg} alt='check sign' /> : <img src={x_svg} alt='x sign' />}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    const content = totalState.loading ?
        <p><em>Loading...</em></p>
        : totalState.error ?
            <p>
                <em>Something Bad happened.</em>
                <button type="button" className="btn btn-outline-primary" onClick={() => getAllLaunchesData()}>Reload</button>
            </p>
            :
            renderLaunchesTable(totalState.allLaunchesData)

    return <div>
        <h1 id="tableLabel">launches List</h1>
        {content}
    </div>;

}

export default AllLaunches;