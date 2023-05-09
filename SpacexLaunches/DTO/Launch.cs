using System.Text.Json.Serialization;

namespace SpacexLaunches.DTO
{

    public class Core
    {
        public string core_serial { get; set; }
        public int? flight { get; set; }
        public int? block { get; set; }
        public bool gridfins { get; set; }
        public bool legs { get; set; }
        public bool reused { get; set; }
        public bool? land_success { get; set; }
        public bool landing_intent { get; set; }
        public string landing_type { get; set; }
        public string landing_vehicle { get; set; }
    }

    public class Fairings
    {
        public bool reused { get; set; }
        public bool recovery_attempt { get; set; }
        public bool recovered { get; set; }
        public List<string> ship { get; set; }
    }

    public class FirstStage
    {
        public List<Core> cores { get; set; }
    }

    public class Launch
    {
        public int? flight_number { get; set; }
        public string mission_name { get; set; }
        public List<string> mission_id { get; set; }
        public string launch_year { get; set; }
        public int? launch_date_unix { get; set; }
        public DateTime? launch_date_utc { get; set; }
        public DateTime? launch_date_local { get; set; }
        public bool? is_tentative { get; set; }
        public string tentative_max_precision { get; set; }
        public bool? tbd { get; set; }
        public int? launch_window { get; set; }
        public Rocket rocket { get; set; }
        public List<string> ships { get; set; }
        public Telemetry telemetry { get; set; }
        public LaunchSite launch_site { get; set; }
        public bool? launch_success { get; set; }
        public Links links { get; set; }
        public string details { get; set; }
        public bool? upcoming { get; set; }
        public DateTime? static_fire_date_utc { get; set; }
        public int? static_fire_date_unix { get; set; }
        public Timeline timeline { get; set; }
    }

    public class LaunchSite
    {
        public string site_id { get; set; }
        public string site_name { get; set; }
        public string site_name_long { get; set; }
    }

    public class Links
    {
        public string mission_patch { get; set; }
        public string mission_patch_small { get; set; }
        public string reddit_campaign { get; set; }
        public string reddit_launch { get; set; }
        public object reddit_recovery { get; set; }
        public string reddit_media { get; set; }
        public string presskit { get; set; }
        public string article_link { get; set; }
        public string wikipedia { get; set; }
        public string video_link { get; set; }
        public string youtube_id { get; set; }
        public List<string> flickr_images { get; set; }
    }

    public class OrbitParams
    {
        public string reference_system { get; set; }
        public string regime { get; set; }
        public float? longitude { get; set; }
        public double? semi_major_axis_km { get; set; }
        public double? eccentricity { get; set; }
        public double? periapsis_km { get; set; }
        public double? apoapsis_km { get; set; }
        public double? inclination_deg { get; set; }
        public double? period_min { get; set; }
        public int? lifespan_years { get; set; }
        public DateTime? epoch { get; set; }
        public double? mean_motion { get; set; }
        public double? raan { get; set; }
        public double? arg_of_pericenter { get; set; }
        public double? mean_anomaly { get; set; }
    }

    public class Payload
    {
        public string payload_id { get; set; }
        public List<int> norad_id { get; set; }
        public bool? reused { get; set; }
        public List<string> customers { get; set; }
        public string nationality { get; set; }
        public string manufacturer { get; set; }
        public string payload_type { get; set; }
        public int? payload_mass_kg { get; set; }
        public int? payload_mass_lbs { get; set; }
        public string orbit { get; set; }
        public OrbitParams orbit_params { get; set; }
    }

    public class Rocket
    {
        public string rocket_id { get; set; }
        public string rocket_name { get; set; }
        public string rocket_type { get; set; }
        public FirstStage first_stage { get; set; }
        public SecondStage second_stage { get; set; }
        public Fairings fairings { get; set; }
    }

    public class SecondStage
    {
        public int? block { get; set; }
        public List<Payload> payloads { get; set; }
    }

    public class Telemetry
    {
        public string flight_club { get; set; }
    }

    public class Timeline
    {
        public int? webcast_liftoff { get; set; }
        public int? go_for_prop_loading { get; set; }
        public int? rp1_loading { get; set; }
        public int? stage1_lox_loading { get; set; }
        public int? stage2_lox_loading { get; set; }
        public int? engine_chill { get; set; }
        public int? prelaunch_checks { get; set; }
        public int? propellant_pressurization { get; set; }
        public int? go_for_launch { get; set; }
        public int? ignition { get; set; }
        public int? liftoff { get; set; }
        public int? maxq { get; set; }
        public int? meco { get; set; }
        public int? stage_sep { get; set; }
        public int? second_stage_ignition { get; set; }
        public int? fairing_deploy { get; set; }
        public int? first_stage_entry_burn { get; set; }

        [JsonPropertyName("seco-1")]
        public int? seco1 { get; set; }
        public int? first_stage_landing { get; set; }
        public int? second_stage_restart { get; set; }

        [JsonPropertyName("seco-2")]
        public int? seco2 { get; set; }
        public int? payload_deploy { get; set; }
    }


}
