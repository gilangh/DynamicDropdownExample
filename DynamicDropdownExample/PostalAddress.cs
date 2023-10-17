public class PostalAddress
{
    public string PostalCode { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return Address; // Only display the postal code in the ComboBox.
    }
}
