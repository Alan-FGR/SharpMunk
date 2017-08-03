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

//[System.Security.SuppressUnmanagedCodeSecurity] //TODO uncomment for performance
public class ChimpPtr
{
    public readonly IntPtr pointer;

    public ChimpPtr(IntPtr ptr)
    {
        pointer = ptr;
    }
    public static implicit operator IntPtr(ChimpPtr obj)
    {
        return obj.pointer;
    }
    public static implicit operator ChimpPtr(IntPtr ptr)
    {
        return new ChimpPtr(ptr);
    }

    private const string F = "chipmunk.dll";

    //Misc
    public static Func<cpFloat, cpFloat, cpFloat, cpVect, cpFloat> MomentForCircle = cpMomentForCircle; //TODO gen these auto
    [DllImport(F)] public static extern     cpFloat cpMomentForCircle(cpFloat m, cpFloat r1, cpFloat r2, cpVect offset);
                   
    //Space        
    [DllImport(F)] protected static extern  cpSpaceP cpSpaceNew ();
    [DllImport(F)] protected static extern  void cpSpaceStep (cpSpaceP space, cpFloat dt);
    [DllImport(F)] protected static extern  void cpSpaceSetGravity (cpSpaceP space, cpVect gv);
    [DllImport(F)] protected static extern  cpBodyP cpSpaceGetStaticBody(cpSpaceP space);
    [DllImport(F)] protected static extern  cpShapeP cpSpaceAddShape(cpSpaceP space, cpShapeP shape);
    [DllImport(F)] protected static extern  cpBodyP cpSpaceAddBody(cpSpaceP space, cpBodyP body);
                                            
    //Shape                                 
    [DllImport(F)] protected static extern  void cpShapeSetFriction(cpShapeP shape, cpFloat friction);
    [DllImport(F)] protected static extern  cpShapeP cpSegmentShapeNew(cpBodyP body, cpVect a, cpVect b, cpFloat r);
                                            
    //Body                                  
    [DllImport(F)] protected static extern  cpBodyP cpSpaceAddBody(cpSpace space, cpBodyP body);
    [DllImport(F)] protected static extern  cpBodyP cpBodyNew(cpFloat mass, cpFloat moment);

}

public static class cpUtil
{
    
}

public class cpSpace : ChimpPtr
{
    public cpSpace() : base(cpSpaceNew())
    {
    }

    public cpBody StaticBody => new cpBody(cpSpaceGetStaticBody(pointer)); //TODO cache

    public void SetGravity(cpVect gv)
    {
        cpSpaceSetGravity(pointer, gv);
    }

    public void AddShape(cpShape shape)
    {
        cpSpaceAddShape(pointer, shape);
    }
}

public class cpShape : ChimpPtr
{
    public cpShape(cpShapeP shapePtr) : base (shapePtr)
    {
    }

    public static cpShape NewSegment(cpBody body, cpVect a, cpVect b, cpFloat r)
    {
        return new cpShape(cpSegmentShapeNew(body, a, b, r));
    }

    public void SetFriction(cpFloat f)
    {
        cpShapeSetFriction(pointer, f);
    }
}

public class cpBody : ChimpPtr
{
    public cpBody(cpFloat mass, cpFloat moment) : base(cpBodyNew(mass, moment))
    {
    }

    public cpBody(cpBodyP bodyPtr) : base(bodyPtr)
    {
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




