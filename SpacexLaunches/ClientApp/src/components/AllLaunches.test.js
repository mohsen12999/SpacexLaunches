import React from 'react';
import { render, screen, act } from '@testing-library/react';
import AllLaunches from './AllLaunches';

global.fetch = (() =>
    Promise.resolve({}));

describe("AllLaunches Component error", () => {
    it('Show something bad happen when problem in converting json...', async () => {
        await act(async () => render(<AllLaunches />));
        expect(screen.getByText("Something Bad happened."));
    })
})


// global.fetch = (() =>
//     Promise.resolve({
//       json: () => Promise.resolve(
//           [{'flight_number':1,'mission_name':'FalconSat','mission_id':[],'upcoming':false,'launch_year':'2006','launch_date_unix':1143239400,'launch_date_utc':'2006-03-24T22:30:00.000Z','launch_date_local':'2006-03-25T10:30:00+12:00','is_tentative':false,'tentative_max_precision':'hour','tbd':false,'launch_window':0,'rocket':{'rocket_id':'falcon1','rocket_name':'Falcon 1','rocket_type':'Merlin A','first_stage':{'cores':[{'core_serial':'Merlin1A','flight':1,'block':null,'gridfins':false,'legs':false,'reused':false,'land_success':null,'landing_intent':false,'landing_type':null,'landing_vehicle':null}]},'second_stage':{'block':1,'payloads':[{'payload_id':'FalconSAT-2','norad_id':[],'reused':false,'customers':['DARPA'],'nationality':'United States','manufacturer':'SSTL','payload_type':'Satellite','payload_mass_kg':20,'payload_mass_lbs':43,'orbit':'LEO','orbit_params':{'reference_system':'geocentric','regime':'low-earth','longitude':null,'semi_major_axis_km':null,'eccentricity':null,'periapsis_km':400,'apoapsis_km':500,'inclination_deg':39,'period_min':null,'lifespan_years':null,'epoch':null,'mean_motion':null,'raan':null,'arg_of_pericenter':null,'mean_anomaly':null}}]},'fairings':{'reused':false,'recovery_attempt':false,'recovered':false,'ship':null}},'ships':[],'telemetry':{'flight_club':null},'launch_site':{'site_id':'kwajalein_atoll','site_name':'Kwajalein Atoll','site_name_long':'Kwajalein Atoll Omelek Island'},'launch_success':false,'launch_failure_details':{'time':33,'altitude':null,'reason':'merlin engine failure'},'links':{'mission_patch':'','mission_patch_small':'','reddit_campaign':null,'reddit_launch':null,'reddit_recovery':null,'reddit_media':null,'presskit':null,'article_link':'','wikipedia':'','video_link':'','youtube_id':'0a_00nJ_Y88','flickr_images':[]},'details':'Engine failure at 33 seconds and loss of vehicle','static_fire_date_utc':'2006-03-17T00:00:00.000Z','static_fire_date_unix':1142553600,'timeline':{'webcast_liftoff':54},'crew':null}])
//     })
//   );


//   describe("AllLaunches Component valid", () => {
//     it('Show Data with good json...', async () => {
//         await act(async() => render(<AllLaunches />));
//         expect(screen.getByText("Mission Name"));
//     })
//   })

