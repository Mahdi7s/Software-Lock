namespace SoftwareSerial.Contracts
{
    public interface ISerialValidator
    {
        IAlgorithm Algorithm { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orginal">the orginal string that serialized.</param>
        /// <param name="randomAndOrginal">a string that contains both random & orginal values together.</param>
        /// <returns></returns>
        bool Validate(string orginal, string randomAndOrginal);
    }
}
