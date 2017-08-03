using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using cpFloat = System.Double;

// we use these for documenting
using cpPtrIn = System.IntPtr; //default input ptr alias, don't use directly (grayed out)
using cpSpaceP = System.IntPtr;
using cpShapeP = System.IntPtr;
using cpBodyP = System.IntPtr;

//TODO namespace

public class ChimpPtr
{
    public IntPtr pointer;
    public static implicit operator IntPtr(ChimpPtr obj)
    {
        return obj.pointer;
    }
    public static implicit operator ChimpPtr(IntPtr ptr)
    {
        return new ChimpPtr{pointer = ptr};
    }
}

public class cpSpace : ChimpPtr
{
    public cpSpace()
    {
        pointer = Chimp.cpSpaceNew();
    }

    public cpBody StaticBody => new cpBody(Chimp.cpSpaceGetStaticBody(pointer));

    public void SetGravity(cpVect gv)
    {
        Chimp.cpSpaceSetGravity(pointer, gv);
    }

    public void AddShape(cpShape shape)
    {
        Chimp.cpSpaceAddShape(pointer, shape);
    }
}

public class cpShape : ChimpPtr
{
    public cpShape(cpShapeP shapePtr)
    {
        pointer = shapePtr;
    }

    public cpShape(cpSpace space)
    {
    }

    public static cpShape NewSegment(cpBody body, cpVect a, cpVect b, cpFloat r)
    {
        return new cpShape(Chimp.cpSegmentShapeNew(body, a, b, r));
    }

    public void SetFriction(cpFloat f)
    {
        Chimp.cpShapeSetFriction(pointer, f);
    }
}

public class cpBody : ChimpPtr
{
    public cpBody(cpBodyP bodyPtr)
    {
        pointer = bodyPtr;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct cpVect
{
    public cpFloat X;
    public cpFloat Y;
    public static cpVect Zero = new cpVect(0,0);
    public cpVect(cpFloat x, cpFloat y)
    {
        X = x;
        Y = y;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct ChimpTransform
{
    public cpVect Position;
    public float Angle;
}

public static class cpUtil
{
    public static Func<cpFloat, cpFloat, cpFloat, cpVect, cpFloat> MomentForCircle = Chimp.cpMomentForCircle;
}

internal static class Chimp
{
    private const string F = "chipmunk.dll";

    //Misc
    [DllImport(F)] internal static extern     cpFloat cpMomentForCircle(cpFloat m, cpFloat r1, cpFloat r2, cpVect offset);
                   
    //Space        
    [DllImport(F)] internal static extern     cpSpaceP cpSpaceNew ();
    [DllImport(F)] internal static extern     void cpSpaceStep (cpSpaceP space, cpFloat dt);
    [DllImport(F)] internal static extern     void cpSpaceSetGravity (cpSpaceP space, cpVect gv);
    [DllImport(F)] internal static extern     cpBodyP cpSpaceGetStaticBody(cpSpaceP space);
    [DllImport(F)] internal static extern     cpShapeP cpSpaceAddShape(cpSpaceP space, cpShapeP shape);
                   
    //Shape        
    [DllImport(F)] internal static extern     void cpShapeSetFriction(cpShapeP shape, cpFloat friction);
    [DllImport(F)] internal static extern     cpShapeP cpSegmentShapeNew(cpBodyP body, cpVect a, cpVect b, cpFloat r);
                   
    //Body         
    [DllImport(F)] internal static extern     cpBodyP cpSpaceAddBody(cpSpace space, cpBodyP body);

//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;
//    [DllImport(F)] internal static extern     ;

}
