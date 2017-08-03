using System;
using System.Runtime.InteropServices;

// chipmunk types
using cpFloat = System.Double;
using cpBool = System.Boolean;

// we use these for documenting
using cpPtrIn = System.IntPtr; //default input ptr alias, don't use directly (grayed out)
using cpSpaceP = System.IntPtr;
using cpShapeP = System.IntPtr;
using cpBodyP = System.IntPtr;
using cpArbiterP = System.IntPtr;
using cpConstraintP = System.IntPtr;

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

    internal const string F = "chipmunk.dll";
                   
    //Space        
    [DllImport(F)] protected static extern  cpSpaceP cpSpaceNew();
    [DllImport(F)] protected static extern  void cpSpaceStep(cpSpaceP space, cpFloat dt);
    [DllImport(F)] protected static extern  void cpSpaceSetGravity(cpSpaceP space, cpVect gravity);
    [DllImport(F)] protected static extern  cpBodyP cpSpaceGetStaticBody(cpSpaceP space);
    [DllImport(F)] protected static extern  cpShapeP cpSpaceAddShape(cpSpaceP space, cpShapeP shape);
    [DllImport(F)] protected static extern  cpBodyP cpSpaceAddBody(cpSpaceP space, cpBodyP body);
                                            
    //Shape                                 
    [DllImport(F)] protected static extern  void cpShapeSetFriction(cpShapeP shape, cpFloat friction);
    [DllImport(F)] protected static extern  cpShapeP cpSegmentShapeNew(cpBodyP body, cpVect a, cpVect b, cpFloat radius);
    [DllImport(F)] protected static extern  cpShapeP cpCircleShapeNew(cpBodyP body, cpFloat radius, cpVect offset);
                                            
    //Body                                  
    [DllImport(F)] protected static extern  cpBodyP cpBodyNew(cpFloat mass, cpFloat moment);

    [DllImport(F)] protected static extern  void cpBodySetPosition(cpBodyP body, cpVect pos);
    [DllImport(F)] protected static extern  cpVect cpBodyGetPosition(cpBodyP body);

    [DllImport(F)] protected static extern  cpVect cpBodyGetVelocity(cpBodyP body);

}

public static class cpUtil
{
    private const string F = ChimpPtr.F;

    //Misc
    public static Func<cpFloat, cpFloat, cpFloat, cpVect, cpFloat> MomentForCircle = cpMomentForCircle; //TODO gen these auto
    [DllImport(F)] public static extern   cpFloat cpMomentForCircle(cpFloat m, cpFloat r1, cpFloat r2, cpVect offset);
    [DllImport(F)] public static extern   cpFloat cpAreaForCircle(cpFloat r1, cpFloat r2);
    [DllImport(F)] public static extern   cpFloat cpMomentForSegment(cpFloat m, cpVect a, cpVect b, cpFloat radius);
    [DllImport(F)] public static extern   cpFloat cpAreaForSegment(cpVect a, cpVect b, cpFloat radius);
    [DllImport(F)] public static extern   cpFloat cpMomentForPoly(cpFloat m, int count, cpVect[] verts, cpVect offset, cpFloat radius);
    [DllImport(F)] public static extern   cpFloat cpAreaForPoly(int count, cpVect[] verts, cpFloat radius);
    [DllImport(F)] public static extern   cpVect  cpCentroidForPoly(int count, cpVect[] verts);
    [DllImport(F)] public static extern   cpFloat cpMomentForBox(cpFloat m, cpFloat width, cpFloat height);

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

    public void AddBody(cpBody body)
    {
        cpSpaceAddBody(pointer, body);
    }

    public void Step(cpFloat dt)
    {
        cpSpaceStep(pointer, dt);
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

    public static cpShape NewCircle(cpBodyP body, cpFloat radius, cpVect offset)
    {
        return new cpShape(cpCircleShapeNew(body, radius, offset));
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

    public cpVect Position
    {
        get => cpBodyGetPosition(pointer);
        set => cpBodySetPosition(pointer, value);
    }

    public cpVect Velocity
    {
        get => cpBodyGetVelocity(pointer);
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




