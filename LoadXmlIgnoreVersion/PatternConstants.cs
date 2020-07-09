namespace LoadXmlIgnoreVersion
{
    /// <summary>
    /// Patterns for properly converting incoming XML 1.1 docs to 1.0
    /// These should cover the changes detailed in https://www.w3.org/TR/xml11/#sec-xml11
    /// </summary>
    public static class PatternConstants
    {
        //writing to a file from a string array seems to add extra spaces between angle brackets
        public const string SpacesBetweenAngleBrackets = ">\\s*<";

        //https://www.fileformat.info/info/unicode/category/Cc/list.htm
        public const string ControlCharacters = "\\p{Cc}+";

        //http://www.fileformat.info/info/unicode/category/Zl/index.htm
        public const string IllegalLineSeparator = "\\p{Zl}";
    }
}
