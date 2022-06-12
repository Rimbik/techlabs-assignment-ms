namespace blogcomment_api.ConfigHelper
{

    public class ConfigReader
    {
        public Webapienv WebAPIEnv { get; set; }
    }

    public class Webapienv
    {
        public string ApiUrlLocal { get; set; }
        public string ApiUrlDocker { get; set; }
        public string ApiUrlK8s { get; set; }
        public Local Local { get; set; }
        public Deocker Deocker { get; set; }
        public K8s K8s { get; set; }
    }

    public class Local
    {
        public string Port { get; set; }
    }

    public class Deocker
    {
        public string Port { get; set; }
    }

    public class K8s
    {
        public string Port { get; set; }
    }
}