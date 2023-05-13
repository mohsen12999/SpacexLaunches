import React from 'react';
import { useParams } from "react-router-dom";

const LaunchData = () => {
    const { id } = useParams();

    const [totalState, setTotalState] = React.useState({ loading: true, error: true, launchData: [] })

    const getLaunchData = async (id) => {
        setTotalState({ loading: true });

        const launches_url = "https://api.spacexdata.com/v5/launches/" + id;
        // const launches_url = "spacex/" + id;
        try {
            const response = await fetch(launches_url);
            const data = await response.json();
            setTotalState({ loading: false, error: false , launchData: data });
        } catch (error) {
            setTotalState({ loading: false, error: true });
        }
    }

    React.useEffect(() => {
        getLaunchData(id);
    }, [id]);

    const renderLaunchData = (launchData) => (
        <div className='container row'>
            <div className='col'>
                <div className="card" style={{ maxWidth: "300px", margin: "1rem" }}>
                    <img src={launchData.links.patch.large} className="card-img-top" alt={launchData.name + " image"} />
                </div>
            </div>
            <div className='col'>
                <ul className="list-group list-group-flush">
                    <li className="list-group-item"><b>Flight Number:</b> {launchData.flight_number}</li>
                    <li className="list-group-item"><b>Mission Name:</b> {launchData.name}</li>
                    <li className="list-group-item"><b>Mission Id:</b> {launchData.id}</li>
                    <li className="list-group-item"><b>Launch Date:</b> {launchData.date_utc}</li>
                    <li className="list-group-item"><b>Launch Success:</b> {launchData.success}</li>
                    <li className="list-group-item"><b>Details:</b> {launchData.details}</li>
                    <li className="list-group-item"><b>Ships:</b> {launchData.ships.join(',')} </li>
                    <li className="list-group-item"><b>Crew:</b> {launchData.crew.join(',')} </li>
                </ul>
            </div>

        </div>
    )

    return totalState.loading ?
        <p><em>Loading...</em></p>
        : totalState.error ?
            <p>
                <em>Something Bad happened.</em>
                <button type="button" className="btn btn-outline-primary" onClick={() => getLaunchData(id)}>Reload</button>
            </p>
            :
            <div>
                <h1 id="tableLabel">launch Data</h1>
                {renderLaunchData(totalState.launchData)}
            </div>

}

export default LaunchData;