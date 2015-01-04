namespace Siti.Data
{
    /// <summary>
    /// Represents a scanned finger (or multiple fingers)
    /// </summary>
    /// <remarks>
    /// The values of this enumerations are based on ANSI/NIST-ITL 1-2011 (Table 8):
    /// http://www.nist.gov/customcf/get_pdf.cfm?pub_id=910136
    /// </remarks>
    public enum Finger
    {
        Unspecified = 0,
        RightThumb = 1,
        RightIndex = 2,
        RightMiddle = 3,
        RightRing = 4,
        RightLittle = 5,
        LeftThumb = 6,
        LeftIndex = 7,
        LeftMiddle = 8,
        LeftRing = 9,
        LeftLittle = 10,
        PlainRightThumb = 11,
        PlainLeftThumb = 12,
        PlainRightFourFingers = 13,
        PlainLeftFourFingers = 14,
        BothThumbs = 15
    }
}
