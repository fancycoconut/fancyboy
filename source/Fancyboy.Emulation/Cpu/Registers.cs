namespace Fancyboy.Emulation.Cpu;

internal class Registers
{
    private readonly byte[] registers = new byte[8];

    private ushort programCouter;
    private ushort stackPointer;

    private byte mClock;
    private byte tClock;
}
