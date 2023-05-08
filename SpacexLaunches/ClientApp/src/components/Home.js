import React, { Component } from 'react';
import x_svg from '../statics/x.svg'
import check_svg from '../statics/check.svg'

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { launches: [], loading: true };
    }

    componentDidMount() {
        this.getLaunchData();
    }

    static renderLaunchesTable(launches) {
        console.log(launches);
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
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
                            <td>{launch.mission_name}</td>
                            <td>{launch.rocket.rocket_name}</td>
                            <td>{launch.launch_site.site_name}</td>
                            <td>{launch.launch_year}</td>
                            <td>{launch.launch_success ? <img src={check_svg} alt='check sign' />: <img src={x_svg} alt='x sign' />}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderLaunchesTable(this.state.launches);

        return (
            <div>
                <h1 id="tableLabel">launches List</h1>
                {contents}
            </div>
        );
    }

    async getLaunchData() {
        const launches_url = "https://api.spacexdata.com/v3/launches";
        const response = await fetch(launches_url);
        const data = await response.json();
        this.setState({ launches: data, loading: false });
    }
}
