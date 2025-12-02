namespace FakeBank.Services
{
    public interface IHashService
    {
        string ComputeSha256(byte[] data);
    }
}
