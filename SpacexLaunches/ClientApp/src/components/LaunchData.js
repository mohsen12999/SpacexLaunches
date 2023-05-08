import React, { Component } from 'react';
import { useParams } from "react-router-dom";

const LaunchData = () => {
    const {id} = useParams();

    const [loading, setLoading] = React.useState(true);
    const [launchData, setLaunchData] = React.useState({});

    const getLaunchData = async (id) => {
        const launches_url = "https://api.spacexdata.com/v3/launches/" + id;
        const response = await fetch(launches_url);
        const data = await response.json();
        setLaunchData(data);
        setLoading(false);
    }

    React.useEffect(()=>{
        getLaunchData(id);
    },[]);

    const renderLaunchData = (launchData) => (
        <div>
            <ul className="list-group list-group-flush">
                <li className="list-group-item"><b>Flight Number:</b> {launchData.flight_number}</li>
                <li className="list-group-item"><b>Mission Name:</b> {launchData.mission_name}</li>
                <li className="list-group-item"><b>Mission Id:</b> {launchData.mission_id.join(',')}</li>
                <li className="list-group-item"><b>Rocket Name:</b> {launchData.rocket.rocket_name}</li>
                <li className="list-group-item"><b>Rocket type:</b> {launchData.rocket.rocket_type}</li>
                <li className="list-group-item"><b>Launch Year:</b> {launchData.launch_year}</li>
                <li className="list-group-item"><b>Launch Window:</b> {launchData.launch_window}</li>
                <li className="list-group-item"><b>Details:</b> {launchData.details}</li>
                <li className="list-group-item"><b>Launch Site:</b> {launchData.launch_site.site_name_long} </li>
                <li className="list-group-item"><b>Ships:</b> {launchData.ships.join(',')} </li>
            </ul>
            <div class="card" style={{maxWidth: "300px", margin:"1rem"}}>
                <img src={launchData.links.mission_patch} class="card-img-top"  />
            </div>
        </div>
    )


    return loading ?
         <p><em>Loading...</em></p>
        : 
        <div>
            <h1 id="tableLabel">launch Data</h1>
            {renderLaunchData(launchData)}
        </div>


}

export default LaunchData;