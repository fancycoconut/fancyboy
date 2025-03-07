namespace Fancyboy.Emulation.Cpu;

internal class FlagMasks
{
    public const byte Zero = 1 << 7; // 0x80
    public const byte Operation = 1 << 6; // 0x40
    public const byte Carry = 1 << 5; // 0x10
    public const byte HalfCarry = 1 << 4; // 0x20;
}
