namespace Fancyboy.Emulation.Cpu;

public class Z80
{
    // 8-bit registers
    public byte A, B, C, D, E, H, L, F;

    // 16-bit registers (SP, PC)
    public ushort SP, PC;

    public bool ZeroFlag
    {
        get => (F & FlagMasks.Zero) == FlagMasks.Zero;
        set => F = (byte)(value ? (F | FlagMasks.Zero) : (F & ~FlagMasks.Zero));
    }

    public bool OperationFlag
    {
        get => (F & FlagMasks.Operation) == FlagMasks.Operation;
        set => F = (byte)(value ? (F | FlagMasks.Operation) : (F & ~FlagMasks.Operation));
    }

    public bool HalfCarryFlag
    {
        get => (F & FlagMasks.HalfCarry) == FlagMasks.HalfCarry;
        set => F = (byte)(value ? (F | FlagMasks.HalfCarry) : (F & ~FlagMasks.HalfCarry));
    }

    public bool CarryFlag
    {
        get => (F & FlagMasks.Carry) == FlagMasks.Carry;
        set => F = (byte)(value ? (F | FlagMasks.Carry) : (F & ~FlagMasks.Carry));
    }

    public ushort AF
    {
        get => (ushort)((A << 8) | F);
        set
        {
            A = (byte)(value >> 8);
            // Lower nibble of F is always 0
            F = (byte)(value & 0xF0);
        }
    }

    public ushort BC
    {
        get => (ushort)((B << 8) | C);
        set => (B, C) = ((byte)(value >> 8), (byte)(value & 0xFF));
    }

    public ushort DE
    {
        get => (ushort)((D << 8) | E);
        set => (D, E) = ((byte)(value >> 8), (byte)(value & 0xFF));
    }

    public ushort HL
    {
        get => (ushort)((H << 8) | L);
        set => (H, L) = ((byte)(value >> 8), (byte)(value & 0xFF));
    }

    public Z80()
    {
        Reset();
    }

    public void Reset()
    {
        A = 0x01; F = 0xB0;
        B = 0x00; C = 0x13;
        D = 0x00; E = 0xD8;
        H = 0x01; L = 0x4D;
        SP = 0xFFFE;
        // Game Boy starts execution at 0x0100
        PC = 0x0100; 
    }
}
